using System.Linq;
using SiteUsers;

namespace SalesMVC.Models
{
    public static class AuthProvider
    {
        private static readonly SalesUsersEntities ContextUsersEntities = new SalesUsersEntities();

        public static UserViewModel Authenticate(string username, string password)
        {
            var entity =
                ContextUsersEntities.SiteUsers.FirstOrDefault(x => x.siteuser == username && x.password == password);
            if (entity == null)
            {
                return null;
            }
            return new UserViewModel()
            {
                Password = entity.password,
                UserName = entity.siteuser,
                UserRole = entity.siterole
            };
        }

        public static void CreateNewUser(string userName, string password, string userRole)
        {
            var newUser = new SiteUsers.SiteUsers()
            {
                password = password, 
                siterole = userRole, 
                siteuser = userName
            };

            ContextUsersEntities.SiteUsers.Add(newUser);
            ContextUsersEntities.SaveChanges();
        }
    }
}
