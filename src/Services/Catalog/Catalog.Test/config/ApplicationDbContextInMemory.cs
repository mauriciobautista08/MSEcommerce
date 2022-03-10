using Catalog.PersistenceDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Test.config
{
    public class ApplicationDbContextInMemory
    {
        public static ApplicationDBContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: $"Catalog.Db")
                .Options;

            return new ApplicationDBContext(options);
        }
    }
}
