using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Main Method
public class Program {
	public static void Main(String[] args) {

		double test = MiEnum.VALOR2.Valor;
		double prueba = test + 2;
		Console.WriteLine(prueba);

		double pi = Math.PI;
		Console.WriteLine(pi+pi);

		double valorDouble = MiEnum.GetValue();

		Console.WriteLine(valorDouble);
	}

}
