using System;
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
    public partial class ParentForm : Form
    {
        int top = -1;
        int count;
        List<Form> frm = new List<Form>();

        public ParentForm()
        {
            frm.Add(new Form1(this));
            frm.Add(new Form2(this));
            frm.Add(new Form3(this));
            count = frm.Count();
            InitializeComponent();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            Next();
        }

        private void LoadForm()
        {
            frm[top].TopLevel = false;
            frm[top].AutoScroll = true;
            frm[top].Dock = DockStyle.Fill;
            this.pnlContent.Controls.Clear();
            this.pnlContent.Controls.Add(frm[top]);
            frm[top].Show();
        }
        public void Next()
        {
            top++;
            LoadForm();
        }
        public void Back()
        {
            top--;
            LoadForm();
        }
    }
}
