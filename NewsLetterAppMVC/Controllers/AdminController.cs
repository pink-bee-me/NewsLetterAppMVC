using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsLetterAppMVC.ViewModels;
using NewsLetterAppMVC;

namespace NewsLetterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {



        }
        public ActionResult Admin()
        {
            string queryString = @"SELECT Id, FirstName,LastName,EmailAddress from SignUps";

            //create new List Called "signUps", which will be populated with items that are of type "NewsletterSignUp"
            List<NewsLetterSignUp> signUps = new List<NewsLetterSignUp>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var signUp = new NewsletterSignUp();
                    signUp.Id = Convert.ToInt32(reader["Id"]);
                    signUp.FirstName = reader["FirstName"].ToString();
                    signUp.LastName = reader["LastName"].ToString();
                    signUp.EmailAddress = reader["EmailAddress"].ToString();

                    signUps.Add(signUp);
                }
            }

            var signUpVMs = new List<SignUpVM>();// made list called signUpVMs that is made up of items that are the type of  SignUpVM

            foreach (var signUp in signUps)
            {
                var signUpVM = new SignUpVM();

                signUpVM.FirstName = signUp.FirstName; //this way you don't need (signUpVM.FirstName = signup.FirstName)
                signUpVM.LastName = signUp.LastName; //you can shorten it to (FirstName = signup.FirstName), etc...
                signUpVM.EmailAddress = signUp.EmailAddress;

                signUpVMs.Add(signUpVM);
            }

            return View(signUpVMs);
        }
    }
}

