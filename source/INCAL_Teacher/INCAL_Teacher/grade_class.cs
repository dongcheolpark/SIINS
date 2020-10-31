using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INCAL_Teacher
{
    public partial class grade_class : Form
    {
        public bool[] grade_checked = new bool[4];
        public bool[] class_checked = new bool[10];
        CheckBox[] class_arr;
        public grade_class()
        {
            InitializeComponent();
        }
        
        private void grade_class_Load(object sender, EventArgs e)
        {
            class_arr = new CheckBox[9]
            {
                class1_CheckBox,class2_CheckBox,
                class3_CheckBox,class4_CheckBox,
                class5_CheckBox,class6_CheckBox,
                class7_CheckBox,class8_CheckBox,
                class9_CheckBox,
            };
        }

        private void class_GroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void grade1_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            grade_checked[1] = grade1_CheckBox.Checked;
        }

        private void grade2_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            grade_checked[2] = grade2_CheckBox.Checked;
        }

        private void grade3_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            grade_checked[3] = grade3_CheckBox.Checked;
        }

        private void class1_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[1] = class1_CheckBox.Checked;
        }

        private void class2_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[2] = class2_CheckBox.Checked;
        }

        private void class3_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[3] = class3_CheckBox.Checked;
        }

        private void class4_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[4] = class4_CheckBox.Checked;
        }

        private void class5_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[5] = class5_CheckBox.Checked;
        }

        private void class6_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[6] = class6_CheckBox.Checked;
        }

        private void class7_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[7] = class7_CheckBox.Checked;
        }

        private void class8_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[8] = class8_CheckBox.Checked;
        }

        private void class9_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            class_checked[9] = class9_CheckBox.Checked;
        }

        private void all_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool a = all_CheckBox.Checked;
            foreach (var item in class_arr)
            {
                item.Checked = a;
            }
        }
    }
}
