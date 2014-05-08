using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using InventoryManagement.Core.Entities;

namespace InventoryManagment.Core.Persistence
{
    public interface IItemTypeRepository
    {
        int Save(ItemType item);

    }

    public class ItemTypeRepository : IItemTypeRepository
    {
        public int Save(ItemType item)
        {
            return 1;
        }
    }
}
