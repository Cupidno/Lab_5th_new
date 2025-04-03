using Main.Enum;

namespace Main;

public class Program
{
    static void Main(string[] args)
    {
        Edition edition = new Edition("Арбузы", new DateTime(2025, 04, 03), 10);
        Console.WriteLine(edition.ToString());

        Edition edition2 = new Edition("Арбузы", new DateTime(2025, 04, 03), 10);
        Console.WriteLine(edition2.ToString());

        Console.WriteLine($"Равны ли ссылки? {ReferenceEquals(edition, edition2)}");
        Console.WriteLine($"Равны ли значения? {edition.Equals(edition2)}");

        Console.WriteLine($"Hash code edition = {edition.GetHashCode()}");
        Console.WriteLine($"Hash code edition2 = {edition2.GetHashCode()}");

        try
        {
            Edition edition3 = new Edition("Арбузы", new DateTime(2025, 03, 06), -1);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }

        NewMagazine newMagazine = new NewMagazine("Ну Журнал", new DateTime(2025, 04, 03), 10, Frequency.Monthly);

        //Editors
        Author author = new Author("Dmitriy", "Revo", new DateTime(2005, 08, 08));

        //Article

        Article article = new Article(author, "Как производить Пармезан", 10);
        Article article1 = new Article(author, "Как производить Рокфор", 9);
        Article article2 = new Article(author, "Как производить Горгонзолу", 8);

        newMagazine.AddArticles(article, article1, article2);
        newMagazine.AddEditors(author);
        Console.WriteLine(newMagazine.ToString());

        Console.WriteLine(newMagazine.Edition.ToString());

        NewMagazine copy = (NewMagazine)newMagazine.DeepCopy();
        Console.WriteLine("КОПИЯ\n" + copy.ToString());

        newMagazine.Title = "Сыр как смысл жизни";

        Console.WriteLine("ОРИГИНАЛ\n" + newMagazine.ToString());

        Console.WriteLine("Статьи с рейтингом 9+");
        foreach (Article a in newMagazine.GetArticles(8))
        {
            Console.WriteLine(a.ToString());
        }
        Console.WriteLine("Статья с ключ. словом (Пармезан)");
        foreach (Article a in newMagazine.GetArticles("Пармезан"))
        {
            Console.WriteLine(a.ToString());
        }
    }
}
