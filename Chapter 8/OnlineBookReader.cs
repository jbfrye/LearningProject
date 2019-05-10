using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.5
    class OnlineBookReader
    {
        private BookDatabase database;
        public BookDatabase Database
        { get; set; }

        private Memberships memberships;
        public Memberships Memberships
        { get; set; }

        public OnlineBookReader()
        {
            Database = new BookDatabase();
            Memberships = new Memberships();
        }

        public static void RunOnlineBookReader()
        {
            OnlineBookReader reader = new OnlineBookReader();
            reader.Database.AddBook(new Book("New Horizons", "Jeremy Frye", "Gotta broaden your horizons."));
            reader.Memberships.NewUser("jfrye", "grqoqbqDpc1");
            Console.WriteLine(reader.Memberships.Login("jfrye", "grqoqbqDpc1"));
            reader.Memberships.ActiveUser.ReadBook(reader.Database.FindBookByAuthor("Jeremy Frye").First());
            Book beingRead = reader.Memberships.ActiveUser.ActiveBook;
            Console.WriteLine(beingRead.Title + "\n" + beingRead.Author + "\n" + beingRead.Text + "\n");
        }
    }

    class Book
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public Book(string t, string a, string txt)
        {
            title = t;
            author = a;
            text = txt;
        }
    }

    class BookDatabase
    {
        System.Collections.Generic.List<Book> database;
        public BookDatabase()
        {
            database = new System.Collections.Generic.List<Book>();
        }

        public void AddBook(Book b)
        {
            database.Add(b);
        }

        public void DeleteBook(Book b)
        {
            database.Remove(b);
        }

        public System.Collections.Generic.List<Book> FindBookByAuthor(string au)
        {
            System.Collections.Generic.List<Book> bookMatch = new System.Collections.Generic.List<Book>();
            foreach (Book book in database)
            {
                if (book.Author == au)
                    bookMatch.Add(book);
            }
            return bookMatch;
        }

        public System.Collections.Generic.List<Book> FindBookByTitle(string ti)
        {
            System.Collections.Generic.List<Book> bookMatch = new System.Collections.Generic.List<Book>();
            foreach (Book book in database)
            {
                if (book.Title == ti)
                    bookMatch.Add(book);
            }
            return bookMatch;
        }
    }

    class User
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private Book activeBook;
        public Book ActiveBook
        {
            get { return activeBook; }
            set { activeBook = value; }
        }

        public User(string n, string p)
        {
            name = n;
            password = p;
            activeBook = null;
        }

        public void ReadBook(Book b)
        {
            activeBook = b;
        }

        public void StopReading()
        {
            activeBook = null;
        }
    }

    class Memberships
    {
        System.Collections.Generic.List<User> userList;
        private User activeUser;
        public User ActiveUser
        {
            get { return activeUser; }
            set { activeUser = value; }
        }

        public Memberships()
        {
            userList = new System.Collections.Generic.List<User>();
            activeUser = null;
        }

        public void NewUser(string n, string p)
        {
            userList.Add(new User(n, p));
        }

        public string Login(string un, string pass)
        {
            foreach (User user in userList)
            {
                if (user.Name == un && user.Password == pass)
                {
                    activeUser = user;
                    return un + " has logged in successfully.";
                }
            }
            return "Invalid Username or Password.";
        }

        public bool Logout()
        {
            if (activeUser != null)
            {
                activeUser = null;
                return true;
            }
            else
                return false;
        }
    }
}
