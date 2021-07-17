namespace SoftwareDesignTextAdventure
{
    public interface iUser
    {
        string uuid {get; set;}
        string username {get; set;}
        string password {get; set;}
        void signIn(); 
        void signUp();
        void searchAdventure();
        void showAdventures();
        void createAdventure();
    }
}