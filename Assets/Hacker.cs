using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = {"book", "aisle", "self", "password", "font", "borrow"};
    string[] level2Passwords = {"prisoner", "handcuffs", "holster", "uniform", "arrest"};
    string[] level3Passwords = {"starfield", "telescope", "environment", "exploration", "astronauts"};
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    // Game state
    int level;
    // Start is called before the first frame update
    string password;
    void Start ()
    {
        ShowMainMenu ();
    }

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA!");
        Terminal.WriteLine("Enter your selection");
    }

    // This should only decide who to handle input, not actually do it
    void OnUserInput(string input)
    {
        if (input == "menu") // We can always go direct to the main menu
        {
            ShowMainMenu();
        }
        else if (input == "exit" || input == "close")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidlevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidlevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter your password: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowlevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowlevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/         
                ");
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine("Play again for greater challenge!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = ' 
                ");
                
                break;
            case 3:
                Terminal.WriteLine("NASA!");
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
                
                ");
                break;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
