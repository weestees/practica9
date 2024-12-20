namespace GestorAsignaturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAsignaturaModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asignaturas", "CD", c => c.Int(nullable: false));
            AddColumn("dbo.Asignaturas", "CP", c => c.Int(nullable: false));
            AddColumn("dbo.Asignaturas", "AA", c => c.Int(nullable: false));
            AlterColumn("dbo.Asignaturas", "Nombre", c => c.String(nullable: false));
            DropColumn("dbo.Asignaturas", "Codigo");
            DropColumn("dbo.Asignaturas", "Horas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Asignaturas", "Horas", c => c.Int(nullable: false));
            AddColumn("dbo.Asignaturas", "Codigo", c => c.String(nullable: false, maxLength: 7));
            AlterColumn("dbo.Asignaturas", "Nombre", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Asignaturas", "AA");
            DropColumn("dbo.Asignaturas", "CP");
            DropColumn("dbo.Asignaturas", "CD");
        }
    }
}
