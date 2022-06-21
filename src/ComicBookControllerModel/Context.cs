using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookControllerModel.Models;

namespace ComicBookControllerModel
{
	class Context : DbContext
	{
		public Context(string connectionString) : base(connectionString) 
		{
			//Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
			Database.SetInitializer(new DatabaseInitializer());
		}

		public DbSet<ComicBook> ComicBooks { get; set; }
		public DbSet<Series> Series { get; set; }
		public DbSet<Artist> Artists { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<ComicBook>().Property(cb => cb.AverageRating).HasPrecision(5, 2);
		}
	}
}
