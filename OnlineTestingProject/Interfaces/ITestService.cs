using OnlineTestingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTestingProject.Interfaces
{
    public interface ITestService
    {
        void AddTest(Test qst);
        List<Test> GetTests();
        Test GetTest(int id);
        List<Test> GetAllTests();
    }
}