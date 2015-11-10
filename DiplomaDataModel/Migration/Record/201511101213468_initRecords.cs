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
                        SecondChoiceOptionId = c.Int(nullable: false),
                        ThirdChoiceOptionId = c.Int(nullable: false),
                        FourthChoiceOptionId = c.Int(nullable: false),
                        SelectionDate = c.DateTime(nullable: false),
                        YearTerm = c.Int(nullable: false),
                        YearTerm_YearTermId = c.Int(),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.YearTerms", t => t.YearTerm_YearTermId)
                .Index(t => t.YearTerm_YearTermId);
            
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
            
            CreateTable(
                "dbo.OptionChoices",
                c => new
                    {
                        Option_OptionId = c.Int(nullable: false),
                        Choice_ChoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Option_OptionId, t.Choice_ChoiceId })
                .ForeignKey("dbo.Options", t => t.Option_OptionId, cascadeDelete: true)
                .ForeignKey("dbo.Choices", t => t.Choice_ChoiceId, cascadeDelete: true)
                .Index(t => t.Option_OptionId)
                .Index(t => t.Choice_ChoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choices", "YearTerm_YearTermId", "dbo.YearTerms");
            DropForeignKey("dbo.OptionChoices", "Choice_ChoiceId", "dbo.Choices");
            DropForeignKey("dbo.OptionChoices", "Option_OptionId", "dbo.Options");
            DropIndex("dbo.OptionChoices", new[] { "Choice_ChoiceId" });
            DropIndex("dbo.OptionChoices", new[] { "Option_OptionId" });
            DropIndex("dbo.Choices", new[] { "YearTerm_YearTermId" });
            DropTable("dbo.OptionChoices");
            DropTable("dbo.YearTerms");
            DropTable("dbo.Options");
            DropTable("dbo.Choices");
        }
    }
}
