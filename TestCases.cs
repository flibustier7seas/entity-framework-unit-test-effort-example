using System.Linq;
using EntityFrameworkEffort.Infrastructure;
using EntityFrameworkEffort.Model;
using NUnit.Framework;

namespace EntityFrameworkEffort
{
    [TestFixture]
    internal class TestCases : FixtureBase
    {
        [Test]
        public void Test()
        {
            Database
                .Has(new Contact { Name = "Notepad" })
                .Has(new Contact { Name = "Pencil" },
                     new Contact { Name = "Pen" },
                     new Contact { Name = "Pear" })
                .Apply();

            var contacts = Query.For<Contact>().ToList();
            Assert.AreEqual(contacts.Count, 4);
        }
    }
}
