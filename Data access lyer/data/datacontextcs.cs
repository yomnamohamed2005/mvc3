﻿using Data_access_lyer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access_lyer.data
{
    public class datacontextcs :DbContext
    {
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            //optionsBuilder.UseSqlServer("connection");
       // }
   
        public datacontextcs(DbContextOptions <datacontextcs>options) : base(options)
        {

        }
        public DbSet<department> department { get; set; }
    }
}
