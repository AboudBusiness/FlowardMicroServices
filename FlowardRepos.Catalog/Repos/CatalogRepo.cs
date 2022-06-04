using FlowardEntities.Catalog.DBContexts;
using FlowardEntities.Catalog.Models;
using FlowardRepos.Repos;

namespace FlowardRepos.Catalog.Repos
{
    public class CatalogRepo : IBaseRepository<Product>
    {
        private readonly CatalogContext _catalogContext;

        public CatalogRepo(CatalogContext catalogContext) : base(catalogContext) => _catalogContext = catalogContext;
    }
}
