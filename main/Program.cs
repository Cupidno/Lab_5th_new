using Main.Enum;

namespace Main;

/// <summary>
/// Основной класс программы
/// </summary>
public class Program
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    /// <param name="args">Аргументы командной строки</param>
    static void Main(string[] args)
    {
        // Демонстрация работы с классом Edition
        DemonstrateEdition();
        
        // Демонстрация работы с классом NewMagazine
        DemonstrateNewMagazine();
    }
    
    /// <summary>
    /// Демонстрирует работу с классом Edition
    /// </summary>
    private static void DemonstrateEdition()
    {
        Console.WriteLine("=== Демонстрация работы с классом Edition ===");
        
        // Создание и вывод первого издания
        Edition edition = new Edition("Арбузы", new DateTime(2025, 04, 03), 10);
        Console.WriteLine("Первое издание:");
        Console.WriteLine(edition.ToString());
        Console.WriteLine();

        // Создание и вывод второго издания с теми же параметрами
        Edition edition2 = new Edition("Арбузы", new DateTime(2025, 04, 03), 10);
        Console.WriteLine("Второе издание:");
        Console.WriteLine(edition2.ToString());
        Console.WriteLine();

        // Сравнение ссылок и значений
        Console.WriteLine($"Равны ли ссылки? {ReferenceEquals(edition, edition2)}");
        Console.WriteLine($"Равны ли значения? {edition.Equals(edition2)}");
        Console.WriteLine();

        // Вывод хеш-кодов
        Console.WriteLine($"Hash code edition = {edition.GetHashCode()}");
        Console.WriteLine($"Hash code edition2 = {edition2.GetHashCode()}");
        Console.WriteLine();

        // Демонстрация обработки исключений
        try
        {
            Console.WriteLine("Попытка создать издание с отрицательным тиражом:");
            Edition edition3 = new Edition("Арбузы", new DateTime(2025, 03, 06), -1);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
        
        Console.WriteLine("\n" + new string('=', 50) + "\n");
    }
    
    /// <summary>
    /// Демонстрирует работу с классом NewMagazine
    /// </summary>
    private static void DemonstrateNewMagazine()
    {
        Console.WriteLine("=== Демонстрация работы с классом NewMagazine ===");
        
        // Создание журнала
        NewMagazine newMagazine = new NewMagazine("Ну Журнал", new DateTime(2025, 04, 03), 10, Frequency.Monthly);
        
        // Создание авторов
        Author author = new Author("Dmitriy", "Revo", new DateTime(2005, 08, 08));
        Author author2 = new Author("Ivan", "Petrov", new DateTime(2000, 05, 15));
        Author author3 = new Author("Anna", "Sidorova", new DateTime(2002, 12, 22));

        // Создание статей
        Article article = new Article(author, "Как производить Пармезан", 10);
        Article article1 = new Article(author, "Как производить Рокфор", 9);
        Article article2 = new Article(author2, "Как производить Горгонзолу", 8);
        Article article3 = new Article(author3, "Секреты Моцареллы", 10);

        // Добавление статей и редакторов в журнал
        newMagazine.AddArticles(article, article1, article2, article3);
        newMagazine.AddEditors(author, author3);
        
        // Вывод информации о журнале
        Console.WriteLine("Информация о журнале:");
        Console.WriteLine(newMagazine.ToString());
        Console.WriteLine();

        // Вывод информации об издании
        Console.WriteLine("Информация об издании:");
        Console.WriteLine(newMagazine.Edition.ToString());
        Console.WriteLine();

        // Демонстрация глубокого копирования
        NewMagazine copy = (NewMagazine)newMagazine.DeepCopy();
        Console.WriteLine("КОПИЯ ЖУРНАЛА:");
        Console.WriteLine(copy.ToString());
        Console.WriteLine();

        // Изменение названия оригинального журнала
        newMagazine.Title = "Сыр как смысл жизни";
        Console.WriteLine("ОРИГИНАЛ ЖУРНАЛА (после изменения названия):");
        Console.WriteLine(newMagazine.ToString());
        Console.WriteLine();

        // Демонстрация фильтрации статей по рейтингу
        Console.WriteLine("Статьи с рейтингом 9+:");
        foreach (Article a in newMagazine.GetArticles(8))
        {
            Console.WriteLine(a.ToString());
        }
        Console.WriteLine();
        
        // Демонстрация фильтрации статей по ключевому слову
        Console.WriteLine("Статьи с ключевым словом (Пармезан):");
        foreach (Article a in newMagazine.GetArticles("Пармезан"))
        {
            Console.WriteLine(a.ToString());
        }
        Console.WriteLine();
        
        // Демонстрация работы реализации IEnumerable
        Console.WriteLine("Перебор всех статей через IEnumerator:");
        foreach (Article a in newMagazine)
        {
            Console.WriteLine(a.ToString());
        }
        Console.WriteLine();
        
        // Демонстрация работы новых методов
        Console.WriteLine("Авторы, не являющиеся редакторами:");
        foreach (Author a in newMagazine.NotEditors())
        {
            Console.WriteLine(a.ToString());
        }
        Console.WriteLine();
        
        Console.WriteLine("Редакторы, являющиеся авторами:");
        foreach (Author a in newMagazine.EditorsAuthors())
        {
            Console.WriteLine(a.ToString());
        }
        Console.WriteLine();
        
        Console.WriteLine("Редакторы, не являющиеся авторами:");
        foreach (Author a in newMagazine.NotAuthors())
        {
            Console.WriteLine(a.ToString());
        }
    }
}
