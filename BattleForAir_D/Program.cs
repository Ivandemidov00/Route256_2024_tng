var testCasesCount = Convert.ToInt32(Console.ReadLine());
for (var i = 0; i < testCasesCount; i++)
{
    var workerCount = int.Parse(Console.ReadLine()!);

    var minRequiredTemp = 15;
    var maxRequiredTemp = 30;

    var tempWithSign = Console.ReadLine()!.ToCharArray();
    var temp = int.Parse(new string(tempWithSign, 3, 2));
    
    if (tempWithSign[0] == '<')
    {
        maxRequiredTemp = temp;
    }
    else
    {
        minRequiredTemp = temp;
    }


    Console.WriteLine(minRequiredTemp);
    var failed = false;
    for (var j = 1; j < workerCount; j++)
    {
        tempWithSign = Console.ReadLine()!.ToCharArray();
        temp = int.Parse(new string(tempWithSign, 3, 2));

        if (failed)
        {
            Console.WriteLine("-1");
            continue;
        }

        if (temp >= minRequiredTemp && temp <= maxRequiredTemp)
        {
            if (tempWithSign[0] == '<')
            {
                maxRequiredTemp = temp;
            }
            else
            {
                minRequiredTemp = temp;
            }
            Console.WriteLine(minRequiredTemp);
        }
        else if (temp < minRequiredTemp && tempWithSign[0] == '>')
        {
            Console.WriteLine(minRequiredTemp);
        }
        else if (temp > maxRequiredTemp && tempWithSign[0] == '<')
        {
            Console.WriteLine(minRequiredTemp);
        }
        else
        {
            failed = true;
            Console.WriteLine("-1");
        }
    }

    Console.WriteLine();
}