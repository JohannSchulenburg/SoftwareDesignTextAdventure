using System.Collections.Generic;

namespace SoftwareDesignTextAdventure
{
    public class Statistic
    {
        public List<int> timesMovedList;
        
        public Statistic(){
            this.timesMovedList = new List<int>();
        }
        public double getAverageTimesMoved(){
            double sum = 0;
            foreach (var time in this.timesMovedList)
            {
                sum += time;
            }
            return sum/timesMovedList.Count;
        }
        public int getTimesPlayed(){
            return timesMovedList.Count;
        }
    }
}