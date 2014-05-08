﻿using System;
using InventoryManagement.Core.Entities;
using InventoryManagment.Core.Persistence;
using NBehave.Spec.NUnit;
using NUnit.Framework;

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
            _itemTypeId = randomNumber.Next(32000);
            _itemTypeRepository = new ItemTypeRepository();
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