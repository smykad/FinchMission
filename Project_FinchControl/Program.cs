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
    // Last Modified: 10/11/2020
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

        #region Theme
        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
        #endregion

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
                Console.WriteLine("\tA: Connect Finch Robot");
                Console.WriteLine("\tB: Talent Show");
                Console.WriteLine("\tC: Data Recorder");
                Console.WriteLine("\tD: Alarm System");
                Console.WriteLine("\tE: User Programming");
                Console.WriteLine("\tF: Disconnect Finch Robot");
                Console.WriteLine("\tQ: Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\tEnter Choice: ");
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
        static void DisplayTalentShowMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tA: Light and Sound");
                Console.WriteLine("\tB: Dance");
                Console.WriteLine("\tC: Mixing it up");
                Console.WriteLine("\tD: Buzzer");
                Console.WriteLine("\tQ: Main Menu");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\tEnter Choice: ");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        DisplayDance(finchRobot);
                        break;

                    case "c":
                        DisplayMixingItUp(finchRobot);
                        break;

                    case "d":
                        DisplayBuzzer(finchRobot);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
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

            HappyBirthday(finchRobot);

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

            SquareLeft(finchRobot);
            SquareRight(finchRobot);

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
            Console.WriteLine("\tThe Finch robot will now play the star wars theme song and then does a little dance!");
            DisplayContinuePrompt();

            StarWars(finchRobot);

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void DisplayBuzzer(Finch finchRobot)
        {
            DisplayScreenHeader("Buzzer");
            Console.WriteLine("Enter the frequency in hertz you'd like to hear: ");
            int hertz = IsValidInt();
            Console.WriteLine("Enter how long you would like the Finch to play this sound (in seconds): ");
            int time = IsValidInt()*1000;
            Console.WriteLine($"The frequency you chose is {hertz}, it will play for {time/1000} seconds.");
            DisplayContinuePrompt();
            Beep(finchRobot, hertz, time);
        }
        #endregion

        #region BEEPER MOVEMENT LIGHT METHODS

        /// <summary>
        /// recreating the console.beep() method for finch
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="hertz"></param>
        /// <param name="time"></param>
        static void Beep(Finch finchRobot, int hertz, int time)
        {
            finchRobot.noteOn(hertz);
            finchRobot.wait(time);
            finchRobot.noteOff();
        }

        /// <summary>
        ///  method to turn on lights, set how long they're on, and then turn them off
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="time"></param>
        static void LEDOnOFFSleep(Finch finchRobot, int r, int g, int b, int time)
        {
            finchRobot.setLED(r, g, b);
            finchRobot.wait(time);
            finchRobot.setLED(0, 0, 0);
        }

        /// <summary>
        /// method to rename sleep to save space
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="time"></param>
        static void Sleep(Finch finchRobot, int time)
        {
            finchRobot.wait(time);
        }

        static void Motors(Finch finchRobot, int left, int right)
        {
            finchRobot.setMotors(left, right);
            finchRobot.setMotors(0, 0);
        }

        #endregion

        #region MOVEMENT


        /// <summary>
        /// Finch moves in a square pattern turninig right
        /// </summary>
        /// <param name="finchRobot"></param>
        static void SquareRight(Finch finchRobot)
        {
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
        }
        /// <summary>
        /// Finch moves in a square moving left
        /// </summary>
        /// <param name="finchRobot"></param>
        static void SquareLeft(Finch finchRobot)
        {
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            Stop(finchRobot);
        }
        /// <summary>
        /// Move finch forward
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="duration"></param>
        static void Forward(Finch finchRobot, int duration)
        {
            finchRobot.setMotors(100, 100);
            Sleep(finchRobot, duration);
        }
        /// <summary>
        /// Stop finch
        /// </summary>
        /// <param name="finchRobot"></param>
        static void Stop(Finch finchRobot)
        {
            finchRobot.setMotors(0, 0);
        }

        /// <summary>
        /// Turn Finch left
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TurnLeft(Finch finchRobot)
        {
            finchRobot.setMotors(-100, 100);
            Sleep(finchRobot, 700);
            finchRobot.setMotors(0, 0);
        }
        /// <summary>
        /// Turn finch right
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TurnRight(Finch finchRobot)
        {
            finchRobot.setMotors(100, -100);
            Sleep(finchRobot, 700);
            finchRobot.setMotors(0, 0);
        }


        #endregion

        #region SONGS
        /// <summary>
        /// Star Wars song
        /// </summary>
        /// <param name="finchRobot"></param>
        static void StarWars(Finch finchRobot)
        {
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            Motors(finchRobot, 50, 50);
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            Motors(finchRobot, 50, 50);
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            Motors(finchRobot, -50, -50);
            Beep(finchRobot, 250, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            Motors(finchRobot, 50, 50);
            Beep(finchRobot, 350, 250);
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            Motors(finchRobot, -50, -50);
            Beep(finchRobot, 250, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            Motors(finchRobot, 50, 50);
            Beep(finchRobot, 350, 250);
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            Motors(finchRobot, 50, 50);
        }

       /// <summary>
       /// Happy Birthday Song
       /// </summary>
       /// <param name="finchRobot"></param>
        static void HappyBirthday(Finch finchRobot)
        {
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

            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tA: Number of Data points");
                Console.WriteLine("\tB: Frequency of Data points");
                Console.WriteLine("\tC: Get Data");
                Console.WriteLine("\tD: Show Data");
                Console.WriteLine("\tQ: Main Menu");
                Console.WriteLine();
                Console.WriteLine();                
                Console.Write("\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

        }

        /// <summary>
        /// Prompt user for number of the reading
        /// validate and convert the user response to a int
        /// echo the value to the user
        /// return the value
        /// </summary>
        /// <returns></returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            DisplayScreenHeader("Number of Data Points");

            int numberOfDataPoints;
            Console.Write("Enter a number: ");
            numberOfDataPoints = IsValidInt();
            Console.WriteLine("{0}", numberOfDataPoints);
            DisplayContinuePrompt();

            return numberOfDataPoints;
            
        }


        /// <summary>
        /// Prompt user for the frequency of readings in seconds
        /// validate and convert the response to a double
        /// echo the value to the user
        /// return the value
        /// </summary>
        /// <returns></returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            DisplayScreenHeader("Frequency");

            double numberOfDataPoints;

            Console.Write("Enter a number: ");
            numberOfDataPoints = IsValidDouble();
            Console.WriteLine("{0}", numberOfDataPoints);
            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            
            DisplayScreenHeader("Get Data");

            
            Console.WriteLine($"Number of Data points: {numberOfDataPoints}");
            Console.WriteLine($"Frequency: {dataPointFrequency}");
            Console.WriteLine("The finch is ready to begin recording the temperature data");
            DisplayContinuePrompt();

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                temperatures[i] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {i+1}: {temperatures[i]:n2}");
                int wait = (int)(dataPointFrequency * 1000);
                finchRobot.wait(wait);
            }

            DisplayContinuePrompt();

            return temperatures;
            
        }
        /// <summary>
        /// Prints the data into a table
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayDataTable(double[] temperatures)
        {
            Console.WriteLine(String.Format("{0, 20}  {1, 15}", "Recording", "Temperature"));
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine(String.Format("{0, 20}  {1, 15}", i + 1, temperatures[i]));
            }
        }
        /// <summary>
        /// Displays Data table with a header and prompts user to continue
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            DataRecorderDisplayDataTable(temperatures);

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
            string welcome = "Finch Control";
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,28}", welcome));
            Console.WriteLine();
            Console.WriteLine(@"
                        | 
    ____________    __ -+-  ____________ 
    \_____     /   /_ \ |   \     _____/
     \_____    \____/  \____/    _____/
      \_____   FINCH CONTROL    _____/
         \___________  ___________/
                   /____\");

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
            Console.WriteLine("\tThank you for using Finch Control!");
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
            Console.WriteLine("\t" + headerText);
            Console.WriteLine();
        }

        #endregion

        #region METHODS
        public static int IsValidInt()
        {
            bool IsValidInt = false;
            int validInt = 0;
            while (!IsValidInt)
            {
                IsValidInt = int.TryParse(Console.ReadLine(), out validInt);
                if (!IsValidInt)
                {
                    Console.WriteLine("Please enter a numeric value");
                    IsValidInt = false;
                }
            }
            return validInt;
        }

        public static double IsValidDouble()
        {
            bool IsValidDouble = false;
            double validDouble = 0;
            while (!IsValidDouble)
            {
                IsValidDouble = double.TryParse(Console.ReadLine(), out validDouble);
                if (!IsValidDouble)
                {
                    Console.WriteLine("Please enter a numeric value");
                    IsValidDouble = false;
                }
            }
            return validDouble;
        }
        #endregion
    }
}
