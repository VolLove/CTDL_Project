using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    internal class User
    {
        private string userName;
        private string password;

        public User() { }

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
        public void UserNew(string userName, string password)
        {
            this.userName = userName;
            Password = password;
        }
        public string UserName { get => userName; set => userName = value; }

        /// <summary>
        /// Passwoord được hash
        /// </summary>
        public string Password
        {
            get => password;
            set
            {
                password = Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
                Console.WriteLine(password);
            }
        }

        public string PrintFile()
        {
            return $"{userName}_{password}";
        }
    }
}
