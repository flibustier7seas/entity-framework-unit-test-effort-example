# Effort - Entity Framework Unit Testing Tool - Example

Article: https://blog.goyello.com/2016/07/14/save-time-mocking-use-your-real-entity-framework-dbcontext-in-unit-tests/

```
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
```