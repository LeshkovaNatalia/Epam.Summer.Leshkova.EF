using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBasicsTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Users adminUser = new Users() { Name = "Admin", Email = "admin@mail.com", RoleId = 1 };
            Users user = new Users() { Name = "User", Email = "user@mail.com", RoleId = 2 };

            //AddUser Disconnected scenario.
            AddUser(adminUser);
            AddUser(user);

            //Update a user in the disconnected mode.
            UpdateUser(user);

            //Delete a user in disconnected mode.
            DeleteUser(user);

            Console.ReadLine();
        }

        private static void DeleteUser(Users user)
        {
            Users userToDelete = null;

            using (var ctx = new GalleryEntities())
            {
                var existingUser = ctx.Users.Count(u => u.Name == user.Name);
                if (existingUser != 0)
                    userToDelete = ctx.Users.Where(u => u.Name == user.Name).FirstOrDefault<Users>();
            }

            using (var newContext = new GalleryEntities())
            {
                if (userToDelete != null)
                {
                    newContext.Entry(userToDelete).State = System.Data.Entity.EntityState.Deleted;
                    newContext.SaveChanges();
                }
            }
        }

        private static void UpdateUser(Users user)
        {
            Users usrToUpdate = null;

            using (var ctx = new GalleryEntities())
            {
                var existingUser = ctx.Users.Count(u => u.Name == user.Name);
                if (existingUser != 0)
                    usrToUpdate = ctx.Users.Where(u => u.Name == user.Name).FirstOrDefault<Users>();
            }

            if (usrToUpdate != null)
            {
                usrToUpdate.Name = "Administrator";

                using (var ctx = new GalleryEntities())
                {
                    ctx.Entry(usrToUpdate).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        private static void AddUser(Users user)
        {
            using (var ctx = new GalleryEntities())
            {
                var existingUser = ctx.Users.Count(u => u.Name == user.Name);
                if (existingUser == 0)
                {
                    ctx.Entry(user).State = System.Data.Entity.EntityState.Added;
                    ctx.SaveChanges();
                }
            }
        }

        private static void AddRoles()
        {
            using (var ctx = new GalleryEntities())
            {
                IEnumerable<Roles> roles = new List<Roles>();
                roles = new[] { new Roles() { Name = "Administrator" }, new Roles() { Name = "User" }, new Roles() { Name = "Guest" } };

                ctx.Roles.AddRange(roles);
                ctx.ChangeTracker.DetectChanges();

                ctx.SaveChanges();
            }
        }
    }
}
