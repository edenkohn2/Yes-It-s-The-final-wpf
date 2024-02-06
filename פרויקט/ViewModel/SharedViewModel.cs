using System;
using System.Collections.Generic;
using System.Linq;
using פרויקט.Model;

namespace פרויקט.ViewModel
{
    public class SharedViewModel
    {
        private List<User> _usersList;


        public SharedViewModel()
        {
            _usersList = new List<User>();
        }
        
        public List<User> UsersList
        {
            get { return _usersList; }
            set { _usersList = value; }
        }
    }
}
