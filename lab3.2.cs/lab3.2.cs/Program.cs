using System;
using System.Linq;
class PrintedEdition
{
    public string Title { get; set; }
    public int Pages { get; set; }

    public PrintedEdition(string title, int pages)
    {
        Title = title;
        Pages = pages;
    }
    public virtual void Show()
    {
        Console.WriteLine($"[Видання] Назва: {Title}, Сторінок: {Pages}");
    }
}
class Book : PrintedEdition
{
    public string Author { get; set; }

    public Book(string title, int pages, string author) : base(title, pages)
    {
        Author = author;
    }
    public override void Show()
    {
        Console.WriteLine($"[Книга] Назва: {Title}, Автор: {Author}, Сторінок: {Pages}");
    }
}
class Magazine : PrintedEdition
{
    public int IssueNumber { get; set; }

    public Magazine(string title, int pages, int issueNumber) : base(title, pages)
    {
        IssueNumber = issueNumber;
    }

    public override void Show()
    {
        Console.WriteLine($"[Журнал] Назва: {Title}, Номер: {IssueNumber}, Сторінок: {Pages}");
    }
}
class Textbook : Book
{
    public string Subject { get; set; }

    public Textbook(string title, int pages, string author, string subject)
        : base(title, pages, author)
    {
        Subject = subject;
    }
    public override void Show()
    {
        Console.WriteLine($"[Підручник] Предмет: {Subject}, Назва: {Title}, Автор: {Author}");
    }
}
class Program
{
    static void Main()
    {
        PrintedEdition[] editions = FillArray();

        Console.WriteLine("Список видань (впорядкований за типом)");
        var sortedEditions = editions.OrderBy(e => e.GetType().Name);
 foreach (var item in sortedEditions)
        {
            item.Show();
        }
    }
    static PrintedEdition[] FillArray()
    {
        return new PrintedEdition[]
        {
            new Magazine("National Geographic", 64, 12),
            new Book("Kobzar", 400, "Taras Shevchenko"),
            new Textbook("C# Programming", 500, "John Smith", "Computer Science"),
            new PrintedEdition("General Catalog", 20),
            new Magazine("Vogue", 120, 5)
        };
    }
}
