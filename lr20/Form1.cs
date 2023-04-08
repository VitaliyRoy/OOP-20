using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Власне виключення для обробки помилок пов'язаних з високосним роком
        public class LeapYearException : Exception
        {
            public LeapYearException(string message)
                : base(message)
            {
            }
        }

        public class LeapYearChecker
        {
            public static bool IsLeapYear(int year)
            {
                // Перевірка чи є рік від'ємним, якщо так - виключення
                if (year < 0)
                {
                    throw new LeapYearException("Рік не може бути від'ємний.");
                }

                if (year % 4 != 0)
                {
                    return false;
                }

                if (year % 100 != 0)
                {
                    return true;
                }

                if (year % 400 == 0)
                {
                    return true;
                }

                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int year = int.Parse(txt_start.Text);
                // Визначення чи є рік високосним
                bool isLeapYear = LeapYearChecker.IsLeapYear(year);

                if (isLeapYear == true)
                {
                    txt_finish.Text = "Рік високосний.";
                }
                else
                {
                    txt_finish.Text = "Рік не високосний.";
                }
            }
            catch (FormatException)
            {
                // Обробка помилки форматування введеного значення
                txt_finish.Text = "Неправильне значення.";
            }
            catch (OverflowException)
            {
                // Обробка помилки переповнення типу int
                txt_finish.Text = "Введене значення занадто довге.";
            }
            catch (LeapYearException ex)
            {
                // Обробка помилки з використанням власного виключення
                txt_finish.Text = ex.Message;
            }
            catch (Exception)
            {
                // Обробка будь-якого іншого виключення
                throw;
            }
        }
    }
}
