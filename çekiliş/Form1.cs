using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace çekiliş
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog=MessageBox.Show("Programı kapatmak istediğine emin misin?","Kapat",MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();

            }
            else
            {
                MessageBox.Show("Çıkış yapılmadı.");
            }
            
            
        }

        int tik_say = 0;

       
        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\muzik.wav";
            ses.SoundLocation = dizin;

            tik_say++;
            if(tik_say%2==1)
            {
                ses.Play();
                pic1.Visible = true;
                pic2.Visible = false;
            }
            else
            {
                ses.Stop();
                pic1.Visible=false;
                pic2.Visible = true;
            }
            
        }


        int kisi = 0;


     
        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Sorted = true;

            if (button1.Text == "GETİR")
            {
                button1.Text = "EKLE";
                lbl4.Text = checkedListBox1.CheckedItems[0].ToString();
                checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[0]);
            }


            else
            {

                
                if (textBox1.Text == "")
                {

                    MessageBox.Show("Film Söyle Lan!");

                    return;

                }
                else
                {


                    if (checkedListBox1.CheckedItems.Count == 0)
                    {
                        string met = textBox1.Text;
                        listBox1.Items.Add(lbl4.Text + " " + met);
                        button1.Enabled = false;
                        button4.Enabled = true;
                        textBox1.Enabled = false;
                        MessageBox.Show("Bütün katılımcılar film önerdi, çekiliş zamanı ;) ");
                        SoundPlayer ses = new SoundPlayer();
                        string dizin = Application.StartupPath + "\\eleme.wav";
                        ses.SoundLocation = dizin;
                        ses.Play();
                        button2.Enabled = false;

                    }
                    else
                    {


                        string met = textBox1.Text;
                        listBox1.Items.Add(lbl4.Text + " " + met);
                        textBox1.Clear();
                        textBox1.Focus();
                        lbl4.Text = checkedListBox1.CheckedItems[0].ToString();
                        checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[0]);
                    }
                }


            }
            



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {


                textBox1.Enabled = true;
                button1.Enabled = true;
                checkedListBox1.Enabled = false;
                textBox1.BackColor = Color.Green;
                



            }
            else
            {
                textBox1.Enabled = false;
                button1.Enabled = false;
                checkedListBox1.Enabled = true;
                textBox1.BackColor = Color.Red;
                lbl4.Text = "Öneren";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int adet = listBox1.Items.Count;
            Random rnd = new Random();
            int sayi = rnd.Next(0, adet);
            listBox1.SelectedIndex = sayi;
            MessageBox.Show("ELENEN FİLM" + " " + listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);

            if(listBox1.Items.Count==1)
            {
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\kazanan.wav";
                ses.SoundLocation = dizin;
                ses.Play();
                MessageBox.Show("KAZANAN FİLM!! İYİ SEYİRLER!!");
                button4.Enabled = false;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Text = "GETİR";
            button1.Enabled = true;
            checkedListBox1.ClearSelected();
            checkedListBox1.Enabled = true;
            listBox1.Items.Clear();
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            SoundPlayer ses = new SoundPlayer();
            string dizin = Application.StartupPath + "\\kazanan.wav";
            ses.SoundLocation = dizin;
            ses.Stop();
            button2.Enabled = true;
            textBox1.BackColor = Color.Red;
            checkBox1.Checked = false;
            pic1.Enabled = false;
            




        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {

        }
    }
}
