using System;

namespace SoftwareDesignTextAdventure
{
    public class Adventure
    {
        public string title;
        public string[,] map;
        public int[] startingPoint;
        public string createdBy;
        public int[] size;
        public Statistic statistic;

        public Adventure(string title, string[,] map, string createdBy, int[] startingPoint, int[] size){
            this.title = title;
            this.map = map;
            this.createdBy = createdBy;
            this.startingPoint = startingPoint;
            this.size = size;
            this.statistic = new Statistic();
        }
        public void read(int[] position){
            Console.WriteLine(this.map[position[0],position[1]]);
        }
    }
}