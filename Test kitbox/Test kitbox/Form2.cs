﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_kitbox
{
    public partial class Form2 : Form
    {
        ParentForm parent;

        public Form2(ParentForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            parent.Next();
        }
    }
}