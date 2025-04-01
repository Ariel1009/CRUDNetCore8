using Microsoft.EntityFrameworkCore;
using P_CRUDNetCore.Models;

namespace P_CRUDNetCore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Agregar los modelos de la DB
        public DbSet<Contact> m_Contacts { get; set; }


    }
}
