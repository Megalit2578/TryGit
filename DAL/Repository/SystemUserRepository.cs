using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SystemUserRepository
    {

        private readonly Su25jlptmockTestDbContext _context;
        public SystemUserRepository()
        {
            _context = new Su25jlptmockTestDbContext();
        }
        public bool IsValidUser(string email, string password)
        {
            var user = _context.Jlptaccounts
                .FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null;
        }
        public int getRoleId(string email)
        {
            var user = _context.Jlptaccounts
                .FirstOrDefault(u => u.Email == email);
            return user?.Role ?? 0;
        }


    }
}
