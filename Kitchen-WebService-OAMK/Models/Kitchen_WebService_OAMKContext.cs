using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kitchen_WebService_OAMK.Models
{
    public class Kitchen_WebService_OAMKContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Kitchen_WebService_OAMKContext() : base("name=Kitchen_WebService_OAMKContext")
        {
        }

        public System.Data.Entity.DbSet<Kitchen_WebService_OAMK.Models.Members> Members { get; set; }

        public System.Data.Entity.DbSet<Kitchen_WebService_OAMK.Models.Kitchen> Kitchen { get; set; }
    
    }
}
