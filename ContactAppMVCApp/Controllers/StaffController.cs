using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactAppMVCApp.Models;

namespace ContactAppMVCApp.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        [HttpGet]
        public ActionResult StaffView()
        {
            return View();
        }

        [HttpPost]

        public ActionResult StaffView(Contact contact)
        {
            var targetUser = UserController.users.FirstOrDefault(user => user.UserId == contact.ContactID);
            if(targetUser==null)
                return RedirectToAction("DataNotFoundOperation", "InvalidOperations");

            Session["Contacts"] = targetUser.contacts;
            return RedirectToAction("ContactDetails");
        }

        [HttpGet]
        public ActionResult ContactDetails()
        {
            var contacts = Session["Contacts"] as List<Contact>;
            TempData["CS"] = contacts;
            return View(contacts);
            
        }

        [HttpGet]

        public ActionResult CreateContact() {
            
            return View();
        }

        [HttpPost]

        public ActionResult CreateContact(Contact contact) {

            var data = TempData["CS"] as List<Contact>;
            data.Add(contact);
            return RedirectToAction("ContactDetails");
        }

        [HttpGet]

        public ActionResult EditContact(int id)
        {
            var user = Session["Contacts"] as List<Contact>;
            var targetUser = user.FirstOrDefault(con => con.ContactID == id);
            if (!targetUser.IsActive)
                return RedirectToAction("InactiveContactOperation","InvalidOperations");
            return View(targetUser);
        }

        [HttpPost]

        public ActionResult EditContact(int id , Contact updatedContact) {
            var user = Session["Contacts"] as List<Contact>;
            var targetUser = user.FirstOrDefault(con => con.ContactID == id);
            targetUser.FName = updatedContact.FName;
            targetUser.LName = updatedContact.LName;
            return RedirectToAction("ContactDetails");
        }

        [HttpGet]

        public ActionResult DeleteContact(int id) {

            var user = Session["Contacts"] as List<Contact>;
            var targetUser = user.FirstOrDefault(con => con.ContactID == id);
            targetUser.IsActive = false;
            return RedirectToAction("ContactDetails");
        }

        [HttpGet]

        public ActionResult GetContactDetails(int id)
        {
            Session["Id"] = id;
            var user = Session["Contacts"] as List<Contact>;
            var targetUser = user.FirstOrDefault(u=>u.ContactID == id);
            return View(targetUser.Details);
        }

        [HttpGet]

        public ActionResult CreateContactDetail()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateContactDetail(ContactDetail contactDetail)
        {
            var contactId = Session["Id"] ;
            var user = Session["Contacts"] as List<Contact>;
            var targetUser = user.FirstOrDefault(u => u.ContactID == (int)contactId);
            targetUser.Details.Add(contactDetail);
            return RedirectToAction("GetContactDetails",new {id=(int)contactId});
        }

        [HttpGet]

        public ActionResult EditContactDetail(int contactDetailID)
        {
            var contactId = Session["Id"];
            var user = Session["Contacts"] as List<Contact>;
            var targetUser = user.FirstOrDefault(u => u.ContactID == (int)contactId);
            var targetContactDetail = targetUser.Details.FirstOrDefault(cd=>cd.ContactDetailId == contactDetailID);
            return View(targetContactDetail);
        }

        [HttpPost]

        public ActionResult EditContactDetail(int contactDetailID,ContactDetail updatedContactDetail) {
            var contactId = Session["Id"];
            var user = Session["Contacts"] as List<Contact>;
            var targetContact = user.FirstOrDefault(u => u.ContactID == (int)contactId);
            var targetContactDetail = targetContact.Details.FirstOrDefault(cd=>cd.ContactDetailId==contactDetailID);
            targetContactDetail.Type = updatedContactDetail.Type;
            targetContactDetail.Value = updatedContactDetail.Value;
            return RedirectToAction("GetContactDetails",new { id = (int)contactId });
        }

        [HttpGet]

        public ActionResult DeleteContactDetail(int contactDetailID) {
            var contactId = Session["Id"];
            var user = Session["Contacts"] as List<Contact>;
            var targetContact = user.FirstOrDefault(u => u.ContactID == (int)contactId);
            var targetContactDetail = targetContact.Details.FirstOrDefault(cd => cd.ContactDetailId == contactDetailID);
            targetContact.Details.Remove(targetContactDetail);
            return RedirectToAction("GetContactDetails", new { id = (int)contactId });
        }
    }
}