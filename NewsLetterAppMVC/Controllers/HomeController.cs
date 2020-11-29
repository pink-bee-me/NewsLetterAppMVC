using NewsLetterAppMVC.Models;
using System.Web.Mvc;

namespace NewsLetterAppMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml"); //tilde(~) means -> relative path or root
            }
            else
            {
                // accessing database with Entity Framework "which is a wrapper for the ADO.NET Framework or ACTIVEX Data Object" both EF and ADO are libraries that deal with the exchanging and maneuvering of data.
               
                using (NewsletterModelEntities db = new NewsletterModelEntities())
               {
                    var signUp = new SignUp();
                    signUp.FirstName = firstName;
                    signUp.LastName = lastName;
                    signUp.EmailAddress = emailAddress;

                    db.SignUps.Add(signUp);
                    db.SaveChanges(); // nothing is saved until you write "db.SaveChanges();"
                }
                return View("Success"); 

                //        string queryString = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress) VALUES (@FirstName, @LastName, @EmailAddress)";


                //        using (SqlConnection connection = new SqlConnection(connectionString))
                //        {
                //            SqlCommand command = new SqlCommand(queryString, connection);
                //            command.Parameters.Add(@"FirstName", SqlDbType.VarChar);
                //            command.Parameters.Add(@"LastName", SqlDbType.VarChar);
                //            command.Parameters.Add(@"EmailAddress", SqlDbType.VarChar);

                //            command.Parameters[@"FirstName"].Value = firstName;
                //            command.Parameters[@"LastName"].Value = lastName;
                //            command.Parameters[@"EmailAddress"].Value = emailAddress;

                //            connection.Open();
                //            command.ExecuteNonQuery();
                //            connection.Close();
                //        }
                //        return View("Success");
                //    }
                //}


            }
        }
    }
}
