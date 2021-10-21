using CommanderDA.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommanderDA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        // note convention, model singular and DbSet is plural
        // think of DbSet as table, and DbContext as DB
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Command> Commands { get; set; }

        // being explicit about relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Tool>()
                .HasMany(t => t.Commands)       // Tool relates to many Commands
                .WithOne(c => c.Tool!)          // Each Command relates to one Tool
                .HasForeignKey(t => t.ToolId);  // Each Tool can be used as a ForeignKey

            modelBuilder
                .Entity<Command>()
                .HasOne(c => c.Tool)            // Command relates to one Tool
                .WithMany(t => t.Commands)      // Each Tool may relate to many Commands
                .HasForeignKey(c => c.ToolId);  // Each Command can be used as a ForeignKey

            modelBuilder.Entity<Tool>().HasData(
                new { Id = 1, Name = "dotnet", Description = "" },
                new { Id = 2, Name = "docker", Description = "" },
                new { Id = 3, Name = "git", Description = "" });

            modelBuilder.Entity<Command>().HasData(
                new { Id = 1, HowTo = "Enable secret storage for project", CommandLine = "dotnet user-secrets init", ToolId = 1  },
                new { Id = 2, HowTo = "Set secret for project", CommandLine = "dotnet user-secrets set \"<key>\" \"<value>\"", ToolId = 1 },
                new { Id = 3, HowTo = "Generate default dotnet gitignore file for project", CommandLine = "dotnet new gitignore", ToolId = 1 },
                new { Id = 4, HowTo = "Create an empty Git repository or reinitialize an existing one", CommandLine = "git init", ToolId = 3 });
        }
    }
}
