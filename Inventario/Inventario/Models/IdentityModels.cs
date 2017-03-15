using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using Inventario.Models;

namespace Inventario.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string apellidoMaterno { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Inventario.Models.Tabla_Clientes> Tabla_Clientes { get; set; }

        public System.Data.Entity.DbSet<Inventario.Models.Tabla_Productos> Tabla_Productos { get; set; }

        public System.Data.Entity.DbSet<Inventario.Models.Tabla_Proveedores> Tabla_Proveedores { get; set; }

        public System.Data.Entity.DbSet<Inventario.Models.Tabla_Intemedia_Comrpas> Tabla_Intemedia_Comrpas { get; set; }

        public System.Data.Entity.DbSet<Inventario.Models.Tabla_Intermedia_Proveen> Tabla_Intermedia_Proveen { get; set; }
    }
}