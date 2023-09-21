using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinqQueries {

	private List<Book> BooksCollection = new List<Book>();

	public LinqQueries() {
		try {
			using (StreamReader reader = new StreamReader("books.json")) {
				string json = reader.ReadToEnd();
				this.BooksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
			}
		} catch (Exception ex) {
			Console.WriteLine($"Ocurrió un error no especificado: {ex.Message}");
		}
	}
	public IEnumerable<Book> GetBooks() {
		return BooksCollection;
	}

	public void PrintValues(IEnumerable<Book> BooksCollection) {
		string authors;

		Console.WriteLine("{0, -60} -- {1, 7} -- {2, 11}\n", "Title", "Pages", "Publishing date", "Authors");

		foreach (var item in BooksCollection) {
			if (item.Authors.Any()) {
				authors = string.Join(", ", item.Authors);
			} else {
				authors = "No authors found";
			}
			Console.WriteLine("{0, -60} -- {1, 4} -- {2, 11} -- {3, -50}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString(), authors);
		}
		Console.WriteLine("\n");
	}

	public IEnumerable<Book> BookListContainsString(string str) {

		return from book in BooksCollection where book.Title.ToLower().Trim().Contains(str.ToLower().Trim()) select book;
	}
}
