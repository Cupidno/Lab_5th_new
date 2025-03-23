namespace Main;

/// <summary>
/// Автор статьи
/// </summary>
public class Author
{
    /// <summary>
    /// Имя
    /// </summary>
    private string name;

    /// <summary>
    /// Фамилия
    /// </summary>
    private string surname;

    /// <summary>
    /// День рождения
    /// </summary>
    private DateTime birthday;

    /// <summary>
    /// Создать автора
    /// </summary>
    /// <param name="name">Имя</param>
    /// <param name="surname">Фамилия</param>
    /// <param name="birthday">День рождения</param>
    public Author(string name, string surname, DateTime birthday)
    {
        this.name = name;
        this.surname = surname;
        this.birthday = birthday;
    }

    public Author()
    {
        name = "Dima";
        surname = "Revo";
        birthday = new DateTime(2005, 08, 08);
    }

    public string Name { get { return name; } set { name = value; } }
    public string Surname { get { return surname; } set { surname = value; } }
    public DateTime Birthday { get { return birthday; } set { birthday = value; } }
    public int Year { get { return birthday.Year; } set { Year = value; } }

    public override string ToString()
    {
        return $"{Name} {Surname} {birthday:dd/MM/yyyy}";
    }

    public virtual string ToShortString()
    {
        return $"{Name} {Surname}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
}