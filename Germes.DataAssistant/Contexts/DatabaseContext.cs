using Germes.NureNET.Types;
using Microsoft.EntityFrameworkCore;

namespace Germes.DataAssistant.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Auditory> Auditories { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user=root;password=12345678;database=usersdb5;";
        optionsBuilder.UseMySql(
            connectionString, 
            ServerVersion.AutoDetect(connectionString)
        );
    }
}