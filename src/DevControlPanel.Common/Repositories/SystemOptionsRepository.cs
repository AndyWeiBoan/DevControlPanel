using DevControlPanel.Common.Models;

namespace DevControlPanel.Common.Repositories
{
    public sealed class SystemOptionsRepository : ISystemOptionsRepository
    {
        private readonly DbContext _context;

        public SystemOptionsRepository(DbContext context)
        {
            _context = context;
        }

        void ISystemOptionsRepository.Update(SystemOptions options)
        {
            var collection = _context.Database.GetCollection<SystemOptions>();

            collection.Update(options);
        }
    }
}
