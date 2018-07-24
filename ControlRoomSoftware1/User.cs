namespace ControlRoomSoftware1
{
    public enum UserLevelEnum
    {
        Unspecified = 0,
        Admin = 1,
        Researcher = 2,
        Public = 3
    }

    public class User
    {
        public int UserID { get; set; }
        public UserLevelEnum UserLevel { get; set; }

        public User(int setUserID, UserLevelEnum setUserLevel)
        {
            UserID = setUserID;
            UserLevel = setUserLevel;
        }
    }
}