using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SyncScopeProvision
{
    public partial class frmReadTheText : Form
    {
        public frmReadTheText(string objTextToRead)
        {
            InitializeComponent();
            this.richTextBox1.Text = objTextToRead;
        }
    }
}
