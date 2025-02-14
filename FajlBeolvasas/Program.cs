﻿using System.Globalization;
using System.Reflection.Metadata;

namespace FajlBeolvasas
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];

			Beolvasas("karakterek.txt", karakterek);
			Eletlegtobb(karakterek);
			AtlagSzint(karakterek);
				//RendezoErosseg(karakterek);
			//Nagyobbe50nel(karakterek);
			KarakterStats(karakterek);





		}

		static void Beolvasas(string fajlnev, List<Karakter> karakterek)
		{
			StreamReader sr = new(fajlnev);
			string[] sorok = File.ReadAllLines(fajlnev);



			sr.ReadLine();




			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				Karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
		}

		static void Eletlegtobb(List<Karakter> karakterek)
		{



			int max = 0;
			Karakter legtobbEletero = null;
			foreach (var item in karakterek)
			{
				if (item.Eletero > max)
				{
					max = item.Eletero;
					legtobbEletero = item;
				}
			}
			Console.WriteLine("Legtöbb életű karakter:");
			Console.WriteLine($"Legtöbb élet: {legtobbEletero}");

		}
		static void AtlagSzint(List<Karakter> karakterek)
		{
			int osszeg = 0;
			foreach (var item in karakterek)
			{
				osszeg += item.Szint;
			}
			double atlag = (double)osszeg / karakterek.Count;
			Console.WriteLine($"Átlag szint: {atlag}");
		}
		static void RendezoErosseg(List<Karakter> karakterek)
		{
			karakterek.Sort((x, y) => x.Ero.CompareTo(y.Ero));
			Console.WriteLine("Erő szerint rendezve:");
			foreach (var item in karakterek)
			{
				Console.WriteLine(item);
			}
		}
		static void Nagyobbe50nel(List<Karakter> karakterek)
		{
			Console.WriteLine("50-nél nagyobb életű karakterek:");
			foreach (var item in karakterek)
			{
				if (item.Eletero > 50)
				{
					Console.WriteLine(item);
				}
			}
		}
		static void KarakterStats(List<Karakter> karakterek)
		{
            Console.WriteLine("");
			Console.WriteLine("Karakterek statisztikája:");
			Console.WriteLine("Név\tErő\tÉlet\tSzint");
			foreach (var item in karakterek)
			{
				Console.WriteLine(item);
				Console.WriteLine($"{item.Nev}\t{item.Ero}\t{item.Eletero}\t{item.Szint}");

			}

        }


	} 
}
