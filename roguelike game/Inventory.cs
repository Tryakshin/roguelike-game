
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

        public int InventoryCount() { return items.Count; }

        public void RemoveItem()
        {
            if (items.Count()==0)
            {
                Console.WriteLine("You do not have any potions left!");
            }
            else
            {
                items.RemoveAt(0);
            }
        }

    }
}
