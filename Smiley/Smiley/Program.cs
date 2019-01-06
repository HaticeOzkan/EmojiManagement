using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smiley
{
    static class Program
    {
        public static EmojiRepo EmojiRepo = new EmojiRepo();
        public static Helperr Helper = new Helperr();
        public static JsonHelper JsonHelper = new JsonHelper();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Application.Run(new Form1());
        }
    }
}
