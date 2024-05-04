using llblbl;
using System;

class Program
{
	static string ToStringWithIntPart(MyFrac f)
	{
		string minus = "";
		if(f.nom < 0) minus = "-";
		long intPart = Math.Abs(f.nom) / f.denom;
		long nom = Math.Abs(f.nom) - intPart * f.denom;
		//if (nom == 0) return $"{minus}({intPart})";
		return $"{minus}({intPart}+{new MyFrac(nom, f.denom)})";
	}
	static double DoubleValue(MyFrac f)
	{
		return (double)f.nom/f.denom;
	}
	static MyFrac Plus(MyFrac f1, MyFrac f2)
	{
		return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom,
						  f1.denom * f2.denom);
	}
	static MyFrac Minus(MyFrac f1, MyFrac f2)
	{
		return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, 
						  f1.denom * f2.denom);

	}
	static MyFrac Multiply(MyFrac f1, MyFrac f2)
	{
		return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
	}
	static MyFrac Divide(MyFrac f1, MyFrac f2)
	{
		return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
	}
	static MyFrac CalcExpr1(int n)
	{
		MyFrac fr = new(0, 1);
		for (long i = 1; i <= n; i++) 
		{
			fr = Plus(fr, new MyFrac(1, i * (i + 1)));
		}
		return fr;
	}
	static MyFrac CalcExpr2(int n)
	{
		if (n == 1) return new MyFrac(1,1);
		MyFrac fr = new(1, 1);		
		for(long i = 2; i <= n; i++)
		{
			fr = Multiply(fr, Minus(new MyFrac(1, 1), new MyFrac(1, i * i)));
		}
		return fr;
	}
	static void Main(string[] args)
	{
		
		Console.WriteLine("Введіть чисельник і знаменник першого дробу: ");
		long[] dataFrac1 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
		long nom1 = dataFrac1[0];
		long denom1 = dataFrac1[1];

		Console.WriteLine("Введіть чисельник і знаменник другого дробу: ");
		long[] dataFrac2 = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
		long nom2 = dataFrac2[0];
		long denom2 = dataFrac2[1];
		
		MyFrac fr1 = new(nom1, denom1);
		MyFrac fr2 = new(nom2, denom2);
		
		Console.WriteLine("1 - ToStringWithIntPart для першого дробу\n" +
						"2 - DoubleValue для першого дробу\n" +
						"3 - Plus\n" +
						"4 - Minus\n" +
						"5 - Multiply\n" +
						"6 - Divide\n" +
						"7 - CalcExpr1\n" +
						"8 - CalcExpr2");
		
		int choice = int.Parse(Console.ReadLine());
		switch (choice)
		{
			case 1:
				Console.WriteLine(ToStringWithIntPart(fr1));
				break;
			case 2:
				Console.WriteLine(DoubleValue(fr1));
				break;
			case 3:
				Console.WriteLine(Plus(fr1, fr2));
				break;
			case 4:
				Console.WriteLine(Minus(fr1, fr2));
				break;
			case 5:
				Console.WriteLine(Multiply(fr1, fr2));
				break;
			case 6:
				Console.WriteLine(Divide(fr1, fr2));
				break;
			case 7:
				{
					Console.WriteLine("Введіть n");
					int n = int.Parse(Console.ReadLine());
					MyFrac ce1 = CalcExpr1(n);
					Console.WriteLine($"Дріб: {ce1}");
					Console.WriteLine($"Дійсне значення: {DoubleValue(ce1)}");
					Console.WriteLine($"За формулою: {n / (n + 1.0)}");
					break;
				}
			case 8:
				{
					Console.WriteLine("Введіть n");
					int n = int.Parse(Console.ReadLine());
					MyFrac ce2 = CalcExpr2(n);
					Console.WriteLine($"Дріб: {ce2}");
					Console.WriteLine($"Дійсне значення: {DoubleValue(ce2)}");
					Console.WriteLine($"За формулою: {(n + 1.0) / (n * 2)}");
					break;
				}
				
			default:
				Console.WriteLine("Неправильний ввід");
				break;

		}
	}
}