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