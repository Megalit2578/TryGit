using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class CandidateService
    {
            private readonly CandidateRepository candidateRepository;
            public CandidateService()
            {
                candidateRepository = new CandidateRepository();
            }
            public List<Candidate> GetAllCandidates()
            {
                return candidateRepository.GetAllCandidates();
            }

    }
}
