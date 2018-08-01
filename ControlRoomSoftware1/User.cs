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
        public string UserName { get; set; }
        public UserLevelEnum UserLevel { get; set; }

        public User(int setUserID, string setUserName, UserLevelEnum setUserLevel)
        {
            UserID = setUserID;
            UserName = setUserName;
            UserLevel = setUserLevel;
        }
    }
}