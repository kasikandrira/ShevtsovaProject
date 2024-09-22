using System;

class Program
{
    static void Main(string[] args)
    {
        string playerName;
        bool hasFirstArtifact = false;
        bool hasSecondArtifact = false;
        bool hasThirdArtifact = false;
        bool hasKey = false;
        bool hasLockpick = false;
        int ventAttempts = 0;

        // 1. Игрок проснулся
        Console.WriteLine("Доброго времени суток! Как твоё имя,бедняжка?");
        playerName = Console.ReadLine();

        // Выбор действий
        while (true)
        {
            Console.WriteLine($"\n{playerName}, что вы хотите сделать?");
            Console.WriteLine("1. Открыть дверь");
            Console.WriteLine("2. Заглянуть под кровать");
            Console.WriteLine("3. Открыть ящик в углу комнаты");
            Console.WriteLine("4. Открыть вентиляцию");
            Console.WriteLine("5. Взглянуть на тумбочку");
            Console.WriteLine("6. Взглянуть на статую рядом с дверью");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (hasLockpick)
                    {
                        Console.WriteLine($"{playerName}, Дверь открыта! Ты успешно сбежал!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Дверь закрыта, нужно найти способ её открыть.");
                    }
                    break;

                case "2":
                    if (!hasFirstArtifact)
                    {
                        Console.WriteLine($"{playerName}, ты нашёл первый артефакт!");
                        hasFirstArtifact = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, под кроватью теперь пусто.");
                    }
                    break;

                case "3":
                    if (hasKey)
                    {
                        if (!hasLockpick)
                        {
                            Console.WriteLine($"{playerName}, Ты открыл ящик и нашёл отмычку!");
                            hasLockpick = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, ящик теперь пустой.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, ящик закрыт. Нужно найти ключ.");
                    }
                    break;

                case "4":
                    ventAttempts++;
                    if (ventAttempts >= 3)
                    {
                        if (!hasSecondArtifact)
                        {
                            Console.WriteLine($"{playerName}, после нескольких попыток вентиляция открылась и ты нашёл второй артефакт!");
                            hasSecondArtifact = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, в вентиляции пусто.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, вентиляция не поддаётся. Попробуй ещё раз.");
                    }
                    break;

                case "5":
                    if (!hasThirdArtifact)
                    {
                        Console.WriteLine($"{playerName}, на тумбочке лежит третий артефакт!");
                        hasThirdArtifact = true;
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, на тумбочке пусто.");
                    }
                    break;
                case "6":
                    if (hasFirstArtifact && hasSecondArtifact && hasThirdArtifact)
                    {
                        if (!hasKey)
                        {
                            Console.WriteLine($"{playerName}, статуя активирована! Ты получил ключ от ящика!");
                            hasKey = true;
                        }
                        else
                        {
                            Console.WriteLine($"{playerName}, ты уже активировал статую.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, для активации статуи нужны три артефакта.");
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуй снова.");
                    break;
            }
        }
    }
}