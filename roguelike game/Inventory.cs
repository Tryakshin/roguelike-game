
namespace roguelike_game
{
    public class Inventory
    {
        private List<Entity> items = new List<Entity>();
        private int capacity;

        public Inventory(int capacity)
        {
            this.capacity = capacity;
        }

        public bool AddItem(Entity item)
        {
            if (items.Count < capacity)
            {
                items.Add(item);
                return true;
            }
            else
            {
                Console.WriteLine("Inventory is full.");
                return false;
            }
        }

        public bool RemoveItem(Entity item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                return true;
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
                return false;
            }
        }

    }
}
