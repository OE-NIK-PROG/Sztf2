using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<IProfile> tree = new BinaryTree<IProfile>();
            IProfile prof1 = new Profile() {
                Level = 3,
                Name = "kata",
                Statistics = new Statistic(4, 13, 23) };

            IProfile prof2 = new Profile()
            {
                Level = 1,
                Name = "Matyika",
                Statistics = new Statistic(2, 7, 40)
            };

            IProfile prof3 = new Profile()
            {
                Level = 2,
                Name = "Endre",
                Statistics = new Statistic(8, 24, 32)
            };

            try
            {
                tree.Insert(prof1.Level, prof1);
                tree.Insert(prof2.Level, prof2);
                tree.Insert(prof3.Level, prof3);

                tree.Enter(BinaryTreeEnterType.inorder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
