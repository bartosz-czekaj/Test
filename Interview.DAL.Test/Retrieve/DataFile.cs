using Interview.DataModel;

namespace Interview.DAL.Test.Retrieve
{
    [TestClass]
    public class DataFile
    {
        private string filepath = "../../../../data.json";

        [TestMethod]
        public void ObjectInstantiatesAndLoadsCorrectly()
        {
            var obj = new DAL.Retrieve.DataFile(filepath);
            Assert.IsTrue(obj.Count() == 17);
        }

        [TestMethod]
        public void TestGet()
        {
            var obj = new DAL.Retrieve.DataFile(filepath);
            var record = obj.Retrieve(Guid.Parse("3f2b12b8-2a06-45b4-b057-45949279b4e5"));
            Assert.IsNotNull(record);
        }

        [TestMethod]
        public void TestDelete() 
        {
            var obj = new DAL.Retrieve.DataFile(filepath);
            obj.Delete(Guid.Parse("3f2b12b8-2a06-45b4-b057-45949279b4e5"));

            Assert.IsTrue(obj.Count() == 16);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var obj = new DAL.Retrieve.DataFile(filepath);
            var record = obj.Retrieve(Guid.Parse("3f2b12b8-2a06-45b4-b057-45949279b4e5"));

            record.Type = "Credit";

            obj.Update(record);

            var update = obj.Retrieve(Guid.Parse("3f2b12b8-2a06-45b4-b057-45949279b4e5"));
            Assert.IsTrue(update.Type == "Credit");
        }

        [TestMethod]
        public void TestCreate()
        {
            var obj = new DAL.Retrieve.DataFile(filepath);
            
            var newTransaction = new Transaction();
            newTransaction.Id = Guid.NewGuid();
            newTransaction.ApplicationId = 65189;
            newTransaction.Type = "Debit";
            newTransaction.Summary = "Test";
            newTransaction.Amount = 72.98;
            newTransaction.PostingDate = DateTime.Now;
            newTransaction.IsCleared = false;

            obj.Create(newTransaction);

            Assert.IsTrue(obj.Count() == 18);
        }

    }
}