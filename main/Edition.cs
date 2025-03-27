namespace Main;

/// <summary>
/// Издание
/// </summary>
internal class Edition
{
    /// <summary>
    /// Название издания
    /// </summary>
    protected string title;

    /// <summary>
    /// Дата выхода издания
    /// </summary>
    protected DateTime releaseDate;

    /// <summary>
    /// Тираж издания
    /// </summary>
    protected int tiraj;

    /// <summary>
    /// Конструктор издания 
    /// </summary>
    /// <param name="title">Название издания</param>
    /// <param name="releaseDate">Дата выхода издания</param>
    /// <param name="tiraj">Тираж издания</param>
    public Edition(string title, DateTime releaseDate, int tiraj)
    {
        this.title = title;
        this.releaseDate = releaseDate;
        this.tiraj = tiraj;
    }

    /// <summary>
    /// Конструктор издания
    /// </summary>
    public Edition()
    {
        title = "Без названия";
        releaseDate = DateTime.Now;
        tiraj = 0;
    }

    public string Title { get { return title; } set { title = value; } }
    public DateTime ReleaseDate { get { return releaseDate; } set { releaseDate = value; } }
    public int Tiraj
    {
        get { return tiraj; }

        set
        {
            if (value < 0)
                throw new ArgumentException("Тираж не может быть отрицательным!");
            tiraj = value;
        }
    }

    /// <summary>
    /// Виртуальный метод глубокого копирования
    /// </summary>
    public virtual object DeepCopy()
    {
        return new Edition(title, releaseDate, tiraj);
    }

    /// <summary>
    /// ...
    /// </summary>
    /// <returns></returns>
    public virtual int GetHashCode()
    {
        return 0;
    }


    public override string ToString()
    {
        return $"{Title} {ReleaseDate} {Tiraj}";
    }
}

