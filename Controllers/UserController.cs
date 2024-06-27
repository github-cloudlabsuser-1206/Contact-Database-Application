using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            return View(userlist);

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            User user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Creat
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Generate a unique ID for the new user
                int newId = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1;

                // Set the ID of the new user
                user.Id = newId;

                // Add the new user to the userlist
                userlist.Add(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If there are validation errors, return the Create view to display them
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {

            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Pass the user to the Edit view
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.

            // Retrieve the user from the userlist based on the provided ID
            User existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFoundResult
            if (existingUser == null)
            {
                return HttpNotFound();
            }

            // Update the existing user's information with the new values
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Pass the user to the Delete view
            return View(user);

        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found with the provided ID, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }


    }
}
