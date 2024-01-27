var testCasesCount = Convert.ToInt32(Console.ReadLine());
for (var i = 0; i < testCasesCount; i++)
{
    var testCase = Console.ReadLine()?.ToCharArray();
    if (testCase != null)
    {
        var validNumbers = new List<string>();
        var validTestCase = false;
        for (var j = testCase.Length - 1; j >= 0; j--)
        {
            if (j == 4)
            {
                if (char.IsLetter(testCase[0])
                    && char.IsNumber(testCase[1])
                    && char.IsNumber(testCase[2])
                    && char.IsLetter(testCase[3])
                    && char.IsLetter(testCase[4]))
                {
                    var number = new string(testCase, 0, 5);
                    validNumbers.Add(number);
                    validTestCase = true;
                }
                break;
            }

            if (j == 3)
            {
                if (char.IsLetter(testCase[0])
                    && char.IsNumber(testCase[1])
                    && char.IsLetter(testCase[2])
                    && char.IsLetter(testCase[3]))
                {
                    var number = new string(testCase, 0, 4);
                    validNumbers.Add(number);
                    validTestCase = true;
                }
                break;
            }

            if (j < 3)
            {
                break;
            }

            if (char.IsLetter(testCase[j-3])
                && char.IsNumber(testCase[j-2])
                && char.IsLetter(testCase[j-1])
                && char.IsLetter(testCase[j]))
            {
                var number = new string(testCase, j-3, 4);
                validNumbers.Add(number);
                j -= 3;
            }
            else if (char.IsLetter(testCase[j-4])
                && char.IsNumber(testCase[j-3])
                && char.IsNumber(testCase[j-2])
                && char.IsLetter(testCase[j-1])
                && char.IsLetter(testCase[j]))
            {
                var number = new string(testCase, j-4, 5);
                validNumbers.Add(number);
                j -= 4;
            }
            else
            {
                break;
            }
        }
        

        if(validTestCase && validNumbers.Any())
        {
            validNumbers.Reverse();
            foreach (var number in validNumbers)
            {
                Console.Write(number + " ");
            }
        }
        else
        {
            Console.Write("-");
        }

        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("-");
    }
}
