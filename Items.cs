using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    class Items
    {
        Item item = new Item();
        public Item GetItem(int ID)
        {
            switch (ID)
            {
                case 1:
                    item.count = 1;
                    item.name = "Sword";
                    return item;
                default:
                    item.count = 0;
                    item.name = " ";
                    return item;
            }
        }
    }
    class Item
    {
        public int count;
        public string name;
    }
}

