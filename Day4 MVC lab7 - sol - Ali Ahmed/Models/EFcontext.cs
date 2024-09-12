namespace Day4_MVC_lab7___sol___Ali_Ahmed.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFcontext : DbContext
    {
        // Your context has been configured to use a 'EFcontext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Day4_MVC_lab7___sol___Ali_Ahmed.Models.EFcontext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EFcontext' 
        // connection string in the application configuration file.
        public EFcontext()
            : base("name=EFcontext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}