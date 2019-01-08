using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smiley
{
    public partial class UpdateEmoji : Form
    {
        public UpdateEmoji()
        {
            InitializeComponent();
        }

        private void UpdateEmoji_Load(object sender, EventArgs e)
        {
          
            Program.Helper.CmBoxGroup(comboBoxCategory);
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.Helper.CmBoxEmoji(comboBoxEmoji, comboBoxCategory.SelectedItem.ToString());
        }

        private void comboBoxEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Text= comboBoxEmoji.SelectedItem.ToString();
            string[] Parts = Text.Split('\n');
            textBoxName.Text = Parts[0];
            textBoxArt.Text = Parts[1];
            Program.EmojiRepo.DeleteEmoji(Parts[0]);

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Program.EmojiRepo.AddEmoji(textBoxName.Text, textBoxArt.Text, comboBoxCategory.SelectedItem.ToString());
            Program.Helper.RefreshMailGrid(sender, e);

        }

       

      
    }
}
