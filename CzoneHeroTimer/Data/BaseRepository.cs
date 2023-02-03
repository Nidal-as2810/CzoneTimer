
using CzoneHeroTimer.Modules;
using CzoneHeroTimer.Properties;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzoneHeroTimer.Data
{
    public class BaseRepository<T> where T : class
    {
        protected string path;
        public BaseRepository()
        {
            path = Application.StartupPath + @"data\hero.db";
        }

      

        public void Add( T entity)
        {
            var _context = new SQLiteConnection(path);
            _context.Insert(entity);
            _context.Close();
        }

        public List<T> AddAll(List<T> entities)
        {
            var _context = new SQLiteConnection(path);
            foreach (var entity in entities)
                {
                    _context.Insert(entity);
                }
            _context.Close();
            return entities;
        }

        public T Update(T entity)
        {
            var _context = new SQLiteConnection(path);
            _context.Update(entity);
            _context.Close(); 
            return entity;
        }

        public void Delete(T entity)
        {
            var _context = new SQLiteConnection(path);
            _context.Delete(entity);
            _context.Close();
        }
    }
}
