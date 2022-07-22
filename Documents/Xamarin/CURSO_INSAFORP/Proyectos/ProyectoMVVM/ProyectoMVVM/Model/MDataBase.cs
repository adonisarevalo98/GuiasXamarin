
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;


namespace ProyectoMVVM.Model
{
    public class MDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public MDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MPersona>().Wait();
        }

        public Task<List<MPersona>> GetPeopleAsync()
        {
            return _database.Table<MPersona>().ToListAsync();
        }

        public Task<int> SavePersonAsync(MPersona person)
        {
            return _database.InsertAsync(person);
        }
    }
}