using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CandidateRepository
    {

        private readonly Su25jlptmockTestDbContext _context;

        public CandidateRepository()
        {
            _context = new Su25jlptmockTestDbContext();
        }

        public List<Candidate> GetAllCandidates()
        {
            return _context.Candidates.ToList();
        }


    }
}
