using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamAPI_Try___MVC.JsonClass
{
    public class SteamPlayerClass
    {
        /*
         "steamid": "76561198131281243",
                 "communityvisibilitystate": 3,
                 "personaname": "xtian.kristian",
                 "profileurl": "http://steamcommunity.com/profiles/76561198131281243/",
                 "avatar": "http://media.steampowered.com/steamcommunity/public/images/avatars/fe/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb.jpg",
                 "avatarmedium": "http://media.steampowered.com/steamcommunity/public/images/avatars/fe/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb_medium.jpg",
                 "avatarfull": "http://media.steampowered.com/steamcommunity/public/images/avatars/fe/fef49e7fa7e1997310d705b2a6158ff8dc1cdfeb_full.jpg",
                 "personastate": 0,
                 "primaryclanid": "103582791429521408",
                 "timecreated": 1396063627,
                 "personastateflags": 0
         */

        
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