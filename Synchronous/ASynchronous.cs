using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronous
{
    internal class ASynchronousFirstEX
    {
        int cseDepId = 1;
        int softDepId = 2;
        public async Task ASynchronousMethod()
        {

            await Task.Delay(1000);
            Console.WriteLine("Method One End");

            // --- sequential asynchronous execution. ---
            //await GetCseStudent();   //Execute Time 6sec
            //await GetSoftStudent(); //Execute Time 3sec

            // Total Execution time 9 Sec for Sequential Asynchronous call

            // --- Parallel Asynchronous Execution ---
            // Parallel Asynchronous Create multy task or thread
            var cseStudents = GetCseStudent();     // Task is created
            var softStudents = GetSoftStudent();  // Task is created

            // Start cseStudents and softStudents at the same time.
            // Wait for both tasks to complete — this is where we finally "await" them.
            var students = await Task.WhenAll(cseStudents, softStudents);


            // Total Execution time 6 Sec for Parallel Asynchronous cal, Reduce 3 Sec 
            int totalStudents =  await TotalStudents(students[0], students[1]);
            Console.WriteLine($"Total Students: {totalStudents}");
        }

        public async Task<int> GetCseStudent()
        {
            var serverResponse = new ServerResponse();
            var cseStudents = await serverResponse.GetCseStudents();
            Console.WriteLine($"CSE Students: {cseStudents}");
            return cseStudents;
        }

        public async Task<int> GetSoftStudent()
        {
            var serverResponse = new ServerResponse();
            var softStudents = await serverResponse.GetSoftStudents();
            Console.WriteLine($"Software Students: {softStudents}");

            return softStudents;
        }

        public async Task<int> TotalStudents(int cse,int soft)
        {
            int totalStudent = cse+soft;
            return totalStudent;
        }
    }

    internal class ASynchronousSecondEx
    {
        int cseDepId = 1;
        int softDepId = 2;
        public async Task ASynchronousMethod()
        {
            int[] items = { 1, 2, 3, 4, 5, 6 };

            await Task.Delay(1000);
            Console.WriteLine("Method One End");

            // --- Parallel Asynchronous Execution ---
            // Parallel Asynchronous Create multy task or thread
            var task1 = MethodTwo(items);  // Task is created
            var task2 = MethodThree(2);   // Task is created

            Console.WriteLine(" After method call and befor await");

            // Start MethodTwo and MethodThree at the same time.
            // Wait for both tasks to complete — this is where we finally "await" them.
            var result = await Task.WhenAll(task1, task2); // Waits for both tasks to finish in parallel

        }

        public async Task<int> MethodTwo(int[] items)
        {
            int sum = 0;

            foreach (var item in items)
            {
                sum += item;
            }
            await Task.Delay(6000);
            Console.WriteLine("Method Two End");

            return sum;
        }
        public async Task<int> MethodThree(int time)
        {
            await Task.Delay(1000 * time);
            Console.WriteLine("Method Three End");
            return time;
        }
    }
}
