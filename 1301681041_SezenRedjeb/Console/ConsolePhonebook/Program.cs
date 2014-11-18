using ConsolePhonebook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginView loginView = new LoginView();
            loginView.Show();

            ContactsManagerView contactManagerView = new ContactsManagerView();
            contactManagerView.Show();
        }
    }
}
