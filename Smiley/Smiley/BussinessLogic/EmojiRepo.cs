﻿using System;
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
    public class EmojiRepo
    {
        public void BringEmoji(FlowLayoutPanel Panel)
        {
            List<EmojiClass.RootObject> Liste = Program.JsonHelper.GetFromJson();
            foreach (EmojiClass.RootObject EmojiGroup in Liste)
            {
                Label lbl = Program.Helper.LabelProperty(EmojiGroup);
                Panel.Controls.Add(lbl);
                if (EmojiGroup.Items != null)
                {
                    foreach (EmojiClass.Item item in EmojiGroup.Items)
                    {
                        Button Btn = Program.Helper.ButonProperty(item);
                        Clipboard.SetText(item.Art + Environment.NewLine + item.Name);
                        Panel.Controls.Add(Btn);
                        Btn.MouseUp += new MouseEventHandler(Btn_MouseClick);

                    }
                }
            }
        }
        private void Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show(((Button)sender).Text);
            }
            if (e.Button == MouseButtons.Right)
            {
                var Result = MessageBox.Show("Silmek istediğinizden eminmisiniz", "Delete", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    string[] Text = ((Button)sender).Text.Split('\n');
                    DeleteEmoji(Text[2]);
                    Program.Helper.RefreshMailGrid(sender, e);
                }
            }
        }
        public void AddEmoji(string EmojiName, string Emoji, string CategoryName)
        {
            List<EmojiClass.RootObject> List = Program.JsonHelper.GetFromJson();

                foreach (EmojiClass.RootObject Group in List)
                {
                    if (Group.Category == CategoryName)
                    {   if(Group.Items==null)
                        Group.Items = new List<EmojiClass.Item>();

                    EmojiClass.Item x = new EmojiClass.Item();
                        x.Art = Emoji;
                        x.Name = EmojiName;
                        Group.Items.Add(x);
                    }
                }
               
            Program.JsonHelper.InsertJson(List);
        }
        public void AddGroup(string GroupName)
        {
            List<EmojiClass.RootObject> List = Program.JsonHelper.GetFromJson();
            EmojiClass.RootObject RootO = new EmojiClass.RootObject();
            RootO.Category = GroupName;
            List.Add(RootO);
            Program.JsonHelper.InsertJson(List);
        }
        public void DeleteEmoji(string Name)
        {
            List<EmojiClass.RootObject> List = Program.JsonHelper.GetFromJson();
            foreach (EmojiClass.RootObject Group in List)
            {
                try
                {
                    foreach (EmojiClass.Item item in Group.Items)
                    {
                        if (item.Name == Name)
                        {
                            Group.Items.Remove(item);
                            Program.JsonHelper.InsertJson(List);
                        }

                    }
                }
                catch {}
               
            }
        }
    }
}

