using System.Security.AccessControl;
using _Delivery;
 
namespace DelTest;

[TestClass]

public class DeliveryTest
{
    [TestMethod]
    public void SetId_ShouldSetString()
    {
        DeliveryContent content = new DeliveryContent();

        content.Id = "B-1064";

        string expected = "B-1094";
        string actual = content.Id;

        Assert.AreEqual(expected, actual);
    }
}

[TestClass]
public class delRepoTest
{
    private DelRepo _repo;

    private DeliveryContent _content;


    [TestInitialize]

    public void Arrange()
    {
        _repo = new DelRepo();
        _content = new DeliveryContent("(12/12/2023)","(12/15/2023)", "Complete", 7, 3, "B-1011");
    }

    [TestMethod]

    public void AddToList_ShouldGetNotNull()
    {
        // arrange 
        DeliveryContent content = new DeliveryContent();
        content.Id = "B-1039";
        DelRepo repository = new DelRepo();

        //act
        repository.AddContentToList(content);
        DeliveryContent contentDirectory = repository.GetContentById("B-1039");

        //assert
        Assert.IsNotNull(contentDirectory);
    }

    [TestMethod]

    public void UpdateExistingContent_ShouldReturnTrue()
    {
        DeliveryContent newContent = new DeliveryContent("(12/12/2023)","(12/15/2023)", "Complete", 7, 3, "B-1011");

        bool updateResult = _repo.UpdateContent("B-1011", newContent);

        Assert.IsTrue(updateResult);
    }

    [DataTestMethod]
    [DataRow("B-1011", true)]
    [DataRow("B-1039", false)]

    public void UpdateExistingContent_ShouldMatchGivenBool(string originalId, bool shouldUpdated)
    {
        DeliveryContent newContent = new DeliveryContent("(12/12/2023)","(12/15/2023)", "Complete", 7, 3, "B-1011");

        bool updateResult = _repo.UpdateContent(originalId, newContent);

        Assert.AreEqual(shouldUpdate, updateResult);
    }
}

