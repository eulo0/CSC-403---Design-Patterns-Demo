using System;
using System.Collections.Generic;


namespace DPFactory
{
    
    class Factory
    {
        /// <summary>
        /// Calls constructor and displays enemy types and their traits.
        /// </summary>
        static void Main()
        {
            Enemy[] enemies = new Enemy[2];
            enemies[0] = new Boss();
            enemies[1] = new Grunt();

            foreach (Enemy enemy in enemies)
            {
                Console.WriteLine("\n" + enemy.GetType().Name + ":");
                foreach (Trait trait in enemy.Traits)
                {
                    Console.WriteLine(" " + trait.GetType().Name);
                }
            }
        }
    }
    

    /// <summary>
    /// Abstract Product class.
    /// Traits for the enemies.
    /// </summary>
    abstract class Trait
    {
    }


    /// <summary>
    /// ConcreteProduct class.  
    /// Matches the player's level with a level of variation between 1-2.
    /// </summary>
    class Common : Trait
    {
    }


    /// <summary>
    /// ConcreteProduct class
    /// Equips the target with a random variation of basic level equipment.
    /// </summary>
    class Basic_Loadout : Trait
    {
    }


    /// <summary>
    /// ConcreteProduct class.
    /// The amount of experience the enemy drops when defeated by the player.
    /// </summary>
    class Experience : Trait
    {
    }


    /// <summary>
    /// ConcreteProduct class.
    /// Makes the enemy 5-10 levels above the players character. Makes the enemy more difficult to defeat.
    /// </summary>
    class Unique : Trait
    {
    }


    /// <summary>
    /// ConcreteProduct class.
    /// There is a maximum amount of these enemies that can spawn.
    /// </summary>

    class Spawn_Limit : Trait
    { 
    }


    /// <summary>
    /// ConcreteProduct class
    /// Enemy will have a random legendary weapon drop when defeated.
    /// </summary>
    class Legendary_Weapon : Trait
    {
    }


    /// <summary>
    /// ConcreteProduct class.
    /// Adds health regeneration to the target.
    /// </summary>
    class Health_Regeneration : Trait
    {
    }

    
    /// <summary>
    /// ConcreteProduct class.
    /// Adds a special attack to the enemy.
    /// </summary>
    class Special_Attacks : Trait
    {
    }
    

    /// <summary>
    /// Abstract Creator class.
    /// </summary>
    abstract class Enemy
    {
        private List<Trait> _traits = new List<Trait>();
        // Constructor calls abstract Factory method

        public Enemy()
        {
            this.CreateTrait();
        }
        public List<Trait> Traits
        {
            get { return _traits; }
        }

        // Factory Method
        public abstract void CreateTrait();
    }
    

    /// <summary>
    /// ConcreteCreator class
    /// </summary>
    class Grunt : Enemy
    {
        // Factory Method implementation
        public override void CreateTrait()
        {
            Traits.Add(new Common());
            Traits.Add(new Basic_Loadout());
            Traits.Add(new Experience());
        }
    }
    

    /// <summary>
    /// ConcreteCreator class
    /// </summary>
    class Boss : Enemy
    {
        public override void CreateTrait()
        {
            Traits.Add(new Unique());
            Traits.Add(new Spawn_Limit());
            Traits.Add(new Legendary_Weapon());
            Traits.Add(new Health_Regeneration());
            Traits.Add(new Special_Attacks());
        }
    }
}