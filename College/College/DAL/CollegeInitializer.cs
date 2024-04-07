using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using College.Models;

namespace College.DAL
{
    public class CollegeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CollegeContext>
    {
        protected override void Seed(CollegeContext context)
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
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var cohorts = new List<Cohort>
            {
                new Cohort{name="A1",Students = {students[0],students[1],students[2],students[3]}},
                new Cohort{name="A2",Students = {students[4],students[5]}},
                new Cohort{name="B1",Students = {students[6],students[7]}},
                new Cohort{name="B2",Students = {students[8]}},
            };
            cohorts.ForEach(s => context.Cohorts.Add(s));
            context.SaveChanges();

            

            var faculties = new List<Faculty>
            {
                new Faculty{name="Rowley",mail="Rowley@faculty.com", Cohorts= {cohorts[0],cohorts[1]},hireDate=DateTime.Parse("2024-01-01")},
                new Faculty{name="Munnely",mail="Munnely@faculty.com", Cohorts= {cohorts[2],cohorts[3]},hireDate=DateTime.Parse("2024-02-01")},
            };
            faculties.ForEach(s => context.Faculty.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{title="Chemistry",credits=15,Cohorts = { cohorts[0] }, Faculties = { faculties[0] } },
                new Course{title="Microeconomics",credits=10,Cohorts = { cohorts[2] }, Faculties = { faculties[1] }},
                new Course{title="Macroeconomics",credits=10,Cohorts = { cohorts[2] }, Faculties = { faculties[1] }},
                new Course{title="Calculus",credits=20,Cohorts = { cohorts[0] }, Faculties = { faculties[0] }},
                new Course{title="Trigonometry",credits=15,Cohorts = { cohorts[1], cohorts[0] }, Faculties = { faculties[0] }},
                new Course{title="Composition",credits=30,Cohorts = { cohorts[3] }, Faculties = { faculties[1] }},
                new Course{title="Literature",credits=10,Cohorts = { cohorts[3] }, Faculties = { faculties[1] }}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var exams = new List<Exam>
            {
                new Exam{ Course = courses[0], Cohort = cohorts[0], name="Project"},
                new Exam{ Course = courses[0], Cohort = cohorts[0], name="Math project"},
                new Exam{ Course = courses[2], Cohort = cohorts[1], name="Project"},
                new Exam{ Course = courses[3], Cohort = cohorts[1], name="Math Assignement"},
                new Exam{ Course = courses[4], Cohort = cohorts[2], name="Business oral"},
                new Exam{ Course = courses[5], Cohort = cohorts[3], name="Dissert"},
            };
            exams.ForEach(s => context.Exam.Add(s));
            context.SaveChanges();

            var grades = new List<Grade>
            {
                new Grade{ grade = Value.A,Student = students[0],Exam = exams[0]},
                new Grade{ grade = Value.B,Student = students[0],Exam = exams[1]},
                new Grade{ grade = Value.A,Student = students[1],Exam = exams[0]},
                new Grade{ grade = Value.B,Student = students[1],Exam = exams[1]},
                new Grade{ grade = Value.C,Student = students[2],Exam = exams[2]},
                new Grade{ grade = Value.C,Student = students[3],Exam = exams[3]},
            };
            grades.ForEach(s => context.Grades.Add(s));
            context.SaveChanges();
        }
    }
}