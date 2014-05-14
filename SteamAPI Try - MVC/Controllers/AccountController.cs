using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortableSteam;
using System.Web.Security;
using TinySteamWrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using SteamAPI_Try___MVC.JsonClass;
using System.Web.Script.Serialization;

namespace SteamAPI_Try___MVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private void SteamID()
        {
            //76561198131281243
            SteamWebAPI.SetGlobalKey("");
            
            var user = User.Identity.Name;
            long id = Convert.ToInt64(user);
            var identity = SteamIdentity.FromSteamID(id);
            var accountID = identity.SteamID;
            var r = SteamWebAPI.General().ISteamUser().ResolveVanityURL("munchies").GetResponse();
            ViewData["UserID"] = accountID;
        }

        
        private void JsonUserData()
        {
            string url = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=&steamids=76561198131281243";
            WebClient c = new WebClient();
            var data = c.DownloadString(url);
            JObject o = JObject.Parse(data);

            var personaname = o["response"]["players"][0]["personaname"];
            var avatarmedium = o["response"]["players"][0]["avatarmedium"];
            
            if (o["response"]["players"][0]["realname"] != null)
            {
                ViewData["realname"] = o["response"]["players"][0]["realname"];
            }
            ViewData["Name"] = personaname;
            ViewData["MedAvatar"] = avatarmedium;
            //Note: Real name is not created by default. The user has to edit it in steam for it to be in the JSON
        }

        public ActionResult Index()
        {
            
            AntiCache();
            SteamID();
            JsonUserData();
            IEconItems();
            return View();
        }

        public ActionResult Settings()
        {
            AntiCache();
            SteamID();
            JsonUserData();
            return View();
        }

        public ActionResult Signout()
        {
            AntiCache();
            /*HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();*/
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Remove("AUTHCOOKIE");
            FormsAuthentication.SignOut();
            return View();
        }

        private void AntiCache()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();
        }

        private void IEconItems()
        {
            /*int conv = Convert.ToInt32(User.Identity.Name);
            SteamWebAPI.SetGlobalKey("CFDCF16D4EC9D68762FBE9C61B43892D");
            var response = SteamWebAPI.Game().Generic()
                                 .IEconItems(GameType.Dota2)
                                 .GetPlayerItems(SteamIdentity.FromSteamID(conv))
                                 .GetResponse();
            string LOL = "";*/
        }

    }
}
