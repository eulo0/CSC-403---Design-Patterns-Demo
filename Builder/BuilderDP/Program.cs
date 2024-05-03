using System;

namespace DPBuilder
{
    class Builder
    {
        /// <summary>
        /// creates a director (cookbook), creates objects (cookies) using the director (which uses the builder CookieRecipe)
        /// and then performs function calls specific to the object
        /// </summary>
        static void Main()
        {
            CookBook cookbook = new CookBook();
            Cookie[] batch = new Cookie[2];
  
            batch[0] = cookbook.BakeChocolateChip("small");
            batch[1] = cookbook.BakeOatmealRaisin("large");

            foreach (Cookie cookie in batch)
            {
                cookie.ShowCookie();
            }

            batch[0].Eat();
            batch[0].ShowBitesRemaining();

            batch[1].Eat();
            batch[1].Eat();
            batch[1].ShowBitesRemaining();
            batch[1].Eat();
            batch[1].ShowBitesRemaining();
        }
    }

    /// <summary>
    /// Concrete Builder for the class Cookie. There was no need to create an abstract 
    /// builder for this specific implementation since we are only concerned with creating only
    /// one type of product (Cookie).
    /// </summary>
    class CookieRecipe
    {
        // mirrors Cookie's attributes with the exception of having setters
        public string? Name { get; set; }
        public string? Size { get; set; }
        public string? Topping { get; set; }
        public string? Shape { get; set; }

        public Cookie Bake()
        {
            // if the parameters for cookie aren't set yet, throw an error
            if (Name == null || Size == null || Topping == null || Shape == null)
            {
                throw new InvalidOperationException("Cookie is not ready to be baked yet...");
            }
            // otherwise return a cookie
            else {
                return new Cookie(Name, Size, Topping, Shape);
            }
        }
    }

    /// <summary>
    /// The Product. Once a Cookie is made, it has to be served. It must not
    /// have any of its attributes change (other than bitesLeft), which can only be
    /// changed from the Eat() function.
    /// </summary>
    class Cookie
    {
        private string Name { get; }
        private string Size { get; }
        private string Topping { get; }
        private string Shape { get; }
        private int BitesLeft;

        public Cookie(string name, string size, string topping, string shape)
        {
            Name = name;
            Size = size;
            Topping = topping;
            Shape = shape;
            SetBitesFromSize(size);
        }

        /* gets called in the constructor. sets BitesLeft depending on the Size of the cookie which
           is a parameter in the constructor */
        private void SetBitesFromSize(string size)
        {
            switch (size)
            {
                case "small":
                    BitesLeft = 1;
                    break;
                case "medium":
                    BitesLeft = 2;
                    break;
                case "large":
                    BitesLeft = 3;
                    break;
                default:
                    Console.WriteLine("Invalid size chosen.");
                    break;
            }
        }

        // takes a Bite off of the cookie
        public void Eat()
        {
            if (BitesLeft > 0)
            {
                BitesLeft--;
                Console.WriteLine($"You've taken a bite out of {Name}!");
            }
        }

        // prints out how many Bites are left 
        public void ShowBitesRemaining()
        {
            Console.WriteLine($"{Name} has {BitesLeft} bites remaining.");
        }

        // prints a statement that shows the attributes of the cookie other than BitesLeft
        public void ShowCookie()
        {
            if (BitesLeft > 0)
            {
                Console.WriteLine($"{Name} is a {Size} {Shape} shaped cookie with {Topping}.");
            }
        }
    }

    /// <summary>
    /// The Director. It serves to store "blueprints" for creating products that have a specific 
    /// configuration. However, in this case, size may vary hence why its a parameter for each of 
    /// the functions for creating a specific type of cookie.
    /// </summary>
    class CookBook
    {   
        // contains the builder
        private CookieRecipe recipe = new CookieRecipe();

        // for creating chocolate chip cookies
        public Cookie BakeChocolateChip(string size)
        {
            string concatName = size + " chocolate chip cookie";
            recipe.Name = concatName;
            recipe.Size = size;
            recipe.Topping = "chocolate chips";
            recipe.Shape = "round";
            return recipe.Bake();
        }

        // for creating oatmeal raisin cookies
        public Cookie BakeOatmealRaisin(string size)
        {
            string concatName = size + " oatmeal raisin cookie";
            recipe.Name = concatName;
            recipe.Size = size;
            recipe.Topping = "oatmeal raisins";
            recipe.Shape = "square";
            return recipe.Bake();
        }
    }
}
