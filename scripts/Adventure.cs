using System;

namespace SoftwareDesignTextAdventure
{
    public class Adventure
    {
        public string title {get; set;}
        public string[,] map {get; set;}
        public int[] startingPoint;
        public string createdBy;

        public Adventure(){}
        public Adventure(string title, int x, int y){
            this.title = title;
            this.map = new string[x,y];
        }
        public Adventure(string title, string[,] map, string createdBy, int[] startingPoint){
            this.title = title;
            this.map = map;
            this.createdBy = createdBy;
            this.startingPoint = startingPoint;
        }
        public void read(int[] position){
            //Console.WriteLine(this.title);
            Console.WriteLine(this.map[position[0],position[1]]);
        }
    }
}