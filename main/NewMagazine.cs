using Main.Enum;
using System.Collections;

namespace Main;

class NewMagazine : Edition, IRateAndCopy
{
    /// <summary>
    /// Периодичность выхода журнала
    /// </summary>
    private Frequency _frequency;

    /// <summary>
    /// Список редакторов журнала (Author)
    /// </summary>
    private ArrayList _editors;

    /// <summary>
    /// Cписок статей в журнале (Article)
    /// </summary>
    private ArrayList _articles;

    public Frequency Frequency { get; set; }
    public ArrayList Editors { get; set; }
    public ArrayList Articles { get; set; }

    /// <summary>
    /// Средний рейтинг статей
    /// </summary>
    public double AverageRating
    {
        get
        {
            if (Articles == null) return 0;
            double sum = 0;
            foreach (Article i in Articles)
            {
                sum += i.Rating;
            }
            return sum / Articles.Count;
        }
    }

    /// <summary>
    /// Оценка
    /// </summary>
    public double Rating { get; set; }


    public Edition Edition
    {
        get { return new Edition(Title, ReleaseDate, Tiraj); }
        set { Title = value.Title; ReleaseDate = value.ReleaseDate; Tiraj = value.Tiraj; }
    }

    /// <summary>
    ///  Базовый конструктор
    /// </summary>
    public NewMagazine() : base()
    {
        Frequency = Frequency.Monthly;
        Editors = new ArrayList();
        Articles = new ArrayList();
    }

    public NewMagazine(string title, DateTime releseDate, int tiraj, Frequency frequency) : base(title, releseDate, tiraj)
    {
        Frequency = frequency;
        Editors = new ArrayList();
        Articles = new ArrayList();
    }

    /// <summary>
    /// Добавление статей
    /// </summary>
    /// <param name="articles">Статья</param>
    public void AddArticles(params Article[] articles)
    {
        foreach (Article a in articles)
        {
            Articles.Add(a);
        }
    }

    /// <summary>
    /// Добавление авторов
    /// </summary>
    /// <param name="editors">Автор</param>
    public void AddEditors(params Author[] editors)
    {
        foreach (Author p in editors)
        {
            Editors.Add(p);
        }
    }

    public override string ToString()
    {
        string result = $"{Title}\n{ReleaseDate.ToLongDateString()}\n{Tiraj}\n{Frequency}\n";

        result += "Авторы: " + "\n";
        foreach (Author temp in Editors)
        {
            result += temp.ToString() + "\n";
        }

        result += "Статьи: " + "\n";
        foreach (Article a in Articles)
        {
            result += a.ToString() + "\n";
        }

        return result;
    }

    public virtual string ToShortString()
    {
        return $"{Title}\n{ReleaseDate.ToLongDateString()}\n{Tiraj}\n{Frequency}\n{AverageRating}";
    }

    public override object DeepCopy()
    {
        NewMagazine copy = new NewMagazine(Title, ReleaseDate, Tiraj, Frequency);
        foreach (Author p in Editors)
        {
            copy.Editors.Add(p);
        }
        foreach (Article a in Articles)
        {
            copy.Articles.Add(a);
        }
        return copy;
    }

    /// <summary>
    /// Итератор с параметром типа double для перебора статей
    /// </summary>
    /// <param name="rating">рейтинг заданного значения</param>
    /// <returns></returns>
    public IEnumerable GetArticles(double rating)
    {
        foreach (Article a in Articles)
        {
            if (a.Rating > rating)
            {
                yield return a;
            }
        }
    }

    /// <summary>
    /// Итератор с параметром типа string для перебора статей
    /// </summary>
    /// <param name="substr">Заданная строка для перебора</param>
    /// <returns></returns>
    public IEnumerable GetArticles(string substr)
    {
        foreach (Article a in Articles)
        {
            if (a.Title.Contains(substr))
            {
                yield return a;
            }
        }
    }
}
