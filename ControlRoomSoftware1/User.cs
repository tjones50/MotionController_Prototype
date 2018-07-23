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
        private string UserName;
        private string Password; // will this be stored in this object?
        public UserLevelEnum UserLevel { get; set; }
    }
}