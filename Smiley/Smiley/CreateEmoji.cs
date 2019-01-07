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
    public partial class CreateEmoji : Form
    {
        public CreateEmoji()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Program.EmojiRepo.AddEmoji(textBoxName.Text, textBoxArt.Text, (string)comboBoxGroupName.SelectedItem);
            Program.Helper.RefreshMailGrid(sender, e);
        }

        public void CreateEmoji_Load(object sender, EventArgs e)
        {
           Program.Helper.CmBoxGroup(comboBoxGroupName);
        }

       
    }
}
