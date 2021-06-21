using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using Newtonsoft.Json;
namespace SoftwareDesignTextAdventure.scripts
{
    public static class Controller
    {
        static void Main(string[] args)
        {
            List<User> userList = new List<User>();
            User john = new User("john", "1808");
            User max = new User("max", "0802");
            User kai = new User("kai", "1410");
            userList.Add(john);
            userList.Add(max);
            userList.Add(kai);
            string json = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(@"data\UserData.json", json);
            Guest hi = new Guest();
            hi.signIn("kai", "110");
        } 

        static void jsonWriteTest()
        {
            List<Adventure> adventureList = new List<Adventure>();
            Adventure dnd = new Adventure("DnD", 5, 6);
            Adventure scifi = new Adventure("Scifi", 3, 3);
            adventureList.Add(dnd);
            adventureList.Add(scifi);
            string adventureJson = JsonConvert.SerializeObject(adventureList, Formatting.Indented);            
            File.WriteAllText(@"data\AdventureData.json", adventureJson);
        }
    }
}