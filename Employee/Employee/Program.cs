// See https://aka.ms/new-console-template for more information

using EmployeeOOP.Classes;

try
{
    int day, month, year, hours;
    string firstName, lastName;
    decimal salary, hourValue, comission, sales;

    Console.WriteLine("OOP Application Juan Andres Gutierrez");
    Console.WriteLine("--------------------------\n");

    Console.Write("Ingresar el dia: ");
    day = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingresar el mes: ");
    month = Convert.ToInt32(Console.ReadLine());

    Console.Write("Ingresar el año: ");
    year = Convert.ToInt32(Console.ReadLine());

    Date dateObject = new Date(day, month, year);
    Console.WriteLine("\n");
    Console.WriteLine(dateObject.ToString());


    Console.Write("Ingresar nombre: ");
    firstName = Console.ReadLine();

    Console.Write("Ingresar apellidos: ");
    lastName = Console.ReadLine();

    //Salary Employee

    Console.Write("Ingresar salario: ");
    salary = Decimal.Parse(Console.ReadLine());

    SalaryEmployee salaryEmployee = new SalaryEmployee()
    {
        Id = 123456,
        FirstName = firstName,
        lastName = lastName,
        BirthDate = dateObject,
        HiringDate = dateObject,
        IsActive = true,
        Salary = salary, 
    };
    Console.WriteLine("\nSalary Employee:\n");
    Console.WriteLine(salaryEmployee.ToString());

    Console.WriteLine("\n");

    //Hourly Employee

    Console.Write("Ingresar horas trabajadas: ");
    hours = Int32.Parse(Console.ReadLine());

    Console.Write("Ingresar valor por hora: ");
    hourValue = Decimal.Parse(Console.ReadLine());

    HourlyEmployee hourlyEmployee = new HourlyEmployee()
    {
        Id = 123456,
        FirstName = firstName,
        lastName = lastName,
        BirthDate = dateObject,
        HiringDate = dateObject,
        IsActive = true,
        HourValue = hourValue,
        Hours = hours,
    };

    Console.WriteLine("\nHourly Employee:\n");
    Console.WriteLine(hourlyEmployee.ToString());

    Console.WriteLine("\n");

    //Comission Employee

    Console.Write("Ingresar porcentaje de comision: ");
    comission = Decimal.Parse(Console.ReadLine());

    Console.Write("Ingresar valor de ventas: ");
    sales = Decimal.Parse(Console.ReadLine());

    ComissionEmployee comissionEmployee = new ComissionEmployee()
    {
        Id = 123456,
        FirstName = firstName,
        lastName = lastName,
        BirthDate = dateObject,
        HiringDate = dateObject,
        IsActive = true,
        Sales = sales,
        ComissionPercentaje = comission,
    };

    Console.WriteLine("\nComission Employee:\n");
    Console.WriteLine(comissionEmployee.ToString());

    Console.WriteLine("\n");
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
