// checkt ob user und pw vorhanden mit bool statement

using ASP.NET_Core_Web_Development_Activity2b_1.Models;

namespace ASP.NET_Core_Web_Development_Activity2b_1.Services
{
    public class SecurityService
    {
        UsersDAO usersDAO = new UsersDAO();

        public SecurityService()
        {
            
        }
        public bool IsValid(UserModel user)
        {
            // return true if found n the list
            return usersDAO.FindUserByNameAndPassword(user);
        }
    }  
}
