using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LR_13_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextSurname_TextChanged(object sender, EventArgs e)
        {


        }
        public bool ValidText(string Text, out string ErrorMess) {
            if (Text.Length == 0)
            {
                ErrorMess = "Введіть текст";
                return false;
            }
            for (int i = 0; i < Text.Length; i++)
            {
                if (char.IsNumber(Text[i]))
                {
                    ErrorMess = "Невірний формат";
                    return false;
                }
            }
            ErrorMess = "";
            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            DateTime DateNow = DateTime.Now;
            int YearNow = DateNow.Year;
            int YearBirth = DateOfBirth.Value.Year;
            int Age = YearNow - YearBirth;
            DateTime NextBirthday = new DateTime(DateNow.Year, DateOfBirth.Value.Month, DateOfBirth.Value.Day);
            TimeSpan timeUntilNextBirthday = NextBirthday - DateNow;
            int DaysToNextBirthday = (int)timeUntilNextBirthday.TotalDays;
            if (DateNow.Date.Day == DateOfBirth.Value.Date.Day && DateNow.Date.Month == DateOfBirth.Value.Date.Month) {
                MessageBox.Show($"Вітаємо у вас сьогодні день народження! Вам виповнилось виповнилось {Age} років");

            }
            else if (DaysToNextBirthday > 0)
            {
                MessageBox.Show($"До дня народження залишилось {DaysToNextBirthday} днів вам виповнилось {Age} років");
            }
            else
            {
                DaysToNextBirthday= 365 + DaysToNextBirthday;
                MessageBox.Show( $"До дня народження залишилось {DaysToNextBirthday} днів вам виповнилось {Age} років");
            }

            
        }

        private void TextName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextSurname_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage;
            if (!ValidText(TextSurname.Text, out errorMessage))
            {
                e.Cancel = true;
                TextSurname.Select(0, TextSurname.Text.Length);

                this.errorProvider1.SetError(TextSurname, errorMessage);
            }
        }

        private void TextName_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage;
            if (!ValidText(TextName.Text, out errorMessage))
            {
                e.Cancel = true;
                TextSurname.Select(0, TextName.Text.Length);

                this.errorProvider1.SetError(TextName, errorMessage);
            }

        }

        private void TextSurname_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextSurname, "");
           
        }

        private void TextName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TextName, "");
        }
    }
}
