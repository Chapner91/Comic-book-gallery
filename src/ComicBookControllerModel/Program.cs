using ComicBookControllerModel.Models;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

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
				context.ComicBooks.Add(new ComicBook()
				{
					SeriesTitle = "The Amazing Spider-man",
					IssueNumber = 1,
					PublishedOn = DateTime.Today
				});
				context.SaveChanges();

				var comicBooks = context.ComicBooks.ToList();

				foreach(var comicBook in comicBooks)
				{
					Console.WriteLine(comicBook.SeriesTitle);
				}

				Console.ReadLine();
			}
		}
	}
}
