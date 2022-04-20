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

namespace ContraseñaAleatoria
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            simbols = new List<string>();
            simbols.Add("!");
            simbols.Add("$");
            simbols.Add(".");
            simbols.Add("@");
            simbols.Add("%");
            simbols.Add(".");
            numbers = new List<string>();
            letras1 = new List<string>();
            letras2 = new List<string>();
            for (int q = 1; q <= 9; q++)
                numbers.Add(q.ToString());
            for (int q = 65; q <= 90; q++)
            {
                if (q != 76)
                {
                    char z = (char)q;
                    letras1.Add(z.ToString());
                    letras2.Add(z.ToString().ToLower());
                }
            }
        }
        List<String> simbols, numbers, letras1, letras2;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> ele = new List<string>();
            Random q = new Random();
            ele.Add(simbols[q.Next(0, simbols.Count - 1)]);
            ele.Add(numbers[q.Next(0, numbers.Count - 1)]);
            ele.Add(letras1[q.Next(0, letras1.Count - 1)]);
            ele.Add(letras2[q.Next(0, letras2.Count - 1)]);
            for (int p = 4; p < 9; p++)
            {
                switch (q.Next(0, 4))
                {
                    case 0:
                        ele.Add(simbols[q.Next(0, simbols.Count - 1)]);
                        break;
                    case 1:
                        ele.Add(numbers[q.Next(0, numbers.Count - 1)]);
                        break;
                    case 2:
                        ele.Add(letras1[q.Next(0, letras1.Count - 1)]);
                        break;
                    case 3:
                        ele.Add(letras2[q.Next(0, letras2.Count - 1)]);
                        break;
                }
            }
            string cad = "";
            while (ele.Count > 0)
            {
                int z = q.Next(0, ele.Count - 1);
                cad = cad + ele[z];
                ele.RemoveAt(z);
            }
            char r = (char) q.Next(65,91);
            if (q.Next(0,2)==0)
                cad = r + cad;
            else
                cad = r.ToString().ToLower() + cad;
            this.Password.Text = cad;
            Clipboard.SetText(cad);
        }
    }
}
