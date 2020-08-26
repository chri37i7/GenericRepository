using GenericRepository.Tester.DataAccess;
using GenericRepository.Tester.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GenericRepository.Tester.MSTests
{
    [TestClass]
    public class SupplierTests
    {
        [TestMethod]
        public void CompositionTest()
        {
            NorthwindDbContext context = new NorthwindDbContext();
            RepositoryBase<Supplier> repository = new RepositoryBase<Supplier>(context);

            Assert.IsNotNull(repository.Context);
        }

        [TestMethod]
        public void GetAllSuppliersTest()
        {
            NorthwindDbContext context = new NorthwindDbContext();
            RepositoryBase<Supplier> repository = new RepositoryBase<Supplier>(context);

            int count = repository.GetAll().Count();

            Assert.AreEqual(29, count);
        }

        [TestMethod]
        public void GetSupplierByIdTest()
        {
            string expectedCompanyName = "Vejlesild";
            int expectedSupplierId = 21;

            NorthwindDbContext context = new NorthwindDbContext();
            RepositoryBase<Supplier> repository = new RepositoryBase<Supplier>(context);

            Supplier supplier = repository.GetBy(expectedSupplierId);

            // Assert
            Assert.AreEqual(expectedSupplierId, supplier.SupplierId);
            Assert.AreEqual(expectedCompanyName, supplier.CompanyName);
        }

        [TestMethod]
        public void UpdateSupplier()
        {
            string newCompanyName = "Vejlesild";
            int supplierId = 21;

            NorthwindDbContext context = new NorthwindDbContext();
            RepositoryBase<Supplier> repository = new RepositoryBase<Supplier>(context);

            Supplier supplier = repository.GetBy(supplierId);
            supplier.CompanyName = newCompanyName;

            repository.Update(supplier);
        }
        [TestMethod]
        public void OrderCompositionTest()
        {
            int id = 10273;

            NorthwindDbContext context = new NorthwindDbContext();
            OrderRepository repository = new OrderRepository(context);

            Order order = repository.GetBy(id);

            Assert.AreEqual("QUICK", order.CustomerId);
            Assert.IsNotNull(order.Customer);
        }
    }
}