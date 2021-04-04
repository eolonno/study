using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
      
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            Console.WriteLine("User1:");
            Random rnd = new Random();
            int caseSwitch = rnd.Next(1, 4);
            Generator(caseSwitch); 

            Console.ReadLine();
        }

        public static void Generator(int caseSwitch)
        {
            switch (caseSwitch)
            {
                case 1:
                    {
                        Hero hero = new Hero(new IronFactory());
                        hero.Congratulate();
                        hero.ShowWeapon();
                    }
                    break;

                case 2:
                    {
                        Hero hero = new Hero(new SpiderFactory());
                        hero.Congratulate();
                        hero.ShowWeapon();
                    }
                    break;

                case 3:
                    {
                        Hero hero = new Hero(new ThorFactory());
                        hero.Congratulate();
                        hero.ShowWeapon();
                    }
                    break;

                case 4:
                    {
                        Hero hero = new Hero(new StrangeFactory());
                        hero.Congratulate();
                        hero.ShowWeapon();
                    }
                    break;
                default:
                    Console.WriteLine("  Fail");
                    break;
            }
        }
    }

    abstract class Weapon
    {
        public abstract void Wfunc();
    }

    abstract class Congrats
    {
        public abstract void Cfunc();
    }

    class Costume : Weapon
    {
        public override void Wfunc()
        {
            Console.WriteLine("  Weapon: costume and brain.");
        }
    }

    class Hammer : Weapon
    {
        public override void Wfunc()
        {
            Console.WriteLine("  Weapon: hammer.");
        }
    }

    class Magic : Weapon
    {
        public override void Wfunc()
        {
            Console.WriteLine("  Weapon: magic.");
        }
    }

    class Web : Weapon
    {
        public override void Wfunc()
        {
            Console.WriteLine("  Weapon: web.");
        }
    }

    class Iron : Congrats
    {
        public override void Cfunc()
        {
            Console.WriteLine("  Congratulations! Your character is genius, billionaire, " +
                "playboy, philanthropist - Iron Man.");
        }
    }

    class Thor : Congrats
    {
        public override void Cfunc()
        {
            Console.WriteLine("  Congratulations! Your character is Thor. But, pls, stop drinking!");
        }
    }

    class Spider : Congrats
    {
        public override void Cfunc()
        {
            Console.WriteLine("  Congratulations! Your character is Spider Man. Be careful, boy.");
        }
    }

    class Strange : Congrats
    {
        public override void Cfunc()
        {
            Console.WriteLine("  Congratulations! Your character is Dr. Strange. Your cloak is near!");
        }
    }

    abstract class HeroFactory
    {
        public abstract Congrats CreateCongrats();
        public abstract Weapon CreateWeapon();
    }

    class IronFactory : HeroFactory
    {
        public override Congrats CreateCongrats()
        {
            return new Iron();
        }

        public override Weapon CreateWeapon()
        {
            return new Costume();
        }
    }

    class ThorFactory : HeroFactory
    {
        public override Congrats CreateCongrats()
        {
            return new Thor();
        }

        public override Weapon CreateWeapon()
        {
            return new Hammer();
        }
    }

    class SpiderFactory : HeroFactory
    {
        public override Congrats CreateCongrats()
        {
            return new Spider();
        }

        public override Weapon CreateWeapon()
        {
            return new Web();
        }
    }

    class StrangeFactory : HeroFactory
    {
        public override Congrats CreateCongrats()
        {
            return new Strange();
        }

        public override Weapon CreateWeapon()
        {
            return new Magic();
        }
    }

    class Hero
    {
        private Weapon weapon;
        private Congrats congrats;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            congrats = factory.CreateCongrats();
        }
        public void Congratulate()
        {
            congrats.Cfunc();
        }
        public void ShowWeapon()
        {
            weapon.Wfunc();
        }
    }

}
