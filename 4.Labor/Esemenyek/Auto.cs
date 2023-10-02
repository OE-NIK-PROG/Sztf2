using System;
namespace Esemenyek
{
	public class Auto
	{
		public int Uzemanyag { get; private set; }
		public int KerekAllapot { get; private set; }

		public Auto(int uzemanyag = 100, int kerekallapot = 100)
		{
			this.Uzemanyag = uzemanyag;
			this.KerekAllapot = kerekallapot;
		}

        // 1. eset
        public HelyzetJelentesEventHandler helyzet;

		// 2. eset
        private HelyzetJelentesEventHandler helyzetek; 

		public void Feliratkozas(HelyzetJelentesEventHandler metodus)
		{
			helyzetek += metodus;
		}

        public void Leiratkozas(HelyzetJelentesEventHandler metodus)
        {
            helyzetek -= metodus;
        }

		public void Verseny()
		{
			if(Uzemanyag > 0)
			{
				this.Uzemanyag -= 10;
                this.KerekAllapot -= 15;

                // visszajelzés...
                helyzetek(this.Uzemanyag, this.KerekAllapot);
                // Itt hívom meg a "gyűjtőt", amiben minden metódus benne van
                //      és ahogy a sima delegáltas példában láttuk, 
                //      minden metódust meghív az adott paraméterrel!
            }
        }


		public void Kerekcsere()
		{
			this.KerekAllapot = 100;
            Console.WriteLine("------------------");
            Console.WriteLine("KEREKCSERE TORTENT");
			Console.WriteLine("------------------");
		}
    }
}

