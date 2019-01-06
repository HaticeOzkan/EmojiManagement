using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smiley
{
   public class EmojiClass
    {
        public class Item
        {
            public string Name { get; set; }
            public string Art { get; set; }
        }

        public class RootObject
        {
            public string Category { get; set; }
            public List<Item> Items { get; set; }
        }
    }
}
