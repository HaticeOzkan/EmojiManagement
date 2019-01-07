using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smiley
{
    class Helperr
    {

       public Label LabelProperty(EmojiClass.RootObject EmojiGroup)
        {
            Label lbl = new Label();
            lbl.Text = EmojiGroup.Category;
            lbl.Font = new Font("Arial", 15, FontStyle.Bold);
            lbl.Height = 30;
            lbl.Width = 300;
            return lbl;
        }

        public Button ButonProperty(EmojiClass.Item item)
        {
            Button Btn = new Button();
            Btn.Height = 80;
            Btn.Width = 170;
            Btn.BackColor = Color.Pink;
            Btn.Text = item.Art + Environment.NewLine + Environment.NewLine + item.Name;
            return Btn;
        }
        public static void CmBoxGroup(ComboBox CmBx)
        {
            List<EmojiClass.RootObject> List = Program.JsonHelper.GetFromJson();
            foreach (EmojiClass.RootObject item in List)
            {
                CmBx.Items.Add(item.Category);
            }
        }
        public static void CmBoxEmoji(ComboBox CmBx)
        {
            List<EmojiClass.RootObject> List = Program.JsonHelper.GetFromJson();
            foreach (EmojiClass.RootObject Group in List)
            {
                foreach (var item in Group.Items)
                {
                    CmBx.Items.Add(item.Name);
                }

            }
        }


    }
}
