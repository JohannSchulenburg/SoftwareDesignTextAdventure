using System.Data;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace SoftwareDesignTextAdventure
{
    public class Player
    {
        private int[] currentPosition;
        public iUser userPlaying;
        public Player(iUser user){
            this.userPlaying = user;
        }
        public void play(Adventure adventure){
            int timesMoved = 0;
            Controller.instance.clear(500);
            this.currentPosition = adventure.startingPoint;
            adventure.read(this.currentPosition);
            bool end = true;
            while(end){
                Controller.instance.clear(2000);
                Console.WriteLine("Please choose a direction or write 'back' to get back to the adventure screen");
                String direction = Console.ReadLine();
                bool isMoving;
                if(!direction.Equals("back")){
                    isMoving = move(adventure, direction);
                    if(isMoving){
                        adventure.read(currentPosition);
                        timesMoved+=1;
                    }
                    else{
                        Console.WriteLine("You cant go there!");
                    }
                }
                else{
                    end = false;
                }
            }
            adventure.statistic.timesMovedList.Add(timesMoved);
            if(!DataAccess.updateAdventure(adventure)){
                Console.WriteLine("Something went wrong updating the adventure data.");
            }
        }
        private bool move(Adventure adventure, String direction){
            switch (direction)
            {
                case "N":
                    if(currentPosition[1]-1>=0){
                        currentPosition[1]-=1;
                        return true;
                    }
                    return false;
                case "E":
                    if(currentPosition[0]+1<adventure.size[0]){
                        currentPosition[0]+=1;
                        return true;
                    }
                    return false;
                case "S":
                    if(currentPosition[1]+1<adventure.size[1]){
                        currentPosition[1]+=1;
                        return true;
                    }
                    return false;
                case "W":
                    if(currentPosition[0]-1>=0){
                        currentPosition[0]-=1;
                        return true;
                    }
                    return false;         
                default:
                    return false;
            }
            
        }

        
    }
}