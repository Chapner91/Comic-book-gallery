using System;
using System.Collections.Generic;
using System.Data.Entity;
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
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
		}

		public DbSet<ComicBook> ComicBooks { get; set; }
	}
}
