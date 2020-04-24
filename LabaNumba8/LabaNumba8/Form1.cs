using System;
using System.Windows.Forms;

namespace LabaNumba8
{
    public partial class Form1 : Form
    {

        public int water;
        public int house_water = 0;


        public void check_water()
        {
            if (Convert.ToInt32(water) + Convert.ToInt32(house_water) < 3000)  
            {
                String s = "WARNING, NOT ENOUGH WATER";
                MessageBox.Show(s, "ERROR");
            }
            if (Convert.ToInt32(house_water) >= 3001){
                String s = "В деревне уже достаточно воды, вы можете затопить её!";
                MessageBox.Show(s, "ERROR");
            }
            else
            {
                timer2.Enabled = !timer2.Enabled;
            }
        }
        public void send_button()
        {
            if (Convert.ToInt32(water) > 3000)
            {
                timer1.Stop();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != 1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    button1.Focus();
                return;
            }
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                water = Convert.ToInt32(textBox1.Text);
                check_water();
            }
            catch
            {
                textBox1.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.textBox1.Text = (water++).ToString();
            send_button();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (Convert.ToInt32(water) == 3000)
            {
                String s = "The water tank is already full";
                MessageBox.Show(s, "Error");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            this.label1.Text = (house_water++).ToString() + "/3000";
            this.textBox1.Text = (water--).ToString();
            if (Convert.ToInt32(house_water) > 3000)
            {
                timer2.Stop();
                String s = "Congratulations! You sent the water into the village!";
                MessageBox.Show(s, "Victory!");
            }
            else if (Convert.ToInt32(water) < 0)
            {
                timer2.Stop();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutTheProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = "В программе присутствуют две кнопки. Первая - количество воды, которое вводит юзер, второе - заправка резервуара, третье - вода в деревне.";
            MessageBox.Show(s, "Instructions");
        }

        private void resetVillageWaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Reset water", "Are you sure that you want to reset village water?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.label1.Text = (house_water = 0).ToString() + "/3000";
            }
            else if (dialogResult == DialogResult.No)
            {
              
            }
        }

        private void randomVillageWaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Random water", "Are you sure that you want to randomize village water?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Random rnd = new Random();
                int house_water = rnd.Next(0, 3000);
                this.label1.Text = (house_water).ToString() + "/3000";
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
    }
}
