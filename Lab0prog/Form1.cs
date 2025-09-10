namespace Lab0prog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateDisk()
        {
            try
            {
                if (!double.TryParse(densityTextBox.Text, out double density) || density <= 0)
                {
                    resultTextBlock.Text = "Введите плотность > 0";
                    return;
                }

                if (!double.TryParse(radiusTextBox.Text, out double radius) || radius <= 0)
                {
                    resultTextBlock.Text = "Введите радиус > 0";
                    return;
                }

                if (!double.TryParse(massTextBox.Text, out double mass) || mass <= 0)
                {
                    resultTextBlock.Text = "Введите массу > 0";
                    return;
                }

                // h = m / (π * r² * ρ)
                double diskThick = mass / (Math.PI * Math.Pow(radius, 2) * density);

                resultTextBlock.Text = $"{diskThick:F6} м";
            }
            catch
            {
                resultTextBlock.Text = "Ошибка расчета";

            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateDisk();
        }
    }
}
