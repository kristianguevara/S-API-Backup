using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPI_Try___MVC.JsonClass
{
    public class SteamPlayerClass
    {
        
        public class Rootobject
        {
            public Response response { get; set; }
        }

        public class Response
        {
            public Player[] players { get; set; }
        }

        public class Player
        {
            public string steamid { get; set; }
            public int communityvisibilitystate { get; set; }
            public string personaname { get; set; }
            public string profileurl { get; set; }
            public string avatar { get; set; }
            public string avatarmedium { get; set; }
            public string avatarfull { get; set; }
            public int personastate { get; set; }
            public string primaryclanid { get; set; }
            public int timecreated { get; set; }
            public int personastateflags { get; set; }
        }

        public class UserList
        {
            public List<Player> data { get; set; }
        }

    }
}
