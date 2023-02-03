using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sectors = { 6, 15, 15, 24, 12 };
            bool isOpen = true;

            while (isOpen)
            {
                int j = 15;

                for (int i = 0; i < sectors.Length; i++)
                {
                    Console.SetCursorPosition(10, j);
                    Console.WriteLine($"В секторе {i + 1} свободно {sectors[i]} мест.");
                    j++;
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Регестрация рейса.");
                Console.WriteLine("\n\n1 - забронировать места.\n\n2 - выход из программы.\n\n");
                Console.Write("Введите номер команды: ");
                var UserInput = Console.ReadKey();

                switch (int.Parse(UserInput.KeyChar.ToString()))
                {
                    case 1:
                        int userSector, userPlaceAmount;
                        Console.WriteLine("\n\nВыберете в каком секторе вы бы хотели лететь? ");
                        userSector = Convert.ToInt32(Console.ReadLine()) - 1;
                        bool gandonyer = userSector > sectors.Length;
                        if (userSector > sectors.Length || userSector < 0)
                        {
                            Console.WriteLine("Такого сектора не существует.");
                            break;
                        }
                        Console.WriteLine("Сколько вы бы хотели забронировать мест? ");
                        userPlaceAmount = Convert.ToInt32(Console.ReadLine());
                        if (userPlaceAmount < 0)
                        {
                            Console.WriteLine("Неверное количество мест.");
                            break;
                        }
                        if (sectors[userSector] < userPlaceAmount)
                        {
                            Console.WriteLine($"В секторе {userSector + 1} недостаточно мест." + $"Остаток {sectors[userSector]}");
                            break;
                        }

                        sectors[userSector] -= userPlaceAmount;
                        Console.WriteLine("Успешное бронирование.");
                        break;
                    case 2:
                        isOpen = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }   
    } 
}
