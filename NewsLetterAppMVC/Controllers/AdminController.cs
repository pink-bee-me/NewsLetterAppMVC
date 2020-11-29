
using System.Collections.Generic;
using System.Web.Mvc;
using NewsLetterAppMVC.ViewModels;
using NewsLetterAppMVC.Models;

namespace NewsLetterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (NewsletterModelEntities db = new NewsletterModelEntities())
            {
                var signUps = db.SignUps;              //this is info from the Context.cs file in the Entity Model Section(represents all the records in the database from the SignUps Table)
                var signUpVMs = new List<SignUpVM>();  // made list called signUpVMs that is made up of items that are the type of  SignUpVM

                foreach (var signUp in signUps)
                {
                    var signUpVM = new SignUpVM();

                    signUpVM.FirstName = signUp.FirstName;  //this way you don't need (signUpVM.FirstName = signup.FirstName)
                    signUpVM.LastName = signUp.LastName;   //you can shorten it to (FirstName = signup.FirstName), etc...
                    signUpVM.EmailAddress = signUp.EmailAddress;

                    signUpVMs.Add(signUpVM);
                }

                return View(signUpVMs);
            }

            return View();

        }
    }
}
    
        
           
            //string queryString = @"SELECT Id, FirstName,LastName,EmailAddress from SignUps";

            ////create new List Called "signUps", which will be populated with items that are of type "NewsletterSignUp"
            //List<NewsLetterSignUp> signUps = new List<NewsLetterSignUp>();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);

            //    connection.Open();

            //    SqlDataReader reader = command.ExecuteReader();


            //    while (reader.Read())
            //    {
            //        var signUp = new NewsletterSignUp();
            //        signUp.Id = Convert.ToInt32(reader["Id"]);
            //        signUp.FirstName = reader["FirstName"].ToString();
            //        signUp.LastName = reader["LastName"].ToString();
            //        signUp.EmailAddress = reader["EmailAddress"].ToString();

            //        signUps.Add(signUp);
            //    }
       
   

