





namespace Helicopter
{
    class Program
    {
        static public Game1 game1 = new Game1();
        private static void Main(string[] args)
        {
            game1.IsFixedTimeStep = true;
            game1.Run();
        }
    }
}
