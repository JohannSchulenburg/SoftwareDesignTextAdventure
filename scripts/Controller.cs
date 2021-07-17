using System.Threading;
using System;


namespace SoftwareDesignTextAdventure
{
    public class Controller
    {
        public static Controller instance;
        public static iUser currentUser;
        static void Main(string[] args)
        {
            initialize();
            instance.mainMenu();
        }
        private static void initialize(){
            instance = new Controller();
            currentUser = new NullUser();
        }
        private void mainMenu(){
            clear(2000);
            Console.WriteLine("Main Menu                                            Current User: "+currentUser.username);
            Console.WriteLine();
            Console.WriteLine("Would you like to: 'sign in', 'sign up', 'search adventure' or 'show adventures'?");
            Console.WriteLine("Note: 'create adventure' is reserved for members only");
            Console.WriteLine();
            String optionChosen = Console.ReadLine();
            clear(1000);
            switch (optionChosen)
            {
                case "sign in":
                    currentUser.signIn();
                    break;
                case "sign up":
                    currentUser.signUp();
                    break;
                case "search adventure":
                    currentUser.searchAdventure();
                    break;
                case "show adventures":
                    currentUser.showAdventures();
                    break;
                case "create adventure":
                    currentUser.createAdventure();
                    break;
                default:
                    return;
            }
            instance.mainMenu();
        }
        public void clear(int number){
            Thread.Sleep(number);
            Console.Clear();
        }
    }
}