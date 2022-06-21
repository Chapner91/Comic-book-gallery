using ComicBookControllerModel.Models;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.Entity;
using System.Diagnostics;

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
				context.Database.Log = (message) => Debug.WriteLine(message);

				//var comicBooksQuery = context.ComicBooks
				//	.Include(cb => cb.Series)
				//	.OrderByDescending(cb => cb.IssueNumber);

				//var comicBooks = comicBooksQuery
				//	.ToList();

				//var comicBooks2 = comicBooksQuery
				//	.Where(cb => cb.AverageRating < 7)
				//	.ToList();

				//Console.WriteLine($"# of comic books: {comicBooks.Count} ");
				//Console.WriteLine();
				//foreach(var comicBook in comicBooks)
				//{
				//	Console.WriteLine(comicBook.DisplayText);
				//}

				//Console.WriteLine($"# of comic books rated under 7: {comicBooks2.Count} ");
				//Console.WriteLine();

				//foreach (var comicBook in comicBooks2)
				//{
				//	Console.WriteLine(comicBook.DisplayText);
				//}

				//var comicBooks = context.ComicBooks
				//	//.Include(cb => cb.Series)
				//	//.Include(cb => cb.Artists.Select(a => a.Artist))
				//	//.Include(cb => cb.Artists.Select(a => a.Role))
				//	.ToList();

				//foreach (var comicBook in comicBooks)
				//{
				//	var artistRoleNames = comicBook.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
				//	var artistRolesDisplayText = string.Join(", ", artistRoleNames);

				//	Console.WriteLine(comicBook.DisplayText);
				//	Console.WriteLine($"Artists: {artistRolesDisplayText}");
				//}

				var comicBookID = 1;
				var comicBook1 = context.ComicBooks.Find(comicBookID);
				var comicBook2 = context.ComicBooks.Find(comicBookID);

				Console.ReadLine();
			}
		}
	}
}
