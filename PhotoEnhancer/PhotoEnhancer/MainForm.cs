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
        Photo originalPhoto;
        Photo resultPhoto;
        List<NumericUpDown> parametrControls;
        public MainForm()
        {
            InitializeComponent();

            //comboBoxFilters.Items.Add("Осветление/затемнение");

            LoadPicture((Bitmap)Image.FromFile("cat.jpg"));
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

            var filter = comboBoxFilters.SelectedItem as IFilter;

            if (filter == null)
                return;
            else
            {
                parametrControls = new List<NumericUpDown>();

                var paramsInfo = filter.GetParametersInfo();
                for (var i = 0; i < paramsInfo.Length; i++)
                {
                    var label = new Label();
                    label.Height = 20;
                    label.Width = parametresPanel.Width - 50;
                    label.Left = 0;
                    label.Top = i * (label.Height + 10);
                    label.Text = paramsInfo[i].Name;
                    parametresPanel.Controls.Add(label);

                    var inputBox = new NumericUpDown();
                    inputBox.Width = 50;
                    inputBox.Height = label.Height;
                    inputBox.Left = label.Right;
                    inputBox.Top = label.Top;
                    inputBox.DecimalPlaces = 2;
                    inputBox.Minimum = (decimal)paramsInfo[i].MinValue;
                    inputBox.Maximum = (decimal)paramsInfo[i].MaxValue;
                    inputBox.Increment = (decimal)paramsInfo[i].Increment;
                    inputBox.Value = (decimal)paramsInfo[i].DefailtValue;
                    parametrControls.Add(inputBox);
                    parametresPanel.Controls.Add(inputBox);
                }
            }


            //if (filter.ToString() == "Осветление/затемнение")
            //{
            //    //MessageBox.Show("Фильтр осветления/затемнения");

            //    //parametresPanel.BackColor = Color.Aquamarine;

            //    var label = new Label();
            //    label.Left = 0;
            //    label.Top = 0;
            //    label.Width = parametresPanel.Width - 50;
            //    label.Height = 20;
            //    label.Text = "Коэффициент";
            //    parametresPanel.Controls.Add(label);

            //    var inputBox = new NumericUpDown();
            //    inputBox.Left = label.Right;
            //    inputBox.Top = label.Top;
            //    inputBox.Width = 50;
            //    inputBox.Height = label.Height;
            //    inputBox.Minimum = 0;
            //    inputBox.Maximum = 10;
            //    inputBox.Increment = (Decimal)0.05;
            //    inputBox.DecimalPlaces = 2;
            //    inputBox.Value = 1;
            //    inputBox.Name = "coefficient";
            //    parametresPanel.Controls.Add(inputBox);
            //}

            this.Controls.Add(parametresPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);

            if(comboBoxFilters.SelectedItem.ToString() == "Осветление/затемнение")
            {
                var k = (double)((NumericUpDown)parametresPanel.Controls["coefficient"]).Value;

                for (int x = 0; x < originalPhoto.Width; x++)
                    for(int y = 0; y < originalPhoto.Height; y++)
                    {
                        newPhoto[x, y] = originalPhoto[x, y] * k;
                    }
            }

            resultPhoto = newPhoto;
            pictureBoxResult.Image = Convertors.Photo2Bitmap(resultPhoto);
        }

        private void LoadPicture(Bitmap bmp)
        {
            originalPhoto = Convertors.Bitmap2Photo(bmp);
            pictureBoxOriginal.Image = bmp;
            pictureBoxResult.Image = null;

        }

        public void AddFilter(IFilter filter)
        {
            comboBoxFilters.Items.Add(filter);
            if (comboBoxFilters.SelectedIndex == -1)
                comboBoxFilters.SelectedIndex = 0;
        }
    }
}
