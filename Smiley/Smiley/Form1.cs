﻿using System;
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

        private void Form1_Load(object sender, EventArgs e)
        {           
            Program.EmojiRepo.BringEmoji(Program.JsonHelper.GetFromJson(), flowLayoutPanelEmoji);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Create().Show();
        }

        
    }
}
