namespace ACMWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalcType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PIMappings", "CType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PIMappings", "CType");
        }
    }
}
