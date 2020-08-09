using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    // Game state
    int level;
    // Start is called before the first frame update
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
        Terminal.WriteLine("Press 2 for the local lobrary");
        Terminal.WriteLine("Enter your selection");
    }

    // This should only decide who to handle input, not actually do it
    void OnUserInput(string input)
    {
        if (input == "menu") // We can always go direct to the main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }

    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please provide a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
