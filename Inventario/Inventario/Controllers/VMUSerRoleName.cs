using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Controllers
{
    internal class VMUSerRoleName
    {
        private ApplicationUser user;

        public VMUSerRoleName(ApplicationUser user)
        {
            this.user = user;
        }
    }
}
