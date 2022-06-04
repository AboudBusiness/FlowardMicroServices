using FlowardEntities.Catalog.Models;
using FlowardRepos.Catalog.Repos;
using FlowardRepos.Repos;
using FlowardServices.Catalog.Interfaces;
using FlowardServices.Implementations;

namespace FlowardServices.Catalog.Implementations
{
    public class CatalogService : BaseService<Product>, ICatalogService
    {
        private CatalogRepo? _catalogRepo;

        public CatalogService(IBaseRepoitory<Product> repository): base(repository) { }
    }
}
