namespace DiplomaDataModel.Migration.Record
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initRecords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        ChoiceId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false, maxLength: 9),
                        StudentFirstName = c.String(nullable: false, maxLength: 40),
                        StudentLastName = c.String(nullable: false, maxLength: 40),
                        FirstChoiceOptionId = c.Int(nullable: false),
                        SecondChoiceOptionId = c.Int(),
                        ThirdChoiceOptionId = c.Int(),
                        FourthChoiceOptionId = c.Int(),
                        SelectionDate = c.DateTime(nullable: false),
                        YearTermId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.Options", t => t.FirstChoiceOptionId, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.SecondChoiceOptionId)
                .ForeignKey("dbo.Options", t => t.ThirdChoiceOptionId)
                .ForeignKey("dbo.Options", t => t.FourthChoiceOptionId)
                .ForeignKey("dbo.YearTerms", t => t.YearTermId, cascadeDelete: true)
                .Index(t => t.FirstChoiceOptionId)
                .Index(t => t.SecondChoiceOptionId)
                .Index(t => t.ThirdChoiceOptionId)
                .Index(t => t.FourthChoiceOptionId)
                .Index(t => t.YearTermId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId);
            
            CreateTable(
                "dbo.YearTerms",
                c => new
                    {
                        YearTermId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Term = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YearTermId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choices", "YearTermId", "dbo.YearTerms");
            DropForeignKey("dbo.Choices", "FourthChoiceOptionId", "dbo.Options");
            DropForeignKey("dbo.Choices", "ThirdChoiceOptionId", "dbo.Options");
            DropForeignKey("dbo.Choices", "SecondChoiceOptionId", "dbo.Options");
            DropForeignKey("dbo.Choices", "FirstChoiceOptionId", "dbo.Options");
            DropIndex("dbo.Choices", new[] { "YearTermId" });
            DropIndex("dbo.Choices", new[] { "FourthChoiceOptionId" });
            DropIndex("dbo.Choices", new[] { "ThirdChoiceOptionId" });
            DropIndex("dbo.Choices", new[] { "SecondChoiceOptionId" });
            DropIndex("dbo.Choices", new[] { "FirstChoiceOptionId" });
            DropTable("dbo.YearTerms");
            DropTable("dbo.Options");
            DropTable("dbo.Choices");
        }
    }
}
