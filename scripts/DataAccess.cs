
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace SoftwareDesignTextAdventure
{
    public static class DataAccess
    {
        public static void addUser(User user){ // TODO: cant create User if username exists
            String jsonData = System.IO.File.ReadAllText("./data/UserData.json");
            User[] userArray = JsonConvert.DeserializeObject<User[]>(jsonData) ?? new User[0]; //?? = "wenns schief geht..."
            List<User> userList = new List<User>(userArray);
            User addNewUser = user; 
            userList.Add(addNewUser);
            jsonData = JsonConvert.SerializeObject(userList,Formatting.Indented);
            System.IO.File.WriteAllText("./data/UserData.json", jsonData);
        }
        public static iUser getUser(String iUsername){
            string jsonData = File.ReadAllText(@"data\UserData.json");
            List<User> userList = new List<User>();
            userList = JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
            foreach(User user in userList){
                if(user.username.Equals(iUsername)){
                    return user;
                }
            }
            return new NullUser();
        }
        public static Adventure getAdventure(String title){
            string jsonData = File.ReadAllText(@"data\AdventureData.json");
            List<Adventure> adventureList = JsonConvert.DeserializeObject<List<Adventure>>(jsonData);
            foreach(Adventure adv in adventureList){
                if(adv.title.Equals(title)){
                    return adv;
                }
            }
            return new Adventure();
        }
        public static List<Adventure> getAdventureList(){
            string allAdventureText = File.ReadAllText(@"data\AdventureData.json");
            return JsonConvert.DeserializeObject<List<Adventure>>(allAdventureText);
        }
        public static void addAdventure(Adventure adventure){
            String jsonData = System.IO.File.ReadAllText("./data/AdventureData.json");
            List<Adventure> adventureList = JsonConvert.DeserializeObject<List<Adventure>>(jsonData);
            adventureList.Add(adventure);
            jsonData = JsonConvert.SerializeObject(adventureList,Formatting.Indented);
            System.IO.File.WriteAllText("./data/AdventureData.json", jsonData);
        }
        public static String createUUID(){
            Guid uuid = Guid.NewGuid();
            string uuidAsString = uuid.ToString();
            return uuidAsString;
        }
    }
}