﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E18I4DABH32D1Gr4.Contexts;
using E18I4DABH32D1Gr4.Core.IRepositories;
using Microsoft.EntityFrameworkCore;


// ADD THIS PART TO YOUR CODE
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace E18I4DABH32D1Gr4.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private DocumentClient client;

        private string DatabaseName { get; }
        private string CollectionId { get; }

        public Repository(string databaseName, string collectionId)
        {      

            client = new DocumentClient(
                new Uri("https://localhost:8081"),
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            DatabaseName = databaseName;
            CollectionId = collectionId;

            createDatabase();
            createCollection();
        }

        private void createDatabase()
        {
            client.CreateDatabaseIfNotExistsAsync(new Database { Id = DatabaseName }).Wait();
        }

        private void createCollection()
        {
            client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseName), new DocumentCollection { Id = CollectionId }).Wait();
        }

        private Uri GetCollectionURI()
        {
            return UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionId);
        }

        protected IOrderedQueryable<TEntity> GetQuery()
        {
            var queryOptions = new FeedOptions() { MaxItemCount = -1 };
            IOrderedQueryable<TEntity> query = client.CreateDocumentQuery<TEntity>(GetCollectionURI(), queryOptions);
            return query;
        }

        async Task IRepository<TEntity>.Add(TEntity entity)
        {
            await AddHelper(entity);
        }

        private async Task AddHelper(TEntity entity)
        {
            Uri uri = GetCollectionURI();
            var document = await client.CreateDocumentAsync(uri, entity);
            setId(entity, document.Resource.Id);
        }

       

        async Task IRepository<TEntity>.Set(TEntity entity)
        {
            await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseName, CollectionId, getId(entity)), entity);
        }
        

        Task<TEntity> IRepository<TEntity>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            return GetQuery().ToList();
        }

        async Task IRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            var tasks = entities.Select(AddHelper);
            await Task.WhenAll(tasks);
        }

        async Task IRepository<TEntity>.Remove(TEntity entity)
        {
            await RemoveHelper(entity);
        }

        private async Task RemoveHelper(TEntity entity)
        {
            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseName, CollectionId, getId(entity)));
        }

        async Task IRepository<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            var tasks = entities.Select(RemoveHelper);

            await Task.WhenAll(tasks);
        }

        protected abstract string getId(TEntity entity);
        protected abstract void setId(TEntity entity, string id);
    }
}
