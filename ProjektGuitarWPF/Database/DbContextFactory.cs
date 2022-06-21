using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGuitarWPF.Database
{
    /// <summary>
    /// Class implementing IDesignTimeDbContextFactory interface for creating DbContext foreach request to database
    /// </summary>
    public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args = null)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=wpfguitarproject;Integrated Security=true").Options;
            return new DataContext(options);
        }
    }
}
