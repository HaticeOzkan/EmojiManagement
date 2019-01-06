using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Smiley
{
   public  class EmojiRepo
    {
        public void BringEmoji(List<EmojiClass.RootObject> Liste,FlowLayoutPanel Panel)
        {            
            foreach (EmojiClass.RootObject EmojiGroup in Liste)
            {
                Label lbl =Program.Helper.LabelProperty(EmojiGroup);
                Panel.Controls.Add(lbl);
                if (EmojiGroup.Items != null)
                {
                    foreach (EmojiClass.Item item in EmojiGroup.Items)
                    {
                        Button Btn = Program.Helper.ButonProperty(item);
                        Panel.Controls.Add(Btn);                       
                        Btn.MouseClick += new MouseEventHandler(Btn_MouseClick);
                       
                    }
                }               
            }
        }
        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("sol");
            }
            if (e.Button == MouseButtons.Right)
            {
              var Result = MessageBox.Show("Silmek istediğinizden eminmisiniz", "Delete", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                   // DeleteEmoji(Btn.Name);
                }
            }
        }
        public void AddEmoji(string EmojiName,string Emoji,string CategoryName)
        {
            List<EmojiClass.RootObject> List =Program.JsonHelper.GetFromJson();
            EmojiClass.Item Item= new EmojiClass.Item();
            Item.Art = Emoji;
            Item.Name = EmojiName;
            foreach (EmojiClass.RootObject Group in List)
            {
                if (Group.Category == CategoryName)
                {
                    Group.Items.Add(Item);
                }
            }
            Program.JsonHelper.InsertJson(List);
        }
        public void AddGroup(string GroupName)
        {
            List<EmojiClass.RootObject> List =Program.JsonHelper.GetFromJson();
            EmojiClass.RootObject RootO = new EmojiClass.RootObject();
            RootO.Category = GroupName;            
            List.Add(RootO);
            Program.JsonHelper.InsertJson(List);
        }
        public void DeleteEmoji(string Name)
        {
            List<EmojiClass.RootObject> List =Program.JsonHelper.GetFromJson();
            foreach (EmojiClass.RootObject Group in List)
            {
                foreach (EmojiClass.Item item in Group.Items)
                {
                    if (item.Name == Name)
                        Group.Items.Remove(item);
                }
            }
        }
       
    }
}
