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
            var lastMaleNames = new[] { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов", "Уткин"};
            var lastFemaleNames = new[] { "Иванова", "Петрова", "Сидорова", "Смирнова", "Кузнецова", "Попова", "Уткина" };

            for (int i = 0; i < count; ++i)
            {
                bool isMale = random.Next(2) == 0;

                string gender;

                if (isMale)
                {
                    gender = "Мужчина";
                }
                else
                {
                    gender = "Женщина";
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
                    return result;
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
            var men = peopleList.Where(p => p.Gender == "Мужчина").ToList();
            var women = peopleList.Where(p => p.Gender == "Женщина").ToList();

            double avgMale;

            if (men.Any())
            {
                avgMale = men.Average(p => p.Height);
            }

            else
            {
                avgMale = 0;
            }

            double avgFemale;

            if (women.Any())
            {
                avgFemale = women.Average(p => p.Height);
            }
            else
            {
                avgFemale = 0;
            }

            Person tallestMan;

            if (men.OrderByDescending(p => p.Height).FirstOrDefault() != null)
            {
                tallestMan = men.OrderByDescending(p => p.Height).FirstOrDefault();
            }
            else
            {
                tallestMan = new Person();
            }


            Person tallestWoman;
            if (women.OrderByDescending(p => p.Height).FirstOrDefault() != null)
            {
                tallestWoman = women.OrderByDescending(p => p.Height).FirstOrDefault();
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
                    MessageBox.Show($"Загружено {people.Count} записей", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}