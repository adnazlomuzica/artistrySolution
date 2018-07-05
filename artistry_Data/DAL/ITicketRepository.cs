using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface ITicketRepository:IDisposable
    {
        List<Tickets> GetTickets(int id);
        List<Tickets> Filter(int id, DateTime start, DateTime end);

        int GetSum(int id);
        int GetMonthSum(int id);
        double GetTotal(int id);
        double GetMonthTotal(int id);
        bool Scan(string code);
    }
}
