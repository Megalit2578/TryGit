using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MockTestRepository
    {
        private readonly Su25jlptmockTestDbContext _context;

        public MockTestRepository()
        {
            _context = new Su25jlptmockTestDbContext();
        }
        //dadasd
        public List<MockTest> GetAllTest()
        {
            return _context.MockTests.Include(mt => mt.Candidate).ToList();
        }

    }
}
