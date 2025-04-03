using System.Reflection;

namespace Main;

/// <summary>
/// Автор статьи
/// </summary>
public class Author //Publisher
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
        if (obj == null || obj.GetType() != this.GetType()) return false;

        if (obj is Author temp)
        {
            return Name == temp.Name && Surname == temp.Surname && Birthday == temp.Birthday;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Surname.GetHashCode() + Birthday.GetHashCode();
    }

    public static bool operator ==(Author p1, Author p2)
    {
        if ((object)p1 == null || (object)p2 == null) return false;
        return p1.Name == p2.Name && p1.Surname == p2.Surname && p1.Birthday == p2.Birthday;
    }

    public static bool operator !=(Author p1, Author p2)
    {
        if ((object)p1 == null || (object)p2 == null) return false;
        return p1.Name != p2.Name || p1.Surname != p2.Surname || p1.Birthday != p2.Birthday;
    }

    public virtual object DeepCopy()
    {
        return new Author(Name, Surname, Birthday);
    }
}