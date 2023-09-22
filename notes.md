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
- in: Se utiliza en cláusulas from para especificar las variables de rango.
- where: Filtra los elementos de la secuencia basándose en una condición.
- select: Proyecta (selecciona) los elementos de la secuencia en un nuevo formato.
- orderby: Ordena los elementos de la secuencia en función de un criterio específico.
- ascending: Utilizado con orderby para ordenar en orden ascendente.
- descending: Utilizado con orderby para ordenar en orden descendente.
- group: Agrupa elementos de la secuencia basándose en una clave específica.
- by: Se utiliza con group para especificar la clave de agrupación.
- join: Realiza una unión entre dos secuencias basándose en una condición específica.
- equals: Se utiliza con join para especificar la condición de igualdad.
- on: Se utiliza con join para especificar la relación entre las dos secuencias.
- let: Permite definir variables locales en una consulta.
- into: Se utiliza con join para crear una cláusula "join into".
- group ... by: Realiza una agrupación de elementos en función de una clave específica.
- orderby ... into: Utilizado con orderby para crear una cláusula "orderby into".
- join ... into: Utilizado con join para crear una cláusula "join into".
- join ... on ... equals: Se utiliza para realizar una unión con condiciones de igualdad.
- from ... let ... where ...: Combinación de cláusulas para filtrar y proyectar datos.
- from ... join ... on ... equals ... into ...: Combinación de cláusulas para realizar una unión y crear una cláusula "into".
- from ... group ... by ... into ...: Combinación de cláusulas para realizar una agrupación y crear una cláusula "into".
- into ...: Se utiliza para crear variables temporales en una consulta.
- distinct: Elimina elementos duplicados de la secuencia.
- first: Obtiene el primer elemento de la secuencia.
- last: Obtiene el último elemento de la secuencia.
- single: Obtiene el único elemento de la secuencia que cumple con la condición.
- any: Comprueba si algún elemento de la secuencia cumple con una condición.
- all: Comprueba si todos los elementos de la secuencia cumplen con una condición.
- count: Cuenta la cantidad de elementos en la secuencia.
- sum: Calcula la suma de los valores de la secuencia.
- average: Calcula el promedio de los valores de la secuencia.
- min: Obtiene el valor mínimo de la secuencia.
- max: Obtiene el valor máximo de la secuencia.
- skip: Omite un número especificado de elementos en la secuencia.
- take: Toma un número especificado de elementos de la secuencia.
- concat: Combina dos secuencias en una sola.
- reverse: Invierte el orden de los elementos en la secuencia.
- union: Combina dos secuencias eliminando duplicados.
- intersect: Obtiene los elementos comunes entre dos secuencias.
- except: Obtiene los elementos que están en una secuencia pero no en la otra.

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