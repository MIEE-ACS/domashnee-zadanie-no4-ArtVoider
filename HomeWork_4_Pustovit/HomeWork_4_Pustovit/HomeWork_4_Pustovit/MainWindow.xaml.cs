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

namespace HomeWork_4_Pustovit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Задача 1:
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            
            int N1 = int.Parse(TB1.Text);
            if (N1 < 1)
            { MessageBox.Show("Количество элементов не должно быть меньше 1!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                TB_3.Text = "Ошибка!";}
            else
            {
                double[] Mass = new double[N1];     //Объявление массива
                for (int i = 0; i < Mass.Length; i++)      
                {
                    Mass[i] = rand.Next(20)/1.3-10;
                }
                string MassResult = "";
                for (int i = 0; i < N1; i++)    //вывод на экран
                { MassResult = MassResult + Math.Round(Mass[i],3) + "; "; }
                TB_3.Text = MassResult;
                MassResult = "";

                //Инвертируем массив
                for (int i = N1-1; i >= 0; i--)   
                { MassResult = MassResult + Math.Round(Mass[i], 3) + "; "; }
                TB_5.Text = MassResult;
                MassResult = "";

                //Находим произведение отрицательных элементов
                double Result = 1;
                for (int i = 0; i < N1; i++)    
                { if (Mass[i]<0)
                    {Result = Result*Mass[i];}
                }
                if (Result == 1)
                {   TB_6.Text = "Ни одного отрицательного элемента нет!"; }
                else
                {
                    MassResult = Math.Round(Result, 3) + ";";
                    TB_6.Text = MassResult;
                }
                MassResult = ""; 
                Result = 0;

                //Найдем сумму положительных элементов массива, расположенных до максимального элемента
                Result = Mass[0];
                int k = 0;
                double Result2 = 0;
                for (int i = 1; i < N1; i++)
                {
                    if (Mass[i]>=Result)
                    { 
                        Result = Mass[i];
                        k = i;
                    }
                }

                if ((k == 0) && (Result<=0))
                { TB_7.Text = "В массиве нет положительных элементов!"; }    
                else if ((k == 0) && (Result > 0))
                { TB_7.Text = "Первое значение наибольшее!"; }
                else
                {
                    for (int i = 0; i < k; i++)
                    {
                        if (Mass[i] > 0)
                        { Result2 = Result2 + Mass[i]; }
                    }
                    if (Result2 == 0)
                    { 
                        TB_7.Text = "До наибольшего элемента стоят только отрицательные!"; 
                    }
                    else
                    {
                        MassResult = Math.Round(Result2, 3) + ";";
                        TB_7.Text = MassResult;
                    }
                }
                MassResult = "";
                Result = 0;
                Result2 = 0;
            }
        }



        //Задача 2:
        private void BT2_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();

            int N2 = int.Parse(TB2.Text);
            if (N2 < 2)
            {
                MessageBox.Show("Количество элементов не должно быть меньше 2!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                TB_4.Text = "Ошибка!";
            }
            else
            {
                TB_4.Text = "";
                int[,] Mass2 = new int[N2, N2];   //Двуммерный массив

                for (int i = 0; i < Mass2.GetLength(0); i++)
                {
                    for (int j = 0; j < Mass2.GetLength(1); j++)
                    {
                        Mass2[i, j] = rand.Next(18) - 9;
                    }
                }


                for (int i = 0; i < N2; i++)        //Печать значений(вывод на экран)
                {
                    for (int j = 0; j < N2; j++)
                    {
                        TB_4.Text = TB_4.Text + Mass2[i, j].ToString()+ "\t";
                    }
                    TB_4.Text = TB_4.Text + "\n";
                }

                //Найдем сумму элементов строк не сожержащих отрицательные элементы

                int z = 0; //счетчик
                int Res = 0;
                TB_8.Text = "";
                for (int i = 0; i < Mass2.GetLength(0); i++)
                {
                    for (int j = 0; j < Mass2.GetLength(1); j++)
                    {
                        if (Mass2[i, j] < 0)
                        { z = z + 1; }
                    }
                    if (z == 0)
                    {
                        for (int j = 0; j < Mass2.GetLength(1); j++)
                        {
                            Res = Res + Mass2[i, j];
                        }
                        TB_8.Text = TB_8.Text + "Строка: " + (i+1).ToString() + "\t";
                        TB_8.Text = TB_8.Text + "Сумма элементов: " + Res.ToString() + "\n";
                    }
                    z = 0;
                    Res = 0;
                }
                if (TB_8.Text == "")
                {
                    TB_8.Text = "Нет ни одной строки не содержащей отрицательные элементы!";
                }


                //Найдем  минимум среди сумм элементов диагоналей, параллельных главной диагонали матрицы
                int[] DiagSumm = new int[N2*2-2];
                string[] DiagEl = new string[N2 * 2 - 2];
                int k = N2-1;
                int f = 0;

                for (int j = 1; j < Mass2.GetLength(1); j++)
                    {
                    DiagSumm[f] = 0;
                    DiagEl[f] = "";
                    for (int i = j; i < Mass2.GetLength(0); i++)
                        {
                        DiagSumm[f] = DiagSumm[f] + Mass2[i, i - j];
                        DiagEl[f] = DiagEl[f]+ " " + Mass2[i, i - j].ToString();
                        }
                    f = f + 1;
                }

                for (int i = 1; i < Mass2.GetLength(1); i++)
                {
                    DiagSumm[f] = 0;
                    DiagEl[f] = "";
                    for (int j = i; j < Mass2.GetLength(0); j++)
                    {
                        DiagSumm[f] = DiagSumm[f] + Mass2[j - i, j];
                        DiagEl[f] = DiagEl[f] + " " + Mass2[j - i, j].ToString();
                    }
                    f = f + 1;
                }

                int min = DiagSumm.Min();
                TB_9.Text = "Все элементы в диагоналях параллельный главной: \n";
                for (int r = 0; r < f; r++)
                {
                    TB_9.Text = TB_9.Text + " " + DiagEl[r] + " |";

                }
                TB_9.Text = TB_9.Text + "\n";
                TB_9.Text = TB_9.Text + "Все суммы элементов диагоналей: \n";
                for (int r = 0; r < f; r++)
                {
                    TB_9.Text = TB_9.Text + " " + DiagSumm[r] + " |";

                }
                TB_9.Text = TB_9.Text + "\n";
                TB_9.Text = TB_9.Text + "Минимальная сумма элементов этих дигоналей: \n";
                TB_9.Text = TB_9.Text + min.ToString();
            }
            

        }






            
    
        


        //Закрытие окна:

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите закрыть окно?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            { e.Cancel = true;}    
        }

        private void TB_4_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
