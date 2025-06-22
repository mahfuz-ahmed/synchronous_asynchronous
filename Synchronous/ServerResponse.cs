using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronous
{
    internal class ServerResponse
    {
        public async Task<int> GetCseStudents()
        {
            int totalStudent = 0;
            await Task.Delay(6000);  //get data time from server
            totalStudent = 60000;
            return totalStudent;
        }

        public async Task<int> GetSoftStudents()
        {
            int totalStudent = 0;
            await Task.Delay(3000);  //get data time from server
            totalStudent = 30000;
            return totalStudent;
        }
    }
}
