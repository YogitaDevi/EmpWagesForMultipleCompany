using TotalWageForEachCompany;

class Program
{
    static void Main(string[] args)
    {
        EmpWageBuilderObject dMart = new EmpWageBuilderObject("Dmart", 20, 2, 10, 200);
        EmpWageBuilderObject reliance = new EmpWageBuilderObject("Reliance", 10, 4, 20, 150);
        dMart.computeEmpWage();
        Console.WriteLine(dMart.toString());
        reliance.computeEmpWage();
        Console.WriteLine(reliance.toString());
    }
}
