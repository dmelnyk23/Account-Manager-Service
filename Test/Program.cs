using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDal = new DatabaseDAL();
            var all = myDal.GetAllAccounts().Count();
            //foreach (var item in all)
            //{
            //    Console.WriteLine(item.Login + " - " + item.Password);
            //}

            Console.WriteLine(all.ToString());
        }
    }
}
