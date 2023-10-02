using System;
namespace Esemenyek_Iface
{
	public class Auto
	{
        private IUzemanyagHelyzet uzemanyagHelyzet;

        public int Uzemanyag { get; set; }

        public Auto(int uzemanyag, IUzemanyagHelyzet uh)
        {
            this.Uzemanyag = uzemanyag;
            this.uzemanyagHelyzet = uh;
        }

        public void Verseny()
        {
            if (Uzemanyag > 0)
            {
                this.Uzemanyag -= 10;

                // visszajelzés...
                uzemanyagHelyzet.UzemanyagVisszajelzo(this.Uzemanyag);
            }
        }
    }
}

