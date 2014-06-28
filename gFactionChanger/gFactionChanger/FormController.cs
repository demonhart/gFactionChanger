using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gFactionChanger
{
    class FormController
    {
        private TextBox[] EditData = new TextBox[11];
        private NumericUpDown[] EdtiTime = new NumericUpDown[3];
        private Label version;

        public void setEditData(params TextBox[] data)
        {
            for (int i = 0; i < EditData.Length; i++)
                EditData[i] = data[i];
        }

        public TextBox[] getEditData()
        {
            return this.EditData;
        }

        public void setEditTime(params NumericUpDown[] time)
        {
            for (int i = 0; i < EdtiTime.Length; i++)
                EdtiTime[i] = time[i];
        }

        public NumericUpDown[] getEditTime()
        {
            return this.EdtiTime;
        }

        public void setVersionText(Label version)
        {
            this.version = version;
        }

        public Label getVersionText()
        {
            return this.version;
        }
    }
}
