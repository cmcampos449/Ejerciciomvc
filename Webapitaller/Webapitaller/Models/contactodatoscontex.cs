using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapitaller.Models
{
    public class contactodatoscontex: DbContext

    {
        public contactodatoscontex(DbContextOptions<contactodatoscontex> options)
            : base(options)
        {
        }

        public DbSet<contactodatos> contactodatoss { get; set; }
    }
}
