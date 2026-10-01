namespace lab2_TPO_B
{
    /// <summary>
    /// Клас для обчислення значення кусково-заданої функції f(x):
    /// f(x) = 2 / (x^2 + 1),           якщо -3 <= x <= 3
    /// f(x) = |x^3 - 7| / x,           у інших випадках (з перевіркою на x == 0)
    /// </summary>
    public class FunctionCalculator
    {
        /// <summary>
        /// Обчислює значення функції f(x) відповідно до кусково-заданого визначення.
        /// </summary>
        /// <param name="x">Значення аргументу функції</param>
        /// <returns>Значення функції f(x)</returns>
        /// <exception cref="FunctionArgumentException">
        /// Викидається, коли x == 0 у гілці |x^3-7|/x (поза діапазоном [-3, 3])
        /// </exception>
        public static double Calculate(double x)
        {
            // Перевіримо, чи значення аргументу знаходиться в діапазоні [-3, 3]
            if (x >= -3 && x <= 3)
            {
                // Гілка 1: якщо -3 <= x <= 3
                // Обчислюємо f(x) = 2 / (x^2 + 1)
                // Знаменник (x^2 + 1) завжди > 0, тому ділення на нуль неможливе
                double denominator = x * x + 1;
                return 2.0 / denominator;
            }
            else
            {
                // Гілка 2: якщо x < -3 або x > 3
                // Обчислюємо f(x) = |x^3 - 7| / x
                // КРИТИЧНО: перевіряємо, чи x == 0, оскільки це призводить до ділення на нуль
                if (x == 0)
                {
                    // Генеруємо власний виняток з описовим повідомленням українською
                    throw new FunctionArgumentException(
                        "Неможливо обчислити функцію: аргумент x=0 у гілці |x^3-7|/x призводить до ділення на нуль");
                }

                // Обчислюємо чисельник: |x^3 - 7| — абсолютне значення вирази (x^3 - 7)
                double numerator = Math.Abs(x * x * x - 7);

                // Обчислюємо результат: чисельник поділити на x
                return numerator / x;
            }
        }
    }

    /// <summary>
    /// Кастомний клас винятку для обробки помилок, пов'язаних з недопустимими значеннями аргументу функції.
    /// </summary>
    public class FunctionArgumentException : Exception
    {
        /// <summary>
        /// Конструктор з повідомленням про помилку.
        /// </summary>
        /// <param name="message">Описове повідомлення про помилку українською</param>
        public FunctionArgumentException(string message) : base(message)
        {
        }

        /// <summary>
        /// Конструктор з повідомленням та внутрішнім винятком.
        /// </summary>
        /// <param name="message">Описове повідомлення про помилку</param>
        /// <param name="innerException">Внутрішній виняток</param>
        public FunctionArgumentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
