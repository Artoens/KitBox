﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitBoxMag
{
    public partial class DataTab : Form
    {
        public Panel pnl;
        public Panel Pnl { get => pnl; set => pnl = value; }

        public DataTab()
        {
            InitializeComponent();
            this.pnl = panel1;
        }
    }

}