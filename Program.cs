using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Main Method
public class Program {
	public static void Main(String[] args) {

		//double test = MiEnum.VALOR2.Valor;
		//double prueba = test + 2;
		//Console.WriteLine(prueba);

		//double pi = Math.PI;
		//Console.WriteLine(pi + pi);

		//double valorDouble = MiEnum.GetValue();

		//Console.WriteLine(valorDouble);

		LinqQueries queries = new LinqQueries();

		IEnumerable<Book> books = queries.GetBooks();

		queries.PrintValues(books);


		//FORMA DE HACERLO CON SINTAXIS TRADICIONAL + .ToList() y foreach de cada objeto de la lista.
		var linqQuery = from element in books
						where element.PublishedDate.Year > 2019
						select element;

		linqQuery.ToList().ForEach(book => {
			Console.WriteLine(book.Title);
		});

		//En lugar de crear LinqQueries objet, podemos usar simplemente una List<Book> para almacenar el resultado de una consulta LINQ previa.
		List<Book> bookList = new List<Book>();

		bookList = linqQuery.ToList();

		bookList.ForEach(p => {
			Console.WriteLine(p.ThumbnailUrl);
		});

		//Extension method
		//FORMA ABREVIADA UTILIZANDO MÉTODO Where, ya que ya teníamos un IEnumerable previamente.
		var linqQuery2 = books.Where(p => p.PublishedDate.Year > 2019);

		queries.PrintValues(linqQuery2);

		//En este caso, tenemos una cláusula group by. La diferencia principal respeco a SQL es que hay
		//que almacenar los resultados del group by resultante en una variable a través de "into"
		var linqQuery3 = from element in books
						 where element.PublishedDate.Year > 2019
						 group element by element.PublishedDate.Year into grouped
						 select grouped;

		//Operación 
		bool hasContent = linqQuery3.Any();

		Console.WriteLine("\n" + hasContent + "\n");

		queries.PrintValues(linqQuery2);


		// Uso de Take(): después de realizar la consulta en formato sql en vez de formato extension.
		//Importante el uso de paréntesis abrazando toda la consulta para luego aplicar el método Take() que probablemente se considere de extensión.
		var linqQuery4 = (from element in books
						  where element.Categories.Contains("Java") || element.Categories.Contains("java")
						  orderby element.PublishedDate descending
						  select element).Take(3);
		Console.WriteLine("\n Consulta con Take(3) de los tres primeros resultados después de filtrar");
		queries.PrintValues(linqQuery4);
		////////MISMA CONSULTA que la anterior pero utilizando extension method.
		//var linqQuery4 = books
		//  .Where(element => element.Categories.Contains("Java", StringComparer.OrdinalIgnoreCase))
		//  .OrderByDescending(element => element.PublishedDate)
		//  .Take(3);

		////////MISMA CONSULTA pero en SQL SERVER
		//	SELECT TOP 3 *
		//	FROM TuTablaDeLibros
		//	WHERE CHARINDEX('Java', Categories) > 0 OR CHARINDEX('java', Categories) > 0
		//	ORDER BY PublishedDate DESC;

		///////MISMA CONSULTA PERO EN POSTGRES SQL:
		///	SELECT *
		//	FROM TuTablaDeLibros
		//	WHERE Categories ILIKE '%Java%' OR Categories ILIKE '%java%'
		//	ORDER BY PublishedDate DESC
		//	LIMIT 3;



		///
		//Pruebas orderby con la lista de libros
		var librosOrdenados = from book in books
							  where book.PublishedDate.Year > 2010
							  orderby book.PublishedDate.Year ascending
							  select book;

		queries.PrintValues(librosOrdenados);

		//CONSULTA EXTENSION LINQ método Count o LongCount, devolviendo int o long del número de objetos que cumplen x condiciones.
		//Es importante tener en cuenta que algunos metodos extension pueden recibir por parámetros condicionales sin necesidad de usar where u otros.
		long linqQuery5 = books.LongCount(book => book.PageCount>=200 && book.PageCount<=500);

		DateTime linqQuery6 = books.Min(book => book.PublishedDate);

		Console.WriteLine(linqQuery6);
		//Probando una funcion que devuelve IEnumerable<Book> de todos los libros cuyo título contenga un string.
		List<Book> searchBooks = new List<Book>();
		searchBooks = queries.BookListContainsString("   Advanced   ").ToList();
		queries.PrintValues(searchBooks);

		///////////// EJERCICIO /////////
		List<Animal> animales = new List<Animal>();
		animales.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
		animales.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
		animales.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
		animales.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
		animales.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
		animales.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
		animales.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
		animales.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
		animales.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });

		// Escribe tu código aquí
		// filtra todos los animales que sean de color verde que su nombre inicie con una vocal
		List<Animal> solucion = animales.Where(animal => animal.Color == "Verde" && "aeiouAEIOU".Contains(animal.Nombre[0])).ToList();
		solucion.ForEach(animal => Console.WriteLine(animal.Nombre + " " + animal.Color));
		////////////////////////////

		//Esta consulta LINQ da el siguiente problema:
		//// Unhandled exception. System.InvalidOperationException: Failed to compare two elements in the array.
		//// Esto se debe a que en orderby grouped descendint no uso grouped.Key
		var solucion0 = from animal in animales
						group animal by animal.Nombre into grouped
						orderby grouped descending
						select grouped;

		//Para pasar de IOrderedEnumerable<IGrouping<string, Animal>> a un simple IEnumerable<> como en una consulta básica,
		//puede conseguirse mediante la siguiente sintaxis.
		var solucionAplanada = solucion0.SelectMany(group => group);

		var solucion1 = from animal in animales
						where animal.Nombre.Contains("a")
						group animal by animal.Color into grouped
						orderby grouped.Key ascending
						select grouped;

		/*En la consulta anterior,  la utilizar group by x into otraVariable(grouped), la estructura de datos devuelta no es un IEnumerable<T>,
		 * sino un IOrderedEnumerable<IGrouping<string, Animal>>. Por esto, si en lugar de usar var queremos especificar el tipo de objeto específico
		 * es un IGrouping<string, Animal>, omitiendo IOrderedEnumerable, que es la estructura que contiene la otra estructura y donde vamos a hacer
		 * el foreach realmente.
		*/
		foreach (IGrouping<string, Animal> grupo in solucion1) {
			Console.WriteLine($"Grupo: {grupo.Key}");

			foreach (Animal animal in grupo) {
				Console.WriteLine($"Nombre: {animal.Nombre}, Color: {animal.Color}");
			}
		}

		//MISMO FOREACH PERO USANDO VAR
		foreach (var grupo in solucion1) {
			Console.WriteLine($"\n Grupo: {grupo.Key}");

			foreach (var animal in grupo) {
				Console.WriteLine($"Nombre: {animal.Nombre}, Color: {animal.Color}");
			}
		}

		//Transformar el tipo de estructura IOrderedEnumerable<Animal> no parece ser posible 
		var solucion2 = animales.OrderByDescending(animal => animal.Nombre);
		//Aquí, no funciona el sistema anterior, pues se trata de otra estructura y debe ser por eso...
		//var solucionAplanada2 = solucion2.SelectMany(group => group);

		string prueba = string.Empty;//Como usar un string vacío correctamente.
	}

	private class Animal {
		public string Nombre { get; set; }
		public string Color { get; set; }
	}
}

