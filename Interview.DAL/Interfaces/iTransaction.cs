using Interview.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.DAL.Interfaces
{
    public interface iTransaction
    {
        int Count();
        Transaction Retrieve(Guid id);
        IEnumerable<Transaction> RetrieveAll();
        void Create(Transaction transaction);
        void Delete(Guid transactionID);
        void Update(Transaction newDetails);
    }
}
