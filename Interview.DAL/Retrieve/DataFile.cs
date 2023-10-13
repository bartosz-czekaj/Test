using Interview.DAL.Interfaces;
using Interview.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Interview.DAL.Retrieve
{
    public class DataFile : iTransaction
    {
        private string filePath = "../data.json";
        private List<Transaction> transactions;

        /// <summary>
        /// Base contructor
        /// </summary>
        public DataFile()
        {
            LoadDataFile();
        }

        /// <summary>
        /// OK this is a bit sledgehammer to crack a nut, but since the tests run from a different location this allows the unit tests to work
        /// using the same physical file but specify it on a different execution path. 
        /// </summary>
        /// <param name="seperateFilePath"></param>
        public DataFile(string seperateFilePath)
        {
            filePath = seperateFilePath;

            LoadDataFile();
        }

        private void LoadDataFile()
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(json);
            }
        }

        public int Count()
        {
            return transactions.Count;
        }

        /// <summary>
        /// Since these are mirroring database access (even if its from a flat file) I'm handling this side as CRUD
        /// </summary>
        /// <param name="id">Unique Identifier of the record</param>
        /// <returns></returns>
        public Transaction Retrieve(Guid id)
        {
            return transactions.SingleOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Returns all transactions in an IEnumerable.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Transaction> RetrieveAll()
        {
            return transactions;
        }

        /// <summary>
        /// Adds the new transaction of the list.
        /// </summary>
        /// <param name="transaction"></param>
        public void Create(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        /// <summary>
        /// Removes specified transaction from list
        /// </summary>
        /// <param name="transactionID">GUID of the record to delete</param>
        public void Delete(Guid transactionID)
        {
            var item = Retrieve(transactionID);
            transactions.Remove(item);
        }

        /// <summary>
        /// Updates and item in the list
        /// </summary>
        /// <param name="newDetails">The record with the details to be updated in.</param>
        public void Update(Transaction newDetails)
        { 
            if (transactions.Exists(t => t.Id == newDetails.Id))
            {
                var target = transactions.Single(t => t.Id == newDetails.Id);
                target.ApplicationId = newDetails.ApplicationId;
                target.Type = newDetails.Type;
                target.Summary = newDetails.Summary;
                target.Amount = newDetails.Amount;
                target.PostingDate = newDetails.PostingDate;
                target.IsCleared = newDetails.IsCleared;
                target.ClearedDate = newDetails.ClearedDate;
            }
        }
    }
}
