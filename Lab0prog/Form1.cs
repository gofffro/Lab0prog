using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Lab0prog
{
    public partial class Form1 : Form
    {
        private List<Person> people = new List<Person>();
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateDisk()
        {
            try
            {
                double density;
                try
                {
                    density = ParseDoubleWithCommaSupport(densityTextBox.Text);
                }
                catch (FormatException)
                {
                    resultTextBlock.Text = "Ошибка: плотность должна быть числом";
                    densityTextBox.Focus();
                    return;
                }

                if (density <= 0)
                {
                    resultTextBlock.Text = "Ошибка: плотность должна быть > 0";
                    densityTextBox.Focus();
                    return;
                }

                if (density > 1E+100)
                {
                    resultTextBlock.Text = "Ошибка: слишком большая плотность";
                    densityTextBox.Focus();
                    return;
                }

                double radius;
                try
                {
                    radius = ParseDoubleWithCommaSupport(radiusTextBox.Text);
                }
                catch (FormatException)
                {
                    resultTextBlock.Text = "Ошибка: радиус должен быть числом";
                    radiusTextBox.Focus();
                    return;
                }

                if (radius <= 0)
                {
                    resultTextBlock.Text = "Ошибка: радиус должен быть > 0";
                    radiusTextBox.Focus();
                    return;
                }

                if (radius > 1E+100)
                {
                    resultTextBlock.Text = "Ошибка: слишком большой радиус";
                    radiusTextBox.Focus();
                    return;
                }

                double mass;
                try
                {
                    mass = ParseDoubleWithCommaSupport(massTextBox.Text);
                }
                catch (FormatException)
                {
                    resultTextBlock.Text = "Ошибка: масса должна быть числом";
                    massTextBox.Focus();
                    return;
                }

                if (mass <= 0)
                {
                    resultTextBlock.Text = "Ошибка: масса должна быть > 0";
                    massTextBox.Focus();
                    return;
                }

                if (mass > 1E+100)
                {
                    resultTextBlock.Text = "Ошибка: слишком большая масса";
                    massTextBox.Focus();
                    return;
                }

                double radiusSquared;

                try
                {
                    radiusSquared = Math.Pow(radius, 2);
                    if (double.IsInfinity(radiusSquared))
                    {
                        resultTextBlock.Text = "Ошибка: радиус слишком большой для вычислений";
                        radiusTextBox.Focus();
                        return;
                    }
                }
                catch (OverflowException)
                {
                    resultTextBlock.Text = "Ошибка: радиус слишком большой";
                    radiusTextBox.Focus();
                    return;
                }

                double denominator;
                try
                {
                    denominator = Math.PI * radiusSquared * density;
                    if (double.IsInfinity(denominator) || denominator == 0)
                    {
                        resultTextBlock.Text = "Ошибка: вычисления привели к недопустимому результату";
                        return;
                    }
                }
                catch (OverflowException)
                {
                    resultTextBlock.Text = "Ошибка: значения слишком большие для вычислений";
                    return;
                }

                double diskThickMeters;
                try
                {
                    diskThickMeters = mass / denominator;

                    if (double.IsInfinity(diskThickMeters) || double.IsNaN(diskThickMeters))
                    {
                        resultTextBlock.Text = "Ошибка: недопустимый результат вычислений";
                        return;
                    }

                    if (diskThickMeters > 1E+10)
                    {
                        resultTextBlock.Text = "Ошибка: толщина слишком большая (проверьте входные данные)";
                        return;
                    }
                }
                catch (DivideByZeroException)
                {
                    resultTextBlock.Text = "Ошибка: деление на ноль (проверьте входные данные)";
                    return;
                }
                catch (OverflowException)
                {
                    resultTextBlock.Text = "Ошибка: переполнение при вычислениях";
                    return;
                }

                double diskThickCm = diskThickMeters * 100;
                resultTextBlock.Text = $"{diskThickCm:F6} см";
            }
            catch (Exception ex)
            {
                resultTextBlock.Text = $"Неожиданная ошибка: {ex.Message}";
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateDisk();
        }

        private double ParseDoubleWithCommaSupport(string input)
        {
            string normalizedInput = input.Replace(',', '.');

            if (double.TryParse(normalizedInput, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            throw new FormatException("Некорректный числовой формат");
        }


        // второе задание

        public class Person
        {
            public string LastName { get; set; } = string.Empty;
            public string FirstName { get; set; } = string.Empty;
            public string Gender { get; set; } = string.Empty;
            public double Height { get; set; }
        }

        private List<Person> GeneratePeople(int count)
        {
            var peopleList = new List<Person>();
            var maleNames = new[] { "Иван", "Алексей", "Дмитрий", "Сергей", "Андрей", "Михаил" };
            var femaleNames = new[] { "Елена", "Анна", "Мария", "Ольга", "Наталья", "Ирина" };
            var lastMaleNames = new[] { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов", "Уткин" };
            var lastFemaleNames = new[] { "Иванова", "Петрова", "Сидорова", "Смирнова", "Кузнецова", "Попова", "Уткина" };

            for (int i = 0; i < count; ++i)
            {
                bool isMale = random.Next(2) == 0;

                string gender;

                if (isMale)
                {
                    gender = "Мужской";
                }
                else
                {
                    gender = "Женский";
                }

                string firstName;

                if (isMale)
                {
                    firstName = maleNames[random.Next(maleNames.Length)];
                }
                else
                {
                    firstName = femaleNames[random.Next(femaleNames.Length)];
                }

                double height;

                if (isMale)
                {
                    height = Math.Round(170 + random.NextDouble() * 30, 1);
                }
                else
                {
                    height = Math.Round(160 + random.NextDouble() * 25, 1);
                }

                string lastName;

                if (isMale)
                {
                    lastName = lastMaleNames[random.Next(lastMaleNames.Length)];
                }
                else
                {
                    lastName = lastFemaleNames[random.Next(lastFemaleNames.Length)];
                }

                var person = new Person
                {
                    LastName = lastName,
                    FirstName = firstName,
                    Gender = gender,
                    Height = height
                };

                peopleList.Add(person);
            }

            return peopleList;
        }

        private void SaveToJson(List<Person> people, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(people, options);
                File.WriteAllText(filePath, json);
                MessageBox.Show($"Данные сохранены в файл: {Path.GetFileName(filePath)}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Person> LoadFromJson(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new List<Person>();
                }

                string json = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<List<Person>>(json);

                if (result != null)
                {
                    var validPeople = new List<Person>();
                    int invalidCount = 0;

                    foreach (var person in result)
                    {
                        bool isValid = true;
                        string errorMessage = "";

                        if (string.IsNullOrWhiteSpace(person.LastName) ||
                            !System.Text.RegularExpressions.Regex.IsMatch(person.LastName, @"^[a-zA-Zа-яА-ЯёЁ\- ]+$"))
                        {
                            isValid = false;
                            errorMessage += "Некорректная фамилия ";
                        }

                        if (string.IsNullOrWhiteSpace(person.FirstName) ||
                            !System.Text.RegularExpressions.Regex.IsMatch(person.FirstName, @"^[a-zA-Zа-яА-ЯёЁ\- ]+$"))
                        {
                            isValid = false;
                            errorMessage += "Некорректное имя ";
                        }

                        if (person.Gender != "Мужской" && person.Gender != "Женский")
                        {
                            isValid = false;
                            errorMessage += "Некорректный пол ";
                        }

                        if (person.Height <= 0 || person.Height > 300) 
                        {
                            isValid = false;
                            errorMessage += "Некорректный рост ";
                        }

                        if (isValid)
                        {
                            validPeople.Add(person);
                        }
                        else
                        {
                            invalidCount++;
                            // Вывод некорректных записей
                            MessageBox.Show($"Некорректная запись: {person.LastName} {person.FirstName} - {errorMessage}", "Информация", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (invalidCount > 0)
                    {
                        MessageBox.Show($"Загружено {validPeople.Count} корректных записей.\n" +
                                       $"Пропущено {invalidCount} некорректных записей.",
                                       "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return validPeople;
                }
                else
                {
                    return new List<Person>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Person>();
            }
        }

        private (double avgMale, double avgFemale, Person tallestMan, Person tallestWoman) CalculateStatistics(List<Person> peopleList)
        {
            var validPeople = peopleList.Where(p => p.Height > 0).ToList();

            var men = validPeople.Where(p => p.Gender == "Мужской").ToList();
            var women = validPeople.Where(p => p.Gender == "Женский").ToList();

            double avgMale;
            if (men.Count > 0)
            {
                avgMale = men.Average(p => p.Height);
            }
            else
            {
                avgMale = 0;
            }

            double avgFemale;
            if (women.Count > 0)
            {
                avgFemale = women.Average(p => p.Height);
            }
            else
            {
                avgFemale = 0;
            }

            Person tallestMan;
            if (men.Count > 0)
            {
                tallestMan = men.OrderByDescending(p => p.Height).First();
            }
            else
            {
                tallestMan = new Person();
            }

            Person tallestWoman;
            if (women.Count > 0)
            {
                tallestWoman = women.OrderByDescending(p => p.Height).First();
            }
            else
            {
                tallestWoman = new Person();
            }

            return (avgMale, avgFemale, tallestMan, tallestWoman);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            people = GeneratePeople(6);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = people;
            MessageBox.Show($"Сгенерировано {people.Count} записей", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (people.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                saveDialog.DefaultExt = "json";
                saveDialog.FileName = "people.json";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveToJson(people, saveDialog.FileName);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openDialog.DefaultExt = "json";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    people = LoadFromJson(openDialog.FileName);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = people;

                    if (people.Count > 0)
                    {
                        MessageBox.Show($"Загружено {people.Count} корректных записей",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnCalculateStats_Click(object sender, EventArgs e)
        {
            if (people.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (avgMale, avgFemale, tallestMan, tallestWoman) = CalculateStatistics(people);

            lblAvgMale.Text = $"{avgMale:F1} см";
            lblAvgFemale.Text = $"{avgFemale:F1} см";

            if (tallestMan.Height > 0)
            {
                lblTallestMan.Text = $"{tallestMan.LastName} {tallestMan.FirstName} ({tallestMan.Height} см)";
            }
            else
            {
                lblTallestMan.Text = "Нет данных";
            }

            if (tallestWoman.Height > 0)
            {
                lblTallestWoman.Text = $"{tallestWoman.LastName} {tallestWoman.FirstName} ({tallestWoman.Height} см)";
            }
            else
            {
                lblTallestWoman.Text = "Нет данных";
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception is FormatException && e.ColumnIndex == 3)
                {
                    MessageBox.Show(
                        "Используйте запятые вместо точки для десятичных дробей.\nНапример: 180,5 вместо 180.5",
                        "Ошибка формата",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"Ошибка ввода данных:\n{e.Exception.Message}",
                        "Ошибка данных",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }

                e.ThrowException = false;

                if (dataGridView1.IsCurrentCellInEditMode)
                {
                    dataGridView1.CancelEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Неожиданная ошибка: {ex.Message}",
                    "Критическая ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dataGridView1_EditingControlShowing(object sender,
    DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.Aquamarine;
        }

        private void ValidateNameCell(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                string input = e.FormattedValue.ToString();

                if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Zа-яА-ЯёЁ\- ]+$"))
                {
                    MessageBox.Show("Можно вводить только буквы, дефисы и пробелы", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void ValidateGenderCell(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string input = e.FormattedValue.ToString().Trim();

                // Проверяем что только допустимые значения
                if (input != "Мужской" && input != "Женский")
                {
                    MessageBox.Show("Введите 'Мужской' или 'Женский'", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void ValidateHeightCell(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string input = e.FormattedValue.ToString().Replace(',', '.');

                if (!double.TryParse(input, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double height) || height <= 0)
                {
                    MessageBox.Show("Введите положительное число", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
    }
}