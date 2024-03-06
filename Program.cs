using System;

class StoryPasswordGenerator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome, adventurer! Are you lost in the digital realm, seeking a secure password?");
        Console.Write("Press enter to embark on your quest...");
        Console.ReadLine();

        // Get password length from user
        int length;
        do
        {
            Console.Write("To forge a strong password, tell me the length of your journey (minimum 8): ");
        } while (!int.TryParse(Console.ReadLine(), out length) || length < 8);

        // Get user preference for character types
        bool uppercase = GetYesNoInput("Will you encounter towering mountains (uppercase letters)? (y/n): ");
        bool lowercase = GetYesNoInput("Will you traverse hidden valleys (lowercase letters)? (y/n): ");
        bool numbers = GetYesNoInput("Will you discover ancient treasures (numbers)? (y/n): ");
        bool symbols = GetYesNoInput("Will you face mystical creatures (symbols)? (y/n): ");

        // Generate random password based on user preferences
        string password = GeneratePassword(length, uppercase, lowercase, numbers, symbols);

        // Display generated password to user
        Console.WriteLine("Your password, forged in the fires of your adventure is: {0}", password);
        Console.WriteLine("May it guide you safely through the digital landscape!");
    }

    static bool GetYesNoInput(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine().ToLower();
        return input == "y" || input == "yes";
    }

    static string GeneratePassword(int length, bool uppercase, bool lowercase, bool numbers, bool symbols)
    {
        string password = "";

        for (int i = 0; i < length; i++)
        {
            char nextChar = GetRandomCharacter(uppercase, lowercase, numbers, symbols);
            password += nextChar;
        }

        return password;
    }

    static char GetRandomCharacter(bool uppercase, bool lowercase, bool numbers, bool symbols)
    {
        string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        string numberChars = "0123456789";
        string symbolChars = "!@#$%^&*()-=_+[]{}|;':,.<>?/";

        string allChars = "";

        if (uppercase)
            allChars += uppercaseChars;

        if (lowercase)
            allChars += lowercaseChars;

        if (numbers)
            allChars += numberChars;

        if (symbols)
            allChars += symbolChars;

        if (allChars.Length == 0)
            return ' '; // Default to a space if no character types are selected

        Random random = new Random();
        return allChars[random.Next(allChars.Length)];
    }

    static string GetStoryElement(bool include)
    {
        if (include)
        {
            string[] elements = { "towering mountains", "hidden valleys", "ancient treasures", "mystical creatures", "enchanted forests", "forgotten ruins" };
            Random random = new Random();
            return elements[random.Next(elements.Length)];
        }
        else
        {
            return "";
        }
    }
}

