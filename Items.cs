namespace AbyssBehaviours
{
    class Items
    {
        public Item GetItem(int ID)
        {
            Item item = new Item();
            switch (ID)
            {
                case 0:
                    item.count = 0;
                    item.name = "Empty";
                    item.rarity = Item.Rare.Common;
                    return item;
                case 1:
                    item.count = 1;
                    item.name = "Sword";
                    item.rarity = Item.Rare.Rare;
                    return item;
                default:
                    item.count = 0;
                    item.name = "";
                    item.rarity = Item.Rare.Common;
                    return item;
            }
        }
    }
    class Item
    {
        public int count;
        public string name;

        public Rare rarity;

        public enum Rare{
            Common = 15,
            Uncommon = 7,
            Rare = 9,
            Legendary = 14,
            Void = 13
        }
    }
}

