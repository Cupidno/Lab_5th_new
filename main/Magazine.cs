using Main.Enum;

namespace Main;

/// <summary>
/// Журнал
/// </summary>
public class Magazine
{
    /// <summary>
    /// Наименование журнала
    /// </summary>
    private string name;

    /// <summary>
    /// Частота выхода
    /// </summary>
    private Frequency frequency;

    /// <summary>
    /// Дата публикации
    /// </summary>
    private DateTime datereales;

    /// <summary>
    /// Тираж
    /// </summary>
    private int tiraj;  
    
    /// <summary>
    /// Статьи
    /// </summary>
    private Article[] articles;

    /// <summary>
    /// Создать журнал
    /// </summary>
    /// <param name="name">Наименование журнала</param>
    /// <param name="frequency">Частота выхода</param>
    /// <param name="datereales">Дата публикации</param>
    /// <param name="tiraj">Тираж</param>
    public Magazine(string name, Frequency frequency, DateTime datereales, int tiraj)
    {
        this.name = name;
        this.frequency = frequency;
        this.datereales = datereales;
        this.tiraj = tiraj;
        articles = new Article[0];
    }

    public Magazine()
    {
        name = "Название";
        frequency = Frequency.Weekly;
        datereales = DateTime.Now;
        tiraj = 1000;
        articles = new Article[0];
    }

    public string Name { get { return name; } set { name = value; } }
    public Frequency Frequency { get { return frequency; } set { frequency = value; } }
    public DateTime Datereales { get { return datereales; } set { datereales = value; } }
    public int Tiraj { get { return tiraj; } set { tiraj = value; } }
    public Article[] Articles { get { return articles; } set { articles = value; } }

    /// <summary>
    /// Средняя оценка журнала 
    /// </summary>
    public double AverageRating
    {
        
        get
        {
            if (articles.Length == 0)
                return 0;
            double sum = 0;
            foreach (Article item in Articles)
            {
                sum += item.Rating;
            }
            return sum / Articles.Length;
        }
    }

    /// <summary>
    /// Индексатор
    /// </summary>
    /// <param name="frequency"></param>
    /// <returns>Выходит ли журнал с указанной частотой</returns>
    public bool this[Frequency frequency]
    {
        get { return this.frequency == frequency; }
    }

    /// <summary>
    /// Добавить статью в журнал
    /// </summary>
    /// <param name="newArticles">Новые статьи</param>
    public void AddArticles(Article[] newArticles)
    {
        int length = newArticles.Length;
        Array.Resize(ref articles, articles.Length + length);

        for (int i = 0; i < articles.Length; i++)
        {
            articles[length - 1 + i] = newArticles[i];
        }
    }
    public override string ToString()
    {
        string str = Name + " " + Frequency + " " + Datereales.ToLongDateString() + " " + Tiraj + " " + AverageRating + "\n";
        foreach (var item in Articles)
        {
            str += item.ToString() + "\n";
        }
        return str;
    }
    public virtual string ToShortString()
    {
        return $"Название: {Name}\nЧастота: {Frequency}\nДата выпуска: {Datereales.ToLongDateString()}\nТираж: {Tiraj}\nСредний рейтинг: {AverageRating}";
    }


}

