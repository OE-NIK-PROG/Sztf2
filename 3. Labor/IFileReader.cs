using System;
using ConsoleApp1;

namespace KlonDatabase
{
	public interface IFileReader
	{
		public int LinesDB();
        public Rank ReadRankFiles(string rankNumber);
        public Clone[] ReadFile();
	}
}