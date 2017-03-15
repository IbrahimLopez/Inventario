using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Inventario.Models;

namespace Inventario.ViewModels
{
    public class VMUSerRoleName
    {
        [Key]
        public string id { get; set; }
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public string rolID { get; set; }

        public VMUSerRoleName(ApplicationUser usr)
        {
            this.nombreCompleto = usr.nombre + ' ' + usr.apellidoPaterno + ' ' + usr.apellidoMaterno;
            this.email = usr.Email;
            this.rolID = usr.Roles.First().RoleId;
            this.id = usr.Id;
            if (usr.Roles.Count > 0)
            {
                this.rolID = usr.Roles.First().RoleId;
            }
           

        }
    }
}