using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Dynamic;
using System.Runtime.InteropServices;
using static System.Console;

List<Meeting> meetings = new List<Meeting>();
meetings.Add(new Meeting()
{
    ind=meetings.Count,
    startTime = new DateTime(2023,2,2,2,2,0),
    endTime = new DateTime(2023, 2, 2, 3, 2, 0),
    notTime = new DateTime(2023, 2, 2, 1, 2, 0)
});
meetings.Add(new Meeting()
{
    ind = meetings.Count,
    startTime = new DateTime(2024, 2, 2, 2, 2, 0),
    endTime = new DateTime(2024, 2, 2, 3, 2, 0),
    notTime = new DateTime(2024, 2, 2, 1, 2, 0)
});
Programm();//запуск программы
DateTime DateIn()
{
    int y, m, d, h, min;
    string str;
    do
    {
        WriteLine("Введите год:");
        str = ReadLine();
        if (Int32.TryParse(str, out y) && y >= DateTime.Now.Year)
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    do
    {
        WriteLine("Введите месяц:");
        str = ReadLine();
        if (Int32.TryParse(str, out m) && m >= 0&&m<=12)
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    do
    {
        WriteLine("Введите день:");
        str = ReadLine();
        if (Int32.TryParse(str, out d) && d >= 0 && d<= System.DateTime.DaysInMonth(y,m))
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    do
    {
        WriteLine("Введите час:");
        str = ReadLine();
        if (Int32.TryParse(str, out h) && h >=0&&h<=24)
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    do
    {
        WriteLine("Введите минуты:");
        str = ReadLine();
        if (Int32.TryParse(str, out min) && min >=0 && min<=60)
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    return new DateTime(y,m,d,h,min,0);
}
int MeetingsIndInList(int c)
{
    for (int i=0; i<meetings.Count;i++ )
    {
        if (meetings[i].ind == c)
            return i;
    }
    return -1;
}
int MeetingSelection()
{
    ShowMeetings();
    string str;
    int choice;
    do
    {
        WriteLine("Введите индекс встречи: ");
        str = ReadLine();
        if (Int32.TryParse(str, out choice) && choice < meetings.Count )
        { 
            if (MeetingsIndInList(choice)!=-1)
                return MeetingsIndInList(choice);
        }
        WriteLine("Введено неверное значение");
    }
    while (true);
}
void AddMeeting()//функция добавления встречи
{
    string str;
    DateTime start, end, not;
    WriteLine("Введите дату начала встречи (учтите, что вы можете планировать встречи только на будущее)");
    do
    {
        start = DateIn();
        if (start > DateTime.Now)
        {
            WriteLine("Вы успешно ввели дату начала встречи");
            break;
        }
        Clear();
        WriteLine("Введена некоректная дата, скорее всего вы ввели дату раньше чем сейчас, попробуйтек еще раз");
    } while (true);
    WriteLine("Введите дату конца встречи (учтите, что встреча может окончится только после ее начала)");
    do
    {
        end = DateIn();
        if (start < end)
        {
            WriteLine("Вы успешно ввели время конца встречи");
            break;
        }
        Clear();
        WriteLine("Введена некоректная дата, скорее всего конец встречи случится раньше чем ее начало, попробуйте еще раз");
    } while (true);
    WriteLine("Введите дату напоминания о встрече ");
    do
    {
        not = DateIn();
        if (not > DateTime.Now&& not<start)
        {
            WriteLine("Вы успешно ввели время напоминания");
            break;
        }
        Clear();
        WriteLine("Введена некоректная дата");
    } while (true);
    meetings.Add(
        new Meeting()
        {
            ind = meetings.Last().ind+1,
            startTime = start,
            endTime = end,
            notTime = not
        });
}
void DeleteMeeting()//функция удаления встречи
{
    WriteLine("Введите индекс встречи, которую хотите удалить");
    meetings.RemoveAt(MeetingSelection());
    WriteLine("Вы успешно удалили встречу");
}
void ChangeMeeting()//функция изменения встречи
{
    WriteLine("Выбирете какую встречу вы хотите поменять:");
    int ind = MeetingSelection();
    WriteLine("Выбирете что вы хотите изменить:" +
        "\n1) Время Начала и конца встречи" +
        "\n2) Время напоминания о встрече" +
        "\n3) Время начала, конца и напоминания о встрече");
    string str;
    int choice;
    do
    {
        WriteLine("Ваш выбор:");
        str = ReadLine();
        if (Int32.TryParse(str, out choice) && choice >= 1 && choice <= 3)
            break;
        WriteLine("Введено неверное значение");
    } while (true);
    if (choice == 1)
    {
        DateTime start, end;
        WriteLine("Введите дату начала встречи (учтите, что вы можете планировать встречи только на будущее)");
        do
        {
            start = DateIn();
            if (start > DateTime.Now)
            {
                WriteLine("Вы успешно ввели дату начала встречи");
                break;
            }
            Clear();
            WriteLine("Введена некоректная дата, скорее всего вы ввели дату раньше чем сейчас, попробуйтек еще раз");
        } while (true);
        meetings[ind].startTime = start;
        WriteLine("Введите дату конца встречи (учтите, что встреча может окончится только после ее начала)");
        do
        {
            end = DateIn();
            if (start < end)
            {
                WriteLine("Вы успешно ввели время конца встречи");
                break;
            }
            Clear();
            WriteLine("Введена некоректная дата, скорее всего конец встречи случится раньше чем ее начало, попробуйте еще раз");
        } while (true);
        meetings[ind].endTime = end;
        WriteLine("Вы успешно изменили время начала и конца встречи"); ;
    }
    else if (choice == 2)
    {
        DateTime not;
        do
        {
            not = DateIn();
            if (not > DateTime.Now && not < meetings[ind].startTime)
            {
                WriteLine("Вы успешно ввели время напоминания");
                break;
            }
            Clear();
            WriteLine("Введена некоректная дата");
        } while (true);
        meetings[ind].notTime = not;
        WriteLine("Вы успешно изменили время напоминания");
    }
    else
    {
        meetings.RemoveAt(ind);
        AddMeeting();
    }
}
void ShowMeetings()//функция просмотра всех встреч
{
    WriteLine("функция просмотра всех встреч");
    if (meetings.Count == 0)
    {
        WriteLine("У вас нет запланированных встреч");
    }
    else {
        foreach (Meeting item in meetings)
        {
            item.show();
        }
    }
}
void ShowMeetingAtCurrentDay()//функция просмотра встреч на определенный день
{
    WriteLine("Вы выбрали посмотреть события в какой-то определенный день");
    int y, m, d;
    bool any_meets=false;
    string str;
    do
    {
        WriteLine("Введите год:");
        str = ReadLine();
        if (Int32.TryParse(str, out y) && y >= DateTime.Now.Year)
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    do
    {
        WriteLine("Введите месяц:");
        str = ReadLine();
        if (Int32.TryParse(str, out m) && m >= 0 && m <= 12)
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    do
    {
        WriteLine("Введите день:");
        str = ReadLine();
        if (Int32.TryParse(str, out d) && d >= 0 && d <= System.DateTime.DaysInMonth(y, m))
            break;
        else
            WriteLine("Вы ввели неверное значение");
    } while (true);
    foreach (Meeting item in meetings)
    {
        if (item.startTime.Year == y && item.startTime.Month == m && item.startTime.Day == d)
        {
            WriteLine();
            item.show();
            any_meets = true;
        }
    }
    if (any_meets)
        WriteLine($"Это все встречи, запланированные на {d} {m} {y}");
    else
        WriteLine($"У вас нет запланированных встреч на {d} {m} {y}");
}
void Export2Txt()//функция экспорта встреч в .txt файл
{
    string filePath = "meetings.txt";
    using (FileStream fs = new FileStream(filePath,
    FileMode.Create))
    {
        using (StreamWriter sw = new StreamWriter(fs,
        Encoding.Unicode))
        {
            foreach (Meeting item in meetings)
            {
                sw.WriteLine("---");
                sw.WriteLine($" | Начало встречи состоится  {item.startTime.ToString("f")}");
                sw.WriteLine($" | Окончание втсречи  {item.endTime.ToString("f")}");
                sw.WriteLine($" | Время напоминания {item.notTime.ToString("f")}");
                sw.WriteLine("---\n");
            }
        }
    }
    WriteLine("Данные о встречах успешно записаны в файл meetings.txt");
}
int ChekKey4Selection()
{
    ConsoleKeyInfo key2return;
    int number=1;
    while (true)
    {
        key2return = Console.ReadKey(true);
        if (Char.IsNumber(key2return.KeyChar))
        {
            if (Int32.TryParse(key2return.KeyChar.ToString(), out number))
            {
                if (number>=0&&number<=6)
                    return number;
            }
            else
                Console.WriteLine("Преобразование прошло неудачно, попробуйте еще раз");
        }
    }
}
void SelectionPrint()//вспомогательная функция для вывода возможностей пользоателя
{
    Clear();
    WriteLine("\nВыберите что вы хотите сделать: ");
    WriteLine("1) Добавить встречу");
    WriteLine("2) Убрать встречу");
    WriteLine("3) Изменить встречу");
    WriteLine("4) Посмотреть расписание встреч на определенный день");
    WriteLine("5) Посмотреть список всех встреч");
    WriteLine("6) Экспортировать список встреч в текстовый файл");
    WriteLine("0) Выйти из программы");
    WriteLine("Чтобы сделать выбор нажмите кнопку\n");
}
int Selection()//функция выбора
{
    SelectionPrint();
    switch (ChekKey4Selection())
    {
        case 1:
            {
                AddMeeting();
                break;
            }
        case 2:
            {
                DeleteMeeting();
                break;
            }
        case 3:
            {
                ChangeMeeting();
                break;
            }
        case 4:
            {
                ShowMeetingAtCurrentDay();
                break;
            }
        case 5:
            {
                ShowMeetings();
                break;
            }
        case 6:
            {
                Export2Txt();
                break;
            }
        case 0:
            {
                return 0;
            }
        default:
            {
                WriteLine("Ошибка выбора");
                break;
            }
    }
    return ChekKey4Selection();
}
void Notifications()
{
    foreach (Meeting item in meetings)
    {
        if (item.NotificationChek())
            item.Notificatioan();
    }
}
void Programm()//функция всей программы
{
    int choice;
    WriteLine("Приветствуем вас в программе встречи!");
    ReadKey(true);
    do
    {
        Notifications();
        choice = Selection();
        Notifications();
    }
    while (choice != 0);
    Clear();
    WriteLine("Вы вышли из программы");
}
class Meeting           //класс встреч
{
    public int ind;
    public DateTime startTime { get; set; }             //время начала встречи
    public DateTime endTime { get; set; }                  //время окончания встречи
    public DateTime notTime { get; set; }                //время уведомления о встрече
    public void Notificatioan()
    {
        Massege.MessageBoxA(IntPtr.Zero,$"На {startTime} у вас заплонирована встреча","Notification", 0);
    }
    public void show()                     //функция вывода информации о встречи в консоль
    {
        WriteLine("---");
        WriteLine($" | Индекс встречи {ind}");
        WriteLine($" | Начало встречи состоится  {startTime.ToString("f")}");
        WriteLine($" | Окончание втсречи  {endTime.ToString("f")}");
        WriteLine($" | Время напоминания {notTime.ToString("f")}");
        WriteLine("---\n");
    }
    public bool NotificationChek()
    {
        if (notTime.Year == DateTime.Now.Year && notTime.Day == DateTime.Now.Day && notTime.Month == DateTime.Now.Month &&  notTime.Hour == DateTime.Now.Hour && notTime.Minute == DateTime.Now.Minute)
            return true;
        else return false;
    } //проверка уведомление
}
public class Massege
{
    [DllImport("User32.dll", ExactSpelling = true)]
    public static extern int MessageBoxA(IntPtr hWnd,
    string text, string caption, uint type);
}
