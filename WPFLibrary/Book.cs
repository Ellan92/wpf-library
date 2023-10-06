namespace WPFLibrary
{
    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }

        public Author Author { get; set; }

        public string GetInfo()
        {
            return $"{Title}\nYear published {Year}\nAuthor: {Author.Name}\nYear of birth: {Author.YearOfBirth}\nNoteworthy Information: {Author.NoteworthyInformation}";
        }

    }

    public class Author
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public string NoteworthyInformation { get; set; }
    }
}
