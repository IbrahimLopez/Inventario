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

    public partial class Tabla_Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tabla_Proveedores()
        {
            this.Tabla_Intermedia_Proveen = new HashSet<Tabla_Intermedia_Proveen>();
        }

        [Key]
        [Display(Name = "RFC")]
        public int RFCproveedor { get; set; }
        [Display(Name = "Nombre del Proveedor")]
        public string nombreProveedor { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string apellidoPaternoProveedor { get; set; }
        [Display(Name = "Apellido Materno")]
        public string apellidoMaternoProveedor { get; set; }
        [Display(Name = "Numero Telefonico")]
        public string telefonoProveedor { get; set; }
        [Display(Name = "Direccion")]
        public string direccionProveedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tabla_Intermedia_Proveen> Tabla_Intermedia_Proveen { get; set; }
    }
}