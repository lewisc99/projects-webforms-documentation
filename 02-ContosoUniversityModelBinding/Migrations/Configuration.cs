namespace ContosoUniversityModelBinding.Migrations
{
    using ContosoUniversityModelBinding.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversityModelBinding.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoUniversityModelBinding.Models.SchoolContext context)
        {
            try
            {
                // se for gerar uma nova migration apaga esse codigo, dpeois de gerado coloca novamente.
                context.Students.AddOrUpdate(
                new Student
                {
                    FirstName = "Carson",
                    LastName = "Alexander",
                    Year = AcademicYear.Freshman
                    ,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                },
                new Student
                {
                    FirstName = "Meredith",
                    LastName = "Alonso",
                    Year = AcademicYear.Freshman,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                },
                new Student
                {
                    FirstName = "Arturo",
                    LastName = "Anand",
                    Year = AcademicYear.Sophomore,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                },
                new Student
                {
                    FirstName = "Gytis",
                    LastName = "Barzdukas",
                    Year = AcademicYear.Sophomore,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                },
                new Student
                {
                    FirstName = "Yan",
                    LastName = "Li",
                    Year = AcademicYear.Junior,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                },
                new Student
                {
                    FirstName = "Peggy",
                    LastName = "Justice",
                    Year = AcademicYear.Junior,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                },
                new Student
                {
                    FirstName = "Laura",
                    LastName = "Norman",
                    Year = AcademicYear.Senior,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                },
                new Student
                {
                    FirstName = "Nino",
                    LastName = "Olivetto",
                    Year = AcademicYear.Senior,
                    EnrollmentDate = new DateTime(2013, 9, 1) // Valid EnrollmentDate
                }
                );

                context.SaveChanges();

                context.Courses.AddOrUpdate(
                    new Course { Title = "Chemistry", Credits = 3 },
                    new Course { Title = "Microeconomics", Credits = 3 },
                    new Course { Title = "Macroeconomics", Credits = 3 },
                    new Course { Title = "Calculus", Credits = 4 },
                    new Course { Title = "Trigonometry", Credits = 4 },
                    new Course { Title = "Composition", Credits = 3 },
                    new Course { Title = "Literature", Credits = 4 }
                    );

                context.SaveChanges();

                context.Enrollments.AddOrUpdate(
                    new Enrollment { StudentID = 1, CourseID = 1, Grade = 1 },
                    new Enrollment { StudentID = 1, CourseID = 2, Grade = 3 },
                    new Enrollment { StudentID = 1, CourseID = 3, Grade = 1 },
                    new Enrollment { StudentID = 2, CourseID = 4, Grade = 2 },
                    new Enrollment { StudentID = 2, CourseID = 5, Grade = 4 },
                    new Enrollment { StudentID = 2, CourseID = 6, Grade = 4 },
                    new Enrollment { StudentID = 3, CourseID = 1 },
                    new Enrollment { StudentID = 4, CourseID = 1 },
                    new Enrollment { StudentID = 4, CourseID = 2, Grade = 4 },
                    new Enrollment { StudentID = 5, CourseID = 3, Grade = 3 },
                    new Enrollment { StudentID = 6, CourseID = 4 },
                    new Enrollment { StudentID = 7, CourseID = 5, Grade = 2 }
                    );

                context.SaveChanges();
            } 
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw; // Re-throw the exception to see it in the output
            }
        }
    }
}
