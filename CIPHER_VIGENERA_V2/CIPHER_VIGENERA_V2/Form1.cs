using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIPHER_VIGENERA_V2
{
    public partial class Form1 : Form
    {
        // Задаємо алфавіт
        public char[] alfavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        // Рядки, які відповідають за введені дані та ключ (відповідно до m та k)
        string m, k;
        // Флажки які відповідають за клік кнопок
        bool btnEnFlag = false;
        bool btnDeFlag = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Encode(object sender, EventArgs e)
        {
            btnEnFlag = true;
            // Перевірка на наявність ключа
            if (textBoxMassage.TextLength == 0)
            {
                MessageBox.Show("Вхідні дані відсутні!");
            }
            else if (textBoxKey.TextLength == 0)
            {
                MessageBox.Show("Введiть ключ!");
            }
            else
            {
                // Присвоюємо рядку введені дані
                m = textBoxMassage.Text;
                // Присвоюємо рядку введений ключ
                k = textBoxKey.Text;
                // Передаємо на екран результат дешифровки
                textBoxResult.Text = Cipher(alfavit, m, k, btnEnFlag, btnDeFlag);
            }
            btnEnFlag = false;
        }
        private void button2_Decode(object sender, EventArgs e)
        {
            btnDeFlag = true;
            // Перевірка на наявність ключа
            if (textBoxMassage.TextLength == 0)
            {
                MessageBox.Show("Вхідні дані відсутні!");
            }
            else if (textBoxKey.TextLength == 0)
            {
                MessageBox.Show("Введiть ключ");
            }
            else
            {
                // Присвоюємо рядку введені дані
                m = textBoxMassage.Text;
                // Присвоюємо рядку введений ключ
                k = textBoxKey.Text;
                // Передаємо на екран результат дешифровки
                textBoxResult.Text = Cipher(alfavit, m, k, btnEnFlag, btnDeFlag);
            }
            btnDeFlag = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Відкриття файлу
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // Отримуємо обраний файл
            string filename = openFileDialog1.FileName;
            // Читаємо файл в рядок
            string fileText = System.IO.File.ReadAllText(filename);
            // Передаємо текстбоксу дані з файлу
            textBoxMassage.Text = fileText;
        }
        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            // Перевіряємо ключ на наявність пробілів
            for (int i = 0; i < textBoxKey.TextLength; i++)
            {
                char ch = Convert.ToChar(textBoxKey.Text.Substring(i, 1));
                if (ch == ' ')
                {
                    MessageBox.Show("Введений пробiл");
                }
            }
        }
            private void button4_Click(object sender, EventArgs e)
        {
            // Збереження в (*.txt)
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.AddExtension = true;
            // Зберігаємо файл
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Отримуємо шлях до файлу
                string filename = saveFileDialog1.FileName;
                // Зберігаємо текст в файл
                System.IO.File.WriteAllText(filename, textBoxResult.Text);
                MessageBox.Show("Файл збережено");
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"  Дана програма працює з шифрвунням символів латинського алфавіту. 
Шифрування:
    Для того щоб зашифрувати текст введіть вхідні дані або ж відкрийте файл (.txt) натиснувши на кнопку '...', а також введіть ключове слово яке не містить пробілів, та натисніть кнопку 'Зашифрувати'. 
Дешифрування:
    Для дешифрування повторюються аналогічні дії, головне ввести той ключ за допомогою якого відбувалося шифрування, та натисніть кнопку 'Дешифрувати'. 
Збереження:
    Якщо маєте бажання зберегти отримані результати натисніть кнопку із зображенням дискети, та оберіть місце збереження.
Видалення вмісту:
    Також можете видалити вміст одночасно вхідного повідомлення та результату роботи програми натиснувши кнопку 'ВИДАЛИТИ'. ","Інструкція");
        }

        private void button5_Click_Delete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви впевнені?", "Видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBoxMassage.Clear();
                textBoxResult.Clear();
            }
        }
    }
}

