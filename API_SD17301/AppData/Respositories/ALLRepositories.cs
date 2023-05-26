using AppData.IRespositories;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Respositories
{
    public class ALLRepositories<T> : IALLRepositories<T> where T : class
    {
        FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context;
        DbSet<T> dbset;
        public ALLRepositories(FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context context, DbSet<T> dbset) 
        {
            this.context = context;
            this.dbset = dbset;
        }
        public bool CreateItem(T item)
        {
            try
            {
                dbset.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteItem(T item)
        {
            try
            {
                dbset.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public bool UpdateItem(T item)
        {
            try
            {
                dbset.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
