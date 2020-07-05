using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace summer_practic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomizeDesing();
        }

        private void CustomizeDesing()
        {
            panelSkladSubmenu.Visible = false;
            panelDocsSubmenu.Visible = false;
        }
        private void HideSubmenu()
        {
            if (panelSkladSubmenu.Visible == true)
            {
                panelSkladSubmenu.Visible = false;
            }
            if (panelDocsSubmenu.Visible == true)
            {
                panelDocsSubmenu.Visible = false;
            }
        }
        private void ShowSubmenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                HideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void buttonSklad_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelSkladSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());
            //some code
            HideSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            //some code
            HideSubmenu();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //some code
            HideSubmenu();

        }

        private void buttonDocs_Click(object sender, EventArgs e)
        {
            ShowSubmenu(panelDocsSubmenu);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //some code
            HideSubmenu();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //some code
            HideSubmenu();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //some code
            HideSubmenu();

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
