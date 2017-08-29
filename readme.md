# Effort - Entity Framework Unit Testing Tool - Example

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

    var products = Query.For<Contact>().ToList();
    Assert.AreEqual(products.Count, 4);
}
```