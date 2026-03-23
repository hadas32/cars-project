using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection
    {
        public DBConnection() { }
        public List<T> GetDbSet<T>() where T : class
        {
            using (CarsDBEntities musicCompEntity = new CarsDBEntities())
            {
                return musicCompEntity.Set<T>().ToList();
            }
        }
        public enum ExecuteActions
        {
            Insert,
            Update,
            Delete
        }
        public void Execute<T>(T entity, ExecuteActions exAction) where T : class
        {
            using (CarsDBEntities musicCompEntity = new CarsDBEntities())
            {
                var model = musicCompEntity.Set<T>();
                switch (exAction)
                {
                    case ExecuteActions.Insert:
                        model.Add(entity);
                        break;
                    case ExecuteActions.Update:
                        model.Attach(entity);
                        musicCompEntity.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        break;
                    case ExecuteActions.Delete:
                        model.Attach(entity);
                        musicCompEntity.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                        break;
                    default:
                        break;
                }
                musicCompEntity.SaveChanges();
            }
        }
    }
}
