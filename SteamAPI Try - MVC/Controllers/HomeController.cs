using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using System.Text.RegularExpressions;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;


namespace SteamAPI_Try___MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            OpenIdRelyingParty openid = new OpenIdRelyingParty();
            OpenIdLogin openlog = new OpenIdLogin();
            openid.SecuritySettings.AllowDualPurposeIdentifiers = true;
            IAuthenticationResponse response = openid.GetResponse();

            if (response != null)
            {
                string regex = Request.QueryString["openid.identity"];
                string[] str = regex.Split('/');
                string id = str[5];
                Session["user"] = id;
                FormsAuthentication.SetAuthCookie(id, false);
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index");
                }
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Account");
                }
            }

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string ReturnUrl)
        {
            OpenIdRelyingParty openid = new OpenIdRelyingParty();
            try
            {
                IAuthenticationRequest request = openid.CreateRequest("http://steamcommunity.com/openid");
                OpenIdLogin openlog = new OpenIdLogin();
                openid.SecuritySettings.AllowDualPurposeIdentifiers = true;
                IAuthenticationResponse response = openid.GetResponse();
                return request.RedirectingResponse.AsActionResult();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(e.Message, "Cannot Fetch Steam Credentials. Please try again Later");
            }

            return View();
        }

        public ActionResult Signout()
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Remove("AUTHCOOKIE");
            FormsAuthentication.SignOut();
            return View();
        }

    }
}
