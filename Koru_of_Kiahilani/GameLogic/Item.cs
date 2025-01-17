namespace BachelorProject.GameLogic
{
    public class Item(string name, string description, Item.ItemType itemType, bool action = false)
    {
        private readonly bool customAction = action;
        private readonly ItemType type = itemType; // TODO: Make this a thing.
        private readonly List<ItemAction> actions = [];

        public int damage = 0;
        public int value = 0;

        public string Name { get; set; } = name;
        public string Description { get; set; } = description;

        public enum ItemType
        {
            Consumable,
            Key,
            Weapon,
            Miscellaneous
        }

        public enum ItemAction
        {
            Heal,
            Unlock,
            Attack,
            Buff,
            None
        }

        public void AddAction(ItemAction action)
        {
            actions.Add(action);
        }

        public void UseItem()
        {
            if (!customAction)
            {
                Console.WriteLine("This item can't be used.");
            }
            else
            {
                foreach (ItemAction action in actions)
                {
                    switch (action)
                    {
                        case ItemAction.Heal:
                            Console.WriteLine("You used the item to heal.");
                            break;
                        case ItemAction.Unlock:
                            Console.WriteLine("You used the item to unlock something.");
                            break;
                        case ItemAction.Attack:
                            Console.WriteLine("You used the item to attack.");
                            break;
                        case ItemAction.Buff:
                            Console.WriteLine("You used the item to apply a buff.");
                            break;
                        case ItemAction.None:
                        default:
                            Console.WriteLine("This action does nothing.");
                            break;
                    }
                }
            }
        }

        public string GetDescription()
        {
            return Description;
        }
    }
}
