namespace Inventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registrosUsuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoPaterno", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoMaterno", c => c.String());
            DropColumn("dbo.AspNetUsers", "nombreUsuario");
            DropColumn("dbo.AspNetUsers", "apellidoPaternoUsuario");
            DropColumn("dbo.AspNetUsers", "apellidoMaternoUsuario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "apellidoMaternoUsuario", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoPaternoUsuario", c => c.String());
            AddColumn("dbo.AspNetUsers", "nombreUsuario", c => c.String());
            DropColumn("dbo.AspNetUsers", "apellidoMaterno");
            DropColumn("dbo.AspNetUsers", "apellidoPaterno");
            DropColumn("dbo.AspNetUsers", "nombre");
        }
    }
}
