﻿using ChallengeFIAPLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Dapper;
using Microsoft.Data.SqlClient;
namespace ChallengeFIAPLibrary.Infrastructure.Persistence.DataSync
{
    public class CdcMonitorService
    {
        private readonly WriteDbContext _sqlContext; 
        private readonly ReadDbContext _mongoContext;

        public CdcMonitorService(WriteDbContext sqlContext, ReadDbContext mongoContext)
        {
            _sqlContext = sqlContext;
            _mongoContext = mongoContext;
        }
       
        public async Task SyncEntitiesAsync<TEntity>(string cdcTable)
            where TEntity : BaseEntity, new()
        { 
            var sql = $"SELECT *, __$operation AS Operation FROM {cdcTable}"; 

            using (var connection = new SqlConnection(_sqlContext.Database.GetDbConnection().ConnectionString))
            {
                await connection.OpenAsync();

                var changes = await connection.QueryAsync<dynamic>(sql);

                foreach (var change in changes)
                {

                    var entity = new TEntity();
                    foreach (var prop in typeof(TEntity).GetProperties())
                    {
                        if (IsValueObject(prop.PropertyType))
                        {
                            var valueObject = Activator.CreateInstance(prop.PropertyType);

                            foreach (var innerProp in prop.PropertyType.GetProperties())
                            {
                                var fullKey = $"{prop.Name}_{innerProp.Name}";

                                if (((IDictionary<string, object>)change).ContainsKey(fullKey))
                                {
                                    var innerValue = ((IDictionary<string, object>)change)[fullKey];
                                    var innerSetter = innerProp.GetSetMethod(true);

                                    if (innerSetter != null)
                                    {
                                        innerSetter.Invoke(valueObject, new[] { innerValue });
                                    }
                                }
                                else if (((IDictionary<string, object>)change).ContainsKey(innerProp.Name))
                                {
                                    var innerValue = ((IDictionary<string, object>)change)[innerProp.Name];
                                    var innerSetter = innerProp.GetSetMethod(true);

                                    if (innerSetter != null)
                                    {
                                        innerSetter.Invoke(valueObject, new[] { innerValue });
                                    }
                                }
                            }

                            var setter = prop.GetSetMethod(true);
                            if (setter != null)
                            {
                                setter.Invoke(entity, new[] { valueObject });
                            }
                        }
                        else
                        {
                            var value = ((IDictionary<string, object>)change).ContainsKey(prop.Name)
                                ? ((IDictionary<string, object>)change)[prop.Name]
                                : null;

                            if (value != null)
                            {
                                var setter = prop.GetSetMethod(true);
                                if (setter != null)
                                {
                                    setter.Invoke(entity, new[] { value });
                                }
                            }
                        }
                    }

                    var operation = (int)((IDictionary<string, object>)change)["Operation"];

                    var collection = _mongoContext.Set<TEntity>();
                    switch (operation)
                    {

                        case 1: 
                            var deleteFilter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
                            await collection.DeleteOneAsync(deleteFilter);
                            break;
                            

                        case 2: 
                            await collection.InsertOneAsync(entity);
                            break;
                            

                        case 4: 
                            var updateFilter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
                            await collection.ReplaceOneAsync(updateFilter, entity);
                            break; 

                        default: 
                            break;

                    }
                }

                await connection.ExecuteAsync($"DELETE FROM {cdcTable}");
            }

            
        }

        bool IsValueObject(Type type)
        {
            return type.IsClass && type != typeof(string);
        }

        public async Task SyncCustomersAsync()
        {
            await SyncEntitiesAsync<Customer>("cdc.dbo_Customers_CT");
        }

        public async Task SyncAuthorsAsync()
        {
            await SyncEntitiesAsync<Author>("cdc.dbo_Authors_CT");
        }
    }

}