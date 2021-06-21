

namespace SoftwareDesignTextAdventure
{
    
    public class Adventure
    {
        public string title {get; set;}
        public string[,] map {get; set;}
        public string createdBy;

        public Adventure(){}
        public Adventure(string title, int x, int y){
            this.title = title;
            this.map = new string[x,y];
        }
        

    }
}