using System.Diagnostics;

namespace BachelorProject.GameLogic
{
    public class PlayerCharacter
    {
        public string Name { get; set; } = "Bob";
        public int HP { get; set; } = 10;
        public List<Item> Inventory { get; set; } = [];
        public Area CurrentArea { get; set; }
        public SubArea CurrentSubArea { get; set; }

        public PlayerCharacter(string name, int hp)
        {
            Name = name;
            HP = hp;

            //CurrentArea = AreaSetup.SetupArea();
            //CurrentSubArea = CurrentArea.SubArea[0];
            //CurrentSubArea.Visit();
        }

        public PlayerCharacter(string name)
        {
            Name = name;
            HP = 10;

            //CurrentArea = FetchArea.FetchRestArea("Camping area").Result;
            //CurrentSubArea = CurrentArea.SubArea[0];
            //CurrentSubArea.Visit();
        }

        public void ChangeArea(SubArea? newArea, bool clearScreen = true)
        {
            if (newArea != null)
            {
                CurrentSubArea = newArea;
                newArea.Visit();
            }
            else
                Trace.Fail("No area was found");
            //if (clearScreen)
            //    DescriptionDisplay.ClearScreen();
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{item.GetDescription()} has been added to your inventory.");
        }

        public void RemoveItem(Item item)
        {
            if (Inventory.Remove(item))
            {
                Console.WriteLine($"{item.GetDescription()} has been removed from your inventory.");
            }
            else
            {
                Console.WriteLine($"{item.Name} is not in your inventory.");
            }
        }

        public void UseItem(string itemName, SubArea area)
        {
            Item? item = Inventory.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                item.UseItem();
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in your inventory.");
            }
        }

        public void ListInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("Inventory:");
                foreach (Item item in Inventory)
                {
                    Console.WriteLine($"- {item.Name}: {item.GetDescription()}");
                }
            }
        }
    }
}
