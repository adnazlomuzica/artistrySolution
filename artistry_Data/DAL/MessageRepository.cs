using artistry_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace artistry_Data.DAL
{
    public class MessageRepository:IMessageRepository, IDisposable
    {
        private Context.Context context;

        public MessageRepository(Context.Context context)
        {
            this.context = context;
        }

        public IEnumerable<Messages> GetMessagesByUser(int Id)
        {  
           IEnumerable<Messages> model= context.Messages.Include(x=>x.Receiver).Include(x=>x.Sender).Where(x=>x.ReceiverId==Id || x.SenderId==Id).OrderByDescending(x=>x.Date).ToList();

            List<Messages> messages = new List<Messages>();
            foreach (var x in model)
            {
                if (!messages.Any(y => (y.SenderId == x.SenderId || y.SenderId==x.ReceiverId) && (y.ReceiverId==x.SenderId || y.ReceiverId==x.ReceiverId)))
                    messages.Add(x);
            }

            return messages;
        }

        public int GetNewMessages(int Id)
        {
            IEnumerable<Messages> model = context.Messages.Include(x => x.Receiver).Include(x => x.Sender).Where(x => x.ReceiverId == Id && x.Seen==false).OrderByDescending(x => x.Date).ToList();

            List<Messages> messages = new List<Messages>();
            foreach (var x in model)
            {
                if (!messages.Any(y => (y.SenderId == x.SenderId)))
                    messages.Add(x);
            }

            int n=messages.Count();
            return n;
        }
        public IEnumerable<Messages> GetMessagesById(int sender, int receiver)
        {
            return context.Messages.Where(x => (x.SenderId == sender && x.ReceiverId==receiver) || (x.SenderId==receiver && x.ReceiverId==sender)).Include(x => x.Receiver).Include(x => x.Sender).OrderBy(x=>x.Date).ToList();
        }
        
        public void InsertMessage(Messages message)
        {
            context.Messages.Add(message);
        }

        public void UpdateMessage(Messages message)
        {
            context.Entry(message).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
