namespace WebEmployees.Migrations
{
    using WebEmployees.Models;
    using WebEmployees.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebEmployeesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebEmployeesContext context)
        {
            var positions = new List<Position>
            {
                new Position { Name = "Developer" },
                new Position { Name = "Tester" },
                new Position { Name = "Manager" },
                new Position { Name = "Team Leader" }
            };
            positions.ForEach(s => context.Positions.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { FirstMidName = "Ivan",   LastName = "Ivanov", 
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Manager").PositionID },
                new Employee { FirstMidName = "Stepan", LastName = "Voinov",    
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Manager").PositionID },
                new Employee { FirstMidName = "Igor",   LastName = "Pupkin",     
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Manager").PositionID },
                new Employee { FirstMidName = "Alexey",    LastName = "Pushkin", 
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Tester").PositionID },
                new Employee { FirstMidName = "Yuri",      LastName = "Petrov",        
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Developer").PositionID },
                new Employee { FirstMidName = "Olga",    LastName = "Ivanova",   
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Tester").PositionID },
                new Employee { FirstMidName = "Kate",    LastName = "Ivanova",    
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Tester").PositionID },
                new Employee { FirstMidName = "Liza",     LastName = "Sidorova",  
                    EnrollmentDate = DateTime.Parse("1990-09-01"),
                    PositionID = positions.Single( s => s.Name == "Tester").PositionID }
            };
            employees.ForEach(s => context.Employees.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
        }
    }
}
