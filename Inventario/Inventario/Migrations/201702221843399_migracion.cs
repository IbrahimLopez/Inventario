namespace Inventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tabla_Clientes",
                c => new
                    {
                        clienteID = c.Int(nullable: false, identity: true),
                        nombreCliente = c.String(),
                        apellidoPaternoCliente = c.String(),
                        apellidoMaternoCliente = c.String(),
                        direccionCliente = c.String(),
                        telefonoCliente = c.String(),
                        correroCliente = c.String(),
                    })
                .PrimaryKey(t => t.clienteID);
            
            CreateTable(
                "dbo.Tabla_Intemedia_Comrpas",
                c => new
                    {
                        compraID = c.Int(nullable: false, identity: true),
                        clienteID = c.Int(nullable: false),
                        productoID = c.Int(nullable: false),
                        fechaCompra = c.DateTime(),
                        cantidad = c.Int(),
                    })
                .PrimaryKey(t => t.compraID)
                .ForeignKey("dbo.Tabla_Clientes", t => t.clienteID, cascadeDelete: true)
                .ForeignKey("dbo.Tabla_Productos", t => t.productoID, cascadeDelete: true)
                .Index(t => t.clienteID)
                .Index(t => t.productoID);
            
            CreateTable(
                "dbo.Tabla_Productos",
                c => new
                    {
                        productoID = c.Int(nullable: false, identity: true),
                        nombreProducto = c.String(),
                        precioVenta = c.Decimal(precision: 18, scale: 2),
                        precioCompra = c.Decimal(precision: 18, scale: 2),
                        pesoNeto = c.Int(),
                        fechaEntrada = c.DateTime(),
                    })
                .PrimaryKey(t => t.productoID);
            
            CreateTable(
                "dbo.Tabla_Intermedia_Proveen",
                c => new
                    {
                        proveenID = c.Int(nullable: false, identity: true),
                        productoID = c.Int(),
                        RFCproveedor = c.Int(),
                        fechaProveen = c.DateTime(),
                    })
                .PrimaryKey(t => t.proveenID)
                .ForeignKey("dbo.Tabla_Productos", t => t.productoID)
                .ForeignKey("dbo.Tabla_Proveedores", t => t.RFCproveedor)
                .Index(t => t.productoID)
                .Index(t => t.RFCproveedor);
            
            CreateTable(
                "dbo.Tabla_Proveedores",
                c => new
                    {
                        RFCproveedor = c.Int(nullable: false, identity: true),
                        nombreProveedor = c.String(),
                        apellidoPaternoProveedor = c.String(),
                        apellidoMaternoProveedor = c.String(),
                        telefonoProveedor = c.String(),
                        direccionProveedor = c.String(),
                    })
                .PrimaryKey(t => t.RFCproveedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tabla_Intermedia_Proveen", "RFCproveedor", "dbo.Tabla_Proveedores");
            DropForeignKey("dbo.Tabla_Intermedia_Proveen", "productoID", "dbo.Tabla_Productos");
            DropForeignKey("dbo.Tabla_Intemedia_Comrpas", "productoID", "dbo.Tabla_Productos");
            DropForeignKey("dbo.Tabla_Intemedia_Comrpas", "clienteID", "dbo.Tabla_Clientes");
            DropIndex("dbo.Tabla_Intermedia_Proveen", new[] { "RFCproveedor" });
            DropIndex("dbo.Tabla_Intermedia_Proveen", new[] { "productoID" });
            DropIndex("dbo.Tabla_Intemedia_Comrpas", new[] { "productoID" });
            DropIndex("dbo.Tabla_Intemedia_Comrpas", new[] { "clienteID" });
            DropTable("dbo.Tabla_Proveedores");
            DropTable("dbo.Tabla_Intermedia_Proveen");
            DropTable("dbo.Tabla_Productos");
            DropTable("dbo.Tabla_Intemedia_Comrpas");
            DropTable("dbo.Tabla_Clientes");
        }
    }
}
