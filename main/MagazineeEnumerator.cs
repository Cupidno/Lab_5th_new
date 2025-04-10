using System.Collections;

namespace Main
{
    /// <summary>
    /// Класс для перебора статей в журнале
    /// </summary>
    class MagazineeEnumerator : IEnumerator
    {
        private readonly NewMagazine _magazine;
        private int _current = -1;

        /// <summary>
        /// Создает новый экземпляр перечислителя для журнала
        /// </summary>
        /// <param name="magazine">Журнал для перебора</param>
        public MagazineeEnumerator(NewMagazine magazine)
        {
            _magazine = magazine ?? throw new ArgumentNullException(nameof(magazine));
        }

        /// <summary>
        /// Получает текущий элемент в переборе
        /// </summary>
        public object Current
        {
            get
            {
                if (_current < 0 || _current >= _magazine.Articles.Count)
                    throw new InvalidOperationException("Перечислитель находится в недопустимом состоянии");
                return _magazine.Articles[_current];
            }
        }

        /// <summary>
        /// Перемещает перечислитель к следующему элементу
        /// </summary>
        /// <returns>true, если перечислитель успешно перемещен к следующему элементу; false, если перечислитель достиг конца коллекции</returns>
        public bool MoveNext()
        {
            if (_current < _magazine.Articles.Count - 1)
            {
                _current++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Устанавливает перечислитель в начальное положение перед первым элементом коллекции
        /// </summary>
        public void Reset()
        {
            _current = -1;
        }
    }
}