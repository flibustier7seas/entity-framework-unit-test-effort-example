using System.Data.Entity;
using System.Linq;
using EntityFrameworkEffort.Model;
using NUnit.Framework;

namespace EntityFrameworkEffort.Infrastructure
{
    internal abstract class FixtureBase
    {
        private DbContext _dbContext;

        protected DataBuilder Database => new DataBuilder(_dbContext);

        protected Query Query => new Query(_dbContext);

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void RunBeforeEachTests()
        {
            EffortProviderFactory.ResetDb();
            _dbContext = new ContactDbContext();
        }

        [TearDown]
        public void RunAfterEachTests()
        {
            _dbContext.Dispose();
        }
    }

    internal sealed class Query
    {
        private readonly DbContext _dbContext;

        public Query(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> For<T>()
            where T: class
        {
            return _dbContext.Set<T>();
        }
    }

    internal sealed class DataBuilder
    {
        private readonly DbContext _dbContext;

        public DataBuilder(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataBuilder Has<T>(params T[] objects) where T : class
        {
            _dbContext.Set<T>().AddRange(objects ?? Enumerable.Empty<T>());
            return this;
        }

        public DataBuilder Apply()
        {
            _dbContext.SaveChanges();
            return this;
        }
    }
}