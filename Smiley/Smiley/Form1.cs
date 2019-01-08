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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanelEmoji.Controls.Clear();  
            Program.EmojiRepo.BringEmoji(flowLayoutPanelEmoji);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Create().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new UpdateEmoji().Show();
        }
    }
}
