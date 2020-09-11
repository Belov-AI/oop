using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public partial class MainForm : Form
    {
        Panel parametresPanel;
        Bitmap originalBmp;
        Bitmap resultBmp;
        public MainForm()
        {
            InitializeComponent();

            comboBoxFilters.Items.Add("Осветление/затемнение");
            comboBoxFilters.Items.Add("");

            //pictureBoxOriginal.Image = Image.FromFile("cat.jpg");
            originalBmp = (Bitmap)Image.FromFile("cat.jpg");
            pictureBoxOriginal.Image = originalBmp;
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (parametresPanel != null)
                this.Controls.Remove(parametresPanel);

            parametresPanel = new Panel();

            parametresPanel.Left = comboBoxFilters.Left;
            parametresPanel.Width = comboBoxFilters.Width;
            parametresPanel.Top = comboBoxFilters.Bottom + 10;
            parametresPanel.Height = buttonApply.Top - comboBoxFilters.Bottom - 20;

            var filter = comboBoxFilters.SelectedItem;

            if (filter.ToString() == "Осветление/затемнение")
            {
                //MessageBox.Show("Фильтр осветления/затемнения");

                //parametresPanel.BackColor = Color.Aquamarine;

                var label = new Label();
                label.Left = 0;
                label.Top = 0;
                label.Width = parametresPanel.Width - 50;
                label.Height = 20;
                label.Text = "Коэффициент";
                parametresPanel.Controls.Add(label);

                var inputBox = new NumericUpDown();
                inputBox.Left = label.Right;
                inputBox.Top = label.Top;
                inputBox.Width = 50;
                inputBox.Height = label.Height;
                inputBox.Minimum = 0;
                inputBox.Maximum = 10;
                inputBox.Increment = (Decimal)0.05;
                inputBox.DecimalPlaces = 2;
                inputBox.Value = 1;
                inputBox.Name = "coefficient";
                parametresPanel.Controls.Add(inputBox);
            }
            else
            {
                //parametresPanel.BackColor = this.BackColor;
            }

            this.Controls.Add(parametresPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            var newBmp = new Bitmap(originalBmp.Width, originalBmp.Height);

            if(comboBoxFilters.SelectedItem.ToString() == "Осветление/затемнение")
            {
                for(int x = 0; x < originalBmp.Width; x++)
                    for(int y = 0; y < originalBmp.Height; y++)
                    {
                        var pixelColor = originalBmp.GetPixel(x, y);

                        var k = (double)((NumericUpDown)parametresPanel.Controls["coefficient"]).Value;
                        
                        var newR = (int)(pixelColor.R * k);
                        if (newR > 255) newR = 255;

                        var newG = (int)(pixelColor.G * k);
                        if (newG > 255) newG = 255;

                        var newB = (int)(pixelColor.B * k);
                        if (newB > 255) newB = 255;



                        newBmp.SetPixel(x, y,
                            Color.FromArgb(newR, newG, newB));
                        
                        
                    }
            }



            //using (var g = Graphics.FromImage(newBmp))
            //{
            //    g.DrawImage(resultBmp,
            //        new Rectangle(0, 0, newBmp.Width, newBmp.Height));

            //}



            resultBmp = newBmp;
            pictureBoxResult.Image = resultBmp;
        }
    }
}
