using System;
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

    }

    public class and_saving_a_valid_item_type : when_working_with_the_item_type_repository
    {
        private int _result;
        private IItemTypeRepository _itemTypeRepository;
        private ItemType _testItemType;
        private int _itemTypeId;

        protected override void Establish_context()
        {
            base.Establish_context();
            var randomNumber = new Random();
            var mockSessionFactory = new Mock<ISessionFactory>();
            var mockSession = new Mock<ISession>();

           

            _itemTypeId = randomNumber.Next(32000);
            mockSessionFactory.Setup(sf => sf.OpenSession()).Returns(mockSession.Object);
            mockSession.Setup(s => s.Save(_testItemType)).Returns(_itemTypeId);
            _itemTypeRepository = new ItemTypeRepository(mockSessionFactory.Object);
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

}
