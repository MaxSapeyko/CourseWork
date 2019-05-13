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
        public static string Cipher(char[] alfavit, string m, string k, bool btnEnFlag, bool btnDeFlag)
        {
            int letter_index, key_index, massage_index; // Змінні для циклів
            int t = 0; // Змінна для нумерації символів ключа
            char[] massage = m.ToCharArray(); // Перетворюємо рядок в масив символів.
            char[] key = k.ToCharArray(); // Перетворюємо ключ в масив символів.
            for (massage_index = 0; massage_index < massage.Length; massage_index++) // Цикл яким проходимо по кожному символу
            {
                // Шукаємо індекс букви
                for (letter_index = 0; letter_index < alfavit.Length; letter_index++)
                {
                    if (massage[massage_index] == alfavit[letter_index])
                    {
                        break;
                    }
                }
                if (letter_index != alfavit.Length) //Якщо j не дорівнює довжині алфавіту, значить символ з алфавіту
                {
                    if (t > key.Length - 1) // Задаємо умову щоб ключ повторювався при заповненні
                    {
                        t = 0;
                    }
                    // Шукаємо індекс букви ключа
                    for (key_index = 0; key_index < alfavit.Length; key_index++)
                    {
                        if (key[t] == alfavit[key_index])
                        {
                            break;
                        }
                        if (key[t] == ' ')
                        {
                            t = 0;
                        }
                    }
                    t++;
                    if (key_index != alfavit.Length) // Якщо f не дорівнює довжині алфавіту, значить символ ключа із алфавіту
                    {
                        if (btnEnFlag == true)
                        {
                            int offset = (letter_index + key_index) % alfavit.Length; // Шукаємо індекс дешифрованої букви
                            massage[massage_index] = alfavit[offset]; // Змінюємо букву
                        }
                        else if (btnDeFlag == true)
                        {
                            int nomer = (letter_index - key_index + alfavit.Length) % alfavit.Length; // Шукаємо індекс зашифрованої букви
                            massage[massage_index] = alfavit[nomer]; // Змінюємо букву
                        }
                    }
                }
            }
            t = 0; // Скидаємо індекс ключа 
            string result = new string(massage); // Складаємо символи назад в рядок.
            return result;
        }
    }
} 