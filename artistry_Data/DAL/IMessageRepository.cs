using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public interface IMessageRepository:IDisposable
    {
        IEnumerable<Messages> GetMessagesByUser(int Id);
        IEnumerable<Messages> GetMessagesById(int sender, int receiver);
        int GetNewMessages(int Id);
        void InsertMessage(Messages message);
        void UpdateMessage(Messages message);
        void Save();
    }
}
