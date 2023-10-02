using System;
namespace Esemenyek_Iface
{
    // = = = = = = = = = = = = = = = = = = = = = = = =
    //
    // Sokkal sokkal később, egy másik galaxisban...
    // Csinálunk egy jelző osztályt, ami az interface-t felhasználva fogja majd elvégezni a dolgot.
    //
    // <!> Ez gyakorlatilag csak azért kell, hogy az interface problémáját,
    // miszerint nem lehet belőle példányt létrehozni, ki tudjuk kerülni.
    //
    // = = = = = = = = = = = = = = = = = = = = = = = =
    public class Jelzo: IUzemanyagHelyzet
	{
        public void UzemanyagVisszajelzo(int mennyiseg)
        {
            Console.WriteLine("Az aktuális mennyiség: " + mennyiseg);
        }
    }
}

