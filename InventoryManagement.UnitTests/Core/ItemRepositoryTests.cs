using System;
using System.Runtime.Serialization;
using InventoryManagement.Core.Entities;
using InventoryManagment.Core.Persistence;
using Moq;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using NHibernate;

namespace InventoryManagement.UnitTests.Core
{
    public class when_working_with_the_item_type_repository : Specification
    {
        protected Mock<ISessionFactory>  _mockSessionFactory;
        protected Mock<ISession>  _mockSession;
        protected IItemTypeRepository _itemTypeRepository;

        protected override void Establish_context()
        {
            base.Establish_context();
            _mockSession = new Mock<ISession>();
            _mockSessionFactory = new Mock<ISessionFactory>();
            _itemTypeRepository = new ItemTypeRepository(_mockSessionFactory.Object);

            _mockSessionFactory.Setup(sf => sf.OpenSession()).Returns(_mockSession.Object);
        }

    }

    public class and_saving_a_valid_item_type : when_working_with_the_item_type_repository
    {
        private int _result;
 
        private ItemType _testItemType;
        private int _itemTypeId;

        protected override void Establish_context()
        {
            base.Establish_context();
            var randomNumber = new Random();

            _itemTypeId = randomNumber.Next(32000);

            _mockSession.Setup(s => s.Save(_testItemType)).Returns(_itemTypeId);
           
        }
        protected override void Because_of()
        {
            _result = _itemTypeRepository.Save(_testItemType);
        }

        [Test]
        public void then_a_valid_item_type_id_should_be_returned()
        {
            _result.ShouldEqual(_itemTypeId);
        }
    }

    public class and_saving_an_invalid_item_type : when_working_with_the_item_type_repository
    {
        private Exception _result;

        [Test]
        public void then_an_argumnet_null_exception_should_be_raised()
        {
            _result.ShouldBeInstanceOfType(typeof(ArgumentNullException));
        }

        protected override void Because_of()
        {
            try
            {
              _itemTypeRepository.Save(null);

            }
            catch (Exception exception)
            {
                
                  _result = exception;
            }
           
        }

        protected override void Establish_context()
        {
            base.Establish_context();
            _mockSession.Setup(s => s.Save(null)).Throws(new ArgumentNullException());
        }
    }
}
