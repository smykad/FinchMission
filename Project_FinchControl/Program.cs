using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Application Type: Console
    // Description: Menus created, functions created
    // Author: Smyka, Doug
    // Dated Created: 10/4/2020
    // Last Modified: 10/4/2020
    //
    // **************************************************

    class Program
    {
        #region MAIN

        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        #endregion

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        #region MAIN MENU
        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DisplayDataRecorderMenuScreen(finchRobot);
                        break;

                    case "d":
                        DisplayAlarmSystemMenuScreen(finchRobot);
                        break;

                    case "e":
                        DisplayUserProgrammingMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #endregion 

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now sing you a glowing birthday song!");
            DisplayContinuePrompt();

            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(297);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(352);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(330);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(297);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(396);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(352);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOn(264);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(2642);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(440);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(352);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(250);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(352);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(330);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(297);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOn(466);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(250);
            finchRobot.noteOn(466);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(125);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(440);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(352);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(396);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(125);
            finchRobot.noteOn(352);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance                  *
        /// *****************************************************************
        /// Finch spins around clockwise and counterclockwise faster and faster
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");
            Console.WriteLine("\tThe Finch robot will now show off its moves!");
            DisplayContinuePrompt();

            for (int i = 0; i < 255; i++)
            {
                finchRobot.setMotors(i, -i);
                finchRobot.wait(10);
            }

            finchRobot.setMotors(0, 0);

            for (int i = 0; i < 255; i++)
            {
                finchRobot.setMotors(-i, i);
                finchRobot.wait(10);
            }

            finchRobot.setMotors(0, 0);


            DisplayMenuPrompt("Talent Show Menu");

        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing it Up                 *
        /// *****************************************************************
        /// Plays the star wars theme song and uses the red light and rotates the finch
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        
        static void DisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it Up");
            Console.WriteLine("\tThe Finch robot will now play the star wars theme song while dancing!");
            DisplayContinuePrompt();

            finchRobot.noteOn(300);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.noteOn(300);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.noteOn(300);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.noteOn(250);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.noteOn(250);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.noteOn(350);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(250);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOn(300);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.noteOn(250);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.noteOn(350);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(250);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOn(300);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);
            finchRobot.setMotors(50, -50);
            finchRobot.setMotors(0, 0);


            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************************************
        /// *                      Data Recorder                            *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayDataRecorderMenuScreen(Finch finchRobot)
        {
            DisplayScreenHeader("Data Recorder");
            Console.WriteLine("This module is under development");
            DisplayContinuePrompt();
        }

        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// *                      Alarm System                            *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayAlarmSystemMenuScreen(Finch finchRobot)
        {
            DisplayScreenHeader("Alarm System");
            Console.WriteLine("This module is under development");
            DisplayContinuePrompt();
        }


        #endregion

        #region USER PROGRAMMING

        /// <summary>
        /// *****************************************************************
        /// *                   User Programming                           *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayUserProgrammingMenuScreen(Finch finchRobot)
        {
            DisplayScreenHeader("User Programming");
            Console.WriteLine("This module is under development");
            DisplayContinuePrompt();
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
