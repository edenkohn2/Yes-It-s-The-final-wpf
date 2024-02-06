using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using פרויקט.Model;
using פרויקט.ViewModel;

namespace פרויקט.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        private CheckVariables check = new CheckVariables();
        private SharedViewModel _sharedViewModel;

        public Register(SharedViewModel sharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel = sharedViewModel;
        }

        private bool IsNotEmpty()
        {

            string userName = UsernameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string password1 = ConfirmPasswordBox.Password;
            string age = Age.Text;

            // Check if there is empty text in any of the fields
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(password1) || string.IsNullOrWhiteSpace(age))
            {
                
                return false;
            }

            return true;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = UsernameTextBox.Text;
                string firstName = FirstNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                string email = EmailTextBox.Text;
                string password = PasswordBox.Password;
                try
                {
                    int age = int.Parse(Age.Text);
                }
                catch 
                {
                    MessageBox.Show("Age Must Be a Number!");
                    return;
                }

                


                // Update properties of the class-level new_Users
                User new_Users = new User
                {
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    State = "",
                    Country = "",
                    Password = password
                };
                
                // Check if there is data in new_Users
                // If there is no data, display Login with the data saved originally
                if (IsNotEmpty() == false)
                {
                    MessageBox.Show("Please Enter All The Fields");
                    return;
                }
                if (check.IsPasswordValid(password) == false)
                {
                    MessageBox.Show("The password must contain between 6-10 characters, must include at least one capital letter, must contain a number");
                    return;
                }
                if (check.IsValidEmail(new_Users.Email) == false)
                {
                    MessageBox.Show("Invalid email");
                    return;
                }
                if (ConfirmPasswordBox.Password != password)
                {
                    MessageBox.Show("The Passwords do not match");
                    return;
                }
                
                foreach (User existingUser in _sharedViewModel.UsersList)
                {
                    if (existingUser.Email == email)
                    {
                        MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                _sharedViewModel.UsersList.Add(new_Users);
                MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Login loginPage = new Login(_sharedViewModel);
                NavigationService.Navigate(loginPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Set focus to the UserName TextBox
            UsernameTextBox.Focus();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                Login llg = new Login(_sharedViewModel);
                NavigationService.Navigate(llg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

     
    }
}
