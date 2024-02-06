using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Threading;
using System.Xml.Linq;
using פרויקט.Model;
using פרויקט.View;
using פרויקט.ViewModel;

namespace פרויקט
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {


        

        private Game game;
        private int num1;
        private int num2;
        private string op;
        private Name nameClass = new Name();
        private System.Timers.Timer questionTimer;
        private int timeRemaining;
        private string def;
        private MediaPlayer mediaPlayer = new MediaPlayer();

        

        private SharedViewModel _sharedViewModel;

        public SecondWindow(string name2 , SharedViewModel sharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel = sharedViewModel;

            //mediaPlayer.Open(new Uri("C:\\Users\\edenk\\Desktop\\ThisIsMyProject-master\\פרויקט\\Images\\COUNTDOWN TIMER ( v 679 ) 30 sec with sound music effects 4K.mp3"));
            //mediaPlayer.Play();
           

            game = new Game();
            SetupNextQuestion();

            def = name2;
            string hisName = nameClass.UpdateName(name2);
            Title.Text = hisName;
            Rank.Text = "Points " +game.GetPoints();
            





        }
        
        private void SetupNextQuestion()
        {
            num1 = game.RandomNums1();
            num2 = game.RandomNums2();
            op = game.Get_Operator();

            number1.Text = num1.ToString();
            number2.Text = num2.ToString();
            operator1.Text = op;

            // Calculate and store the correct answer for the new question
            int currentCorrectAnswer = game.GetCorrectAnswer(num1, num2, op);
            
        }
        private void mediaPlayer_MediaEnded()
        {
            mediaPlayer.Position = TimeSpan.Zero; // Reset the position to the beginning
            mediaPlayer.Play(); // Start playing again
        }










        private void check_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int userAnswer = int.Parse(Resault.Text);

                game.CheckAnswer(userAnswer);
                
                Rank.Text = "Points: " + game.GetPoints().ToString();

                if (game.IsGameFinished())
                {
                    MessageBox.Show("You've completed all 5 questions!");
                    MessageBox.Show("Thank You For Playing!");
                     // Assuming Title.Text contains the username
                    User currentUser = _sharedViewModel.UsersList.FirstOrDefault(user => user.UserName == def);

                    _sharedViewModel.UsersList = _sharedViewModel.UsersList.OrderByDescending(u => u.Points).ToList();



                    if (currentUser != null)
                    {
                        currentUser.Points = game.GetPoints(); // Update the points for the found user

                        LeaderBoard board = new LeaderBoard(_sharedViewModel);
                        board.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("User not found!"); // Handle the case where the user is not found
                    }
                }
                else
                {
                    Resault.Text = string.Empty;  // Use string.Empty instead of null
                    SetupNextQuestion();
                }
            }
            catch
            {
                Resault.Text = string.Empty;
                MessageBox.Show("Please Enter A Valid Number");

            }
        }


        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
