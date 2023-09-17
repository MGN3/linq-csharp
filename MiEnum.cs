using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Trying to emulate enum behaviour java-like
/// 
/// Adding some constants
/// </summary>
public class MiEnum {
	public static readonly MiEnum VALOR1 = new MiEnum(1.0);
	public static readonly MiEnum VALOR2 = new MiEnum(2.5);
	public static readonly MiEnum VALOR3 = new MiEnum(3.14);

	public double Valor { get; private set; }
	
	private static readonly double Value = 1.23456789;
	private MiEnum(double valor) {
		Valor = valor;
	}

	public static double GetValue() {
		return Value;
	}
}
