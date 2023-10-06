using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListBox listBox = new();

            List<Book> existingBooks = new List<Book>
            {
            new Book { Title = "Dune", Author = new Author { Name = "Frank Herbert", YearOfBirth = 1920, NoteworthyInformation = "Master of science fiction and creator of acaptivating dystopian universe." }, Year = 1965 },
            new Book { Title = "Harry Potter and the Philosopher's Stone", Author = new Author { Name = "J.K. Rowling", YearOfBirth = 1965, NoteworthyInformation = "Magicalwordsmith and bringer of joy to millions of readers." }, Year = 1997 },
            new Book { Title = "Ender's Game", Author = new Author { Name = "Orson Scott Card", YearOfBirth = 1951, NoteworthyInformation = "Mentor of young prodigies and mastermind of thrilling intergalactic battles." }, Year = 1985 },
            new Book { Title = "The Hobbit", Author = new Author { Name = "J.R.R. Tolkien", YearOfBirth = 1892, NoteworthyInformation = "Creator of Middle-earth and chronicler of epic adventures." }, Year = 1937 },
            new Book { Title = "Neuromancer", Author = new Author { Name = "William Gibson", YearOfBirth = 1948, NoteworthyInformation = "Visionary wordsmith who pioneeredthe cyberpunk genre." }, Year = 1984 },
            new Book { Title = "A Wizard of Earthsea", Author = new Author { Name = "Ursula K. Le Guin", YearOfBirth = 1929, NoteworthyInformation = "Magical storyteller who transported readers to enchanting realms." }, Year = 1968 },
            new Book { Title = "The Left Hand of Darkness", Author = new Author { Name ="Ursula K. Le Guin", YearOfBirth = 1929, NoteworthyInformation = "Bold explorer ofgender and society in thought-provoking science fiction." }, Year = 1969 },
            new Book { Title = "Dawn", Author = new Author { Name = "Octavia Butler", YearOfBirth = 1947, NoteworthyInformation = "Groundbreaking author who pushed the boundaries of imagination." }, Year = 1987 },
            new Book { Title = "Ancillary Justice", Author = new Author { Name = "Ann Leckie", YearOfBirth = 1966, NoteworthyInformation = "Space opera virtuoso and masterof intricate interstellar politics." }, Year = 2013 },
            new Book { Title = "The Dispossessed", Author = new Author { Name = "Ursula K.Le Guin", YearOfBirth = 1929, NoteworthyInformation = "Subversive visionary who challenged social norms with her transformative tales." }, Year = 1974 }
            };

            foreach (Book book in existingBooks)
            {
                ListBoxItem item = new();
                item.Content = book.GetInfo();
                item.Tag = book;

                lstBooks.Items.Add(item);
            }

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbBirthyear.Text, out int yearOfBirth);
            int.TryParse(tbYear.Text, out int yearPublished);

            if (tbTitle.Text == "" || tbAuthor.Text == "" || yearPublished == 0 || yearOfBirth == 0 || tbNoteworthyInformation.Text == "")
            {
                MessageBox.Show("You must fill all fields");
            }
            Book newBook = new Book
            {
                Title = tbTitle.Text,
                Year = yearPublished,
                Author = new Author
                {
                    Name = tbAuthor.Text,
                    YearOfBirth = yearOfBirth,
                    NoteworthyInformation = tbNoteworthyInformation.Text,

                }

            };
            ListBoxItem addedBook = new();

            addedBook.Content = newBook.GetInfo();
            addedBook.Tag = newBook;

            lstBooks.Items.Add(addedBook);
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedBook = (ListBoxItem)lstBooks.SelectedItem;

            if (selectedBook != null)
            {
                lstBooks.Items.Remove(selectedBook);
            }

            // TODO Refactor this logic to a method "GetUsersCount"
            if (lstBooks.Items.Count <= 0)
            {
                btnRemove.IsEnabled = false;
            }
        }

        private void lstBooks_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)lstBooks.SelectedItem;
            Book newBook = (Book)selectedItem.Tag;
            tbAuthor.Text = newBook.Author.Name;
            tbTitle.Text = newBook.Title;
            tbBirthyear.Text = newBook.Author.YearOfBirth.ToString();
            tbYear.Text = newBook.Year.ToString();
            tbNoteworthyInformation.Text = newBook.Author.NoteworthyInformation;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //Button editButton = (Button)sender;

            ListBoxItem selectedItemEdit = (ListBoxItem)lstBooks.SelectedItem;
            if (selectedItemEdit != null)
            {
                if (int.TryParse(tbBirthyear.Text, out int yearOfBirth) && int.TryParse(tbYear.Text, out int yearPublished))
                {
                    Book newBook = (Book)selectedItemEdit.Tag;
                    newBook.Author.Name = tbAuthor.Text;
                    newBook.Title = tbTitle.Text;
                    newBook.Year = Convert.ToInt32(tbYear.Text);
                    newBook.Author.YearOfBirth = Convert.ToInt32(tbBirthyear.Text);
                    newBook.Author.NoteworthyInformation = tbNoteworthyInformation.Text;

                    selectedItemEdit.Tag = newBook;
                    selectedItemEdit.Content = newBook.GetInfo();

                    tbAuthor.Text = "";
                    tbTitle.Text = "";
                    tbYear.Text = "";
                    tbBirthyear.Text = "";
                    tbNoteworthyInformation.Text = "";

                }
                else
                {
                    MessageBox.Show("Years can only be numbers!");
                }
            }
            else
            {
                MessageBox.Show("You must select an item!");
            }



        }

        //private void nånting
        //    {
        //                    if (lstBooks.SelectedItem != null)
        //        {
        //            btnEdit.Visibility = Visibility.Visible
        //}
        //        else
        //        {
        //            btnEdit.Visibility = Visibility.Collapsed;
        //        }
    }
}

//private void Button_Click_Edit(object sender, RoutedEventArgs e)
//{

//}


