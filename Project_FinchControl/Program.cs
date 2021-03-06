﻿using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control
    // Application Type: Console
    // Description: Menus created, functions created
    // Author: Smyka, Doug
    // Dated Created: 10/4/2020
    // Last Modified: 11/7/2020
    //
    // **************************************************

    class Program
    {
        #region MAIN
        public enum Command
        {
            NONE,
            MOVEFORWARD,
            MOVEBACKWARD,
            STOPMOTORS,
            WAIT,
            TURNRIGHT,
            TURNLEFT,
            LEDON,
            LEDREDON,
            LEDGREENON,
            LEDBLUEON,
            LEDOFF,
            GETLIGHTSENSOR,
            GETTEMPERATURE,
            DONE
        }
        public enum Note
        {
            NONE,
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            DONE
        }

        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            SetTheme();

            DisplayLoginRegister();
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
                Console.WriteLine("\tF: Stored Users and Passwords");
                Console.WriteLine("\tG: Disconnect Finch Robot");
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
                        DisplayCredentials();
                        break;

                    case "g":
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
        // *    Methods for Movement of Finch        *
        // *******************************************

        /// <summary>
        /// ******************************************************
        ///         FINCH MOVES IN SQUARE PATTERN MOVING RIGHT                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void SquareRight(Finch finchRobot)
        {
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
            TurnRight(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
        }

        /// <summary>
        /// ******************************************************
        ///         FINCH MOVES IN SQUARE PATTERN MOVING LEFT                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void SquareLeft(Finch finchRobot)
        {
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
            TurnLeft(finchRobot);
            Forward(finchRobot, 1000);
            FinchStopMotors(finchRobot);
        }

        /// <summary>
        /// ******************************************************
        ///         MOVE FINCH FORWARD                           
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="duration"></param>
        static void Forward(Finch finchRobot, int duration)
        {
            finchRobot.setMotors(100, 100);
            Sleep(finchRobot, duration);
        }

        /// <summary>
        /// ******************************************************
        ///             TURN LEFT                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TurnLeft(Finch finchRobot)
        {
            finchRobot.setMotors(-100, 100);
            Sleep(finchRobot, 700);
            finchRobot.setMotors(0, 0);
        }

        /// <summary>
        /// ******************************************************
        ///             TURN RIGHT                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TurnRight(Finch finchRobot)
        {
            finchRobot.setMotors(100, -100);
            Sleep(finchRobot, 700);
            finchRobot.setMotors(0, 0);
        }

        /// <summary>
        /// ******************************************************
        ///          MOVE FINCH FORWARD                     
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="Motors"></param>
        static void FinchMoveForward(Finch finchRobot, int Motors)
        {
            finchRobot.setMotors(Motors, Motors);
        }

        /// <summary>
        /// ******************************************************
        ///         MOVE FINCH BACKWARDS                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="Motors"></param>
        static void FinchMoveBackwards(Finch finchRobot, int Motors)
        {
            finchRobot.setMotors(-Motors, -Motors);
        }

        /// <summary>
        /// ******************************************************
        ///         STOP FINCH MOTORS                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void FinchStopMotors(Finch finchRobot)
        {
            finchRobot.setMotors(0, 0);
        }

        /// <summary>
        /// ******************************************************
        ///         FINCH WAIT                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="ms"></param>
        static void FinchWait(Finch finchRobot, int ms)
        {
            finchRobot.wait(ms);
        }

        /// <summary>
        /// ******************************************************
        ///         ALL LEDS ON                             
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="rgb"></param>
        static void FinchAllLEDOn(Finch finchRobot, int rgb )
        {
            finchRobot.setLED(rgb, rgb, rgb);
        }

        /// <summary>
        /// ******************************************************
        ///         RED LED ON                            
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="r"></param>
        static void FinchRedLEDOn(Finch finchRobot, int r)
        {
            finchRobot.setLED(r, 0, 0);
        }

        /// <summary>
        /// ******************************************************
        ///         GREEN LED ON                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="g"></param>
        static void FinchGreenLEDOn(Finch finchRobot, int g)
        {
            finchRobot.setLED(0, g, 0);
        }

        /// <summary>
        /// ******************************************************
        ///         BLUE LED ON                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="b"></param>
        static void FinchBlueLEDOn(Finch finchRobot, int b)
        {
            finchRobot.setLED(0, 0, b);
        }

        /// <summary>
        /// ******************************************************
        ///         LED OFF                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void FinchLEDOff(Finch finchRobot)
        {
            finchRobot.setLED(0, 0, 0);
        }

        /// <summary>
        /// ******************************************************
        ///         TURN RIGHT                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void FinchTurnRight(Finch finchRobot)
        {
            finchRobot.setMotors(100, -100);
        }

        /// <summary>
        /// ******************************************************
        ///         TURN LEFT                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void FinchTurnLeft(Finch finchRobot)
        {
            finchRobot.setMotors(-100, 100);
        }

        /// <summary>
        /// ******************************************************
        ///     STOP MOVEMENT, TURN OFF LIGHTS                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void FinchDONE(Finch finchRobot)
        {
            FinchStopMotors(finchRobot);
            FinchLEDOff(finchRobot);
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

            thresholdValue = isValidThresholdAndRange(thresholdValue, 0, 255);
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
                Console.WriteLine();

                // if range type was maximum

                if (rangeType == "maximum")
                    if(currentSensorValue > minMaxThresholdValue && tempNow > minMaxTemperatureValue)
                    {
                        Console.WriteLine($"\tThe {rangeType} threshold {minMaxThresholdValue} was exceeded by the current sensor value: {currentSensorValue}");
                        Console.WriteLine();
                        Console.WriteLine($"\tThe {rangeType} temperature {minMaxTemperatureValue} was exceeded by the current sensor value: {tempNow:n0} ");
                    }
                    else if (currentSensorValue > minMaxThresholdValue)
                    {
                        
                        Console.WriteLine($"\tThe {rangeType} threshold {minMaxThresholdValue} was exceeded by the current sensor value: {currentSensorValue}");
                        
                    }
                    else
                    {
                        Console.WriteLine($"\tThe {rangeType} temperature {minMaxTemperatureValue} was not exceeded by the current sensor value: {tempNow:n0} ");
                    }

                // i frange type was minimum

                if (rangeType =="minimum")
                {
                    if (currentSensorValue < minMaxThresholdValue && tempNow < minMaxTemperatureValue)
                    {
                        Console.WriteLine($"\tThe {rangeType} threshold {minMaxThresholdValue} was exceeded by the current sensor value: {currentSensorValue}");
                        Console.WriteLine();
                        Console.WriteLine($"\tThe {rangeType} temperature {minMaxTemperatureValue} was exceeded by the current sensor value: {tempNow:n0} ");
                    }
                    else if (currentSensorValue < minMaxThresholdValue)
                    {
                        Console.WriteLine($"\tThe {rangeType} threshold {minMaxThresholdValue} was exceeded by the current sensor value: {currentSensorValue}");
                    }
                    else
                    {
                        Console.WriteLine($"\tThe {rangeType} temperature {minMaxTemperatureValue} was exceeded by the current sensor value: {tempNow:n0} ");
                    }
                }
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
        /// *                     USER PROGRAMMING                          *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayUserProgrammingMenuScreen(Finch finchRobot)
        {


            string menuChoice;
            bool quitMenu = false;

            //
            //  Tuple to store command parameters
            //

            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>();


            do
            {
                //
                // display header
                //
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tA: Set Command Parameters");
                Console.WriteLine("\tB: Add Commands");
                Console.WriteLine("\tC: View Commands");
                Console.WriteLine("\tD: Execute Commands");
                Console.WriteLine("\tE: Song Maker");
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
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(finchRobot, commands, commandParameters);
                        break;

                    case "e":
                        DisplaySongMenu(finchRobot);
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
        /// *      USER PROGRAMMING  >  SET COMMAND PARAMETERS              *
        /// *****************************************************************
        /// </summary>
        /// 
        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            DisplayScreenHeader("Set Command Parameters");

            // Prompt user
            Console.WriteLine();
            commandParameters.motorSpeed = ValidIntegerAndRange("\tEnter Motor Speed [1-255]: ", 1, 255);
            Console.WriteLine();
            commandParameters.ledBrightness = ValidIntegerAndRange("\tEnter LED Brightness [1-255]: ", 1, 255);
            Console.WriteLine();
            commandParameters.waitSeconds = ValidDoubleAndRange("\tEnter wait in seconds (1-10): ", 0, 10);

            // Echo the values provided by the user

            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tLED Brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tWait command duration: {commandParameters.waitSeconds}");
            

            DisplayMenuPrompt("User Programming Menu");

            // Return all of the values as a tuple

            return commandParameters;
        }
        /// <summary>
        /// *****************************************************************
        /// *             USER PROGRAMMING  >  ADD COMMANDS                 *
        /// *****************************************************************
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            // Display commands avaialble

            DisplayCommandInstructions();
            DisplayContinuePrompt();
            Console.Clear();
            Console.WriteLine();
            CommandList(commands);
            
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.Write("\tEnter Command: ");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a command from the list above");
                    Console.WriteLine();
                }
            }

            DisplayContinuePrompt();

            // Display commands entered

            PrintCommands(commands, "Your Commands");

            DisplayMenuPrompt("User Programming Menu");

        }
        /// <summary>
        /// *****************************************************************
        /// *            USER PROGRAMMING  >  VIEW COMMANDS                 *
        /// ***************************************************************** 
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            // Display all commands stored in the command list

            PrintCommands(commands, "Your Commands");
            

            DisplayMenuPrompt("User Programming Menu");

        }
        /// <summary>
        /// *****************************************************************
        /// *            USER PROGRAMMING  >  EXECUTE COMMANDS              *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayExecuteFinchCommands(
            Finch finchRobot,
            List<Command> commands,
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMS = (int)(commandParameters.waitSeconds * 1000);
            string commandFeedback = "";

            DisplayScreenHeader("Execute Commands");

            // Display all commands stored in the command list

            PrintCommands(commands, "Your Commands");

            // Inform and prompt the user

            Console.WriteLine();
            Console.WriteLine("\tThe finch robot is ready to execute the list of commands");
            DisplayContinuePrompt();
            Console.Clear();
            Console.WriteLine();

            // Execute all of the commands

            foreach (Command command in commands)
            {
                switch(command)
                {
                    case Command.NONE:
                        commandFeedback = Command.NONE.ToString();
                        break;
                    case Command.MOVEFORWARD:
                        FinchMoveForward(finchRobot, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;
                    case Command.MOVEBACKWARD:
                        FinchMoveBackwards(finchRobot, motorSpeed);
                        commandFeedback = Command.MOVEBACKWARD.ToString();
                        break;
                    case Command.STOPMOTORS:
                        FinchStopMotors(finchRobot);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;
                    case Command.WAIT:
                        FinchWait(finchRobot, waitMS);
                        commandFeedback = Command.WAIT.ToString();
                        break;
                    case Command.TURNRIGHT:
                        FinchTurnRight(finchRobot);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;
                    case Command.TURNLEFT:
                        FinchTurnLeft(finchRobot);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;
                    case Command.LEDON:
                        FinchAllLEDOn(finchRobot, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;
                    case Command.LEDREDON:
                        FinchRedLEDOn(finchRobot, ledBrightness);
                        commandFeedback = Command.LEDREDON.ToString();
                        break;
                    case Command.LEDGREENON:
                        FinchGreenLEDOn(finchRobot, ledBrightness);
                        commandFeedback = Command.LEDGREENON.ToString();
                        break;
                    case Command.LEDBLUEON:
                        FinchBlueLEDOn(finchRobot, ledBrightness);
                        commandFeedback = Command.LEDBLUEON.ToString();
                        break;
                    case Command.LEDOFF:
                        FinchLEDOff(finchRobot);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;
                    case Command.GETLIGHTSENSOR:
                        commandFeedback = LightSensorsAverage(finchRobot, "Light sensor value:");
                        break;
                    case Command.GETTEMPERATURE:
                        commandFeedback = GetTempNow(finchRobot, "Temperature: ");
                        break;
                    case Command.DONE:
                        FinchDONE(finchRobot);
                        commandFeedback = Command.DONE.ToString();
                        break;
                }

                // Display each command name as it is executed

                Console.WriteLine($"\t{commandFeedback}");
                FinchWait(finchRobot, waitMS);
            }

            Console.WriteLine();
            DisplayMenuPrompt("User Programming Menu");
        }
        /// <summary>
        /// ******************************************************
        ///         PRINT USER COMMANDS                             
        /// ******************************************************
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="info"></param>
        static void PrintCommands(List<Command> commands, string info)
        {
            int commandCount = 1;
            Console.WriteLine();
            Console.WriteLine($"\t{info}");
            Console.WriteLine();
            Console.Write("\t");
            foreach (Command command in commands)
            {
                Console.Write($"| {command} | ");
                if (commandCount % 5 == 0) Console.Write("\n\t");
                commandCount++;
            }
            Console.WriteLine();
        }
        static void CommandList(List<Command> commands)
        {
            int commandCount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.Write("\t");
            foreach(string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.Write($"| {commandName.ToLower()} | ");
                if (commandCount % 5 == 0) Console.Write("\n\t");
                commandCount++;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// ******************************************************
        ///         DISPLAY INSTRUCTIONS                           
        /// ******************************************************
        /// </summary>
        static void DisplayCommandInstructions()
        {
            Console.Write(@"
            COMMAND GUIDE:
            **********************************************************
            MOVEFORWARD: Move the Finch forward
            MOVEBACKWARD: Move the Finch backwards
            STOPMOTORS: Stop the Finch motors
            WAIT: Pause the Finch
            TURNRIGHT: Turn the Finch right
            TURNLEFT: Turn the Finch left
            LEDON: Turn the LED's on
            LEDREDON: Turn the red LED on
            LEDGREENON: Turn the green LED on
            LEDBLUEON:  Turn the blue LED on
            LEDOFF: Turn the LED's off
            GETLIGHTSENSOR: Get current light sensor readings
            GETTEMPERATURE: Get current temperature
            **********************************************************
            When programming the finch make sure to add a wait between
            commands and a stopmotors when you want the finch to stop
            moving.
 
            Type 'done' when you are finished giving commands
            to the finch.
            ");
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
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine("\t" + headerText);
            Console.WriteLine();
        }

        #endregion

        #region VALIDATION METHODS
        /// <summary>
        /// ******************************************************
        ///         PROMPTS FOR INTEGER WITHIN A RANGE
        ///         VALIDATES USER INPUT
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static int ValidIntegerAndRange(string prompt, int min, int max)
        {
            Console.Write(prompt);
            int thresholdValue = IsValidInt();
            thresholdValue = isValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        /// <summary>
        /// ******************************************************
        ///         PROMPTS FOR DOUBLE WITHIN A RANGE
        ///         VALIDATES USER INPUT
        /// ******************************************************
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static double ValidDoubleAndRange(string prompt, int min, int max)
        {

            Console.Write(prompt);
            double thresholdValue = IsValidDouble();
            thresholdValue = isValidThresholdAndRange(thresholdValue, min, max);
            return thresholdValue;
        }
        /// <summary>
        /// ******************************************************
        ///         VALIDATES DOUBLE FALLS WITHIN A RANGE     
        /// ******************************************************
        /// 
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static double isValidThresholdAndRange(double thresholdValue, int min, int max)
        {
            bool isValidThreshold = false;
            while (!isValidThreshold)
            {
                if (thresholdValue > max || thresholdValue < min)
                {
                    Console.WriteLine();
                    Console.Write($"\tPlease enter a threshold value between {min} and {max}: ");
                    thresholdValue = IsValidDouble();
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
        ///         VALIDATES INTEGER FALLS WITHIN A RANGE     
        /// ******************************************************
        /// </summary>
        /// <param name="thresholdValue"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>

        static int isValidThresholdAndRange(int thresholdValue, int min, int max)
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
        /// <summary>
        /// ******************************************************
        ///         GET CURRENT LEFT SENSOR VALUE                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
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
        ///         LIGHT SENSOR AVERAGE FOR USER PROGRAMMING                               
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        static string LightSensorsAverage(Finch finchRobot, string info)
        {
            string lightSensorAvg;
            double lightSensorsNow = ((GetCurrentLeftSensorValue(finchRobot) + GetCurrentRightSensorValue(finchRobot)) / 2 );
            lightSensorsNow = CelciusConversion(lightSensorsNow);
            lightSensorAvg = $"{info} {lightSensorsNow.ToString("n2")}";
            return lightSensorAvg;
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
        /// <summary>
        /// ******************************************************
        ///         OVERLOAD GETTEMPNOW FOR USER PROGRAMMING                              
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        static string GetTempNow(Finch finchRobot, string display)
        {
            double temp = finchRobot.getTemperature();
            temp = CelciusConversion(temp);
            string print = $"{display} {temp.ToString("n2")}";
            return print;
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

        #region SONGMAKER
        /// <summary>
        /// ******************************************************
        ///             SONG MAKER MENU
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void DisplaySongMenu(Finch finchRobot)
        {
            List<Note> notes = new List<Note>();
            string menuChoice;
            bool quitMenu = false;

            do
            {
                //
                // display header
                //
                DisplayScreenHeader("Song Maker Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\tA: Set Notes");
                Console.WriteLine("\tB: Play Song");
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
                        GetSong(notes);
                        break;

                    case "b":
                        PlaySong(finchRobot, notes);
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
        /// ******************************************************
        ///             SONG MAKER MENU  >  GET SONG
        /// ******************************************************
        /// </summary>
        /// <param name="notes"></param>
        static void GetSong(List<Note> notes)
        {
            
            Note note = Note.NONE;

            // Display header

            DisplayScreenHeader("Set Notes for Song");

            // Display list of available notes

            CommandList(notes);

            // Prompt user for notes

            while (note != Note.DONE)
            {
                Console.Write("\tEnter Note: ");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out note))
                {
                    notes.Add(note);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a note from the list above");
                    Console.WriteLine();
                }
            }

            // Echo list of notes

            PrintCommands(notes);

            Console.WriteLine();
            DisplayMenuPrompt("Song Maker Menu");
        }
        /// <summary>
        /// ******************************************************
        ///             SONG MAKER MENU  >  PLAY SONG
        /// ******************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="notes"></param>
        static void PlaySong(Finch finchRobot, List<Note> notes)
        {
            DisplayScreenHeader("Your song");
            Console.WriteLine("\tThe Finch will now sing your song!");
            DisplayContinuePrompt();
            Console.WriteLine();
            Console.Write("\t");

            foreach (Note note in notes)
            {
                switch (note)
                {
                    case Note.NONE:
                        break;
                    case Note.A:
                        Beep(finchRobot, 220, 250);
                        Console.Write(" A ");
                        break;
                    case Note.B:
                        Beep(finchRobot, 247, 250);
                        Console.Write(" B ");
                        break;
                    case Note.C:
                        Beep(finchRobot, 131, 250);
                        Console.Write(" C ");
                        break;
                    case Note.D:
                        Beep(finchRobot, 147, 250);
                        Console.Write(" D ");
                        break;
                    case Note.E:
                        Beep(finchRobot, 165, 250);
                        Console.Write(" E ");
                        break;
                    case Note.F:
                        Beep(finchRobot, 175, 250);
                        Console.Write(" F ");
                        break;
                    case Note.G:
                        Beep(finchRobot, 196, 250);
                        Console.Write(" G ");
                        break;
                    case Note.DONE:
                        break;
                }

                
            }
            Console.WriteLine();
            DisplayMenuPrompt("Song Maker Menu");
        }
        /// <summary>
        /// ******************************************************
        ///         OVERLOAD PRINTCOMMANDS FOR SONG MAKER                        
        /// ******************************************************
        /// </summary>
        /// <param name="notes"></param>
        static void PrintCommands(List<Note> notes)
        {
            int noteCount = 1;
            Console.WriteLine();
            Console.Write("\t| ");
            foreach (Note note in notes)
            {
                Console.Write($"{note} | ");
                if (noteCount % 10 == 0) Console.Write("\n\t| ");
                noteCount++;
            } 
        }
        /// <summary>
        /// ******************************************************
        ///         OVERLOAD COMMANDLIST FOR SONG MAKER                        
        /// ******************************************************
        /// 
        /// </summary>
        /// <param name="notes"></param>
        static void CommandList(List<Note> notes)
        {
            
            Console.WriteLine("\tList of Available Notes");
            Console.WriteLine();
            Console.Write("\t|");
            foreach (string noteName in Enum.GetNames(typeof(Note)))
            {
                Console.Write($" {noteName} | ");
                
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion

        #region System I/0


        /// <summary>
        /// ******************************************************
        ///             LOGIN OR REGISTER MENU
        /// ******************************************************
        /// </summary>
        static void DisplayLoginRegister()
        {
            DisplayScreenHeader("Login/Register");

            Console.Write("\tAre you a registered user?  [Yes/No] ");
            string userResponse = Console.ReadLine().ToLower();
            if (userResponse == "yes" || userResponse == "y")
            {
                DisplayLogin();
            }
            else
            {
                DisplayRegisterUser();
                DisplayLogin();
            }
        }
        /// <summary>
        /// ******************************************************
        ///             REGISTER USER            
        /// ******************************************************
        /// </summary>
        static void DisplayRegisterUser()
        {
            string userName;
            string password;
            string encryptedPassword;
            int key;

            DisplayScreenHeader("Register");

            userName = GetUserName();
            Console.Write("\tEnter your password: ");
            password = Console.ReadLine();
            key = ValidIntegerAndRange("\tEnter a cipher value between 1 and 26: ", 1, 26);         
            encryptedPassword = Encrypt(password, key);
            

            WriteLoginInfoData(userName, encryptedPassword);
            WriteUserNameInfoData(userName);

            Console.WriteLine();
            Console.WriteLine("\tYour login credentials are as followed: ");
            Console.WriteLine($"\tUser name: {userName}");
            Console.WriteLine($"\tPassword: {password}");
            Console.WriteLine($"\tYour key: {key}");
            Console.WriteLine($"\tEncrypted Password: {encryptedPassword}");

            DisplayContinuePrompt();
        }
        /// <summary>
        /// ******************************************************
        ///             WRITE LOGIN INFO DATA
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        static void WriteLoginInfoData(string userName, string password)
        {
            string dataPath = @"Data/Logins.txt";
            string loginInfoText = userName + "," + password + "\n";

            File.AppendAllText(dataPath, loginInfoText);
        }
        /// <summary>
        /// ******************************************************
        ///             DISPLAY LOGIN
        /// ******************************************************
        /// </summary>
        static void DisplayLogin()
        {
            string userName;
            string password;
            string encryptedPassword;
            int key;
            bool validLogin;


            do
            {
                DisplayScreenHeader("Login");

                Console.WriteLine();
                Console.Write("\tEnter your user name: ");
                userName = Console.ReadLine();
                Console.Write("\tEnter password: ");
                password = Console.ReadLine();
                Console.Write("\tEnter Key: ");
                key = IsValidInt();
                encryptedPassword = Encrypt(password, key);

                validLogin = isValidLoginInfo(userName, encryptedPassword);

                Console.WriteLine();
                if (validLogin)
                {
                    Console.WriteLine($"\tYou are now logged in {userName}");
                    DisplayContinuePrompt();
                }
                else
                {
                    DisplayContinuePrompt();
                }

            } while (!validLogin);
        }
        /// <summary>
        /// ******************************************************
        ///             VALIDATE LOGIN CREDENTIALS
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        static bool isValidLoginInfo(string userName, string password)
        {
            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();
            bool validUser = false;

            registeredUserLoginInfo = ReadLoginInfoData();

            foreach ((string userName, string password) userLoginInfo in registeredUserLoginInfo)
            {
                if ((userLoginInfo.userName == userName) && (userLoginInfo.password == password))
                {
                    validUser = true;
                    break;
                }
            }

            if (!validUser)
            {
                Console.WriteLine("\tWrong login credentials");
            }
            return validUser;
        }

        /// <summary>
        /// ******************************************************
        ///             READ LOGIN INFO DATA
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static List<(string userName, string password)> ReadLoginInfoData()
        {
            string dataPath = @"Data/Logins.txt";


            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();

            loginInfoArray = File.ReadAllLines(dataPath);

            foreach (string loginInfoText in loginInfoArray)
            {
                loginInfoArray = loginInfoText.Split(',');

                loginInfoTuple.userName = loginInfoArray[0];
                loginInfoTuple.password = loginInfoArray[1];

                registeredUserLoginInfo.Add(loginInfoTuple);
            }

            return registeredUserLoginInfo;

        }
        /// <summary>
        /// ******************************************************
        ///             WRITE USER NAMES TO FILE
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        static void WriteUserNameInfoData(string userName)
        {
            string dataPath = @"Data/UserNames.txt";
            string userNames = userName + "\n";

            File.AppendAllText(dataPath, userNames);
        }
        /// <summary>
        /// ******************************************************
        ///             GET USER NAME AND SEE IF IT'S TAKEN
        /// ******************************************************
        /// </summary>
        /// <returns></returns>
        static string GetUserName()
        {
            bool validUserName;
            string userName;
            do
            {
                Console.Write("\tEnter user name: ");
                userName = Console.ReadLine();
                validUserName = isValidUserName(userName);

            } while (validUserName);

            return userName;
        }
        /// <summary>
        /// ******************************************************
        ///             CHECK IF USERNAME EXISTS ALREADY
        /// ******************************************************
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        static bool isValidUserName(string userName)
        {
            string dataPath = @"Data/UserNames.txt";
            bool validUserName = File.ReadLines(dataPath).Contains(userName);
            if (validUserName)
            {
                Console.WriteLine($"\tUser name already taken.");
            }
            return validUserName;
        }
        /// <summary>
        /// ******************************************************
        ///             DISPLAY USERNAMES AND ENCRYPTED PASSWORDS
        /// ******************************************************
        /// </summary>
        static void TableofUserNames()
        {
            string dataPath = @"Data\Logins.txt";

            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            loginInfoArray = File.ReadAllLines(dataPath);

            Console.WriteLine(string.Format($"\t{"User Name",10} \t {"Password",20}"));
            Console.WriteLine();
            foreach (string loginInfoText in loginInfoArray)
            {
                loginInfoArray = loginInfoText.Split(',');

                Console.WriteLine(string.Format($"\t{ loginInfoTuple.userName = loginInfoArray[0],10} \t {loginInfoTuple.password = loginInfoArray[1],20}"));

            }

        }
        /// <summary>
        /// ******************************************************
        ///             Display Credentials
        /// ******************************************************
        /// </summary>
        static void DisplayCredentials()
        {
            DisplayScreenHeader("User Names and Passwords");
            TableofUserNames();
            DisplayMenuPrompt("Main Menu");
        }
        #endregion

        #region Cipher
        /// <summary>
        /// ******************************************************
        ///             CHIPHER METHOD
        /// ******************************************************
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static char CaesarCipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
        /// <summary>
        /// ******************************************************
        ///             ENCRYPTION
        /// ******************************************************
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>

        public static string Encrypt(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += CaesarCipher(ch, key);

            return output;
        }
        /// <summary>
        /// ******************************************************
        ///             DECRYPTION
        /// ******************************************************
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string input, int key)
        {
            return Encrypt(input, 26 - key);
        }

        #endregion

    }
}
