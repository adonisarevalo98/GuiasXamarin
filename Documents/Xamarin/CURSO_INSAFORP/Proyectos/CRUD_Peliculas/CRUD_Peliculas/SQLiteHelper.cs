using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace CRUD_Peliculas
{
    public class SQLiteHelper
    {
        //db se convierte en la cadena de conexion a la BDD
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Peliculas>().Wait();
        }

        //Lista de todas las peliculas
        public Task<List<Peliculas>> GetItemsAsync()
        {
            return db.Table<Peliculas>().ToListAsync();
        }

        //Obtener una sola pelicula por su ID
        public Task<Peliculas> GetItemAsync(int idpelicula)
        {
            return db.Table<Peliculas>().Where(i=>i.IdPelicula==idpelicula).FirstOrDefaultAsync();
        }

        //Métodos para persistir en la base de datos
        public Task<int> SaveItemAsync(Peliculas peliculas)
        {
            if(peliculas.IdPelicula != 0)
            {
                return db.UpdateAsync(peliculas);
            }
            else
            {
                return db.InsertAsync(peliculas);
            }
        }

       public Task<int> DeleteItemAsync(Peliculas peliculas)
        {
            return db.DeleteAsync(peliculas);
        }
    }
}
