

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }
        public int Count { get { return this.Shoes.Count; } }

        
        public string AddShoe(Shoe shoe)
        {
            if (StorageCapacity > 0)
            {
                Shoes.Add(shoe);
                StorageCapacity--;
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            else
            {
                return "No more space in the storage room.";
            }
        }
        public int RemoveShoes(string material)
        {
            int removedCount = Shoes.RemoveAll(shoe => shoe.Material == material);
            StorageCapacity += removedCount;
            return removedCount;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            string searchType = type.ToLower(); 

            List<Shoe> matchingShoes = Shoes.Where(shoe => shoe.Type.ToLower() == searchType).ToList();
            return matchingShoes;
        }
        public Shoe GetShoeBySize(double size)
        {
            Shoe shoe = Shoes.Where(s => s.Size == size).FirstOrDefault();
            return shoe;
        }
        public string StockList(double size, string type)
        {
            string searchType = type.ToLower();

            List<Shoe> stockList = Shoes.FindAll(shoe => shoe.Size == size && shoe.Type.ToLower() == searchType);
            if (stockList.Count > 0)
            {
                return $"Stock list for size {size} - {type} shoes:{Environment.NewLine}" 
                    + string.Join(Environment.NewLine, stockList);                   
            }
            else
            {
                return "No matches found!";
            }
        }
    }
}
