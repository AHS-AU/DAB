﻿using E18I4DABH4Gr4.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH4Gr4.Repositories
{
    public abstract class ProsumerRepository<TEntity> : IProsumerRepository<TEntity> where TEntity : class
    {
        private DocumentClient client;

        private string DatabaseName { get; }
        private string CollectionId { get; }

        public ProsumerRepository(string databaseName, string collectionId)
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

        async Task IProsumerRepository<TEntity>.Add(TEntity entity)
        {
            await AddHelper(entity);
        }

        private async Task AddHelper(TEntity entity)
        {
            Uri uri = GetCollectionURI();
            var document = await client.CreateDocumentAsync(uri, entity);
            setId(entity, document.Resource.Id);
        }

        async Task IProsumerRepository<TEntity>.Set(TEntity entity)
        {
            await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseName, CollectionId, getId(entity)), entity);
        }


        Task<TEntity> IProsumerRepository<TEntity>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IProsumerRepository<TEntity>.GetAll()
        {
            return GetQuery().ToList();
        }

        async Task IProsumerRepository<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            var tasks = entities.Select(AddHelper);
            await Task.WhenAll(tasks);
        }

        async Task IProsumerRepository<TEntity>.Remove(TEntity entity)
        {
            await RemoveHelper(entity);
        }

        private async Task RemoveHelper(TEntity entity)
        {
            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseName, CollectionId, getId(entity)));
        }

        async Task IProsumerRepository<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            var tasks = entities.Select(RemoveHelper);

            await Task.WhenAll(tasks);
        }

        protected string getId(Prosumer entity)
        {
            return entity.ProsumerId;
        }

        protected  void setId(Prosumer entity, string id)
        {
            entity.ProsumerId = id;
        }
        protected abstract string getId(TEntity entity);
        protected abstract void setId(TEntity entity, string id);

        public Prosumer GetProsumer(string name)
        {
            return GetQuery().Where(x => x.Name.ToLower() == name.ToLower()).ToList().FirstOrDefault();
        }
    }
}
