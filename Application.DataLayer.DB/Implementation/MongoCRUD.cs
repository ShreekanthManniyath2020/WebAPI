using Application.DataLayer.DB.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataLayer.DB.Implementation
{
    public class MongoCRUD : IMongCRUD
    {
        private IMongoDatabase db;
        public MongoCRUD(string Databasename)
        {
            var connectionstring = "mongodb+srv://root:root@cluster0.acqhi.mongodb.net/test?authSource=admin&replicaSet=atlas-10c209-shard-0&readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=true";
            var client = new MongoClient(connectionstring);
            db = client.GetDatabase(Databasename);

        }  
        public DeleteResult Delete<T>(string table, string id)
        {
            var collections = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collections.DeleteOne(filter);
        }

        public List<T> Get<T>(string table)
        {
            var collections = db.GetCollection<T>(table);
            return collections.Find(new BsonDocument()).ToList();
        }

        public T GetById<T>(string table, string id)
        {
            var collections = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collections.Find(filter).First();
        }

        public void insertRecord<T>(string table, T Record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(Record);
        }

        public void UpsertRecord<T>(string table, string id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = collection.ReplaceOne(filter, 
                record,
                new ReplaceOptions { IsUpsert = true });
        }
    }
}
