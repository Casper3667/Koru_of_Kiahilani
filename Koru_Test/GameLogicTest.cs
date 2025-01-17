using BachelorProject.GameLogic;

namespace Koru_Test;

[TestClass]
public class GameLogicTest
{
    [TestMethod]
    public void ItemInitializationTest()
    {
        // Arrange
        string Name = "Health Potion";
        string Description = "Restores health";
        Item.ItemType Type = Item.ItemType.Consumable;
        bool Action = true;

        // Act
        Item NewItem = new(Name, Description, Type, Action);

        // Assert
        Assert.AreEqual(Name, NewItem.Name);
        Assert.AreEqual(Description, NewItem.Description);
    }
}
