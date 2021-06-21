
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace SoftwareDesignTextAdventure
{
    public class Guest
    {
        public Adventure searchAdventure(string title){

            return null;
        }
        public void signIn(string username, string password){
            string allUserText = File.ReadAllText(@"data\UserData.json");
            if(allUserText.Contains(username)){
                List<User> userList = new List<User>();
                userList = JsonConvert.DeserializeObject<List<User>>(allUserText);
                foreach(User user in userList){
                    if(user.username.Equals(username)){
                        if(user.password.Equals(password)){
                            Console.WriteLine("Welcome back, "+username);
                            return;
                        }
                    }
                }
                Console.WriteLine("The given login credentials are incorrect");
            }
        }
        void signUp(string username, string password){
            
        }
        public void play(Adventure adventure){

        }
    }
}