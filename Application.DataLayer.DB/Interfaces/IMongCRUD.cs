using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataLayer.DB.Interfaces
{
    public interface IMongCRUD
    {
        public DeleteResult Delete<T>(string table, string id);
        public List<T> Get<T>(string table);
        public T GetById<T>(string table, string id);
        public void insertRecord<T>(string table, T Record);
        public void UpsertRecord<T>(string table, string id, T record);

    }
}
