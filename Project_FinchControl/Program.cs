using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using System.Threading;
using System.Runtime.InteropServices;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Application Type: Console
    // Description: Menus created, functions created
    // Author: Smyka, Doug
    // Dated Created: 10/4/2020
    // Last Modified: 10/18/2020
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
                        Console.WriteLine("\tThat is not a valid input");
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
        /// <summary>
        /// ********************************************************************
        /// *           Talent Show > Buzzer                                   *
        /// ********************************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayBuzzer(Finch finchRobot)
        {
            DisplayScreenHeader("Buzzer");
            Console.Write("\tEnter the frequency in hertz you'd like to hear: ");
            int hertz = IsValidInt();
            Console.Write("\tEnter how long you would like the Finch to play this sound (in seconds): ");
            int time = IsValidInt() * 1000;
            Console.WriteLine();
            Console.WriteLine($"\tThe frequency you chose is {hertz}, it will play for {time / 1000} seconds.");
            DisplayContinuePrompt();
            Beep(finchRobot, hertz, time);
            DisplayMenuPrompt("Talent Show Menu");
        }
        #endregion

        #region BEEPERS AND LIGHTS OH MY

        //
        // *********************************************
        // *        Methods for Finch Beeper and LEDs  *
        // *********************************************
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

        //
        // *******************************************
        // *    Methods for Movement of Ficnh        *
        // *******************************************

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
        /// *********************************************************
        /// * Star Wars Song with movement functionality and lights *
        /// *********************************************************
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
        /// *********************************************************
        /// *       Star Wars Song with lights no movement          *
        /// *********************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void StarWarsNoMotors(Finch finchRobot)
        {
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);           
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);            
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);            
            Beep(finchRobot, 250, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);            
            Beep(finchRobot, 350, 250);
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);            
            Beep(finchRobot, 250, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);           
            Beep(finchRobot, 350, 250);
            Beep(finchRobot, 300, 500);
            LEDOnOFFSleep(finchRobot, 255, 0, 0, 50);
            
        }



        /// <summary>
        /// ******************************************************
        /// *       HAPPY BIRTHDAY SONG WITH LIGHTS              *
        /// ******************************************************
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
        /// *                      DATA RECORDER                            *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayDataRecorderMenuScreen(Finch finchRobot)
        {
            DisplayScreenHeader("Data Recorder");

            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;
            int[][] lights = null;
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
                Console.WriteLine("\tC: Get Temperuture Data");
                Console.WriteLine("\tD: Get Light Sensor Data");
                Console.WriteLine("\tE: Show Data");
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
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetTemperatureData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        lights = DataRecorderDisplayGetLightSensorData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "e":
                        DataRecorderDisplayData(temperatures, lights);
                        break;
                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tThat is not a valid input");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);

        }




        /// <summary>
        /// *********************************************************
        /// *       DATA RECORDER > DATA POINTS                     *
        /// ********************************************************* 
        /// </summary>
        /// <returns></returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            DisplayScreenHeader("Number of Data Points");

            int numberOfDataPoints;
            Console.Write("\tEnter a number of Data points you would like to collect: ");
            numberOfDataPoints = IsValidInt();
            DisplayMenuPrompt("Data Recorder Menu");

            return numberOfDataPoints;

        }


        /// <summary>
        /// *********************************************************
        /// *       DATA RECORDER > FREQUENCY                       *
        /// ********************************************************* 
        /// </summary>
        /// <returns></returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            DisplayScreenHeader("Frequency");

            double numberOfDataPoints;

            Console.Write("\tEnter the frequency at which you would like to collect Data (in seconds): ");
            numberOfDataPoints = IsValidDouble();
            DisplayMenuPrompt("Data Recorder Menu");

            return numberOfDataPoints;
        }

        /// <summary>
        /// *********************************************************
        /// *       DATA RECORDER > GET TEMPERATURE                 *
        /// ********************************************************* 
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static double[] DataRecorderDisplayGetTemperatureData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Temperature Data");


            Console.WriteLine($"\tNumber of Data points: {numberOfDataPoints}");
            Console.WriteLine($"\tFrequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe finch is ready to begin recording the temperature data");
            DisplayContinuePrompt();
            Console.WriteLine();
            for (int i = 0; i < numberOfDataPoints; i++)
            {
                temperatures[i] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {i + 1}: {temperatures[i]:n2}");
                int wait = (int)(dataPointFrequency * 1000);
                finchRobot.wait(wait);
            }

            DisplayMenuPrompt("Data Recorder Menu");

            return temperatures;

        }
        /// <summary>
        /// *********************************************************
        /// *       DATA RECORDER > GET LIGHT SENSOR DATA           *
        /// ********************************************************* 
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static int[][] DataRecorderDisplayGetLightSensorData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {

            int[][] lights = new int[numberOfDataPoints][];

            DisplayScreenHeader("Get Light Sensor Data");

            Console.WriteLine($"\tNumber of Data points: {numberOfDataPoints}");
            Console.WriteLine($"\tFrequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe finch is ready to begin recording the Light Sensor data");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                lights[i] = finchRobot.getLightSensors();
                Console.WriteLine(string.Format($"\tReading: {i + 1} {lights[i][0],14}{lights[i][1],20}"));
                int wait = (int)(dataPointFrequency * 1000);
                finchRobot.wait(wait);
            }

            DisplayMenuPrompt("Data Recorder Menu");
            return lights;
        }
        /// <summary>
        /// ********************************************************
        /// *       DATA RECORDER > DISPLAY DATA                   *
        /// ********************************************************* 
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayData(double[] temperatures, int[][] lights)
        {
            DisplayScreenHeader("\t\tShow Data");

            DataRecorderDisplayDataTable(temperatures, lights);

            DisplayMenuPrompt("Data Recorder Menu");
        }


        /// <summary>
        /// ********************************************************
        /// *       DATA RECORDER METHOD FOR DISPLAYING DATA       *
        /// ******************************************************** 
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayDataTable(double[] temperatures, int[][] lights)
        {
            // variables
            //
            double average;
            string avg;
            //
            // Table Header for Temperatures in Celcius
            //
            Console.WriteLine(string.Format($"{"Reading",17}    {"Temperature (Cº)",17}"));
            Console.WriteLine();
            for (int i = 0; i < temperatures.Length; i++)
            {
                string temps = temperatures[i].ToString("n2");
                Console.WriteLine(string.Format($"{i + 1,14}{temps,15}"));
            }

            //
            // Prints out the average temperature in Celcius
            //
            Console.WriteLine();
            average = Average(temperatures);
            avg = average.ToString("n2");

            Console.WriteLine($"\tAverage Temperature (Cº): {avg}");
            Console.WriteLine();

            //
            // Table header for Temperatures in Farenheit
            //

            Console.WriteLine(string.Format($"{"Reading",17}    {"Temperature (Fº)",17}"));
            Console.WriteLine();
            for (int i = 0; i < temperatures.Length; i++)
            {
                double celcius = temperatures[i];
                double temperature = CelciusConversion(celcius);
                string temp = temperature.ToString("n2");
                Console.WriteLine(string.Format($"{i + 1,14}{temp,15}"));
            }

            //
            // Prints out the average temperatue in Farenheit
            //
            Console.WriteLine();
            Console.WriteLine();
            average = CelciusConversion(average);
            avg = average.ToString("N2");
            Console.WriteLine($"\tAverage Temperature (Fº): {avg}");
            Console.WriteLine();

            //
            // Table Header for Light Sensor data
            //
            Console.WriteLine();
            Console.WriteLine(string.Format($"{"Reading",17} {"Left Sensor",17} {"Right Sensor",17}"));
            Console.WriteLine();

            for (int i = 0; i < lights.Length; i++)
            {
                Console.WriteLine(string.Format($" {i + 1,14} {lights[i][0],14}{lights[i][1],17}"));
            }

        }

        #endregion

        #region ALARM SYSTEM

        /// <summary>
        /// *****************************************************************
        /// *                      ALARM SYSTEM                            *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayAlarmSystemMenuScreen(Finch finchRobot)
        {
            //
            // display header
            //
            DisplayScreenHeader("Alarm System");

            //
            // initialize variables
            //
            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            double minMaxTemperatureValue = 0;
            int timeToMonitor = 0;

            bool quitMenu = false;
            string menuChoice;


            do
            {
                DisplayScreenHeader("Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tA: Set Sensors to Monitor");
                Console.WriteLine("\tB: Set Range Type");
                Console.WriteLine("\tC: Set Maximum/Minimum Threshold Value");
                Console.WriteLine("\tD: Set Maximum/Minimum Temperature Value");
                Console.WriteLine("\tE: Set Time to Monitor");                
                Console.WriteLine("\tF: Set Light Alarm");                
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
                        sensorsToMonitor = AlarmDisplaySetSensorsToMonitor(finchRobot);
                        break;

                    case "b":
                        rangeType = AlarmDisplaySetRangeType();
                        break;
                        
                    case "c":
                        minMaxThresholdValue = AlarmDisplaySetMinMaxThresholdValue(finchRobot, rangeType);
                        break;

                    case "d":
                        minMaxTemperatureValue = AlarmDisplaySetMinMaxTemperatureValue(finchRobot, rangeType);
                        break;

                    case "e":
                        timeToMonitor = AlarmDisplaySetMaximumTimeToMonitor();
                        break;
                    case "f":
                        AlarmSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor, minMaxTemperatureValue);
                        break;
                    
                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tThat is not a valid input");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }
        


        /// <summary>
        /// *****************************************************************
        /// *               ALARM SYSTEM  >  SET SENSORS TO MONITOR         *      
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static string AlarmDisplaySetSensorsToMonitor(Finch finchRobot)
        {

            string sensorsToMonitor;
            DisplayScreenHeader("Set sensors to Monitor");
            DisplayLeftAndRightSensorValue(finchRobot);
            
            // prompt user for light sensors they wish to monitor
            // use method LeftRightBoth to validate their input

            sensorsToMonitor = LeftRightBoth();
            Console.WriteLine();

            //
            // echo user input
            //

            Console.WriteLine($"\tSensors to Monitor: {sensorsToMonitor}");
            DisplayMenuPrompt("Alarm System Menu");

            // return input

            return sensorsToMonitor;
        }

        /// <summary>
        /// *****************************************************************
        /// *               ALARM SYSTEM  >   SET RANGE TYPE                *          
        /// *****************************************************************
        /// </summary>
        /// <returns></returns>
        static string AlarmDisplaySetRangeType()
        {
            string range;

            DisplayScreenHeader("Set Range Type");

            // prompt user for range value
            // use method IsMinMax to validate their input
            
            range = IsMinMax();
            Console.WriteLine();
            
            // echo user input back

            Console.WriteLine($"\tThe threshold you chose was: {range}");
            DisplayContinuePrompt();
            DisplayMenuPrompt("Alarm System Menu");

            // return input

            return range;
        }

        /// <summary>
        /// *****************************************************************
        /// *     ALARM SYSTEM  >  SET MAXIMUM/MINIMUM THRESHOLD VALUE      *  
        /// *****************************************************************
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static int AlarmDisplaySetMinMaxThresholdValue(Finch finchRobot, string rangeType)
        {
            int thresholdValue;
            DisplayScreenHeader("Maximum/Minimum Threshold Value");

            // display left and right sensor value

            Console.WriteLine();
            DisplayLeftAndRightSensorValue(finchRobot);

            // prompt user for input

            Console.Write($"\tEnter the {rangeType} threshold value: ");

            // validate user input with method IsValidInt

            thresholdValue = IsValidInt();

            // validate user input is within the proper range using
            // method isValidThresholdAndRange

            thresholdValue = isValidThresholdAndRange(thresholdValue, 255, 0);
            Console.WriteLine();

            // echo back user input

            Console.WriteLine($"\tLight sensor {rangeType} value: {thresholdValue}");
            DisplayMenuPrompt("Alarm System Menu");

            // return user input

            return thresholdValue;
        }

        /// <summary>
        /// *****************************************************************
        /// *          ALARM SYSTEM  > SET MINIMUM/MAXIMUM TEMPERATURE      *      
        /// *****************************************************************
        /// </summary>
        /// <param name="rangeType"></param>
        /// <returns></returns>
        static double AlarmDisplaySetMinMaxTemperatureValue(Finch finchRobot, string rangeType)
        {
            double temperatureValue;
            double tempNow = GetTempNow(finchRobot);
            DisplayScreenHeader("Maximum/Minimum Temperature Value");

            // display current temperature

            Console.WriteLine();
            Console.WriteLine(string.Format($"\tCurrent temperature: {tempNow:n0}"));
            Console.WriteLine();
            

            // prompt user for input

            Console.Write($"\tEnter the {rangeType} threshold value: ");

            // validate user input using method IsValidInt

            temperatureValue = IsValidInt();
            Console.WriteLine();

            // echo back user input

            Console.WriteLine($"\tTemperature sensor {rangeType} value: {temperatureValue}");
            DisplayMenuPrompt("Alarm System Menu");

            // return user input

            return temperatureValue;
        }
        /// <summary>
        /// *****************************************************************
        /// *               ALARM SYSTEM  >  SET TIME TO MONITOR            *
        /// *****************************************************************
        /// </summary>
        /// <returns></returns>
        static int AlarmDisplaySetMaximumTimeToMonitor()
        {
            DisplayScreenHeader("Maximum time to Monitor");
            int timeToMonitor;
            Console.Write("\tEnter maximum number of seconds to monitor: ");
            timeToMonitor = IsValidInt();
            Console.WriteLine();
            Console.WriteLine($"\tThe numer of seconds you chose is: {timeToMonitor}");
            Console.WriteLine();
            DisplayMenuPrompt("Alarm System Menu");
            return timeToMonitor;
        }

        /// <summary>
        /// *****************************************************************
        /// *               ALARM SYSTEM  >  SET LIGHT ALARM                *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="timeToMonitor"></param>
        static void AlarmSetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor, double minMaxTemperatureValue)


        {
            DisplayScreenHeader("Monitor Light Sensor");

            // echo back all the input user has given you

            Console.WriteLine($"\tSensors to monitor: {sensorsToMonitor}");
            Console.WriteLine($"\tRange type: {rangeType}");
            Console.WriteLine($"\tThe {rangeType} threshold value: {minMaxThresholdValue}");
            Console.WriteLine($"\tThe {rangeType} temperature value: {minMaxTemperatureValue}");
            Console.WriteLine($"\tMaximum time to monitor: {timeToMonitor}");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to start monitoring ...");
            Console.ReadKey();

            // use Alarm method to monitor light and temperature based on parameters provided by user input 

            Alarm(finchRobot, rangeType, minMaxThresholdValue, sensorsToMonitor, timeToMonitor, minMaxTemperatureValue);
            DisplayMenuPrompt("Alarm System Menu");

        }
        /// <summary>
        /// ******************************************************
        ///         ALARM MONITORING METHOD               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="timeToMonitor"></param>
        static void Alarm(Finch finchRobot, string rangeType, int minMaxThresholdValue, string sensorsToMonitor, int timeToMonitor, double minMaxTemperatureValue)
        {
            int timeElapsed = 0;
            bool threshold = false;
            int currentLightSensorValue = 0;
            double tempNow = 0;
            
            // monitor tempeerature and light

            while (timeElapsed < timeToMonitor && !threshold)
            {
                // get the current temperature and convert it to farenheit

                tempNow = GetTempNow(finchRobot);

                // get the current light sensor value based on user input

                currentLightSensorValue = LeftRightBothSensorValue(finchRobot, sensorsToMonitor);

                // display sensor values, time elapsed and temperature in a fixed location

                DisplayCurrentLightSensorValues(finchRobot, sensorsToMonitor, timeToMonitor, timeElapsed, 5, 10);

                // monitor based on user input

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue || tempNow < minMaxTemperatureValue)
                        {
                            // if threshold is exceeded loop breaks

                            threshold = true;
                        }

                        break;
                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue || tempNow > minMaxTemperatureValue)
                        {
                            // if threshold is exceeded loop breaks

                            threshold = true;
                        }
                        break;

                }

                // pause loop for one second

                finchRobot.wait(1000);

                // increment timeElapsed

                timeElapsed++;
            }
            
            // use the method Threshold to determine what is displayed on screen

            Threshold(finchRobot, threshold, rangeType, currentLightSensorValue, minMaxThresholdValue, minMaxTemperatureValue, tempNow);
        }
        /// <summary>
        /// ******************************************************
        ///         ALARM DISPLAY BASED ON BOOLEAN              
        /// ******************************************************
        /// </summary>
        /// <param name="threshold"></param>
        /// <param name="rangeType"></param>
        /// <param name="currentSensorValue"></param>
        /// <param name="minMaxThresholdValue"></param>
        static void Threshold(Finch finchRobot, bool threshold, string rangeType, int currentSensorValue, int minMaxThresholdValue, double minMaxTemperatureValue, double tempNow)
        {
            // if threshold was exceeded 

            if (threshold)
            {
                Skull(finchRobot);
                Console.WriteLine(@"
                    
                    ");
                Console.WriteLine();
                Console.WriteLine($"\tThe {rangeType} threshold {minMaxThresholdValue} was exceeded by the current sensor value: {currentSensorValue}");
            }

            // if threshold was not exceeded

            if (!threshold)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"\tThe {rangeType} light sensor threshold {minMaxThresholdValue} was not exceeded by the current sensor value: {currentSensorValue}");
                Console.WriteLine();
                Console.WriteLine($"\tThe {rangeType} temperature {minMaxTemperatureValue} was not exceeded by the current sensor value: {tempNow:n0} ");
            }


        }
        /// <summary>
        /// ******************************************************
        ///         DANGER SKULL ASCII ART              
        /// ******************************************************
        /// </summary>
        static void Skull(Finch finchRobot)
        {
            Console.Clear();
            Console.Write(@"
              _____          _   _  _____ ______ _____  
             |  __ \   /\   | \ | |/ ____|  ____|  __ \ 
             | |  | | /  \  |  \| | |  __| |__  | |__) |
             | |  | |/ /\ \ | . ` | | |_ |  __| |  _  / 
             | |__| / ____ \| |\  | |__| | |____| | \ \ 
             |_____/_/    \_\_| \_|\_____|______|_|  \_\
                                            
         @@@@@                                        @@@@@
        @@@@@@@                                      @@@@@@@
        @@@@@@@           @@@@@@@@@@@@@@@            @@@@@@@
         @@@@@@@@       @@@@@@@@@@@@@@@@@@@        @@@@@@@@
             @@@@@     @@@@@@@@@@@@@@@@@@@@@     @@@@@
               @@@@@  @@@@@@@@@@@@@@@@@@@@@@@  @@@@@
                 @@  @@@@@@@@@@@@@@@@@@@@@@@@@  @@
                    @@@@@@@    @@@@@@    @@@@@@
                    @@@@@@      @@@@      @@@@@
                    @@@@@@      @@@@      @@@@@
                     @@@@@@    @@@@@@    @@@@@
                      @@@@@@@@@@@  @@@@@@@@@@
                       @@@@@@@@@@  @@@@@@@@@
                   @@   @@@@@@@@@@@@@@@@@   @@
                   @@@@  @@@@ @ @ @ @ @@@@  @@@@
                  @@@@@   @@@ @ @ @ @ @@@   @@@@@
                @@@@@      @@@@@@@@@@@@@      @@@@@
              @@@@          @@@@@@@@@@@          @@@@
           @@@@@              @@@@@@@              @@@@@
          @@@@@@@                                 @@@@@@@
           @@@@@                                   @@@@@
                            ");
            Console.WriteLine();
            StarWarsNoMotors(finchRobot);
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

        #region VALIDATION METHODS

        /// <summary>
        /// ******************************************************
        ///         VALIDATES INTEGER FALLS WITHIN A RANGE     
        /// ******************************************************
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        static int isValidThresholdAndRange(int thresholdValue, int max, int min)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();
                    Console.Write($"\tPlease enter a threshold value between {min} and {max}: ");
                    thresholdValue = IsValidInt();
                }
                else
                {
                    isValidThreshold = true;
                }
            }
            return thresholdValue;
        }
        /// <summary>
        /// ******************************************************
        ///         VALIDATES USER INPUT IS AN INTEGER
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        public static int IsValidInt()
        {
            bool IsValidInt = false;
            int validInt = 0;
            while (!IsValidInt)
            {
                IsValidInt = int.TryParse(Console.ReadLine(), out validInt);
                if (!IsValidInt)
                {
                    Console.WriteLine();
                    Console.Write("\tPlease enter an integer value: ");
                    IsValidInt = false;
                }
            }
            return validInt;
        }
        /// <summary>
        /// ******************************************************
        ///         VALIDATES USER INPUT IS A DOUBLE
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        public static double IsValidDouble()
        {
            bool IsValidDouble = false;
            double validDouble = 0;
            while (!IsValidDouble)
            {
                IsValidDouble = double.TryParse(Console.ReadLine(), out validDouble);
                if (!IsValidDouble)
                {
                    Console.WriteLine();
                    Console.Write("\tPlease enter a numeric value: ");
                    IsValidDouble = false;
                }
            }
            return validDouble;
        }

        /// <summary>
        /// ******************************************************
        ///         AVERAGE OF A DOUBLE ARRAY
        /// ******************************************************
        /// </summary>
        /// <param name="temperatures"></param>
        /// <returns></returns>
        static double Average(double[] temperatures)
        {
            double result = 0;

            for (int i = 0; i < temperatures.Length; i++)
            {
                result += temperatures[i];
            }

            result = result / temperatures.Length;
            return result;
        }
        /// <summary>
        /// ******************************************************
        ///         VALIDATE USER STRING INPUT FOR LEFT, RIGHT
        ///         OR BOTH
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static string LeftRightBoth()
        {
            Console.Write("\tPlease enter the sensor to monitor [ left, right or both ]: ");
            string lRB = Console.ReadLine().ToLower();
            bool isFalse = false;
            while (!isFalse)
            {

                if (lRB == "left" || lRB == "l")
                {
                    lRB = "left";
                    break;
                }
                else if (lRB == "right" || lRB == "r")
                {
                    lRB = "right";
                    break;
                }
                else if (lRB == "both" || lRB == "b")
                {
                    lRB = "both";
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("\tPlease enter one of the following choices [ left, right, both ]: ");
                    lRB = Console.ReadLine().ToLower();
                    if (lRB != "left" || lRB != "l" || lRB != "right" || lRB != "r" || lRB != "both" || lRB != "b")
                    {
                        isFalse = false;
                        continue;
                    }
                }
                return lRB;
            }
            return lRB;
        }
        /// <summary>
        /// ******************************************************
        ///         VALIDATE USER STRING INPUT IS MINIMUM
        ///         OR MAXIMUM
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static string IsMinMax()
        {
            Console.Write("\tPlease enter the range to monitor [ maximum, minimum ]: ");
            string minMax = Console.ReadLine().ToLower();
            bool isFalse = false;
            while (!isFalse)
            {

                if (minMax == "maximum" || minMax == "max")
                {
                    minMax = "maximum";
                    break;
                }
                else if (minMax == "minimum" || minMax == "min")
                {
                    minMax = "minimum";
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("\tPlease enter one of the following choices [ maximum, minimum ]: ");
                    minMax = Console.ReadLine().ToLower();
                    if (minMax != "maximum" || minMax != "minimum" || minMax != "max" || minMax != "min")
                    {
                        isFalse = false;
                        continue;
                    }
                }
                return minMax;
            }
            return minMax;
        }

        #endregion

        #region SENSOR METHODS
        /// <summary>
        /// ******************************************************
        ///         CONVERTS CELCIUS TO FARENHEIT
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        public static double CelciusConversion(double celsius)
        {
            double fahrenheit = (celsius * 9) / 5 + 32;
            return fahrenheit;
        }
        /// <summary>
        /// ******************************************************
        ///         DISPLAY LEFT AND RIGHT SENSOR VALUES                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplayLeftAndRightSensorValue(Finch finchRobot)
        {
            int leftLight = finchRobot.getLeftLightSensor();
            int rightLight = finchRobot.getRightLightSensor();

            Console.WriteLine($"\tCurrent ambient left light sensor level  :  {leftLight}");
            Console.WriteLine($"\tCurrent ambient right light sensor level :  {rightLight}");
            Console.WriteLine();
        }

        /// <summary>
        /// ******************************************************
        ///         DISPLAY LIGHT SENSOR VALUES IN FIXED LOCATION     
        ///         DISPLAY TEMPERATURE IN FIXED LOCATION             
        ///         DISPLAY TIMER IN FIXED LOCATION                   
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="timeToMonitor"></param>
        /// <param name="timeElapsed"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        static void DisplayCurrentLightSensorValues(Finch finchRobot, string sensorsToMonitor, int timeToMonitor, int timeElapsed, int left, int top)
        {
            int[][] lights = new int[timeToMonitor][];
            double temp = GetTempNow(finchRobot);
            if (sensorsToMonitor == "both")
            {  
                Console.SetCursorPosition(left, top);
                Console.WriteLine();
                Console.WriteLine($"\tTime Elapsed: {timeElapsed}");
                Console.WriteLine();                
                Console.WriteLine(string.Format($"\tTemperature: {temp:n0}"));
                Console.WriteLine();
                lights[0] = finchRobot.getLightSensors();
                Console.WriteLine(string.Format($"\tLeft  Sensor: {lights[0][0]}"));
                Console.WriteLine();
                Console.WriteLine(string.Format($"\tRight Sensor: {lights[0][1]}"));
            }
            else if (sensorsToMonitor == "left")
            {                
                Console.SetCursorPosition(left, top);
                Console.WriteLine();
                Console.WriteLine($"\tTime Elapsed: {timeElapsed}");
                Console.WriteLine();
                Console.WriteLine(string.Format($"\tTemperature: {temp:n0}"));
                Console.WriteLine();
                lights[0] = finchRobot.getLightSensors();
                lights[0] = finchRobot.getLightSensors();
                Console.WriteLine(string.Format($"\tLeft Sensor: {lights[0][0]}"));                
            }
            else
            {                
                Console.SetCursorPosition(left, top);
                Console.WriteLine();
                Console.WriteLine($"\tTime Elapsed: {timeElapsed}");
                Console.WriteLine();
                Console.WriteLine(string.Format($"\tTemperature: {temp:n0}"));
                Console.WriteLine();
                lights[0] = finchRobot.getLightSensors();
                Console.WriteLine(string.Format($"\tRight Sensor: {lights[0][1]}"));    
            }
        }
        static int GetCurrentLeftSensorValue(Finch finchRobot)
        {
            int leftsensor = finchRobot.getLeftLightSensor();
            return leftsensor;
        }
        /// <summary>
        /// ******************************************************
        ///         GET RIGHT LIGHT SENSOR VALUE                         
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static int GetCurrentRightSensorValue(Finch finchRobot)
        {
            int rightsensor = finchRobot.getRightLightSensor();
            return rightsensor;
        }

        /// <summary>
        /// ******************************************************
        ///         GET LEFT LIGHT SENSOR VALUE                                         
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <returns></returns>
        static int LeftRightBothSensorValue(Finch finchRobot, string sensorsToMonitor)
        {
            int currentLightsensorValue = 0;
            switch (sensorsToMonitor)
            {
                case "left":
                    currentLightsensorValue = GetCurrentLeftSensorValue(finchRobot);
                    break;
                case "right":
                    currentLightsensorValue = GetCurrentRightSensorValue(finchRobot);
                    break;
                case "both":
                    currentLightsensorValue = ((GetCurrentLeftSensorValue(finchRobot) + GetCurrentRightSensorValue(finchRobot)) / 2);
                    break;
            }
            return currentLightsensorValue;
        }
        /// <summary>
        /// ******************************************************
        ///         GET CURRENT TEMPERATURE                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static double GetTempNow(Finch finchRobot)
        {
            double temp = finchRobot.getTemperature();
            temp = CelciusConversion(temp);
            return temp;
        }

        #endregion
        
        #region UNUSED METHODS
        /// <summary>
        /// ******************************************************
        ///         GET LEFT AND RIGHT SENSOR VALUE                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static int[][] GetLeftAndRightSensorValue(Finch finchRobot)
        {
            int[][] lights = new int[0][];
            lights[0] = finchRobot.getLightSensors();
            return lights;
        }

        /// <summary>
        /// ******************************************************
        ///         DISPLAY CURRENT LIGHT SENSOR VALUES
        ///         IN A FIXED LOCATION
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="timeToMonitor"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        static void DisplayCurrentLightSensorValue(Finch finchRobot, string sensorsToMonitor, int timeToMonitor, int left, int top)
        {
            int[][] lights = new int[timeToMonitor][];

            if (sensorsToMonitor == "both")
            {
                for (int i = 0; i < timeToMonitor; i++)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine($"\tTime Elapsed: {i}");
                    Console.WriteLine();
                    lights[i] = finchRobot.getLightSensors();
                    Console.WriteLine(string.Format($"\tL: {lights[i][0]} R: {lights[i][1]}"));
                    finchRobot.wait(1000);
                }

            }
            else if (sensorsToMonitor == "left")
            {
                for (int i = 0; i < timeToMonitor; i++)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine($"\tTime Elapsed: {i}");
                    Console.WriteLine();
                    lights[i] = finchRobot.getLightSensors();
                    Console.WriteLine(string.Format($"\tL: {lights[i][0]}"));
                    finchRobot.wait(1000);
                }
            }
            else
            {
                for (int i = 0; i < timeToMonitor; i++)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine($"\tTime Elapsed: {i}");
                    Console.WriteLine();
                    lights[i] = finchRobot.getLightSensors();
                    Console.WriteLine(string.Format($"\tR: {lights[i][1]}"));
                    finchRobot.wait(1000);
                }
            }
        }
        /// <summary>
        /// ******************************************************
        ///         TIMER FOR COUNTING UP                                      
        /// ******************************************************
        /// </summary>
        /// <param name="time"></param>
        static void timer(int time, int left, int top)
        {
            for (int i = 1; i <= time; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.CursorVisible = false;
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// ******************************************************
        ///         COUNTDOWN METHOD                                      
        /// ******************************************************
        /// </summary>
        /// <param name="time"></param>
        static void countdown(int time, int left, int top)
        {
            for (int i = time; i >= 0; --i)
            {
                Console.CursorVisible = false;
                if (i > 10)
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine(i + " ");
                    Thread.Sleep(1000);
                }
            }
        }

        #endregion
    }
}
