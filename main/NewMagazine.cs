using Main.Enum;
using System.Collections;

namespace Main;

/// <summary>
/// Класс, представляющий журнал с расширенной функциональностью
/// </summary>
class NewMagazine : Edition, IRateAndCopy, IEnumerable
{
    /// <summary>
    /// Периодичность выхода журнала
    /// </summary>
    private Frequency _frequency;

    /// <summary>
    /// Список редакторов журнала
    /// </summary>
    private readonly ArrayList _editors;

    /// <summary>
    /// Список статей в журнале
    /// </summary>
    private readonly ArrayList _articles;

    /// <summary>
    /// Получает или устанавливает периодичность выхода журнала
    /// </summary>
    public Frequency Frequency { get; set; }

    /// <summary>
    /// Получает или устанавливает список редакторов журнала
    /// </summary>
    public ArrayList Editors { get; set; }

    /// <summary>
    /// Получает или устанавливает список статей в журнале
    /// </summary>
    public ArrayList Articles { get; set; }

    /// <summary>
    /// Получает средний рейтинг статей в журнале
    /// </summary>
    public double AverageRating
    {
        get
        {
            if (Articles == null || Articles.Count == 0) return 0;

            double sum = 0;
            foreach (Article article in Articles)
            {
                sum += article.Rating;
            }
            return sum / Articles.Count;
        }
    }

    /// <summary>
    /// Получает или устанавливает рейтинг журнала
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Получает или устанавливает издание журнала
    /// </summary>
    public Edition Edition
    {
        get { return new Edition(Title, ReleaseDate, Tiraj); }
        set
        {
            Title = value.Title;
            ReleaseDate = value.ReleaseDate;
            Tiraj = value.Tiraj;
        }
    }

    /// <summary>
    /// Создает новый экземпляр журнала с параметрами по умолчанию
    /// </summary>
    public NewMagazine() : base()
    {
        Frequency = Frequency.Monthly;
        Editors = new ArrayList();
        Articles = new ArrayList();
    }

    /// <summary>
    /// Создает новый экземпляр журнала с указанными параметрами
    /// </summary>
    /// <param name="title">Название журнала</param>
    /// <param name="releaseDate">Дата выпуска</param>
    /// <param name="tiraj">Тираж</param>
    /// <param name="frequency">Периодичность выхода</param>
    public NewMagazine(string title, DateTime releaseDate, int tiraj, Frequency frequency)
        : base(title, releaseDate, tiraj)
    {
        Frequency = frequency;
        Editors = new ArrayList();
        Articles = new ArrayList();
    }

    /// <summary>
    /// Добавляет статьи в журнал
    /// </summary>
    /// <param name="articles">Статьи для добавления</param>
    public void AddArticles(params Article[] articles)
    {
        if (articles == null) return;

        foreach (Article article in articles)
        {
            if (article != null)
            {
                Articles.Add(article);
            }
        }
    }

    /// <summary>
    /// Добавляет редакторов в журнал
    /// </summary>
    /// <param name="editors">Редакторы для добавления</param>
    public void AddEditors(params Author[] editors)
    {
        if (editors == null) return;

        foreach (Author editor in editors)
        {
            if (editor != null)
            {
                Editors.Add(editor);
            }
        }
    }

    /// <summary>
    /// Возвращает строковое представление журнала
    /// </summary>
    /// <returns>Строковое представление журнала</returns>
    public override string ToString()
    {
        string result = $"{Title}\n{ReleaseDate.ToLongDateString()}\n{Tiraj}\n{Frequency}\n";

        result += "Авторы: " + "\n";
        foreach (Author editor in Editors)
        {
            result += editor.ToString() + "\n";
        }

        result += "Статьи: " + "\n";
        foreach (Article article in Articles)
        {
            result += article.ToString() + "\n";
        }

        return result;
    }

    /// <summary>
    /// Возвращает краткое строковое представление журнала
    /// </summary>
    /// <returns>Краткое строковое представление журнала</returns>
    public virtual string ToShortString()
    {
        return $"{Title}\n{ReleaseDate.ToLongDateString()}\n{Tiraj}\n{Frequency}\n{AverageRating}";
    }

    /// <summary>
    /// Создает глубокую копию журнала
    /// </summary>
    /// <returns>Глубокая копия журнала</returns>
    public override object DeepCopy()
    {
        NewMagazine copy = new NewMagazine(Title, ReleaseDate, Tiraj, Frequency);

        foreach (Author editor in Editors)
        {
            copy.Editors.Add(editor);
        }

        foreach (Article article in Articles)
        {
            copy.Articles.Add(article);
        }

        return copy;
    }

    /// <summary>
    /// Возвращает перечислитель для перебора статей в журнале
    /// </summary>
    /// <returns>Перечислитель статей</returns>
    public IEnumerator GetEnumerator()
    {
        return new MagazineeEnumerator(this);
    }

    /// <summary>
    /// Возвращает статьи с рейтингом выше указанного
    /// </summary>
    /// <param name="rating">Минимальный рейтинг</param>
    /// <returns>Коллекция статей с рейтингом выше указанного</returns>
    public IEnumerable GetArticles(double rating)
    {
        foreach (Article article in Articles)
        {
            if (article.Rating > rating)
            {
                yield return article;
            }
        }
    }

    /// <summary>
    /// Возвращает статьи, содержащие указанную подстроку в названии
    /// </summary>
    /// <param name="substr">Подстрока для поиска</param>
    /// <returns>Коллекция статей, содержащих указанную подстроку в названии</returns>
    public IEnumerable GetArticles(string substr)
    {
        if (string.IsNullOrEmpty(substr)) yield break;

        foreach (Article article in Articles)
        {
            if (article.Title.Contains(substr))
            {
                yield return article;
            }
        }
    }

    /// <summary>
    /// Возвращает авторов, которые не являются редакторами
    /// </summary>
    /// <returns>Коллекция авторов, не являющихся редакторами</returns>
    public IEnumerable NotEditors()
    {
        HashSet<Author> editors = new();
        foreach (Author editor in Editors)
        {
            editors.Add(editor);
        }

        HashSet<Author> authors = new();
        foreach (Article article in Articles)
        {
            authors.Add(article.Author);
        }

        foreach (Author author in authors.Except(editors))
        {
            yield return author;
        }
    }

    /// <summary>
    /// Возвращает редакторов, которые являются авторами
    /// </summary>
    /// <returns>Коллекция редакторов, являющихся авторами</returns>
    public IEnumerable EditorsAuthors()
    {
        HashSet<Author> editors = new();
        foreach (Author editor in Editors)
        {
            editors.Add(editor);
        }

        HashSet<Author> authors = new();
        foreach (Article article in this)
        {
            authors.Add(article.Author);
        }

        foreach (Author editor in editors.Intersect(authors))
        {
            yield return editor;
        }
    }

    /// <summary>
    /// Возвращает редакторов, которые не являются авторами
    /// </summary>
    /// <returns>Коллекция редакторов, не являющихся авторами</returns>
    public IEnumerable NotAuthors()
    {
        HashSet<Author> editors = new();
        foreach (Author editor in Editors)
        {
            editors.Add(editor);
        }

        HashSet<Author> authors = new();
        foreach (Article article in this)
        {
            authors.Add(article.Author);
        }

        foreach (Author editor in editors.Except(authors))
        {
            yield return editor;
        }
    }
}
