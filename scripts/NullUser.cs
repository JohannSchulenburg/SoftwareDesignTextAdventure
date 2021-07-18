using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace SoftwareDesignTextAdventure
{
    public class NullUser : iUser
    {
        public string username {get; set;}
        public string password {get; set;}
        public string uuid {get; set;}

        public NullUser(){
            this.uuid = "0";
            this.username = "Guest";
            this.password = "";
        }
        public void signIn(){
            Console.WriteLine("Please provide the username and password to your account");
            Console.Write("Username: ");
            String username = Console.ReadLine();
            Console.Write("Password: ");
            String password = Console.ReadLine();
            
            iUser iuser = DataAccess.getUser(username);

            if(iuser.GetType().ToString().Equals("SoftwareDesignTextAdventure.NullUser")){
                Console.WriteLine("Wrong credentials.");
                return;
            }
            else{
                User user = (User) DataAccess.getUser(username);
                if(user.password == password){
                            Console.WriteLine("Welcome back, "+username);
                            Controller.currentUser = user;
                            Controller.currentUser.username = user.username;
                            Controller.currentUser.password = user.password;
                            Controller.currentUser.uuid = user.uuid;
                            return;
                }
            }
        }
        public void signUp(){
            bool wrongInput = true;
            while(wrongInput){
                wrongInput = false;
                Console.WriteLine("Please provide a username and password.");
                Console.WriteLine("The username and password need to have at least 8-15 characters and may only include digits and characters of the english alphabet.");
                Console.Write("Username: ");
                String username = Console.ReadLine();
                Console.Write("Password: ");
                String password = Console.ReadLine();
                Regex regex = new Regex("^[a-zA-Z0-9]{8,15}$");
                if(!regex.IsMatch(username)){
                    Console.WriteLine("Username not valid.");
                    Controller.instance.clear(1000);
                    wrongInput = true;
                }
                if(!regex.IsMatch(password)){
                    Console.WriteLine("Password not valid.");
                    Controller.instance.clear(1000);
                    wrongInput = true;
                }
                if(!wrongInput){
                    User user = new User(username, password);
                    DataAccess.addUser(user);
                    Console.WriteLine("Success!");
                }
            }
        }
        public void searchAdventure(){
            Console.WriteLine("Please provide the title of the adventure");
            Console.Write("Title: ");
            String title = Console.ReadLine();

            Adventure advFound = DataAccess.getAdventure(title);
            if (advFound != null){
                Console.WriteLine("We have found "+advFound.title+" in our database! Do you want to play it?");
                String answer = Console.ReadLine();
                if(answer.Equals("Yes")||answer.Equals("yes")||answer.Equals("Y")||answer.Equals("y")){
                    new Player(this).play(advFound);
                }
            }
            else{
                Console.WriteLine("Unfortunately we have not found "+title);
            }
        }
        public void showAdventures(){
            List<Adventure> adventureList = DataAccess.getAdventureList();
            if(adventureList == null){
                Console.WriteLine("Unfortunately no adventures exist yet. Go make one if you like!");
                return;
            }
            int inner;
            int outer = 0;
            List<Adventure> innerList = new List<Adventure>();
            while(outer<adventureList.Count)
            {
                int modulo = adventureList.Count%5;
                Console.WriteLine();
                if(outer>=adventureList.Count-modulo){
                    for (inner = 0; inner < modulo; inner++)
                    {
                        innerList.Insert(inner, adventureList[(outer+inner)]);
                        Console.WriteLine((inner+1)+". "+innerList[inner].title);
                    }
                }
                else{
                    for (inner = 0; inner < 5; inner++)
                    {
                        innerList.Insert(inner, adventureList[(outer+inner)]);
                        Console.WriteLine((inner+1)+". "+innerList[inner].title);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("You may now choose an adventure by typing its name!");
                Console.WriteLine("'prev' for previous page, 'next' for next page, 'menu' to get back to the Main Menu");
                Console.WriteLine();
                String answer = Console.ReadLine();
                switch (answer)
                {
                    case "prev":
                        if(outer!=0) outer-=5;
                        else Console.WriteLine("Cant go back!");
                        break;
                    case "next":
                        if(outer+5>adventureList.Count) Console.WriteLine("No next page available");
                        else outer+=5;
                        break;
                    case "menu":
                        return;
                    default:
                        break;
                }
                for(int i = 0; i<innerList.Count;i++){
                    if(answer.Equals(innerList[i].title)){
                        new Player(this).play(innerList[i]);
                    }
                }  
                Controller.instance.clear(1000);   
                innerList.Clear();   
            }
        }
        public void createAdventure(){
            Console.WriteLine("You have to be logged in to create an adventure.");
        }
        public void seeStatistic(){
            Console.WriteLine("You have to be logged in to see the statistics of your adventures.");
        }
    }
}