using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json; 

namespace JsonManagerApp
{
    public partial class Form1 : Form
    {
        List<Book> _books = new List<Book>();
        string _filePath = "library.json";

        public Form1()
        {
            InitializeComponent(); 

            button1.Click += (s, e) => OpenData();    
            button2.Click += (s, e) => SaveData();    
            button3.Click += (s, e) => AddBook();     
            button4.Click += (s, e) => MessageBox.Show("Виконав: Чубко Олег\nГрупа: К-26");
            textBox1.TextChanged += (s, e) => Search(); 

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AddBook()
        {
            _books.Add(new Book { Title = "Нова книга", Author = "Автор", Year = 2025 });
            RefreshGrid(_books);
        }

        private void SaveData()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_books));
            MessageBox.Show("Збережено у файл!");
        }

        private void OpenData()
        {
            if (File.Exists(_filePath))
            {
                _books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(_filePath));
                RefreshGrid(_books);
            }
        }

        private void Search()
        {
     
            string text = textBox1.Text.ToLower();
            var filtered = _books.Where(b => b.Title.ToLower().Contains(text)).ToList();
            RefreshGrid(filtered);
        }

        private void RefreshGrid(List<Book> list)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}