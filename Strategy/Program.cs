using System;
using System.Collections.Generic;


namespace DPStrategy
{
    /// <summary>
    /// Strategy Design Pattern
    /// </summary>
    public class Strategy
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the first number:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter an operation(add, subtract, multiply):");
            string op = Console.ReadLine();

            Context Calculate;

            switch (op)
            {
                case "add":
                    Calculate = new Context(new AddStrategy());
                    break;

                case "subtract":
                    Calculate = new Context(new SubStrategy());
                    break;

                case "multiply":
                    Calculate = new Context(new MulStrategy());
                    break;

                default:
                    Console.WriteLine("Invalid operation. Please enter add, subtract, or multiply.");
                    return;
            }

            int result = Calculate.ExecuteCalc(a, b);
            Console.WriteLine("Answer: " + result);
        }
    }
}

/// <summary>
/// Strategy Interface
/// </summary>
public abstract class InterfaceStrategy
{
    public abstract int Calc(int a, int b);
}

/// <summary>
/// Context class
/// </summary>
public class Context
{
    private InterfaceStrategy Istrategy;

    public Context(InterfaceStrategy strategy)
    {
        this.Istrategy = strategy;
    }

    public int ExecuteCalc(int a, int b)
    {
        return Istrategy.Calc(a, b);
    }
}

/// <summary>
/// Addition strategy
/// </summary>
public class AddStrategy : InterfaceStrategy
{
    public override int Calc(int a, int b)
    {
        return a + b;
    }
}

/// <summary>
/// subtraction strategy
/// </summary>
public class SubStrategy : InterfaceStrategy
{
    public override int Calc(int a, int b)
    {
        return a - b;
    }
}

/// <summary>
/// multiplication strategy
/// </summary>
public class MulStrategy : InterfaceStrategy
{
    public override int Calc(int a, int b)
    {
        return a * b;
    }
}
