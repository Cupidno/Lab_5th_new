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
        this.Tiraj = tiraj;
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

    // Свойства
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
        return new Edition(Title, ReleaseDate, Tiraj);
    }

    /// <summary>
    /// Метод равенства объектов как совпадение всех данных объектов.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public virtual bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType()) return false;

        if (obj is Edition temp)
        {
            return Title == temp.Title && ReleaseDate == temp.ReleaseDate && Tiraj == temp.Tiraj;
        }
        return false;
    }

    /// <summary>
    /// Метод GetHashCode
    /// </summary>
    /// <returns>Сумма всех ГХК объектов</returns>
    public override int GetHashCode()
    {
        return Tiraj.GetHashCode() + ReleaseDate.GetHashCode() + Title.GetHashCode();
    }


    public override string ToString()
    {
        return $"{Title} {ReleaseDate} {Tiraj}";
    }

    /// <summary>
    /// Переопределенный "=="
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static bool operator ==(Edition p1, Edition p2)
    {
        if ((object)p1 == null || (object)p2 == null) return false;
        return p1.Title == p2.Title && p1.ReleaseDate == p2.ReleaseDate && p1.Tiraj == p2.Tiraj;
    }

    /// <summary>
    /// Переопределенный "!="
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static bool operator !=(Edition p1, Edition p2)
    {
        if ((object)p1 == null || (object)p2 == null) return false;
        return p1.Title != p2.Title || p1.ReleaseDate != p2.ReleaseDate || p1.Tiraj != p2.Tiraj;
    }
}

