namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationToMovieNameInMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieName", c => c.String());
        }
    }
}
