namespace GestorAsignaturas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabaseSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asignaturas", "Codigo", c => c.String(nullable: false, maxLength: 7));
            AddColumn("dbo.Asignaturas", "Area", c => c.String());
            AlterColumn("dbo.Asignaturas", "Nombre", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Asignaturas", "Nombre", c => c.String(nullable: false));
            DropColumn("dbo.Asignaturas", "Area");
            DropColumn("dbo.Asignaturas", "Codigo");
        }
    }
}
