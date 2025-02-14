using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FajlBeolvasas
{
	internal class Karakter
	{
		private string nev;
		private int ero;
		private int eletero;
		private int szint;

		public Karakter(string nev, int ero, int eletero, int szint)
		{
			this.nev = nev;
			this.ero = ero;
			this.eletero = eletero;
			this.szint = szint;
		}

		public string Nev { get => nev; set => nev = value; }
		public int Ero { get => ero; set => ero = value; }
		public int Eletero { get => eletero; set => eletero = value; }
		public int Szint { get => szint; set => szint = value; }













		public override string? ToString()
		{
			return $"Név: {nev} Szint :  {Szint}  Élet : {eletero} Ero : {ero}";
		}
	}
}
