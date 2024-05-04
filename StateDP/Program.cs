// See https://aka.ms/new-console-template for more information


using stateattempt;
using System.Runtime.InteropServices.Marshalling;

namespace stateattempt
{
    // CONTEXT
    public class Context
    {
        State state;

        public Context(State state)
        {
            this.State = state;
        }


        //state get set
        public State State
        {
            get { return state; }
            set
            {
                state = value;
            }
        }


        //request initialization
        public void Request()
        {
            State.Handle(this);
        }
    }


    //strategy abstract class
    public abstract class State
    {
        public abstract void Handle(Context context);
    }



    //concrete classes
    class GreenLight : State
    {
        public override void Handle(Context context)
        {
            context.State = new YellowLight();
            Console.WriteLine("Green Light");
        }
    }

    class YellowLight : State
    {
        public override void Handle(Context context)
        {
            context.State = new RedLight();
            Console.WriteLine("Yellow Light");
        }
    }

    class RedLight : State
    {
        public override void Handle(Context context)
        {
            context.State = new GreenLight();
            Console.WriteLine("Red Light");
        }
    }



    //program
    class Program
    {
        public static void Main(string[] args)
        {
            var context = new Context(new GreenLight());

            for(int i = 0; i < 6; i++)
            {
                context.Request();
            }
            

            Console.ReadKey();

        }
    }
}
