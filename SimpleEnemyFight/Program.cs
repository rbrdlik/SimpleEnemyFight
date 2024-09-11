using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleEnemyFight.Domain;

namespace SimpleEnemyFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Enemy franta = new Enemy("Franta", 5, 30);
            Enemy pepa = new Enemy("Pepa", 5, 40);

            while (franta.IsLiving && pepa.IsLiving)
            {
                franta.Attact(pepa);
                Console.WriteLine(pepa);
                pepa.Attact(franta);
                pepa.Heal(Potions.Small);
                Console.WriteLine(franta);
            }

            Console.ReadKey();
        }
    }
}
