using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectHash
{
    internal partial class Controller
    {
        const int SPEED = 0;

        /// <summary>
        /// Deletes and moves the cursor to the start position.
        /// </summary>
        /// <param name="cursorLeft"></param>Cursor start position's distance to left
        /// <param name="cursorTop"></param>Cursor start position's distance to top
        /// <param name="rightStep"></param>How many steps horizontal plane (from left to right)
        /// <param name="bottomStep"></param>How many steps vertical plane (from top to bottom)
        private void ConsoleClear(in int cursorLeft, int cursorTop, in int rightStep, in int bottomStep)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            for (int y = 0; y < bottomStep; y++)
            {
                for (int x = 0; x < rightStep; x++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(cursorLeft, ++cursorTop);
            }
            Console.SetCursorPosition(cursorLeft, cursorTop);
        }

        //ConsoleTypewrite-String
        private void ConsoleTypewrite(in string post, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            foreach (char x in post)
            {
                Console.Write(x);
                System.Threading.Thread.Sleep(speed);
            }
        }
        private void ConsoleTypewrite(in string post, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewrite(in string post)
        {
            ConsoleTypewrite(post, SPEED);
        }
        private void ConsoleTypewrite(in string post, in int speed)
        {
            ConsoleTypewrite(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewrite(in string post, in ConsoleColor consoleColor, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.ForegroundColor = consoleColor;
            ConsoleTypewrite(post, SPEED, cursorLeft, cursorTop);
        }
        private void ConsoleTypewrite(in string post, in ConsoleColor consoleColor, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, consoleColor, SPEED, cursorLeft, cursorTop);
        }
        private void ConsoleTypewrite(in string post, in ConsoleColor consoleColor)
        {
            ConsoleTypewrite(post, consoleColor, SPEED);
        }
        private void ConsoleTypewrite(in string post, in ConsoleColor consoleColor, in int speed)
        {
            ConsoleTypewrite(post, consoleColor, speed, Console.CursorLeft, Console.CursorTop);
        }

        //ConsoleTypewriteLine-String
        private void ConsoleTypewriteLine(in string post, in int speed, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, speed, cursorLeft, cursorTop);
            Console.Write("\n");
        }
        private void ConsoleTypewriteLine(in string post, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewriteLine(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewriteLine(in string post)
        {
            ConsoleTypewriteLine(post, SPEED);
        }
        private void ConsoleTypewriteLine(in string post, in int speed)
        {
            ConsoleTypewriteLine(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewriteLine(in string post, in ConsoleColor consoleColor, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.ForegroundColor = consoleColor;
            ConsoleTypewriteLine(post, speed, cursorLeft, cursorTop);
        }
        private void ConsoleTypewriteLine(in string post, in ConsoleColor consoleColor, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewriteLine(post, consoleColor, SPEED, cursorLeft, cursorTop);
        }
        private void ConsoleTypewriteLine(in string post, in ConsoleColor consoleColor)
        {
            ConsoleTypewriteLine(post, consoleColor, SPEED);
        }
        private void ConsoleTypewriteLine(in string post, in ConsoleColor consoleColor, in int speed)
        {
            ConsoleTypewriteLine(post, consoleColor, speed, Console.CursorLeft, Console.CursorTop);
        }

        //ConsoleTypewrite-Char
        private void ConsoleTypewrite(in char post, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            System.Threading.Thread.Sleep(speed);
            Console.Write(post);
        }
        private void ConsoleTypewrite(in char post, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewrite(in char post)
        {
            ConsoleTypewrite(post, SPEED);
        }
        private void ConsoleTypewrite(in char post, in int speed)
        {
            ConsoleTypewrite(post, speed, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewrite(in char post, in ConsoleColor consoleColor, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.ForegroundColor = consoleColor;
            ConsoleTypewrite(post, speed, cursorLeft, cursorTop);
        }
        private void ConsoleTypewrite(in char post, in ConsoleColor consoleColor, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, consoleColor, SPEED, cursorLeft, cursorTop);
        }
        private void ConsoleTypewrite(in char post, in ConsoleColor consoleColor)
        {
            ConsoleTypewrite(post, consoleColor, SPEED);
        }
        private void ConsoleTypewrite(in char post, in ConsoleColor consoleColor, in int speed)
        {
            ConsoleTypewrite(post, consoleColor, speed, Console.CursorLeft, Console.CursorTop);
        }

        //ConsoleTypewriteLine-Char
        private void ConsoleTypewriteLine(in char post, in int speed, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, speed, cursorLeft, cursorTop);
            Console.Write("\n");
        }
        private void ConsoleTypewriteLine(in char post, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewriteLine(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewriteLine(in char post)
        {
            ConsoleTypewriteLine(post, SPEED);
        }
        private void ConsoleTypewriteLine(in char post, in int speed)
        {
            ConsoleTypewriteLine(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewriteLine(in char post, in ConsoleColor consoleColor, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.ForegroundColor = consoleColor;
            ConsoleTypewriteLine(post, speed, cursorLeft, cursorTop);
        }
        private void ConsoleTypewriteLine(in char post, in ConsoleColor consoleColor, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewriteLine(post, consoleColor, SPEED, cursorLeft, cursorTop);
        }
        private void ConsoleTypewriteLine(in char post, in ConsoleColor consoleColor)
        {
            ConsoleTypewriteLine(post, consoleColor, SPEED);
        }
        private void ConsoleTypewriteLine(in char post, in ConsoleColor consoleColor, in int speed)
        {
            ConsoleTypewriteLine(post, consoleColor, speed, Console.CursorLeft, Console.CursorTop);
        }

        //ConsoleTypewrite-<T>
        private void ConsoleTypewrite<T>(in T post, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            System.Threading.Thread.Sleep(speed);
            Console.Write(post);
        }
        private void ConsoleTypewrite<T>(in T post, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewrite<T>(in T post)
        {
            ConsoleTypewrite(post, SPEED);
        }
        private void ConsoleTypewrite<T>(in T post, in int speed)
        {
            ConsoleTypewrite(post, speed, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewrite<T>(in T post, in ConsoleColor consoleColor, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.ForegroundColor = consoleColor;
            ConsoleTypewrite(post, speed, cursorLeft, cursorTop);
        }
        private void ConsoleTypewrite<T>(in T post, in ConsoleColor consoleColor, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, consoleColor, SPEED, cursorLeft, cursorTop);
        }
        private void ConsoleTypewrite<T>(in T post, in ConsoleColor consoleColor)
        {
            ConsoleTypewrite(post, consoleColor, SPEED);
        }
        private void ConsoleTypewrite<T>(in T post, in ConsoleColor consoleColor, in int speed)
        {
            ConsoleTypewrite(post, consoleColor, speed, Console.CursorLeft, Console.CursorTop);
        }

        //ConsoleTypewriteLine-<T>
        private void ConsoleTypewriteLine<T>(in T post, in int speed, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewrite(post, speed, cursorLeft, cursorTop);
            Console.Write("\n");
        }
        private void ConsoleTypewriteLine<T>(in T post, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewriteLine(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewriteLine<T>(in T post)
        {
            ConsoleTypewriteLine(post, SPEED);
        }
        private void ConsoleTypewriteLine<T>(in T post, in int speed)
        {
            ConsoleTypewriteLine(post, SPEED, Console.CursorLeft, Console.CursorTop);
        }
        private void ConsoleTypewriteLine<T>(in T post, in ConsoleColor consoleColor, in int speed, in int cursorLeft, in int cursorTop)
        {
            Console.ForegroundColor = consoleColor;
            ConsoleTypewriteLine(post, speed, cursorLeft, cursorTop);
        }
        private void ConsoleTypewriteLine<T>(in T post, in ConsoleColor consoleColor, in int cursorLeft, in int cursorTop)
        {
            ConsoleTypewriteLine(post, consoleColor, SPEED, cursorLeft, cursorTop);
        }
        private void ConsoleTypewriteLine<T>(in T post, in ConsoleColor consoleColor)
        {
            ConsoleTypewriteLine(post, consoleColor, SPEED);
        }
        private void ConsoleTypewriteLine<T>(in T post, in ConsoleColor consoleColor, in int speed)
        {
            ConsoleTypewriteLine(post, consoleColor, speed, Console.CursorLeft, Console.CursorTop);
        }
    }
}
