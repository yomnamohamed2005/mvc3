using Data_access_lyer.data;
using Data_access_lyer.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business_acess_lyer.repositories
{
    public class data_repositories : Idata_repositories
    {

        //datacontextcs dbcontext = new datacontextcs(); //hard code 
        //property injection
        //  [FromServices]
        // public datacontextcs dbcontext { get; set; }
        //ctor injection
        private readonly datacontextcs _datacontext;
        public data_repositories(datacontextcs dbcontext)
        {
            _datacontext = dbcontext;
        }
        public department Get(int id)
        {
            return _datacontext.department.Find(id);
        }
        public IEnumerable<department> Getall()
        {
            return _datacontext.department.ToList();
        }
        public int create(department entity)
        {
            _datacontext.department.Add(entity);

            return _datacontext.SaveChanges();
        }
        public int update(department entity)
        {
            _datacontext.department.Update(entity);

            return _datacontext.SaveChanges();
        }
        public int delete(department entity)
        {
            _datacontext.department.Remove(entity);

            return _datacontext.SaveChanges();
        }
    }
}
