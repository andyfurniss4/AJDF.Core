using DAL.Base.Infrastructure;
using DAL.EntityFramework.Tests.Integration.Models;
using DAL.EntityFramework.Tests.Integration.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace DAL.EntityFramework.Tests.Integration.Tests
{
    [TestFixture]
    public class TestEntityRepositoryTests : TestBase
    {
        private TestEntityRepository repository;
        private IUnitOfWork unitOfWork;

        [OneTimeSetUp]
        public void Initialise()
        {
            this.repository = new TestEntityRepository(base.DataContext);
            this.unitOfWork = base.Services.GetService<IUnitOfWork>();

            var entities = new TestEntity[]
            {
                new TestEntity { Name = "Update Me", CreatedDate = DateTime.Now.Date },
                new TestEntity { Name = "Delete Me", CreatedDate = DateTime.Now.Date }
            };

            this.repository.Insert(entities);
            unitOfWork.Commit();
        }

        [Test]
        [Category("DAL.EntityFramework.Integration")]
        public void InsertSucceeds_ReturnsTrue()
        {
            // Arrange
            var entity = new TestEntity()
            {
                Name = "Test Entity",
                CreatedDate = DateTime.Now.Date
            };

            // Act
            var result = this.repository.Insert(entity);
            this.unitOfWork.Commit();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [Category("DAL.EntityFramework.Integration")]
        public void UpdateSucceeds_ReturnsTrue()
        {
            // Arrange
            var entity = this.repository.FindOne(x => x.Name.Equals("Update Me"));
            entity.Name = "Updated";

            // Act
            var result = this.repository.Update(entity);
            this.unitOfWork.Commit();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        [Category("DAL.EntityFramework.Integration")]
        public void DeleteSucceeds_ReturnsTrue()
        {
            // Arrange
            var entity = this.repository.FindOne(x => x.Name.Equals("Delete Me"));

            // Act
            var result = this.repository.Delete(entity);
            this.unitOfWork.Commit();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
