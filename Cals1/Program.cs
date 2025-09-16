using System;

class Calculator
{
    static void Main()
    {
        bool exit = false;
        double result = 0.0;

        Console.WriteLine("🎯 КАЛЬКУЛЯТОР");
        Console.WriteLine("==============");

        while (!exit)
        {
            Console.WriteLine("📋 Операции: +, -, *, /, %, 1/x, x^2, sqrt, exit");
            Console.Write("➡️  Выберите операцию: ");
            string op = Console.ReadLine();

            try
            {
                if (op == "exit")
                {
                    exit = true;
                    Console.WriteLine("👋 До свидания!");
                    continue;
                }

                Console.Write("🔢 Введите число: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                if (op == "+" || op == "-" || op == "*" || op == "/" || op == "%")
                {
                    Console.Write("🔢 Введите второе число: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    if (op == "+") result = num1 + num2;
                    else if (op == "-") result = num1 - num2;
                    else if (op == "*") result = num1 * num2;
                    else if (op == "/")
                    {
                        if (num2 == 0) throw new DivideByZeroException();
                        result = num1 / num2;
                    }
                    else if (op == "%")
                    {
                        if (num2 == 0) throw new DivideByZeroException();
                        result = num1 % num2;
                    }
                }
                else if (op == "1/x")
                {
                    if (num1 == 0) throw new DivideByZeroException();
                    result = 1 / num1;
                }
                else if (op == "x^2")
                {
                    result = num1 * num1;
                }
                else if (op == "sqrt")
                {
                    result = Math.Sqrt(num1);
                }
                else
                {
                    Console.WriteLine("❌ Неизвестная операция.");
                    continue;
                }

                Console.WriteLine($"✅ Результат: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("❌ Ошибка: Деление на ноль!");
            }
            catch (FormatException)
            {
                Console.WriteLine("❌ Ошибка: Неверный формат числа!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"❌ Ошибка: {e.Message}");
            }
        }
    }
}