using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lottery {
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window {
        public int spen;
        public int firn;
        public int secn;
        public int thrn;
        public int totaln;
        public int sper;
        public Settings() {
            InitializeComponent();
        }
        public Settings(int n1, int n2, int n3, int n4, int n5, int n6) {
            InitializeComponent();
            SpecialNum.Text = n1.ToString();
            FirstNum.Text = n2.ToString();
            SecondNum.Text = n3.ToString();
            ThirdNum.Text = n4.ToString();
            TotalNum.Text = n5.ToString();
            SpecialRange.Text = n6.ToString();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e) {


            bool verification = int.TryParse(SpecialNum.Text, out spen) &&
                    int.TryParse(FirstNum.Text, out firn) &&
                    int.TryParse(SecondNum.Text, out secn) &&
                    int.TryParse(ThirdNum.Text, out thrn) &&
                    int.TryParse(TotalNum.Text, out totaln) &&
                    int.TryParse(SpecialRange.Text, out sper);
            if (verification) {
                
                this.DialogResult = true;
            } else {
                if (!int.TryParse(SpecialNum.Text, out spen)) { SpecialNum.Foreground = Brushes.Red; }
                if (!int.TryParse(SpecialRange.Text, out spen)) { SpecialRange.Foreground = Brushes.Red; }
                if (!int.TryParse(TotalNum.Text, out spen)) { TotalNum.Foreground = Brushes.Red; }
                if (!int.TryParse(FirstNum.Text, out spen)) { FirstNum.Foreground = Brushes.Red; }
                if (!int.TryParse(SecondNum.Text, out spen)) { SecondNum.Foreground = Brushes.Red; }
                if (!int.TryParse(ThirdNum.Text, out spen)) { ThirdNum.Foreground = Brushes.Red; }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }
    }
}
