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
    public partial class Create : Form
    {
        public Create()
        {
            InitializeComponent();
        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            new CreateEmoji().Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            new CreateCategory().Show();
        }
    }
}
