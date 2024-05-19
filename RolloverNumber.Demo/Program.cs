using RolloverNumber;

var number = new RolloverNumber<int>(10, 21);

Console.WriteLine("Addition");
for (var i = 0; i < 17; i++)
{
	number += 2;
	Console.WriteLine($"Number is now {number}");
}

Console.WriteLine("Subtraction");
for (var i = 0; i < 17; i++)
{
	number -= 2;
	Console.WriteLine($"Number is now {number}");
}

Console.WriteLine("Increment");
for (var i = 0; i < 17; i++)
{
	Console.WriteLine($"Number is now {number++}");
}

Console.WriteLine("Decrement");
for (var i = 0; i < 17; i++)
{
	Console.WriteLine($"Number is now {number--}");
}