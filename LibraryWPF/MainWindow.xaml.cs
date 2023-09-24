using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SerializeDesLib;

namespace LibraryWPF
{
    public partial class MainWindow : Window
    {
        private List<Person> people;
        public string filename = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\people.json";
        public MainWindow()
        {
            InitializeComponent();
            people = new List<Person>();
            FileGrid.ItemsSource = people;
        }

        private void SerializeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(AgeTextBox.Text))
            {
                if (int.TryParse(AgeTextBox.Text, out int age))
                {
                    var person = new Person
                    {
                        Name = NameTextBox.Text,
                        Age = age
                    };
                    people.Add(person);
                    JsonClass<List<Person>>.Serialize(people, "people.json");
                    MessageBox.Show("Список объектов успешно сериализован в файл JSON.");
                }
                else
                {
                    MessageBox.Show("Поле 'Возраст' должно содержать целое число.");
                }
            }
            else MessageBox.Show("Поля не могут быть пустыми");
        }

        private void DeserializeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show("Файл не существует. Пожалуйста, выполните сериализацию перед десериализацией.");
                return;
            }
            people = JsonClass<List<Person>>.Deserialize<List<Person>>("people.json");
            FileGrid.ItemsSource = people;
            MessageBox.Show($"Количество объектов: {people.Count}");
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
