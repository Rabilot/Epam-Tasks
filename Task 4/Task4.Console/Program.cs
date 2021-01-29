using System;
using System.Collections.Generic;
using System.Data.Entity;
using Task4.DAL;
using Task4.Models;

namespace Task4.Console
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[]  Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }
        
        public Grade Grade { get; set; }
    }
    
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
    
        public ICollection<Student> Students { get; set; }
    }
    
    namespace EF6Console
    {
        public class SchoolContext: DbContext 
        {
            public SchoolContext(): base("con")
            {
            
            }
            
            public DbSet<Student> Students { get; set; }
            public DbSet<Grade> Grades { get; set; }
        }
    }


        class Program
        {
            static void Main(string[] args)
            {
     
                using (var ctx = new DatabaseContext())
                {
                    
                    
                    var stud = new Client() {LastName = "AAA", FirstName = "BBB"};

                    ctx.Clients.Add(stud);
                    ctx.SaveChanges();                
                }
            }
        }
    
}