using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Smiley
{
    class JsonHelper
    {
        public JavaScriptSerializer Translator { get; set; }
        public List<EmojiClass.RootObject> CategoryList { get; set; }


        public JsonHelper()
        {
            Translator = new JavaScriptSerializer();
            CategoryList = new List<EmojiClass.RootObject>();


        }
        public List<EmojiClass.RootObject> GetFromJson()
        {
            string Text = File.ReadAllText("../../Emoji.json");
            CategoryList = Translator.Deserialize<List<EmojiClass.RootObject>>(Text);
            return CategoryList;
        }
        public void InsertJson(List<EmojiClass.RootObject> List)
        {
            File.WriteAllText("../../Emoji.json", "");
            string Text = Translator.Serialize(List);
            File.WriteAllText("../../Emoji.json", Text);
        }
    }
}
