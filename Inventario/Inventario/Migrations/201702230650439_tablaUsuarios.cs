namespace Inventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablaUsuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombreUsuario", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoPaternoUsuario", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoMaternoUsuario", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "apellidoMaternoUsuario");
            DropColumn("dbo.AspNetUsers", "apellidoPaternoUsuario");
            DropColumn("dbo.AspNetUsers", "nombreUsuario");
        }
    }
}
