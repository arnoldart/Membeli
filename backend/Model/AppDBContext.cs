using Microsoft.EntityFrameworkCore;

public class AppDBContext : DbContext
{
    public DbSet<User> User {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;port=3306;database=mengbelanja;user=root;password=root;");

        base.OnConfiguring(optionsBuilder);
    }
}