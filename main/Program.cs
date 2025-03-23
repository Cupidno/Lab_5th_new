using Main.Enum;
using System.Diagnostics;

namespace Main;

public class Program
{
    static void Main(string[] args)
    {
        #region 1
        Magazine magazine = new Magazine("Playboy", Frequency.Monthly, new DateTime(1999, 2, 2), 1000);
        Console.WriteLine(magazine.ToShortString());
        #endregion

        #region 2
        Console.WriteLine("Выходит ли журнал наждую неделю ?" + magazine[Frequency.Weekly]);
        Console.WriteLine("Выходит ли журнал наждый месяц ?" + magazine[Frequency.Monthly]);
        Console.WriteLine("Выходит ли журнал наждый год ?" + magazine[Frequency.Yearly]);
        #endregion

        #region 3 4
        Author author = new Author("Dmirtiy", "Revo", new DateTime(2005, 8, 8));

        Article article = new Article(author, "Как клеить обои.", 0);

        magazine.AddArticles(new Article[] { article });
        Console.WriteLine(magazine.ToString());
        #endregion

        #region 5
        int rows = 1000;
        int columns = 1000;

        Article[] Array1 = new Article[rows * columns];
        Article[,] Array2 = new Article[rows, columns];
        Article[][] jaggedArray = new Article[rows][];
        for (int i = 0; i < rows; i++)
            jaggedArray[i] = new Article[columns];

        Stopwatch timer = new Stopwatch();

        //для одномерного массива
        timer.Start();
        int size = rows * columns;
        for (int i = 0; i < size; i++)
            Array1[i] = new Article();
        timer.Stop();
        Console.WriteLine($"Измерение времени для одномерного массива: {timer.Elapsed.TotalSeconds} сек");

        //для двумерного массива
        timer.Restart();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                Array2[i, j] = new Article();
        timer.Stop();
        Console.WriteLine($"Измерение времени для двумерного массива: {timer.Elapsed.TotalSeconds} сек");

        //для ступенчатого массива
        timer.Restart();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                jaggedArray[i][j] = new Article();
        timer.Stop();
        Console.WriteLine($"Измерение времени для ступенчатого массива: {timer.Elapsed.TotalSeconds} сек");
        #endregion
    }
}
