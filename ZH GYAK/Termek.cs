using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
	public delegate void ArValtozasDelegate();

    public class Termek
    {
		private int ar;

		public int Ar
		{
			get { return ar; }
			set { ar = value; ArValtozasFigyelo(); }
		}

		public event ArValtozasDelegate ArValtozes;

		protected void ArValtozasFigyelo() 
		{
			ArValtozes?.Invoke();
		}

        public override string ToString()
        {
			return $"{Ar}";
        }
    }
}
