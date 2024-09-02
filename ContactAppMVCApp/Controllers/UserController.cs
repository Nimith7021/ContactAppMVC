using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactAppMVCApp.Models;

namespace ContactAppMVCApp.Controllers
{
    public class UserController : Controller
    {
        public static List<User> users = new List<User>()
        {
            new User{UserId=1,FName="John",LName="Adams",IsAdmin=true,contacts = { new Contact {ContactID=100,
            FName="John",LName="Adams",Details={ new ContactDetail
            { ContactDetailId=1000,Type="E-Mail",Value="jamesAD@xyz.com"},new ContactDetail{ContactDetailId=1001,Type="E-mail",
            Value="jAdams@xyz.com"} }},new Contact{ContactID=101,FName="John",LName="Adams",Details={ new ContactDetail 
            { ContactDetailId=1002,Type="Number",Value="22222222222"},new ContactDetail{ContactDetailId=1003,Type="E-mail",
            Value="jAdams@xyz.com"} } } } },


            new User{UserId=2,FName="Raj",LName="Shetty",IsAdmin=true,contacts = { new Contact {ContactID=102,
            FName="Raj",LName="Shetty",Details={ new ContactDetail
            { ContactDetailId=1004,Type="E-Mail",Value="RajSH@xyz.com"},new ContactDetail{ContactDetailId=1005,Type="E-mail",
            Value="shettyRaj@xyz.com"} }},new Contact{ContactID=103,FName="Raj",LName="Shetty",Details={ new ContactDetail
            { ContactDetailId=1006,Type="Number",Value="3456781234"},new ContactDetail{ContactDetailId=1007,Type="E-mail",
            Value="rajshetty454465@xyz.com"} }} }},


            new User{UserId=3,FName="Max",LName="Stevens",IsAdmin=false,contacts = { new Contact {ContactID=104,
            FName="Max",LName="Stevens",Details={ new ContactDetail
            { ContactDetailId=1008,Type="Number",Value="8888888888"},new ContactDetail{ContactDetailId=1009,Type="Number",
            Value="6565765466"} }},new Contact{ContactID=105,FName="Max",LName="Stevens",Details={ new ContactDetail
            { ContactDetailId=1010,Type="E-Mail",Value="Mstevens@xyz.com"},new ContactDetail{ContactDetailId=1011,Type="Number",
            Value="1099922834"} }} }},



            new User{UserId=4,FName="Samuel",LName="Anthony",IsAdmin=false,contacts = { new Contact {ContactID=106,
            FName="Samuel",LName="Anthony",Details={ new ContactDetail
            { ContactDetailId=1012,Type="E-Mail",Value="samAN@xyz.com"},new ContactDetail{ContactDetailId=1013,Type="E-mail",
            Value="anthonyS@xyz.com"} }},new Contact{ContactID=107,FName="Samuel",LName="Anthony",Details={ new ContactDetail
            { ContactDetailId=1014,Type="Number",Value="9999543123"},new ContactDetail{ContactDetailId=1015,Type="Number",
            Value="8612659963"} }} }}
        };
        // GET: User

        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPage(User inputUser) {

           var targetUser = users.FirstOrDefault(user => user.UserId == inputUser.UserId);
            if (targetUser == null)
                return RedirectToAction("DataNotFoundOperation","InvalidOperations");
            if (targetUser.IsAdmin)
                return RedirectToAction("AdminView");
            else
                return RedirectToAction("StaffView","Staff");
        }


        [HttpGet]
        public ActionResult AdminView() {

            var data = users;
            return View(data);
        }

        [HttpGet]

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateUser(User user)
        {
            users.Add(user);
            return RedirectToAction("AdminView");
        }

        [HttpGet]

        public ActionResult EditUser(int id) {

            var targetUser = users.FirstOrDefault(user => user.UserId == id);
            if (!targetUser.IsActive)
                return RedirectToAction("InactiveUserOperation","InvalidOperations");
            return View(targetUser);
        }

        [HttpPost]
        public ActionResult EditUser(int id , User newDetailsOfUser)
        {
            var targetUser = users.FirstOrDefault(user => user.UserId == id);
            targetUser.FName = newDetailsOfUser.FName;
            targetUser.LName = newDetailsOfUser.LName;
            targetUser.IsAdmin = newDetailsOfUser.IsAdmin;
            return RedirectToAction("AdminView");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id) {

            var targetUser = users.FirstOrDefault(u => u.UserId == id);
            targetUser.IsActive = false;
            return RedirectToAction("AdminView");
        }
        
        
        }


    }
