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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace lottery {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        DispatcherTimer StartDrawing = new DispatcherTimer();
        List<int> Ranhistory = new List<int>();
        public int WinnerNum { get; set; }
        public int TotalNum { get; set; } = 600;
        public int SpecialNum { get; set; } = 1;
        public int FirstNum { get; set; } = 2;
        public int SecondNum { get; set; } = 3;
        public int ThirdNum { get; set; } = 10;
        public int SpecialRange { get; set; } = 100;
        public string[] ChineseNumber = { "", "一", "两", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十", "二十一", "二十二", "二十三" };


        public string ThirdAwardStr { get; set; } = "水壶 十位";
        public string SecondAwardStr { get; set; } = "破壁机 三位";
        public string FirstAwardStr { get; set; } = "iPad mini4 两位";
        public string SpecialAwardStr { get; set; } = "mate 20 一位";
        public MainWindow() {
            InitializeComponent();
            StartDrawing.Interval = new TimeSpan(0, 0, 0, 0, 50);
            StartDrawing.Tick += StartDrawing_Tick;
        }

        private string RandomNum(int seed) {
            if (Ranhistory.Count >= WinnerNum) {
                Ranhistory.Clear();
            }
            int ran;
            do {
                ran = new Random((int)DateTime.Now.Ticks + seed).Next(1, TotalNum);
            } while (Ranhistory.Contains(ran));
            Ranhistory.Add(ran);
            string s = (ran).ToString();
            if (TotalNum > 999) {

                return string.Format("{0,4}", s);
            } else {
                return string.Format("{0,3}", s);

            }
        }


        private void StartDrawing_Tick(object sender, EventArgs e) {
            List<string> strings = new List<string>();
            switch (WinnerNum) {
                case 1:
                    Winner.FontSize = Background.ActualWidth / 6;

                    Winner.Text = RandomNum(0);
                    break;
                case 2:

                    Winner.FontSize = Background.ActualWidth / 8;
                    Winner.Text = RandomNum(1) + " " + RandomNum(2);
                    break;
                case 3:
                case 4:
                case 5:
                    Winner.FontSize = 120;
                    Winner.Text = RandomNum(100);
                    for (int i = 0; i < WinnerNum - 1; i++) {
                        Winner.Text += "\n" + RandomNum(i);
                    }
                    break;
                case 6:
                case 8:
                case 10:
                case 12:
                case 14:
                    Winner.FontSize = 72;
                    Winner.Text = RandomNum(10000) + " " + RandomNum(20000);
                    for (int i = 0; i < WinnerNum / 2 - 1; i++) {
                        Winner.Text += "\n" + RandomNum(i) + " " + RandomNum(100 + i);
                    }
                    break;
                case 7:
                case 9:
                case 11:
                case 13:
                    Winner.FontSize = 72;
                    Winner.Text = RandomNum(100) + " " + RandomNum(100);
                    for (int i = 0; i < WinnerNum / 2 - 1; i++) {
                        Winner.Text += "\n" + RandomNum(i) + " " + RandomNum(100);
                    }
                    Winner.Text += "\n" + RandomNum(5);
                    break;
                case 15:
                case 18:
                case 21:
                case 24:
                    Winner.FontSize = 48;
                    Winner.Text = RandomNum(102) + " " + RandomNum(105) + " " + RandomNum(10830);
                    for (int i = 0; i < WinnerNum / 3 - 1; i++) {
                        Winner.Text += "\n" + RandomNum(i) + " " + RandomNum(i * 100) + " " + RandomNum(i * 1000);
                    }
                    break;
                case 16:
                case 19:
                case 22:
                    Winner.FontSize = 48;
                    Winner.Text = RandomNum(102) + " " + RandomNum(105) + " " + RandomNum(10830);
                    for (int i = 0; i < WinnerNum / 3 - 1; i++) {
                        Winner.Text += "\n" + RandomNum(i) + " " + RandomNum(i * 100) + " " + RandomNum(i * 1000);
                    }
                    Winner.Text += "\n" + RandomNum(102);
                    break;
                case 17:
                case 20:
                case 23:
                    Winner.FontSize = 48;
                    Winner.Text = RandomNum(102) + " " + RandomNum(105) + " " + RandomNum(10830);
                    for (int i = 0; i < WinnerNum / 3 - 1; i++) {
                        Winner.Text += "\n" + RandomNum(i) + " " + RandomNum(i * 100) + " " + RandomNum(i * 1000);
                    }
                    Winner.Text += "\n" + RandomNum(102) + " " + RandomNum(1);
                    break;

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void ThirdAward_Click(object sender, RoutedEventArgs e) {
            if (StartDrawing.IsEnabled) {
                StartDrawing.Stop();
                ThirdAward.Content = "三等奖";

            } else {
                ThirdAward.Content = "开奖";
                WinnerNum = ThirdNum;
                Winner.Text = "";
                StartDrawing.Start();
            }
        }

        private void SecondAward_Click(object sender, RoutedEventArgs e) {
            if (StartDrawing.IsEnabled) {
                StartDrawing.Stop();
                SecondAward.Content = "二等奖";

            } else {
                SecondAward.Content = "开奖";
                Winner.Text = "";
                WinnerNum = SecondNum;
                StartDrawing.Start();
            }
        }

        private void FirstAward_Click(object sender, RoutedEventArgs e) {
            if (StartDrawing.IsEnabled) {
                StartDrawing.Stop();
                FirstAward.Content = "一等奖";

            } else {
                FirstAward.Content = "开奖";
                Winner.Text = "";
                WinnerNum = FirstNum;

                StartDrawing.Start();
            }
        }

        private void SpecialAward_Click(object sender, RoutedEventArgs e) {
            if (StartDrawing.IsEnabled) {
                StartDrawing.Stop();
                if (TotalNum > 999) {

                    Winner.Text = string.Format("{0,4}", new Random().Next(1, SpecialRange).ToString());
                } else {
                    Winner.Text = string.Format("{0,3}", new Random().Next(1, SpecialRange).ToString());
                }
                SpecialAward.Content = "特等奖";

            } else {
                SpecialAward.Content = "开奖";
                Winner.Text = "";
                WinnerNum = SpecialNum;
                StartDrawing.Start();
            }

        }

        private void ThirdAward_MouseEnter(object sender, MouseEventArgs e) {
            Award.Content = "三等奖 奖品：" + ThirdAwardStr;
        }

        private void SecondAward_MouseEnter(object sender, MouseEventArgs e) {
            Award.Content = "二等奖 奖品：" + SecondAwardStr;

        }

        private void FirstAward_MouseEnter(object sender, MouseEventArgs e) {
            Award.Content = "一等奖 奖品：" + FirstAwardStr;

        }

        private void SpecialAward_MouseEnter(object sender, MouseEventArgs e) {
            Award.Content = "特等奖 奖品：" + SpecialAwardStr;

        }

        private async void Settings_PreviewMouseUp(object sender, MouseButtonEventArgs e) {
            Settings settings = new Settings(SpecialNum, FirstNum, SecondNum, ThirdNum, TotalNum, SpecialRange);
            if (settings.ShowDialog() == true) {
                SpecialNum = settings.spen;
                FirstNum = settings.firn;
                SecondNum = settings.secn;
                ThirdNum = settings.thrn;
                TotalNum = settings.totaln;
                SpecialRange = settings.sper;
                SpecialAwardStr = settings.SpecialStr.Text + " " + ChineseNumber[SpecialNum] + "位";
                FirstAwardStr = settings.FirstStr.Text + " " + ChineseNumber[FirstNum] + "位";
                SecondAwardStr = settings.SecondStr.Text + " " + ChineseNumber[SecondNum] + "位";
                ThirdAwardStr = settings.ThirdStr.Text + " " + ChineseNumber[ThirdNum] + "位";
                using (HttpClient client = new HttpClient()) {
                    await Task.Run(async () => {
                        string content = TotalNum + "," +
                                         SpecialRange + "," +
                                         SpecialNum + "," + SpecialAwardStr + "," +
                                         FirstNum + "," + FirstAwardStr + "," +
                                         SecondNum + "," + SecondAwardStr + "," +
                                         ThirdNum + "," + ThirdAwardStr;

                        var response = await client.GetAsync("http://liuyonglun.com/lottery?lotterycontent=" + content);
                    });
                }
            }
        }
    }
}
