// See https://aka.ms/new-console-template for more information

using Employee.Classes;

try
{
    int day, month, year;

    Console.WriteLine("OOP Application");

    Console.Write("Ingresar el dia: ");
    day = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingresar el mes: ");
    month = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingresar el año: ");
    year = Convert.ToInt32(Console.ReadLine());

    Date dateObject = new Date(day, month, year);
    Console.WriteLine(dateObject.ToString());
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
