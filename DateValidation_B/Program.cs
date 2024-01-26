using System.Globalization;

var testCasesCount = Convert.ToInt32(Console.ReadLine());
const string dateFormat = "d M yyyy";
for (var i = 0; i < testCasesCount; i++)
{
    var testCase = Console.ReadLine()?.ToCharArray();
    Console.WriteLine(
        DateTime.TryParseExact(testCase, dateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out _)?
        "YES":
        "NO");
}