using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class MockTestService
    {
            private readonly MockTestRepository mockTestRepository;
            public MockTestService()
            {
                mockTestRepository = new MockTestRepository();
            }
            public List<MockTest> GetAllTest()
            {
                return mockTestRepository.GetAllTest();
            }
    }
}
