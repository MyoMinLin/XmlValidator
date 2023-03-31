using XmlValidator;

Console.WriteLine("------------- Take home coding test (XML) ----------");
Console.WriteLine("Implemented by Myo Min Lin");
Console.WriteLine(Environment.NewLine);

do
{
    DoXmlValidation();

    while (true)
    {
        Console.WriteLine("Do you want to continue: ? (Y/N)");

        string continuationInput = Console.ReadLine()?.ToUpper() ?? string.Empty;

        if (continuationInput == "Y" || continuationInput == "YES")
        {
            DoXmlValidation();
        }
        else if (continuationInput == "N" || continuationInput == "NO")
        {
            return;
        }
        else
        {
            Console.WriteLine("Incorrect input. Please enter Y or N.");
        }
    }
} while (true);


static void DoXmlValidation()
{
    Console.WriteLine("Please provide XML text to be validated...");

    var inputXml = Console.ReadLine();

    Console.WriteLine($"Input: {inputXml}");
    Console.WriteLine($"Output: {Validator.DetermineXml(inputXml ?? string.Empty)}");
}
