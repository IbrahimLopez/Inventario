//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tabla_Intermedia_Proveen
    {
        [Key]
        [Display(Name = "Id")]
        public int proveenID { get; set; }
        [Display(Name = "ProductoID")]
        public Nullable<int> productoID { get; set; }
        [Display(Name = "RFC del Proveedor")]
        public Nullable<int> RFCproveedor { get; set; }
        [Display(Name = "Fecha Proveen")]
        public Nullable<System.DateTime> fechaProveen { get; set; }
    
        public virtual Tabla_Productos Tabla_Productos { get; set; }
        public virtual Tabla_Proveedores Tabla_Proveedores { get; set; }
    }
}
