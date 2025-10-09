//Wilcris Diaz Villanueva 20250911
int num = 0;
Console.WriteLine("Insert a number to check if it is even or not");
num = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

if(num % 2  == 0)
{
    Console.WriteLine("Your number is even");
}
else
{
    Console.WriteLine("Your number is not even");
}

Console.ReadLine();