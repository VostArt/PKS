using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание (1-7) или 0 для выхода:");
            Console.WriteLine("1. Ряды Маклорена");
            Console.WriteLine("2. Счастливый билет");
            Console.WriteLine("3. Сокращение дроби");
            Console.WriteLine("4. Угадай число");
            Console.WriteLine("5. Кофейный аппарат");
            Console.WriteLine("6. Лабораторный опыт");
            Console.WriteLine("7. Колонизация Марса");
            
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный ввод!");
                continue;
            }
            
            switch (choice)
            {
                case 0:
                    return;
                case 1:
                    CalculateMaclaurinSeries();
                    break;
                case 2:
                    CheckLuckyTicket();
                    break;
                case 3:
                    ReduceFraction();
                    break;
                case 4:
                    GuessNumber();
                    break;
                case 5:
                    CoffeeMachine();
                    break;
                case 6:
                    BacteriaExperiment();
                    break;
                case 7:
                    MarsColonization();
                    break;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    // Задание 1: Ряды Маклорена для sin(x)
    static void CalculateMaclaurinSeries()
    {
        Console.Write("Введите x: ");
        double x = double.Parse(Console.ReadLine());
        
        Console.Write("Введите точность e (e < 0.01): ");
        double e = double.Parse(Console.ReadLine());
        
        if (e >= 0.01)
        {
            Console.WriteLine("Точность должна быть меньше 0.01");
            return;
        }
        
        double sum = 0;
        double term = x;
        int k = 0;
        
        while (Math.Abs(term) > e)
        {
            sum += term;
            k++;
            term = -term * x * x / ((2 * k) * (2 * k + 1));
        }
        
        Console.WriteLine($"sin({x}) ≈ {sum:F6} (точность {e})");
        Console.WriteLine($"Проверка: Math.Sin({x}) = {Math.Sin(x):F6}");
        
        Console.Write("Введите номер члена ряда n: ");
        int n = int.Parse(Console.ReadLine());
        
        double nthTerm = Math.Pow(-1, n - 1) * Math.Pow(x, 2 * n - 1) / CalculateFactorial(2 * n - 1);
        Console.WriteLine($"{n}-й член ряда: {nthTerm:F6}");
    }
    
    static double CalculateFactorial(int num)
    {
        double result = 1;
        for (int i = 2; i <= num; i++)
            result *= i;
        return result;
    }

    // Задание 2: Счастливый билет (без строк и массивов)
    static void CheckLuckyTicket()
    {
        Console.Write("Введите шестизначный номер билета: ");
        int ticket = int.Parse(Console.ReadLine());
        
        if (ticket < 100000 || ticket > 999999)
        {
            Console.WriteLine("Ошибка: номер должен быть шестизначным");
            return;
        }
        
        int digit1 = ticket / 100000;
        int digit2 = (ticket / 10000) % 10;
        int digit3 = (ticket / 1000) % 10;
        int digit4 = (ticket / 100) % 10;
        int digit5 = (ticket / 10) % 10;
        int digit6 = ticket % 10;
        
        int sumFirst = digit1 + digit2 + digit3;
        int sumLast = digit4 + digit5 + digit6;
        
        if (sumFirst == sumLast)
            Console.WriteLine("Билет счастливый!");
        else
            Console.WriteLine("Билет обычный");
    }

    // Задание 3: Сокращение дроби
    static void ReduceFraction()
    {
        Console.Write("Введите числитель M: ");
        int m = int.Parse(Console.ReadLine());
        
        Console.Write("Введите знаменатель N: ");
        int n = int.Parse(Console.ReadLine());
        
        if (n == 0)
        {
            Console.WriteLine("Ошибка: знаменатель не может быть нулем");
            return;
        }
        
        int gcd = FindGCD(m, n);
        int newM = m / gcd;
        int newN = n / gcd;
        
        Console.WriteLine($"{m}/{n} = {newM}/{newN}");
    }
    
    static int FindGCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Задание 4: Угадай число (бинарный поиск)
    static void GuessNumber()
    {
        Console.WriteLine("Загадайте число от 0 до 63.");
        Console.WriteLine("Отвечайте 'д' для ДА или 'н' для НЕТ");
        
        int left = 0;
        int right = 63;
        int questions = 0;
        
        while (left < right && questions < 7)
        {
            int mid = (left + right) / 2;
            Console.Write($"Ваше число больше {mid}? (д/н): ");
            string answer = Console.ReadLine().ToLower();
            
            if (answer == "д")
                left = mid + 1;
            else if (answer == "н")
                right = mid;
            else
            {
                Console.WriteLine("Пожалуйста, введите 'д' или 'н'");
                continue;
            }
            
            questions++;
        }
        
        Console.WriteLine($"Ваше число: {left}");
        Console.WriteLine($"Угадано за {questions} вопросов");
    }

    // Задание 5: Кофейный аппарат
    static void CoffeeMachine()
    {
        Console.Write("Введите количество воды (мл): ");
        int water = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество молока (мл): ");
        int milk = int.Parse(Console.ReadLine());
        
        int americanoCount = 0;
        int latteCount = 0;
        int totalIncome = 0;
        
        while (true)
        {
            Console.WriteLine($"\nОстаток: вода - {water} мл, молоко - {milk} мл");
            Console.WriteLine("Выберите напиток:");
            Console.WriteLine("1 - Американо (300 мл воды, 150 руб)");
            Console.WriteLine("2 - Латте (30 мл воды, 270 мл молока, 170 руб)");
            Console.WriteLine("0 - Завершить работу");
            
            int choice = int.Parse(Console.ReadLine());
            
            if (choice == 0)
                break;
                
            if (choice == 1)
            {
                if (water >= 300)
                {
                    water -= 300;
                    americanoCount++;
                    totalIncome += 150;
                    Console.WriteLine("Ваш американо готов! Стоимость: 150 руб");
                }
                else
                {
                    Console.WriteLine("Не хватает воды для американо");
                }
            }
            else if (choice == 2)
            {
                if (water >= 30 && milk >= 270)
                {
                    water -= 30;
                    milk -= 270;
                    latteCount++;
                    totalIncome += 170;
                    Console.WriteLine("Ваш латте готов! Стоимость: 170 руб");
                }
                else if (water < 30)
                {
                    Console.WriteLine("Не хватает воды для латте");
                }
                else
                {
                    Console.WriteLine("Не хватает молока для латте");
                }
            }
            
            // Проверка возможности приготовления любого напитка
            if (water < 300 && (water < 30 || milk < 270))
            {
                Console.WriteLine("\nИнгредиенты закончились!");
                break;
            }
        }
        
        // Отчет
        Console.WriteLine("\n=== ОТЧЕТ ===");
        Console.WriteLine($"Приготовлено американо: {americanoCount}");
        Console.WriteLine($"Приготовлено латте: {latteCount}");
        Console.WriteLine($"Общий заработок: {totalIncome} руб");
        Console.WriteLine($"Остаток воды: {water} мл");
        Console.WriteLine($"Остаток молока: {milk} мл");
    }

    // Задание 6: Лабораторный опыт
    static void BacteriaExperiment()
    {
        Console.Write("Введите количество бактерий N: ");
        int bacteria = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество капель антибиотика X: ");
        int drops = int.Parse(Console.ReadLine());
        
        int hour = 0;
        int killEffect = 10; // Начальная эффективность одной капли
        
        Console.WriteLine("\nЧас\tБактерий до\tБактерий после\tУбито\tОсталось");
        Console.WriteLine("---------------------------------------------------");
        
        while (bacteria > 0 && killEffect > 0)
        {
            hour++;
            int bacteriaBefore = bacteria;
            
            // Удвоение бактерий
            bacteria *= 2;
            
            // Действие антибиотика
            int killed = Math.Min(bacteria, drops * killEffect);
            bacteria -= killed;
            
            Console.WriteLine($"{hour}\t{bacteriaBefore}\t\t{bacteria + killed}\t\t{killed}\t{bacteria}");
            
            // Уменьшение эффективности
            killEffect--;
            
            if (bacteria <= 0)
                bacteria = 0;
        }
        
        Console.WriteLine($"\nФинальный результат: {bacteria} бактерий через {hour} часов");
    }

    // Задание 7: Колонизация Марса
    static void MarsColonization()
    {
        Console.Write("Введите количество модулей n: ");
        int n = int.Parse(Console.ReadLine());
        
        Console.Write("Введите размеры модуля a b: ");
        string[] sizes = Console.ReadLine().Split();
        int a = int.Parse(sizes[0]);
        int b = int.Parse(sizes[1]);
        
        Console.Write("Введите размеры поля w h: ");
        sizes = Console.ReadLine().Split();
        int w = int.Parse(sizes[0]);
        int h = int.Parse(sizes[1]);
        
        int maxD = -1;
        
        // Перебираем возможные толщины защиты
        for (int d = 0; d <= Math.Min(w, h); d++)
        {
            int newA = a + 2 * d;
            int newB = b + 2 * d;
            
            // Проверяем размещение в двух ориентациях
            bool canPlace1 = (w / newA) * (h / newB) >= n;
            bool canPlace2 = (w / newB) * (h / newA) >= n;
            
            if (canPlace1 || canPlace2)
                maxD = d;
            else
                break; // Дальнейшее увеличение d бесполезно
        }
        
        if (maxD >= 0)
            Console.WriteLine($"Максимальная толщина защиты: {maxD} м");
        else
            Console.WriteLine("Размещение невозможно");
    }
}