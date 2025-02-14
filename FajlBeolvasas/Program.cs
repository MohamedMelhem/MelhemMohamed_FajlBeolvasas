using System.Globalization;
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
			//KarakterStats(karakterek);
			//CSVbeRako(karakterek);

			//Legjobb3Karakter(karakterek);
			//CsataVerseny(karakterek);
			








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

		//static void CSVbeRako(List<Karakter> karakterek)
		//{
		//	StreamWriter sw = new("kimenet.csv");
		//	sw.WriteLine("Név;Erő;Élet;Szint");
		//	foreach (var item in karakterek)
		//	{
		//		sw.WriteLine($"{item.Nev};{item.Ero};{item.Eletero};{item.Szint}");
		//	}
		//	sw.Close();
		//}
		static void Legjobb3Karakter(List<Karakter> karakterek)
		{
			Console.WriteLine("Legjobb 3 karakter:");
			karakterek.Sort((x, y) => y.Ero.CompareTo(x.Ero));
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine(karakterek[i]);
			}
		}



		static void KarakterRangsorEleteroEsErosseg(List<Karakter> karakterek)
		{
			Console.WriteLine("Karakterek rangsora életerő és erősség szerint:");
			karakterek.Sort((x, y) => x.Eletero.CompareTo(y.Eletero));
			karakterek.Sort((x, y) => x.Ero.CompareTo(y.Ero));
			foreach (var item in karakterek)
			{
				Console.WriteLine(item);
			}
		}
		static void CsataVerseny(List<Karakter> karakterek)
		{
			Random r = new();
			int karakter1 = r.Next(0, karakterek.Count);
			int karakter2 = r.Next(0, karakterek.Count);
			Console.WriteLine("Csata: ELINDULT!!!!");
			while (karakter1 == karakter2)
			{
				karakter2 = r.Next(0, karakterek.Count);
			}
			Console.WriteLine("Csata:");
			Console.WriteLine($"{karakterek[karakter1]} vs {karakterek[karakter2]}");
			if (karakterek[karakter1].Ero > karakterek[karakter2].Ero)
			{
				Console.WriteLine($"{karakterek[karakter1].Nev} nyert");
			}
			else if (karakterek[karakter1].Ero < karakterek[karakter2].Ero)
			{
				Console.WriteLine($"{karakterek[karakter2].Nev} nyert");
			}
			else
			{
				Console.WriteLine("Döntetlen");
			}
		}



	} 
}
