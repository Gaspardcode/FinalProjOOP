namespace College.Migrations
{
    using College.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.CollegeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }
   
        
        protected override void Seed(DAL.CollegeContext context)
        {
                var students = new List<Student>
                {
                new Student{firstname="Carson",lastname="Hubert",mail="carson@student.com",address="124 North road circular"},
                new Student{firstname="Alexander",lastname="Kilou",mail="alexander@student.com",address="14 North road circular"},
                new Student{firstname="Arturo",lastname="Guhu",mail="arturo@student.com",address="167 North road circular"},
                new Student{firstname="Laura",lastname="Mali",mail="laura@student.com",address="99 North road circular"},
                new Student{firstname="Max",lastname="Jergon",mail="max@student.com",address="34 North road circular"},
                new Student{firstname="Emily",lastname="Pulu",mail="emily@student.com",address="78 North road circular"},
                new Student{firstname="Ema",lastname="Vernon",mail="ema@student.com",address="45 North road circular"},
                new Student{firstname="Lara",lastname="Duper",mail="lara@student.com",address="77 North road circular"},
                new Student{firstname="Ursula",lastname="Dirton",mail="ursula@student.com",address="78 North road circular"}
                };
                students.ForEach(s => context.Students.AddOrUpdate(p => p.mail,s));
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                var cohorts = new List<Cohort>
                {
                    new Cohort{name="A1",Students = new List<Student> {students[0],students[1],students[2],students[3]}},
                    new Cohort{name="A2",Students = new List<Student> {students[4],students[5]}},
                    new Cohort{name="B1",Students = new List<Student> {students[6],students[7]}},
                    new Cohort{name="B2",Students = new List<Student> {students[8]}}, 
                };
                cohorts.ForEach(s => context.Cohorts.AddOrUpdate(p => p.name, s));
                context.SaveChanges();

                int i = 0;
                foreach(var stu in context.Students)
                {
                    stu.Cohort = cohorts[i];
                    i = (i + 1) % cohorts.Count;
                }

            var faculties = new List<Faculty>
                {
                    new Faculty{name="Rowley",mail="Rowley@faculty.com", Cohorts = new List<Cohort> {cohorts[0],cohorts[1]},hireDate=DateTime.Parse("2024-01-01")},
                    new Faculty{name="Munnely",mail="Munnely@faculty.com", Cohorts= new List<Cohort> {cohorts[2],cohorts[3] },hireDate=DateTime.Parse("2024-02-01")},
                };
                faculties.ForEach(s => context.Faculty.AddOrUpdate(p => p.name, s));
                context.SaveChanges();

                var courses = new List<Course>
                {
                    new Course{title="Chemistry",credits=15,Cohorts = new List<Cohort> { cohorts[0] }, Faculties = new List<Faculty> { faculties[0] } },
                    new Course{title="Microeconomics",credits=10,Cohorts = new List<Cohort> { cohorts[2] }, Faculties = new List<Faculty> { faculties[1] }},
                    new Course{title="Macroeconomics",credits=10,Cohorts = new List<Cohort> { cohorts[2] }, Faculties = new List<Faculty> { faculties[1] }},
                    new Course{title="Calculus",credits=20,Cohorts = new List<Cohort> { cohorts[0] }, Faculties = new List<Faculty> { faculties[0] }},
                    new Course{title="Trigonometry",credits=15,Cohorts = new List<Cohort> { cohorts[1], cohorts[0] }, Faculties = new List<Faculty> { faculties[0] }},
                    new Course{title="Composition",credits=30,Cohorts = new List<Cohort> { cohorts[3] }, Faculties = new List<Faculty> { faculties[1] }},
                    new Course{title="Literature",credits=10,Cohorts = new List<Cohort> { cohorts[3] }, Faculties = new List<Faculty> { faculties[1] }}
                };
                courses.ForEach(s => context.Courses.AddOrUpdate(p => p.title, s));
                context.SaveChanges();

                var exams = new List<Exam>
                {
                    new Exam{ Course = courses[0], Cohort = cohorts[0], name="Project"},
                    new Exam{ Course = courses[0], Cohort = cohorts[0], name="Math project"},
                    new Exam{ Course = courses[2], Cohort = cohorts[1], name="Firm Project"},
                    new Exam{ Course = courses[3], Cohort = cohorts[1], name="Math Assignement"},
                    new Exam{ Course = courses[4], Cohort = cohorts[2], name="Business oral"},
                    new Exam{ Course = courses[5], Cohort = cohorts[3], name="Dissert"},
                };
                exams.ForEach(s => context.Exam.AddOrUpdate(p => p.name, s));
                context.SaveChanges();

                var grades = new List<Grade>
                {
                    new Grade{ grade = Value.A,Student = students[0],Exam = exams[0],coefficient = 1},
                    new Grade{ grade = Value.B,Student = students[0],Exam = exams[1],coefficient = 1},
                    new Grade{ grade = Value.A,Student = students[1],Exam = exams[0],coefficient = 1},
                    new Grade{ grade = Value.B,Student = students[1],Exam = exams[1],coefficient = 1},
                    new Grade{ grade = Value.C,Student = students[2],Exam = exams[2],coefficient = 1},
                    new Grade{ grade = Value.C,Student = students[3],Exam = exams[3],coefficient = 1},
                };
                grades.ForEach(s => context.Grades.AddOrUpdate(s));
                context.SaveChanges();
        }
    }
}
        

/*
 namespace College.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapped : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Cohort",
                    c => new
                    {
                        CohortId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        CourseId = c.Int(),
                        FacultyId = c.Int(),
                    })
                    .PrimaryKey(t => t.CohortId)
                    .ForeignKey("dbo.Course", t => t.CourseId)
                    .ForeignKey("dbo.Faculty", t => t.FacultyId)
                    .Index(t => t.CourseId)
                    .Index(t => t.FacultyId);

            CreateTable(
                "dbo.Course",
                c => new
                {
                    CourseId = c.Int(nullable: false, identity: true),
                    title = c.String(),
                    credits = c.Int(),
                })
                .PrimaryKey(t => t.CourseId);

            CreateTable(
                "dbo.Faculty",
                c => new
                {
                    FacultyId = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    hireDate = c.DateTime(),
                    mail = c.String(),
                    CourseId = c.Int(),
                })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    StudentId = c.Int(nullable: false, identity: true),
                    address = c.String(),
                    firstname = c.String(),
                    lastname = c.String(),
                    mail = c.String(),
                    CohortId = c.Int(),
                })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Cohort", t => t.CohortId)
                .Index(t => t.CohortId);

            CreateTable(
                "dbo.Grade",
                c => new
                {
                    GradeId = c.Int(nullable: false, identity: true),
                    grade = c.Int(),
                    coefficient = c.Int(),
                    ExamId = c.Int(),
                    StudentId = c.Int(),
                })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Exam", t => t.ExamId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.ExamId)
                .Index(t => t.StudentId);

            CreateTable(
                "dbo.Exam",
                c => new
                {
                    ExamId = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    description = c.String(),
                    CohortId = c.Int(),
                    CourseId = c.Int(),
                })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Cohort", t => t.CohortId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CohortId)
                .Index(t => t.CourseId);

        }
        public override void Down()
        {
        }
    }
}
  
        
 */
