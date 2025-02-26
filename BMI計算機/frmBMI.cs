using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class frmBMI : Form
    {
        public frmBMI()
        {
            InitializeComponent();
        }

        // Event handler for the Run button click event
        private void btnRun_Click(object sender, EventArgs e)
        {
            // Validate height input
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            // Validate weight input
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);

            // Show error message if height input is invalid
            if (!isHeightValid)
            {
                MessageBox.Show("身高的輸入錯誤。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Show error message if weight input is invalid
            if (!isWeightValid)
            {
                MessageBox.Show("體重的輸入錯誤。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert height from cm to meters
            height /= 100;

            // Calculate BMI
            double bmi = weight / (height * height);

            // Define result categories and corresponding colors
            string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖", "中度肥胖", "重度肥胖" };
            Color[] colorList = { Color.Blue, Color.Green, Color.Orange, Color.DarkOrange, Color.Red, Color.Purple };

            string strResult = "";
            Color colorResult = Color.Black;
            int resultIndex = 0;

            // Determine BMI category
            if (bmi < 18.5)
            {
                resultIndex = 0;
            }
            else if (bmi < 24)
            {
                resultIndex = 1;
            }
            else if (bmi < 27)
            {
                resultIndex = 2;
            }
            else if (bmi < 30)
            {
                resultIndex = 3;
            }
            else if (bmi < 35)
            {
                resultIndex = 4;
            }
            else
            {
                resultIndex = 5;
            }

            // Get result string and color based on BMI category
            strResult = strResultList[resultIndex];
            colorResult = colorList[resultIndex];

            // Display BMI result and set background color
            lblResult.Text = $"{bmi:F2} ({strResult})";
            lblResult.BackColor = colorResult;
        }
    }
}

