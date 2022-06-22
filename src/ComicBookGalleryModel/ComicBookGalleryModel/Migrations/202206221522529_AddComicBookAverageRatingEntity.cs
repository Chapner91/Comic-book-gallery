namespace ComicBookGalleryModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComicBookAverageRatingEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComicBookAverageRating",
                c => new
                    {
                        ComicBookAverageRatingID = c.Int(nullable: false, identity: true),
                        ComicBookId = c.Int(nullable: false),
                        AverageRating = c.Decimal(nullable: false, precision: 5, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ComicBookAverageRatingID)
                .ForeignKey("dbo.ComicBook", t => t.ComicBookId, cascadeDelete: true)
                .Index(t => t.ComicBookId);

			// Populate the initial values for the ComicBookAverageRating table
			Sql(@"
				INSERT INTO dbo.ComicBookAverageRating 
					(ComicBookId, AverageRating, Date) 
				SELECT 
					Id, AverageRating, GETDATE() 
				FROM dbo.ComicBook 
				WHERE AverageRating IS NOT NULL");

            DropColumn("dbo.ComicBook", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComicBook", "AverageRating", c => c.Decimal(precision: 5, scale: 2));

			// Populate ComicBook.AverageRating column with most recent average rating value
			Sql(@"
				update cb
				set cb.AverageRating = cbar.AverageRating
				from ComicBook cb
				cross apply (
					select top 1 AverageRating, Date
					from ComicBookAverageRating 
					where ComicBookId = cb.Id
					order by Date desc
				) as cbar
			");

            DropForeignKey("dbo.ComicBookAverageRating", "ComicBookId", "dbo.ComicBook");
            DropIndex("dbo.ComicBookAverageRating", new[] { "ComicBookId" });
            DropTable("dbo.ComicBookAverageRating");
        }
    }
}
