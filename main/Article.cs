namespace Main;

/// <summary>
/// Статья
/// </summary>
public class Article
{
    /// <summary>
    /// Автор
    /// </summary>
    public Author Author { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Оценка
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Создать статью
    /// </summary>
    /// <param name="author">Автор</param>
    /// <param name="title">Наименование</param>
    /// <param name="rating">Оценка</param>
    public Article(Author author, string title, double rating)
    {
        Author = author;
        Title = title;
        Rating = rating;
    }

    public Article()
    {
        Author = new Author();
        Title = "В мире животных!";
        Rating = 0;
    }

    public override string ToString()
    {
        return $"{Author} {Title} {Rating}";
    }
}