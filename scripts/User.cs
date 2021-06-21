using System.Globalization;
namespace SoftwareDesignTextAdventure
{
    public class User: Guest
    {
        public string username;
        public string password;
        
        public User(string username, string password){
            this.username = username;
            this.password = password;
        }
    }
}