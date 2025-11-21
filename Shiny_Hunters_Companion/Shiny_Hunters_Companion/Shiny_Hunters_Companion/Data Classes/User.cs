using System;


namespace Shiny_Hunters_Companion
{
    public class User
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public DateTime JoinDate { get; set; }
        public User()
        {

        }

        public User(int userID, string username, string passwordHash, string salt, DateTime joinDate)
        {
            UserID = userID;
            Username = username;
            PasswordHash = passwordHash;
            Salt = salt;
            JoinDate = joinDate;
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
