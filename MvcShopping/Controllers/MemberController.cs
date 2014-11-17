using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcShopping.Controllers
{
    /// <summary>
    /// 会员相关功能
    /// </summary>
    public class MemberController : Controller
    {
        // 会员注册

        public ActionResult Register()
        {
            return View();
        }

        //写入会员信息
        [HttpPost]
        public ActionResult Register([Bind(Exclude="RegisterOn,AuthCode")] Member member)
        {
            return View();
        }

        //显示会员登录页面
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        //运行会员登录
        [HttpPost]
        public ActionResult Login(string email , string password , string returnUrl)
        {
            //ValidateUser() ：验证账户密码是否正确
            if(ValidateUser(email , password))   //如果验证成功
            {
                /*FormsAuthentication为Web应用程序管理Forms身份验证服务，SetAuthCookie(string userName, bool createPersistentCookie)为提供的用户名创建一个身份验证票证，并将该票证添加到响应的Cookie集合中或URL中（如果使用的是无Cookie身份验证）简单来说，就是很多网站登录的时候有一个“请记住我”的选项，它会将登录信息记录在cookie中，这样，下次用户访问网站无需再输入密码就可以自动登录了。第二个参数指定为false的时候，跨浏览器会话就无效了。*/
                FormsAuthentication.SetAuthCookie(email, false);
                
                if(String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "您输入的账号或密码错误");
            return View();
        }

        private bool ValidateUser(string email , string  password)
        {
            throw new NotImplementedException();
        }


        //运行会员注销
        public ActionResult Logout()
        {
            //清除窗体验证的Cookie
            FormsAuthentication.SignOut();

            //清除所有曾经写入过的Session信息
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}
