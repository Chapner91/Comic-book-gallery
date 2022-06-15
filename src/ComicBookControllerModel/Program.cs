using ComicBookControllerModel.Models;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.Entity;

namespace ComicBookControllerModel
{
	class Program
	{
		static void Main()
		{
			IConfiguration config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();

			string comicBooksConnectionString = config.GetConnectionString("ComicBooks");
			using (var context = new Context(comicBooksConnectionString))
			{
				var series1 = new Series() { Title = "The Amazing Spider-man" };
				var series2 = new Series() { Title = "The Invincible Iron Man" };
				var artist1 = new Artist() { Name = "Stan Lee" };
				var artist2 = new Artist() { Name = "Allan Moore" };
				var artist3 = new Artist() { Name = "Jack Kirby" };
				var roleScript = new Role() { Name = "Script" };
				var rolePencils = new Role() { Name = "Pencils" };

				var comicBook1 = new ComicBook()
				{
					Series = series1,
					IssueNumber = 1,
					PublishedOn = DateTime.Today
				};
				comicBook1.AddArtist(artist1, roleScript);
				comicBook1.AddArtist(artist3, rolePencils);
	
				var comicBook2 = new ComicBook()
				{
					Series = series1,
					IssueNumber = 2,
					PublishedOn = DateTime.Today
				};
				comicBook2.AddArtist(artist1, roleScript);
				comicBook2.AddArtist(artist3, rolePencils);

				var comicBook3 = new ComicBook()
				{
					Series = series2,
					IssueNumber = 1,
					PublishedOn = DateTime.Today
				};
				comicBook3.AddArtist(artist2, roleScript);
				comicBook3.AddArtist(artist3, rolePencils);

				context.ComicBooks.Add(comicBook1);
				context.ComicBooks.Add(comicBook2);
				context.ComicBooks.Add(comicBook3);
				context.SaveChanges();

				var comicBooks = context.ComicBooks
					.Include(cb => cb.Series)
					.Include(cb => cb.Artists.Select(a => a.Artist))
					.Include(cb => cb.Artists.Select(a => a.Role))
					.ToList();

				foreach(var comicBook in comicBooks)
				{
					var artistRoleNames = comicBook.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
					var artistRolesDisplayText = string.Join(", ", artistRoleNames);

					Console.WriteLine(comicBook.DisplayText);
					Console.WriteLine($"Artists: {artistRolesDisplayText}");
				}

				Console.ReadLine();
			}
		}
	}
}
