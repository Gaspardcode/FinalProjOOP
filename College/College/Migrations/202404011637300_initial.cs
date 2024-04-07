namespace College.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cohort",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Course_Id = c.Int(),
                        Faculty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .ForeignKey("dbo.Faculty", t => t.Faculty_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Faculty_Id);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        credits = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        hireDate = c.DateTime(nullable: false),
                        mail = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        address = c.String(),
                        firstname = c.String(),
                        lastname = c.String(),
                        mail = c.String(),
                        Cohort_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cohort", t => t.Cohort_Id)
                .Index(t => t.Cohort_Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        grade = c.Int(),
                        coefficient = c.Int(),
                        Exam_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.Exam_Id)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .Index(t => t.Exam_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        Cohort_Id = c.Int(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cohort", t => t.Cohort_Id)
                .ForeignKey("dbo.Course", t => t.Course_Id)
                .Index(t => t.Cohort_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grade", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.Grade", "Exam_Id", "dbo.Exam");
            DropForeignKey("dbo.Exam", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Exam", "Cohort_Id", "dbo.Cohort");
            DropForeignKey("dbo.Student", "Cohort_Id", "dbo.Cohort");
            DropForeignKey("dbo.Faculty", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Cohort", "Faculty_Id", "dbo.Faculty");
            DropForeignKey("dbo.Cohort", "Course_Id", "dbo.Course");
            DropIndex("dbo.Exam", new[] { "Course_Id" });
            DropIndex("dbo.Exam", new[] { "Cohort_Id" });
            DropIndex("dbo.Grade", new[] { "Student_Id" });
            DropIndex("dbo.Grade", new[] { "Exam_Id" });
            DropIndex("dbo.Student", new[] { "Cohort_Id" });
            DropIndex("dbo.Faculty", new[] { "Course_Id" });
            DropIndex("dbo.Cohort", new[] { "Faculty_Id" });
            DropIndex("dbo.Cohort", new[] { "Course_Id" });
            DropTable("dbo.Exam");
            DropTable("dbo.Grade");
            DropTable("dbo.Student");
            DropTable("dbo.Faculty");
            DropTable("dbo.Course");
            DropTable("dbo.Cohort");
        }
    }
}
