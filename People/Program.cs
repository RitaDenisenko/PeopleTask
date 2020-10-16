using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace People
{
    class Program
    {
        public class Person
        {
            private String name;
            private String email;

            private static bool isValidName(String newName)
            {
                return Regex.IsMatch(newName, "^[a-zA-Z]+[- a-zA-Z]*$");
            }

            private static bool isValidEmail(String newEmail)
            {
                string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
                Match isMatch = Regex.Match(newEmail, pattern, RegexOptions.IgnoreCase);
                return isMatch.Success;
            }

            public String Name
            {
                get { return name;  }
                set
                {
                    if (isValidName(value))
                    {
                        name = value;
                    }
                    else
                    {
                        throw new Exception("Имя может содержать только символы латинского алфавита");
                    }
                    
                }
            }
            public String Email
            {
                get { return email; }
                set
                {
                    if (isValidEmail(value))
                    {
                        email = value;
                    }
                    else
                    {
                        throw new Exception("Недопустимый формат имейл-адреса");
                    }
                }
            }

            public Person(String newName, String newEmail)
            {
                if (isValidName(newName))
                {
                    name = newName;
                }
                else
                {
                    throw new Exception("Имя может содержать только символы латинского алфавита");
                }
                if (isValidEmail(newEmail))
                {
                    email = newEmail;
                }
                else
                {
                    throw new Exception("Недопустимый формат имейл-адреса");
                }
            }

        }


        static void Main(string[] args)
        {
            Person[] people = { new Person("Alex", "alex1986@gmail.com"), new Person("Martin", "martin1987@gmail.com"), new Person("Alice", "alice1989@gmail.com"),
                                new Person("Anna-Maria", "anna1990@gmail.com"), new Person("George", "george1991@gmail.com"), new Person("Linda", "linda1992@gmail.com")
                                /*,new Person("Maxim<script>alert('Name!')</script>", "maxim1993@gmail.com")*/
                              };
            

            StringBuilder html = new StringBuilder();
            html.Append("<body> ");

            foreach(Person person in people)
            {
                html.Append("<a href = \"mailto:" + person.Email + " \">" + person.Name + "<br /> " + " </a>");
            }

            html.Append(" </body>");

            File.WriteAllText("index.html", html.ToString());
            Console.WriteLine("HTML файл сформирован.");
            Console.ReadLine();
        }

    }
}
