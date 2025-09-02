using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;

namespace BAL.Service
{
    public class SystemUserService
    {

        private readonly SystemUserRepository systemUserRepository;
        public SystemUserService()
        {
            systemUserRepository = new SystemUserRepository();
        }
        public bool IsValidUser(string email, string password)
        {
            return systemUserRepository.IsValidUser(email, password);
        }
        public int GetRoleId(string email)
        {
            return systemUserRepository.getRoleId(email);
        }

    }
}
