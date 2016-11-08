using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkBasedService.Context;

namespace EntityFrameworkBasedService
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentsDbContextInitializer.Initialize();
            Console.ReadLine();
        }
    }
}
