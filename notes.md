# Linq for C# notes.

### Use cases and basic info.
This .NET functionality is useful to store the result of a query in a IEnumerable<T> structure that fastens the searching process in a given data structure like an Array, List, Dictionary...
Apart from those native collections that can store data from other sources, LINQ can query C# data structures that come from SQL tables, XML files and more. There are also extra libraries that give more functionalities like JSON queries.

The returned data structure from basic LINQ query seems to be an IEnumerable<T>. 
**The outcome of the LINQ query can vary depending on the operation performed. For example, IOrderedEnumerable<T> or IOrderedEnumerable<IGrouping<key, Object>> will be returned when orderby/group into is used.**

This data structure can be transformed into other data structures that implement IEnumerable interface with: 
- ToArray()
- ToList()
- ToDictionary
- ToHashSet()
- ToLookup "Its a dictionary like structure"

## Keywords with definition

- where / .Where()
- from: Define la fuente de datos para la consulta LINQ.
- in: Se utiliza en cl�usulas from para especificar las variables de rango.
- where: Filtra los elementos de la secuencia bas�ndose en una condici�n.
- select: Proyecta (selecciona) los elementos de la secuencia en un nuevo formato.
- orderby: Ordena los elementos de la secuencia en funci�n de un criterio espec�fico.
- ascending: Utilizado con orderby para ordenar en orden ascendente.
- descending: Utilizado con orderby para ordenar en orden descendente.
- group: Agrupa elementos de la secuencia bas�ndose en una clave espec�fica.
- by: Se utiliza con group para especificar la clave de agrupaci�n.
- join: Realiza una uni�n entre dos secuencias bas�ndose en una condici�n espec�fica.
- equals: Se utiliza con join para especificar la condici�n de igualdad.
- on: Se utiliza con join para especificar la relaci�n entre las dos secuencias.
- let: Permite definir variables locales en una consulta.
- into: Se utiliza con join para crear una cl�usula "join into".
- group ... by: Realiza una agrupaci�n de elementos en funci�n de una clave espec�fica.
- orderby ... into: Utilizado con orderby para crear una cl�usula "orderby into".
- join ... into: Utilizado con join para crear una cl�usula "join into".
- join ... on ... equals: Se utiliza para realizar una uni�n con condiciones de igualdad.
- from ... let ... where ...: Combinaci�n de cl�usulas para filtrar y proyectar datos.
- from ... join ... on ... equals ... into ...: Combinaci�n de cl�usulas para realizar una uni�n y crear una cl�usula "into".
- from ... group ... by ... into ...: Combinaci�n de cl�usulas para realizar una agrupaci�n y crear una cl�usula "into".
- into ...: Se utiliza para crear variables temporales en una consulta.
- distinct: Elimina elementos duplicados de la secuencia.
- first: Obtiene el primer elemento de la secuencia.
- last: Obtiene el �ltimo elemento de la secuencia.
- single: Obtiene el �nico elemento de la secuencia que cumple con la condici�n.
- any: Comprueba si alg�n elemento de la secuencia cumple con una condici�n.
- all: Comprueba si todos los elementos de la secuencia cumplen con una condici�n.
- count: Cuenta la cantidad de elementos en la secuencia.
- sum: Calcula la suma de los valores de la secuencia.
- average: Calcula el promedio de los valores de la secuencia.
- min: Obtiene el valor m�nimo de la secuencia.
- max: Obtiene el valor m�ximo de la secuencia.
- skip: Omite un n�mero especificado de elementos en la secuencia.
- take: Toma un n�mero especificado de elementos de la secuencia.
- concat: Combina dos secuencias en una sola.
- reverse: Invierte el orden de los elementos en la secuencia.
- union: Combina dos secuencias eliminando duplicados.
- intersect: Obtiene los elementos comunes entre dos secuencias.
- except: Obtiene los elementos que est�n en una secuencia pero no en la otra.

## Keywords & extension method
"average" keyword and other keywords might not exist, only the extension method.
TODO: categorice the keywords/methods in groups like: aggregation, grouping, basic...
```
from			-
in				-
where			.Where()
select			.Select()
orderby			.OrderBy(), .OrderByDescending()
ascending		-
descending		-
group			.GroupBy()
by				-
join			.Join()
equals			-
on				-
let				-
into			-
group ... by	.GroupBy()
orderby ... into	-
join ... into		-
join ... on ... equals		.Join()
from ... let ... where ...		-
from ... join ... on ... equals ... into ...		-
into ...		-
distinct		.Distinct()
first			.First(), .FirstOrDefault()
last			.Last(), .LastOrDefault()
single			.Single(), .SingleOrDefault()
any				.Any()
all				.All()
count			.Count()
sum				.Sum()
average			.Average()
min				.Min()
max				.Max()
skip			.Skip()
take			.Take()
concat			.Concat()
reverse			.Reverse()
union			.Union()
intersect		.Intersect()
except			.Except()
```

### LINQ Query example:
```
var newDataStructure =  from "item" in "dataStructure"
						group "item" by "condition" into "groupVariable"
						select "item/groupVariable";
```

## Summary and SQL like syntax vs Extension method

### Using SQL-like syntax (query query):

**Readability and familiarity:**

For people who are more familiar with SQL or who find the SQL-like syntax more readable, the query query may be preferred.

Complex queries: 
In extremely complex queries involving multiple JOIN, GROUP BY operations, subqueries, etc., SQL-like syntax may be easier to follow and maintain.

External database support: 
If you are writing LINQ queries that will be executed against an external database (for example, LINQ to SQL or Entity Framework), SQL-like syntax may be more appropriate as it will translate more directly to SQL.

Team readability requirements: 
On some development teams, you may have coding guidelines that favor SQL-like syntax to maintain a consistent coding style throughout the project.

### Using extension methods in LINQ:

Integration with C# code: 
Extension methods in LINQ integrate more naturally with C# code and are more consistent with the object-oriented programming style. This can make it easier to combine LINQ operations with other C# operations.

Greater flexibility: 
Extension methods in LINQ offer greater flexibility and allow chained operations to be performed on a sequence of data more smoothly. This is useful for simpler queries and filtering and projection operations.

Ease of writing and maintaining: 
In many situations, extension methods in LINQ can be more concise and easier to write and maintain, especially in simple queries and basic operations such as filtering, sorting, and projection.

Support for in-memory collections: 
Extension methods in LINQ work well with in-memory collections, such as lists and arrays, and are particularly useful when working with in-memory data.