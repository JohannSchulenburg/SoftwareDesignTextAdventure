using System;
namespace SoftwareDesignTextAdventure
{
    public class User: NullUser, iUser
    {
        public new string username;
        public new string password;
        public new string uuid;
        
        public User(string username, string password){
            this.uuid = DataAccess.createUUID();
            this.username = username;
            this.password = password;
        }
        public new void signIn(){
            Console.WriteLine("You are already signed in.");
        }
        public new void signUp(){
            Console.WriteLine("You first need to log out.");
        }
        public new void createAdventure(){
            Console.WriteLine("Welcome "+Controller.currentUser.username+"! Here you can create your own adventures!");
            Console.WriteLine("First, you need to give it a title.");
            Console.Write("Title: ");
            String title = Console.ReadLine();
            Controller.instance.clear(500);
            Console.WriteLine("Next step is to define the size of the adventure.");
            Console.WriteLine("Every adventure is rectangular in dimensions. The max in height/width is 5 tiles");
            Console.Write("Width: ");
            String widthString = Console.ReadLine();
            int width;
            Console.Write("Height: ");
            String heightString = Console.ReadLine();
            int height;            
            while(!Int32.TryParse(heightString, out height)||height<1||height>5||
            !Int32.TryParse(widthString, out width)||width<1||width>5){
                Controller.instance.clear(1000);
                Console.WriteLine("Please try again. The chosen dimensions must be numbers between 1 and 5");
                Console.Write("Width: ");
                widthString = Console.ReadLine();
                Console.Write("Height: ");
                heightString = Console.ReadLine();
            }
            Controller.instance.clear(1000);
            Console.WriteLine("Nice! We are ready to go. We will go through your declared tiles from top left to bottom right.");
            Console.WriteLine("Tell the player what they see in each room!");
            String[,] map = new String[width,height];
            for(int y = 0; y<height; y++){
                for(int x = 0; x<width; x++){
                    Console.Write("Room "+(x+1)+" - "+(y+1)+": ");
                    map[x,y] = Console.ReadLine();
                }
            }
            Console.WriteLine("You are almost done! Now you just need to define a starting point. Please give a value for x and y, where Room x - y");
            Console.Write("Starting point X: ");
            String startingXString = Console.ReadLine();
            int startingX;
            Console.Write("Starting point Y: ");
            String startingYString = Console.ReadLine();
            int startingY;
            while(!Int32.TryParse(startingXString, out startingX)||startingX<1||startingX>width+1||
            !Int32.TryParse(startingYString, out startingY)||startingY<1||startingY>height+1){
                Controller.instance.clear(1000);
                Console.WriteLine("Please try again. The position of the starting point has to be within the adventure dimensions");
                Console.Write("Starting point X: ");
                startingXString = Console.ReadLine();
                Console.Write("Starting point Y: ");
                startingYString = Console.ReadLine();
            }
            int[] startingPoint = {startingX-1, startingY-1};
            int[] size = {width, height};
            DataAccess.addAdventure((new Adventure(title, map, Controller.currentUser.username, startingPoint, size)));
            Console.WriteLine("Congratulations! '"+title+"' has been created.");
        }
        public new void seeStatistic(){
            Console.WriteLine("Please provide the title of the adventure");
            Console.Write("Adventure title: ");
            Console.WriteLine();
            String title = Console.ReadLine();
            Adventure adventureFound = DataAccess.getAdventure(title);
            if(adventureFound == null){
                Console.WriteLine("Unfortunately the title given was not found.");
            }
            else if(!adventureFound.createdBy.Equals(this.username)){
                Console.WriteLine("You do not own this adventure.");
            }
            else{
                Controller.instance.clear(500);
                Console.WriteLine("Average time moved: "+adventureFound.statistic.getAverageTimesMoved());
                Console.WriteLine("Times played: "+adventureFound.statistic.getTimesPlayed());
            }
        }
    }
}