using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnemyFight.Domain
{
    class Entity
    {
        public string Name;
        public int baseDamage;
        public int hp;
        public int maxHp;
    }
    enum Potions
    {
        Small = 5,
        Medium = 7,
        Large = 12,
    }
    enum Weapons
    {
        Dagger = 1,
        Sword = 2,
        Spear = 3,
    }
    class Enemy : Entity
    {
        public Weapons? Weapon { get; set; }

        public Enemy(string name, int baseDamage, int hp, Weapons? weapon = null)
        {
            this.hp = hp;
            this.baseDamage = baseDamage;
            this.Name = name;
            this.Weapon = weapon;
            this.maxHp = hp;
        }
        public void Attact(Entity e)
        {
            int dmg = baseDamage + (int)(Weapon ?? 0);
            if (dmg > e.hp)
            {
                e.hp = 0;
            }
            e.hp -= dmg;
            Console.WriteLine($"{Name} zaútočil na {e.Name} a odebral mu -{dmg}Hp");
        }
        public void Heal(Potions p)
        {
            if (this.hp + (int)p > this.maxHp)
            {
                Console.WriteLine($"{Name} se nemohl vyhealovat potionem, protože má plný počet Hp");
            }
            else
            {
                this.hp += (int)p;
                Console.WriteLine($"{Name} se healnul potionem {p} (+{(int)p}Hp)");
            }
        }
        public bool IsLiving
        {
            get
            {
                return this.hp > 0;
            }
        }
        public override string ToString()
        {
            string info;
            if (!IsLiving)
            {
                return $"{Name} zemřel!";
            }

            if (Weapon == null)
            {
                info = $"{Name} má {hp}Hp a základní damage {baseDamage}";
            }
            else
            {
                info = $"{Name} má {hp}Hp a damage s jeho zbraní {this.Weapon} je {baseDamage + (int)this.Weapon}";
            }
            return info;
        }
    }
}
