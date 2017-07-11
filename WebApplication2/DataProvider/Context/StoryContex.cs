using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvider.Context
{
    public class StoryContext : DbContext
    {
        static StoryContext()
        {
            Database.SetInitializer<StoryContext>(new StoreDbInitializer());
        }
        //public StoryContext()
        // : base("MyDBConection")
        //{
        //}
        public StoryContext(string connectionString)
            : base(connectionString)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet <Story> Stories { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StoryContext>
    {
        protected override void Seed(StoryContext context)
        {
            context.Groups.Add(new Group { Name = "Cars", Description = "Old cars" });
            context.Groups.Add(new Group { Name = "Enimals", Description = "Wild enimals" });
            context.Groups.Add(new Group { Name = "Natural", Description = "Wild flowers" });

            context.SaveChanges();
        }
    }
}
