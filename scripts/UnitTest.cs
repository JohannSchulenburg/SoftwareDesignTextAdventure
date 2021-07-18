namespace SoftwareDesignTextAdventure
{
    public static class UnitTest
    {
        public static void registerAndLogin(){
            NullUser nullUser = new NullUser();
            nullUser.signUp();
            nullUser.signIn();
        }
    }
}