using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using פרויקט.Model;
using פרויקט.View;

using פרויקט.ViewModel;

namespace פרויקט
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private SharedViewModel _sharedViewModel;
        private UserViewModel _userViewModel;
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public Login(SharedViewModel sharedViewModel)
        {
            InitializeComponent();

            _sharedViewModel = sharedViewModel;
            mediaPlayer.Open(new Uri("C:\\Users\\edenk\\Desktop\\ThisIsMyProject-master\\פרויקט\\Images\\Slow Mysterious Lofi No Copyright Free Easy Night Background Music  Crow's Quest by Filo Starquez.mp3"));
            mediaPlayer.Play();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Handle sign-up or navigate to the registration window
                Register registerPage = new Register(_sharedViewModel);
                NavigationService.Navigate(registerPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void UsrTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text when the TextBox gets focus
            UserName.Text = "";
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Set focus to the UserName TextBox
            UserName.Focus();
        }



        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the entered email and password 
                string enteredEmail = UserName.Text;
                string enteredPassword = PasswordText.Password;
                string enteredUserName = UserName.Text;
                string app_Name = "";

                // Search for a match in the list
                User matchedUser = null;

                foreach (User user in _sharedViewModel.UsersList)
                {
                    if ((user.Email == enteredEmail && user.Password == enteredPassword) || (user.UserName == enteredUserName && user.Password == enteredPassword))
                    {
                        matchedUser = user;
                        app_Name = matchedUser.UserName;
                        break; // Found a match, exit the loop
                    }
                }

                // Check if a match was found and load the main page
                if (matchedUser != null)
                {
                    // Create and show the new window
                    try
                    {
                        mediaPlayer.Stop();
                        SecondWindow secondWindow = new SecondWindow(app_Name , _sharedViewModel);
                        secondWindow.Show();

                        // Close the current window (assuming this is the login window)
                        Window.GetWindow(this).Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    // No match found, display an error message
                    MessageBox.Show("Invalid email or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
