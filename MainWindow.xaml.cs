using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace OAP_Ex1
{
 /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int rol = 1; // 0- я начигаю хожу ноликами - робот ходит крестиками  1-я начинаю хожу крестиками робот ходит ноликаит
        int i = 0;
        string[,] mas = new string[3, 3] { { "","",""},{ "","",""},{ "","",""} }; // создали массив 3 на 3, для хранения информации где нолик и крестик
        public MainWindow()
        {
        InitializeComponent();
        

        }
        public void Block()
        { 
            B1_1.IsEnabled = false;
            B1_2.IsEnabled = false;
            B1_3.IsEnabled = false;
            B2_1.IsEnabled = false;
            B2_2.IsEnabled = false;
            B2_3.IsEnabled = false;
            B3_1.IsEnabled = false;
            B3_2.IsEnabled = false;
            B3_3.IsEnabled = false;
        }
     public void Proverka() // проверят победу или ничью 
        {
            if (mas[0, 0] == "X" && mas[0, 1] == "X" && mas[0, 2] == "X") { T1.Text = "Победили крестики"; Block(); }
            if (mas[1, 0] == "X" && mas[1, 1] == "X" && mas[1, 2] == "X") { T1.Text = "Победили крестики"; Block(); }
            if (mas[2, 0] == "X" && mas[2, 1] == "X" && mas[2, 2] == "X") { T1.Text = "Победили крестики"; Block(); }
            if (mas[0, 0] == "X" && mas[1, 0] == "X" && mas[2, 0] == "X") { T1.Text = "Победили крестики"; Block(); }
            if (mas[0, 1] == "X" && mas[1, 1] == "X" && mas[2, 1] == "X") { T1.Text = "Победили крестики"; Block(); }
            if (mas[0, 2] == "X" && mas[1, 2] == "X" && mas[2, 2] == "X") { T1.Text = "Победили крестики"; Block(); }
            if (mas[0, 0] == "X" && mas[1, 1] == "X" && mas[2, 2] == "X") { T1.Text = "Победили крестики"; Block(); }
            if (mas[2, 0] == "X" && mas[1, 1] == "X" && mas[0, 2] == "X") { T1.Text = "Победили крестики"; Block(); }

            if (mas[0, 0] == "0" && mas[0, 1] == "0" && mas[0, 2] == "0") { T1.Text = "Победили нолики"; Block(); }
            if (mas[1, 0] == "0" && mas[1, 1] == "0" && mas[1, 2] == "0") { T1.Text = "Победили нолики"; Block(); }
            if (mas[2, 0] == "0" && mas[2, 1] == "0" && mas[2, 2] == "0") { T1.Text = "Победили нолики"; Block(); }
            if (mas[0, 0] == "0" && mas[1, 0] == "0" && mas[2, 0] == "0") { T1.Text = "Победили нолики"; Block(); }
            if (mas[0, 1] == "0" && mas[1, 1] == "0" && mas[2, 1] == "0") { T1.Text = "Победили нолики"; Block(); }
            if (mas[0, 2] == "0" && mas[1, 2] == "0" && mas[2, 2] == "0") { T1.Text = "Победили нолики"; Block(); }
            if (mas[0, 0] == "0" && mas[1, 1] == "0" && mas[2, 2] == "0") { T1.Text = "Победили нолики"; Block(); }
            if (mas[2, 0] == "0" && mas[1, 1] == "0" && mas[0, 2] == "0") { T1.Text = "Победили нолики"; Block(); }
            i++;

        }

     public void Press(Button a)   // функция нажатия кнопки
        {
            if (rol == 0)
            {
                
                a.Content = "0";
                a.IsEnabled= false;
                if (a == B1_1) { mas[0,0]= "0"; }
                if (a == B1_2) { mas[0,1]= "0";}
                if (a == B1_3) { mas[0,2]= "0";}
                if (a == B2_1) { mas[1,0]= "0";}
                if (a == B2_2) { mas[1,1]= "0";}
                if (a == B2_3) { mas[1,2]= "0";}
                if (a == B3_1) { mas[2,0]= "0";}
                if (a == B3_2) { mas[2,1]= "0";}
                if (a == B3_3) { mas[2,2]= "0";}
          
            }
            else
            {
                a.Content = "X";
                a.IsEnabled = false;
                if (a == B1_1) { mas[0, 0] = "X"; }
                if (a == B1_2) { mas[0, 1] = "X"; }
                if (a == B1_3) { mas[0, 2] = "X"; }
                if (a == B2_1) { mas[1, 0] = "X"; }
                if (a == B2_2) { mas[1, 1] = "X"; }
                if (a == B2_3) { mas[1, 2] = "X"; }
                if (a == B3_1) { mas[2, 0] = "X"; }
                if (a == B3_2) { mas[2, 1] = "X"; }
                if (a == B3_3) { mas[2, 2] = "X"; }
            }
  
            Proverka();   // прооверяем
            if (i < 9)
            {
                PressComp();   //ход робота
                Proverka();   // прооверяем
            }
            else
            {
                T1.Text = "Ничья";
                Proverka();
            }
        }
        public void PressComp() //Теперь ходит компьютер
        {
            int s;  
            Random rnd = new Random();
            do
            {
                s = rnd.Next(1, 9);  // генерим случайное число

                if (s ==1 && mas[0,0]=="" )  // проверяю ячейку 1 на пустоту
                {
                   
                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[0, 0] = "X";
                        B1_1.Content = "X";
                    }
                    else
                    {
                        mas[0, 0] = "0";
                        B1_1.Content = "0";
                    }
                   B1_1.IsEnabled = false;
                  break;
                }

                if (s == 2 && mas[0, 1] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[0, 1] = "X";
                        B1_2.Content = "X";
                    }
                    else
                    {
                        mas[0, 1] = "0";
                        B1_2.Content = "0";
                    }
                    B1_2.IsEnabled = false;
                    break;
                }

                if (s == 3 && mas[0, 2] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[0, 2] = "X";
                        B1_3.Content = "X";
                    }
                    else
                    {
                        mas[0, 2] = "0";
                        B1_3.Content = "0";
                    }
                    B1_3.IsEnabled = false;
                    break;
                }

                if (s == 4 && mas[1, 0] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[1, 0] = "X";
                        B2_1.Content = "X";
                    }
                    else
                    {
                        mas[1, 0] = "0";
                        B2_1.Content = "0";
                    }
                    B2_1.IsEnabled = false;
                    break;
                }

                if (s == 5 && mas[1, 1] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[1, 1] = "X";
                        B2_2.Content = "X";
                    }
                    else
                    {
                        mas[1, 1] = "0";
                        B2_2.Content = "0";
                    }
                    B2_2.IsEnabled = false;
                    break;
                }

                if (s == 6 && mas[1, 2] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[1, 2] = "X";
                        B2_3.Content = "X";
                    }
                    else
                    {
                        mas[1, 2] = "0";
                        B2_3.Content = "0";
                    }
                    B2_3.IsEnabled = false;
                    break;
                }

                if (s == 7 && mas[2, 0] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[2, 0] = "X";
                        B3_1.Content = "X";
                    }
                    else
                    {
                        mas[2, 0] = "0";
                        B3_1.Content = "0";
                    }
                    B3_1.IsEnabled = false;
                    break;
                }

                if (s == 8 && mas[2, 1] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[2, 1] = "X";
                        B3_2.Content = "X";
                    }
                    else
                    {
                        mas[2, 1] = "0";
                        B3_2.Content = "0";
                    }
                    B3_2.IsEnabled = false;
                    break;
                }

                if (s == 9 && mas[2, 2] == "")  // проверяю ячейку  на пустоту
                {

                    if (rol == 0) //робот ходит крестиками
                    {
                        mas[2, 2] = "X";
                        B3_3.Content = "X";
                    }
                    else
                    {
                        mas[2, 2] = "0";
                        B3_3.Content = "0";
                    }
                    B3_3.IsEnabled = false;
                    break;
                }
            } while (true);            

        }

         private void B1_1_Click(object sender, RoutedEventArgs e)
            {
             Press(B1_1);

            }

        private void B1_2_Click_1(object sender, RoutedEventArgs e)
        {
            Press(B1_2);

        }

        private void B1_3_Click(object sender, RoutedEventArgs e)
        {
            Press(B1_3);
        }

        private void B2_1_Click(object sender, RoutedEventArgs e)
        {
            Press(B2_1);
        }

        private void B2_2_Click(object sender, RoutedEventArgs e)
        {
            Press(B2_2);
        }

        private void B2_3_Click(object sender, RoutedEventArgs e)
        {
            Press(B2_3);
        }

        private void B3_1_Click(object sender, RoutedEventArgs e)
        {
            Press(B3_1);
        }

        private void B3_2_Click(object sender, RoutedEventArgs e)
        {
            Press(B3_2);
        }

        private void B3_3_Click(object sender, RoutedEventArgs e)
        {
            Press(B3_3);
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
 
            // очищаем массив 
            mas[0, 0] = "";
            mas[0, 1] = "";
            mas[0, 2] = "";

            mas[1, 0] = "";
            mas[1, 1] = "";
            mas[1, 2] = "";

            mas[2, 0] = "";
            mas[2, 1] = "";
            mas[2, 2] = "";


            // очистить кнопки
            B1_1.Content = "";   //
            B1_2.Content = "";
            B1_3.Content = "";
            B2_1.Content = "";
            B2_2.Content = "";
            B2_3.Content = "";
            B3_1.Content = "";
            B3_2.Content = "";
            B3_3.Content = "";
            //сделаем кнопки активными
            B1_1.IsEnabled = true;
            B1_2.IsEnabled = true;
            B1_3.IsEnabled = true;
            B2_1.IsEnabled = true;
            B2_2.IsEnabled = true;
            B2_3.IsEnabled = true;
            B3_1.IsEnabled = true;
            B3_2.IsEnabled = true;
            B3_3.IsEnabled = true;

            i = 0;
            T1.Text = "";


            if (rol == 1) { rol = 0; }
            
            else if (rol == 0) { rol = 1; }
           
        }
    }
  
}
