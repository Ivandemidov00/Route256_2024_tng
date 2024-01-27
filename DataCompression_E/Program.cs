var testCasesCount = Convert.ToInt32(Console.ReadLine());
for (var i = 0; i < testCasesCount; i++)
{
        Console.ReadLine();
        var numbers = Console.ReadLine();
        var numbersArray = numbers!.Split(' ').ToArray();
        var compressedData = new Queue<CompressDataItem>();
        var compress = false;
        var currentMotion = 0;
        var iteration = 0;
        for (var k = 0; k < numbersArray.Length; k++)
        {
            if (k == numbersArray.Length - 1)
            {
                compress = true;
            }
            else
            {
                var diff= int.Parse(numbersArray[k + 1]) - int.Parse(numbersArray[k]);
                if (diff == -1 || diff == 1)
                {
                    if (currentMotion == 0)
                    {
                        currentMotion = diff;
                    }

                    if (diff == -1 && currentMotion == -1)
                    {
                        iteration--;
                    }
                    else if (diff == 1 && currentMotion == 1)
                    {
                        iteration++;
                    }
                    else
                    {
                        compress = true;
                    }
                }
                else
                {
                    compress = true;
                }
            }

            if (compress)
            {
                var iterationAbs = Math.Abs(iteration);
                var startNumber = int.Parse(numbersArray[k - iterationAbs]);
                compressedData.Enqueue(new CompressDataItem(startNumber, iteration));
                compress = false;
                currentMotion = 0;
                iteration = 0;
            }
        }

        Console.WriteLine(compressedData.Count * 2);
        while (compressedData.TryDequeue(out var compressDataItem))
        {
            Console.Write(compressDataItem);
        }
        Console.WriteLine();
}


public record CompressDataItem(int B, int C)
{
    public override string ToString()
        => $"{B} {C} ";
}
