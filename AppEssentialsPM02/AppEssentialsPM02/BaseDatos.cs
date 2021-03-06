using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppEssentialsPM02
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection db;
        public BaseDatos(String dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            //creacion de las tablas de la bd
            db.CreateTableAsync<Sitios>().Wait();
            db.CreateTableAsync<pictures>().Wait();
        }

        //Metodos del CRUD para Sitios

        #region Sitios
        //Select
        public Task<List<Sitios>> ObtenerSitios()
        {
            return db.Table<Sitios>().ToListAsync();
        }

        //Insert
        public Task<int> InsertarSitios(Sitios ubicacion)
        {
            if (ubicacion.id != 0)
            {
                return db.UpdateAsync(ubicacion);
            }
            else
            {
                return db.InsertAsync(ubicacion);
            }
        }
        //Traer un solo sitio (Ubicacion)
        public Task<Sitios> ObtenerSitios(int pid)
        {
            return db.Table<Sitios>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        //Delete
        public Task<int> EliminarSitios(Sitios ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }
        #endregion Sitios

        #region Pictures
        public Task<List<pictures>> GetPictures()
        {
            return db.Table<pictures>().ToListAsync();
        }

        public Task<int> InsertPicture(pictures picture)
        {
            if (picture.id != 0)
            {
                return db.UpdateAsync(picture);
            }
            else
            {
                return db.InsertAsync(picture);
            }
        }
        public Task<int> DeletePicture(pictures picture)
        {

                return db.DeleteAsync(picture);
          
        }

        #endregion
    }

}
