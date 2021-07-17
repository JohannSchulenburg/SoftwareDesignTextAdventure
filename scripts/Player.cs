using System.Data;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace SoftwareDesignTextAdventure
{
    public class Player
    {
        int[] currentPosition;
        iUser user;
        public Player(iUser user){
            this.user = user;
        }
        public void play(Adventure adventure){
            this.currentPosition = adventure.startingPoint;
            adventure.read(this.currentPosition);
            bool end = true;
            while(end){
                Controller.instance.clear(500);
                Console.WriteLine("Please choose a direction or write 'menu' to get back to the menu");
                String direction = Console.ReadLine();
                bool isMoving;
                if(!direction.Equals("menu")){
                    isMoving = move(direction);
                    if(isMoving){
                        adventure.read(currentPosition);
                    }
                    else{
                        Console.WriteLine("You cant go there!");
                    }
                }
                else{
                    end = false;
                }
            }
        }
        public bool move(String direction){
            switch (direction)
            {
                case "N":
                    if(currentPosition[1]-1>0){
                        currentPosition[1]-=1;
                        return true;
                    }
                    return false;
                case "E":
                    if(currentPosition[0]+1>0){
                        currentPosition[0]+=1;
                        return true;
                    }
                    return false;
                case "S":
                    if(currentPosition[1]+1>0){
                        currentPosition[1]+=1;
                        return true;
                    }
                    return false;
                case "W":
                    if(currentPosition[0]-1>0){
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