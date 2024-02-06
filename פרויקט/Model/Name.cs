using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace פרויקט
{
    internal class Name
    {
        private string name;
        
        public Name(string name) 
        {
            this.name = name;
        }
        public Name() 
        { 

        }
        public string getName()
        {
            return this.name;
        }
        public bool IsOk(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {

                MessageBox.Show("Please Enter Your Name.");
                return false;

            }
            return true;
        }
        public string UpdateName(string name)
        {
            string name1 = "";
            
            
            {
                try
                {
                    string firstLetter = name.Substring(0, 1);
                    string restOfTheString = name.Substring(1);
                    firstLetter = firstLetter.ToUpper();
                    name1 = firstLetter + restOfTheString;






                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }


            }
            return name1;
        }

    }
}
