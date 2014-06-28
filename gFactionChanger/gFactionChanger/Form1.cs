using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gFactionChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        gFactiond gFactiond = new gFactiond();

        string path;
        UInt16 version;
        int[] lst = new int[12];

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = "",
                Title = "Загрузка gfaction",
                Filter = "gfactiond|gfactiond|Все файлы|*.*"
            };
            if (open.ShowDialog() != DialogResult.Cancel)
            {
                path = open.FileName;
                label17.ForeColor = Color.Red;

                this.Text = "gFaction Changer (" + open.FileName + ")";
                
                using (BinaryReader read = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
                {
                    read.BaseStream.Position = 252;
                    version = read.ReadUInt16();
                    switch (version)
                    {
                        case 20720:
                            {
                                label17.Text = "1.2.6";
                                Reader(read, 424810, 833008, 833028);
                                break;
                            }
                        case 49864:
                            {
                                label17.Text = "1.3.1";
                                Reader(read, 390758, 779632, 779652);
                                break;
                            }
                        case 17128:
                            {
                                label17.Text = "1.4.4";
                                Reader(read, 536106, 1041976, 1041996);
                                break;
                            }
                        case 17224:
                            {
                                label17.Text = "1.4.5";
                                Reader(read, 536154, 1041976, 1041996);
                                break;
                            }
                        case 17256:
                            {
                                label17.Text = "1.4.6 (70)";
                                Reader(read, 537010, 1041976, 1041996);
                                break;
                            }
                        case 33640:
                            {
                                label17.Text = "1.4.6 (80)";
                                Reader(read, 548726, 1057016, 1057036);
                                break;
                            }
                        case 5064:
                            {
                                label17.Text = "1.4.8";
                                Reader(read, 564638, 1098684, 1098704);
                                break;
                            }
                        case 5800:
                            {
                                label17.Text = "1.5.0";
                                Reader(read, 565030, 1099516, 1099536);
                                break;
                            }
                        case 7528:
                            {
                                label17.Text = "1.5.1 (101)";
                                Reader(read, 565626, 1101372, 1101392);
                                break;
                            }
                    }
                    read.Close();
                }
                textBox2.Text = lst[1].ToString();
                textBox3.Text = lst[2].ToString();
                textBox4.Text = lst[3].ToString();
                textBox5.Text = lst[4].ToString();
                textBox6.Text = lst[5].ToString();
                textBox7.Text = lst[6].ToString();
                textBox8.Text = lst[7].ToString();
                textBox9.Text = lst[8].ToString();
                textBox10.Text = lst[9].ToString();
                textBox11.Text = lst[10].ToString();
                textBox12.Text = lst[11].ToString();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (BinaryWriter write = new BinaryWriter(new FileStream(path, FileMode.Open, FileAccess.Write)))
                {
                    switch (version)
                    {
                        case 20720: Writer(write, 424810, 833008, 833028); break;
                        case 49864: Writer(write, 390758, 779632, 779652); break;
                        case 17128: Writer(write, 536106, 1041976, 1041996); break;
                        case 17224: Writer(write, 536154, 1041976, 1041996); break;
                        case 17256: Writer(write, 537010, 1041976, 1041996); break;
                        case 33640: Writer(write, 548726, 1057016, 1057036); break;
                        case 5064: Writer(write, 564638, 1098684, 1098704); break;
                        case 5800: Writer(write, 565030, 1099516, 1099536); break;
                        case 7528: Writer(write, 565626, 1101372, 1101392); break;
                    }
                    write.Close();
                }
                MessageBox.Show("Файл успешно пропатчен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "gFaction Changer";
            gFactiond.getFormController().setEditData(textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12);
            gFactiond.getFormController().setEditTime(numericUpDown1, numericUpDown2, numericUpDown3);
            gFactiond.getFormController().setVersionText(label17);
        }

        private void Writer(BinaryWriter write, int pos1, int pos2, int pos3)
        {
            write.BaseStream.Position = pos1;
            write.Write(lst[0]);
            write.BaseStream.Position = pos2;
            for (int i = 1; i < 4; i++)
                write.Write(lst[i]);
            write.BaseStream.Position = pos3;
            for (int i = 4; i < 12; i++)
                write.Write(lst[i]);
        }

        private void Reader(BinaryReader read, int pos1, int pos2, int pos3)
        {
            read.BaseStream.Position = pos1;
            lst[0] = read.ReadInt32();
            read.BaseStream.Position = pos2;
            for (int i = 1; i < 4; i++)
                lst[i] = read.ReadInt32();
            read.BaseStream.Position = pos3;
            for (int i = 4; i < 12; i++)
                lst[i] = read.ReadInt32();
            Time(lst[0]);
        }

        private void Time(int seconds)
        {
            int secs = 0, mins = 0, hours = 0;
            for (int i = 0; i < seconds; i++)
            {
                secs++;
                if (secs > 59)
                {
                    secs = 0;
                    mins++;
                    if (mins > 59)
                    {
                        mins = 0;
                        hours++;
                    }
                }
            }
            numericUpDown1.Value = hours;
            numericUpDown2.Value = mins;
            numericUpDown3.Value = secs;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            lst[1] = Int32.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            lst[2] = Int32.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            lst[3] = Int32.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            lst[4] = Int32.Parse(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            lst[5] = Int32.Parse(textBox6.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            lst[6] = Int32.Parse(textBox7.Text);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            lst[7] = Int32.Parse(textBox8.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            lst[8] = Int32.Parse(textBox9.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            lst[9] = Int32.Parse(textBox10.Text);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            lst[10] = Int32.Parse(textBox11.Text);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            lst[11] = Int32.Parse(textBox12.Text);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lst[0] = Convert.ToInt32(numericUpDown1.Value * 3600 + numericUpDown2.Value * 60 + numericUpDown3.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            lst[0] = Convert.ToInt32(numericUpDown1.Value * 3600 + numericUpDown2.Value * 60 + numericUpDown3.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            lst[0] = Convert.ToInt32(numericUpDown1.Value * 3600 + numericUpDown2.Value * 60 + numericUpDown3.Value);
        }
    }
}
