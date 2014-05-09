using InventoryManagement.Core.Entities;
using NHibernate;

namespace InventoryManagment.Core.Persistence
{
    public interface IItemTypeRepository
    {
        int Save(ItemType item);

    }

    public class ItemTypeRepository : IItemTypeRepository
    {
        private ISessionFactory _sessionFactory;

        public ItemTypeRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public int Save(ItemType item)
        {
            int Id;

            using (var session = _sessionFactory.OpenSession())
            {
                Id = (int)session.Save(item);
                session.Flush();
            }

            return Id;
        }

        public ItemType GetItemById(int Id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Get<ItemType>(Id);
            }

        }
    }
}
