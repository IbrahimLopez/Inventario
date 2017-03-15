namespace Inventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class llavesTablas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tabla_Intermedia_Proveen", "productoID", "dbo.Tabla_Productos");
            DropForeignKey("dbo.Tabla_Intermedia_Proveen", "RFCproveedor", "dbo.Tabla_Proveedores");
            DropIndex("dbo.Tabla_Intermedia_Proveen", new[] { "productoID" });
            DropIndex("dbo.Tabla_Intermedia_Proveen", new[] { "RFCproveedor" });
            AlterColumn("dbo.Tabla_Clientes", "nombreCliente", c => c.String());
            AlterColumn("dbo.Tabla_Clientes", "apellidoPaternoCliente", c => c.String());
            AlterColumn("dbo.Tabla_Clientes", "apellidoMaternoCliente", c => c.String());
            AlterColumn("dbo.Tabla_Clientes", "direccionCliente", c => c.String());
            AlterColumn("dbo.Tabla_Clientes", "telefonoCliente", c => c.String());
            AlterColumn("dbo.Tabla_Intemedia_Comrpas", "fechaCompra", c => c.DateTime());
            AlterColumn("dbo.Tabla_Intemedia_Comrpas", "cantidad", c => c.Int());
            AlterColumn("dbo.Tabla_Productos", "nombreProducto", c => c.String());
            AlterColumn("dbo.Tabla_Productos", "precioVenta", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Tabla_Productos", "precioCompra", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Tabla_Productos", "pesoNeto", c => c.Int());
            AlterColumn("dbo.Tabla_Productos", "fechaEntrada", c => c.DateTime());
            AlterColumn("dbo.Tabla_Intermedia_Proveen", "productoID", c => c.Int());
            AlterColumn("dbo.Tabla_Intermedia_Proveen", "RFCproveedor", c => c.Int());
            AlterColumn("dbo.Tabla_Intermedia_Proveen", "fechaProveen", c => c.DateTime());
            AlterColumn("dbo.Tabla_Proveedores", "nombreProveedor", c => c.String());
            AlterColumn("dbo.Tabla_Proveedores", "apellidoPaternoProveedor", c => c.String());
            AlterColumn("dbo.Tabla_Proveedores", "apellidoMaternoProveedor", c => c.String());
            AlterColumn("dbo.Tabla_Proveedores", "telefonoProveedor", c => c.String());
            AlterColumn("dbo.Tabla_Proveedores", "direccionProveedor", c => c.String());
            CreateIndex("dbo.Tabla_Intermedia_Proveen", "productoID");
            CreateIndex("dbo.Tabla_Intermedia_Proveen", "RFCproveedor");
            AddForeignKey("dbo.Tabla_Intermedia_Proveen", "productoID", "dbo.Tabla_Productos", "productoID");
            AddForeignKey("dbo.Tabla_Intermedia_Proveen", "RFCproveedor", "dbo.Tabla_Proveedores", "RFCproveedor");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tabla_Intermedia_Proveen", "RFCproveedor", "dbo.Tabla_Proveedores");
            DropForeignKey("dbo.Tabla_Intermedia_Proveen", "productoID", "dbo.Tabla_Productos");
            DropIndex("dbo.Tabla_Intermedia_Proveen", new[] { "RFCproveedor" });
            DropIndex("dbo.Tabla_Intermedia_Proveen", new[] { "productoID" });
            AlterColumn("dbo.Tabla_Proveedores", "direccionProveedor", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Proveedores", "telefonoProveedor", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Proveedores", "apellidoMaternoProveedor", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Proveedores", "apellidoPaternoProveedor", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Proveedores", "nombreProveedor", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Intermedia_Proveen", "fechaProveen", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tabla_Intermedia_Proveen", "RFCproveedor", c => c.Int(nullable: false));
            AlterColumn("dbo.Tabla_Intermedia_Proveen", "productoID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tabla_Productos", "fechaEntrada", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tabla_Productos", "pesoNeto", c => c.Int(nullable: false));
            AlterColumn("dbo.Tabla_Productos", "precioCompra", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tabla_Productos", "precioVenta", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tabla_Productos", "nombreProducto", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Intemedia_Comrpas", "cantidad", c => c.Int(nullable: false));
            AlterColumn("dbo.Tabla_Intemedia_Comrpas", "fechaCompra", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tabla_Clientes", "telefonoCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Clientes", "direccionCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Clientes", "apellidoMaternoCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Clientes", "apellidoPaternoCliente", c => c.String(nullable: false));
            AlterColumn("dbo.Tabla_Clientes", "nombreCliente", c => c.String(nullable: false));
            CreateIndex("dbo.Tabla_Intermedia_Proveen", "RFCproveedor");
            CreateIndex("dbo.Tabla_Intermedia_Proveen", "productoID");
            AddForeignKey("dbo.Tabla_Intermedia_Proveen", "RFCproveedor", "dbo.Tabla_Proveedores", "RFCproveedor", cascadeDelete: true);
            AddForeignKey("dbo.Tabla_Intermedia_Proveen", "productoID", "dbo.Tabla_Productos", "productoID", cascadeDelete: true);
        }
    }
}
