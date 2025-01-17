using System.Text;

namespace BachelorProject.GameLogic
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">Name of sub-area</param>
    /// <param name="description">Description of sub-area</param>
    public class SubArea(string name, string description)
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public List<SubArea> ConnectedAreas { get; } = [];
        public string ConnectLater { get; set; } = ""; // HACK: It doesn't work as a list for the json file.
        public List<Item> Items { get; set; } = [];
        public List<NPC> Npcs { get; set; } = [];
        public List<string> Events { get; set; } = [];
        public bool Visited { get; set; } = false;
        public List<string> AmbientDescriptions { get; set; } = [];
        public Dictionary<string, string> TraversalRestrictions { get; set; } = [];

        public void SetConnections(SubArea newConnection)
        {
            if (ConnectedAreas.Contains(newConnection))
                return;
            else
                ConnectedAreas.Add(newConnection);
            if (newConnection.ConnectedAreas.Contains(newConnection))
                return;
            else
                newConnection.ConnectedAreas.Add(this);
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void AddNpc(NPC npc)
        {
            Npcs.Add(npc);
        }

        public void AddEvent(string eventDescription)
        {
            Events.Add(eventDescription);
        }

        public void SetTraversalRestriction(string direction, string restriction) //TODO: Implement travel restrictions.
        {
            TraversalRestrictions[direction] = restriction;
        }

        public bool CanTraverse(string direction)
        {
            return !TraversalRestrictions.ContainsKey(direction);
        }

        public void Visit()
        {
            Visited = true;
        }

        public bool HasBeenVisited()
        {
            return Visited;
        }

        public void AddAmbientDescription(string description)
        {
            AmbientDescriptions.Add(description);
        }

        public string GetAmbientDescription()
        {
            if (AmbientDescriptions.Count == 0) return "";
            Random rand = new();
            return AmbientDescriptions[rand.Next(AmbientDescriptions.Count)];
        }

        public string? GetItems()
        {
            List<string> input = [];
            foreach (Item item in Items)
            {
                input.Add(item.Name);
            }
            return GetResult(input);
        }

        private static string? GetResult(List<string> input)
        {
            StringBuilder result = new(); // Use StringBuilder for efficient string concatenation.
            if (input.Count >= 1)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    string item = input[i];

                    // Add the item's information to the result.
                    result.Append(item);

                    // Check if this is not the last item.
                    if (i != input.Count - 1)
                    {
                        result.Append(", "); // Add a comma separator between items.
                    }
                }
                return result.ToString();
            }
            else
                return null;
        }

        public string GetExits()
        {
            List<string> exits = [];
            foreach (SubArea connection in ConnectedAreas)
            {
                exits.Add(connection.Name);
            }

            string? result = GetResult(exits);

            if (!string.IsNullOrWhiteSpace(result))
                return result;
            else
                return "Nowhere.";
        }

        public string? GetNPC()
        {
            List<string> Input = [];
            foreach (NPC npc in Npcs)
            {
                Input.Add(npc.Name);
            }
            return GetResult(Input);
        }
    }
}
