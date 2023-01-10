using System;
using System.Collections.Generic;

namespace Fuck_Language
{
    class Program
    {
        static void Main(string[] args) 
        {
            string code = "[[]*>*>*>]";
            string tape = "000";
            //string outp = Interpreter(code, tape);
            //Console.WriteLine(outp);
        }
    }

    /*
        Ссылки на все решения:

        • [Code 1] MiniStringFuck: https://blog.csdn.net/weixin_45444821/article/details/103135172
        • [Code 2] Smallfuck: https://github.com/RasPat1/practice-codewars/blob/master/Smallfuck.java
        • [Code 3] Paintfuck: https://gist.githubusercontent.com/ldcc/f5d3aa8081dedb150cd5169fe6593ace/raw/841da614b973c93523327d6ed84887f7e2a79b48/13_paintfuck-interpreter.java
        • [Code 4] Boolfuck: https://github.com/DonaldKellett/Boolfuck/blob/master/js/function.boolfuck.js

        + Отличный сборник программ, с многими алгоритмами на Java: https://gist.github.com/ldcc/f5d3aa8081dedb150cd5169fe6593ace

        А также кину файлик со всеми этими кодами (и пояснениями, которые я написал к ним сам)

    */

    // ------ 

    /*////////////////////////////////////////////////////////
    //                                                      //
    //           Решения для всех 4х Fuck-языков            //
    //                                                      //
    /////////////////////////////////////////////////////// */

    /*/////////////////////////////////
    //            CODE: 1            //
    /////////////////////////////////*/

    /*/////////////////////////////////
    //           Пояснение:          //
    /////////////////////////////////*/

    /*
        MiniStringFuck - это язык, похожий на машину Тьюринга.
        Он также работает по типу бесконченой ленты со значениями в её ячейках

        Простым языком, как работают примеры: Если на входе символ '+' то он увеличивает значение переменной memory
        А если символ '.', то он добавляет к выходной строке сивол, код которого - это числовое значение, 
        которое лежит в переменной memory

        Вот почему так легко было вывести алфавит - сначала мы идём до числового значения символа 'A' (английского алфавита) = 66
        а потом просто выводим каждый следующий символ

        Да, вывести какое-либо предложение, и даже слово будет проблемно, потому что если нужный нам символ находится слева по алфавиту,
        то нам нужно будет пройти 255 значений, прежде чем мы до него дойдём. Т.к. этот алгоритм обнуляется, если 
        значение переменной memory > 255

        Ссылка на Wiki: https://esolangs.org/wiki/MiniStringFuck
        Ссылка на сайт с вариантами реализации этого алгоритма: https://blog.csdn.net/weixin_45444821/article/details/103135172
    */

    /*/////////////////////////////////
    //           Решение:            //
    /////////////////////////////////*/

    /*

    public class Kata
    {
        public static string MyFirstInterpreter(string code)
        {
            byte memory = 0;
            string stdout = "";
            foreach (char c in code)
            {
                if (c == '+') ++memory;
                if (c == '.') stdout += (char)memory;
            }
            return stdout;
        }
    }

    */

    /*/////////////////////////////////
    //            CODE: 2            //
    /////////////////////////////////*/

    /*/////////////////////////////////
    //           Пояснение:          //
    /////////////////////////////////*/

    /*
        Smallfuck - это зык, который ещё больше похож на машину Тьюринга

        Здесь у нас есть 2 бесконечные ленты со значениями
            
            Одна лента содержит только значения 0 или 1. Она называется tape - лента значений
            
            Другая лента может содержать один из 5 кодовых символов, в каждой ячейке. Но по мимо этого, там может быть и мусор
            Как они работают нормально расписано на сайте и в wiki, но лично я очень долго не мог понять, как же работают эти переходы с угловыми скобками
            Обясняю:

                Если интерпертатор встречает символ '[' в коде, и ячейка которую он рассматривает в ленте значений равна символу '0', то он
                идёт вперёд по строке команд, пока не встретит символ ']'. Все эти команды он пропускает, и не выполняет.

                Тоже самое с символом ']' - получается цикл обратного хода

        Ссылка на Wiki: https://esolangs.org/wiki/Smallfuck
        Ссылка идеальную реализацию алгоритма: https://github.com/RasPat1/practice-codewars/blob/master/Smallfuck.java
    */

    /*/////////////////////////////////
    //           Решение:            //
    /////////////////////////////////*/

    /*
        public class Smallfuck
        {
            
            //static void Main(string[] args) // Вот эту функцию надо убрать, она только для тестов
            //{
            //    string code = "[[]*>*>*>]";
            //    string tape = "000";
            //    string outp = Interpreter(code, tape);
            //    Console.WriteLine(outp);
            //}

            public static char invert(char c)
            {
                if (c == '0') return '1';
                else return '0';
            }

            public static int jumpPast(string codeArray, int codeIndex, char currentCell)
            // Код, который я своровал из верного примера :)
            {
                if (currentCell == '0')
                {
                    int openCount = 1;
                    while (codeIndex < codeArray.Length && (codeArray[codeIndex] != ']' || openCount != 0))
                    {
                        codeIndex++;
                        if (codeArray[codeIndex] == '[')
                        {
                            openCount++;
                        }
                        else if (codeArray[codeIndex] == ']')
                        {
                            openCount--;
                        }
                    }
                }
                return codeIndex;
            }

            public static int jumpBefore(string codeArray, int codeIndex, char currentCell)
            {
                if (currentCell == '1')
                {
                    int closeCount = 1;
                    while (codeIndex >= 0 && (codeArray[codeIndex] != '[' || closeCount != 0))
                    {
                        codeIndex--;
                        if (codeArray[codeIndex] == '[')
                        {
                            closeCount--;
                        }
                        else if (codeArray[codeIndex] == ']')
                        {
                            closeCount++;
                        }
                    }
                }
                return codeIndex;
            }

            public static string ret(char[] stringArray)
            {
                string myRet = "";
                for (int i = 0; i < stringArray.Length; i++)
                {
                    myRet += stringArray[i];
                }
                return myRet;
            }

            public static string Interpreter(string code, string tape)
            {
                int ind = 0;
                char[] stringArray = new char[tape.Length];

                for (int i = 0; i < tape.Length; i++) // Gad code
                {
                    stringArray[i] = tape[i];
                }

                for (int i = 0; i < code.Length; i++)
                {
                    if (code[i] == '*') stringArray[ind] = invert(stringArray[ind]);
                    else if (code[i] == '>')
                    {
                        if ((ind + 1) < (tape.Length)) ind++;
                        else return ret(stringArray);
                    }
                    else if (code[i] == '<')
                    {
                        if ((ind - 1) >= (0)) ind--;
                        else return ret(stringArray);
                    }
                    else if (code[i] == '[')
                    {
                        i = jumpPast(code, i, stringArray[ind]);
                        // Возвращает индекс символа кода, который мы обрабатываем, и идём дальше

                        if ((i >= code.Length) || (i < 0)) return ret(stringArray);

                    // Код, который не работает с бесконечными петлями. Я не разобрался почему
                    //if (stringArray[ind] == '0')
                    //{
                    //    Console.WriteLine("Нашли цикл продвижения вперёд, i = " + i);
                    //    for (int j = i; j < code.Length; j++)
                    //    {
                    //        if (code[j] == ']')
                    //        {
                    //            i = j;
                    //            break;
                    //        }
                    //    }
                    //    Console.WriteLine("Вышли из цикла продвижения вперёд, i = " + i);
                    //}

                }
                else if (code[i] == ']')
                {
                    i = jumpBefore(code, i, stringArray[ind]);

                    if ((i >= code.Length) || (i < 0)) return ret(stringArray);


                    //if (stringArray[ind] == '1')
                    //{
                    //    Console.WriteLine("Нашли цикл продвижения назад, i = " + i);
                    //    for (int j = i; j > 0; j--)
                    //    {
                    //        if (code[j] == '[')
                    //        {
                    //            i = j;
                    //            break;
                    //        }
                    //    }
                    //    Console.WriteLine("Вышли из цикла продвижения назад, i = " + i);
                    //}

                }

                //Console.WriteLine("Промежуточное значение, i = " + i + ", ret = " + ret(stringArray));
            }

            return ret(stringArray);
        }
    }
    */

    /*/////////////////////////////////
    //            CODE: 3            //
    /////////////////////////////////*/

    /*/////////////////////////////////
    //           Решение:            //
    /////////////////////////////////*/

    // Используйте язык Java:

    /*
    import java.util.ArrayList;
    import java.util.Arrays;
    import java.util.List;
    import java.util.Stack;
    import java.util.stream.Collectors;

    import org.junit.Test;
    import static org.junit.Assert.assertEquals;
    import org.junit.runners.JUnit4;

    // Solution
    public class Paintfuck
    {
        public static String interpreter(String code, int iterations, int width, int height)
        {
            code = code.replaceAll("[^nesw\\[\\]*]*", "");
            int[][] tapes = new int[height][width];
            List<Integer> pres = new ArrayList<>();
            Stack<Boolean> braces = new Stack<>();
            braces.push(true);
            int currX = 0;
            int currY = 0;
            for (int i = 0; i < code.length() && iterations > 0; i++, iterations--)
            {
                if (currY >= tapes.length) currY = 0;
                else if (currX >= tapes[0].length) currX = 0;
                else if (currY < 0) currY = tapes.length - 1;
                else if (currX < 0) currX = tapes[0].length - 1;
                if (code.charAt(i) == ']' || code.charAt(i) == '[')
                {
                    if (code.charAt(i) == ']')
                    {
                        braces.pop();
                        i = tapes[currY][currX] != 0 ? pres.get(braces.size() - 1) : i;
                    }
                    else
                    {
                        braces.push(tapes[currY][currX] != 0);
                        pres.add(i - 1);
                        iterations++;
                    }
                }
                else if (braces.peek())
                {
                    if (code.charAt(i) == 'e') ++currX;
                    else if (code.charAt(i) == 'w') --currX;
                    else if (code.charAt(i) == 's') ++currY;
                    else if (code.charAt(i) == 'n') --currY;
                    else if (code.charAt(i) == '*') tapes[currY][currX] ^= 1;
                }
                else iterations++;
            }
            return toTapes(tapes);
        }

        private static String toTapes(int[][] tapes)
        {
            return Arrays.stream(tapes)
                    .map(tape->Arrays.stream(tape)
                            .mapToObj(String::valueOf)
                            .collect(Collectors.joining()))
                    .collect(Collectors.joining("\r\n"));
        }
    }
    */

    // Отличный сборник программ, с многими алгоритмами на Java: https://gist.github.com/ldcc/f5d3aa8081dedb150cd5169fe6593ace

    /*/////////////////////////////////
    //            CODE: 4            //
    /////////////////////////////////*/

    /*/////////////////////////////////
    //           Решение:            //
    /////////////////////////////////*/

    // Используйте язык JavaScript:

    /*
    function boolfuck(code, input = "")
    {
        // Initialize tape (can be extended infinitely in both directions)
        var tape = [0];
        // Pointer
        var pointer = 0;
        // Convert input into corresponding bytes then into a string of bits
        var bitInput = input.split("").map(c => c.charCodeAt().toString(2)).map(b => "0".repeat(8 - b.length) + b).map(b => b.split("").reverse().join(""));
        bitInput = bitInput.join("");
        // Read bits from left to right one by one
        var bitIndex = 0;
        // Output (in terms of bits - will have to convert into character output at a later stage)
        var bitOutput = "";
        for (var i = 0; i < code.length; i++)
        {
            // Loop through each character of the Boolfuck program
            switch (code[i])
            {
                case "+":
                    // Flip the bit
                    tape[pointer] = +!tape[pointer];
                    break;
                case ",":
                    // Read one bit from the converted input into the current cell
                    tape[pointer] = bitInput[bitIndex++] === undefined ? 0 : parseInt(bitInput[bitIndex - 1]);
                    break;
                case ";":
                    // Output the bit
                    bitOutput += tape[pointer];
                    break;
                case "<":
                    // Move the pointer left by 1 bit.  Expand the tape to the left if necessary
                    pointer--;
                    if (pointer < 0)
                    {
                        tape = [0].concat(tape);
                        pointer++;
                    }
                    break;
                case ">":
                    // Move the pointer right by 1 bit.  Expand the tape to the right if necessary
                    pointer++;
                    if (pointer >= tape.length) tape.push(0);
                    break;
                case "[":
                    if (tape[pointer] === 0)
                    {
                        // Unmatched opening bracket found.  Find matching closing bracket
                        var unmatched = 1;
                        while (unmatched > 0)
                        {
                            i++;
                            if (code[i] === "[") unmatched++;
                            if (code[i] === "]") unmatched--;
                        }
                    }
                    break;
                case "]":
                    if (tape[pointer] === 1)
                    {
                        // Unmatched closing bracket found.  Find matching opening bracket
                        var unmatched = 1;
                        while (unmatched > 0)
                        {
                            i--;
                            if (code[i] === "[") unmatched--;
                            if (code[i] === "]") unmatched++;
                        }
                    }
                    break;
            }
        }
        // Separate the bit output into bytes
        var bytes = [];
        for (var i = 0; i < bitOutput.length; i++) bytes[~~(i / 8)] = bytes[~~(i / 8)] ? bytes[~~(i / 8)] + bitOutput[i] : bitOutput[i];
        bytes[bytes.length - 1] += "0".repeat(8 - bytes[bytes.length - 1].length);
        bytes = bytes.map(b => b.split("").reverse().join(""));
        // Convert bytes into characters
        var characters = bytes.map(b => String.fromCharCode(parseInt(b, 2)));
        // Convert characters into output string
        var output = characters.join("");
        return output;
    }
    */

    // Ссылка: https://github.com/DonaldKellett/Boolfuck/blob/master/js/function.boolfuck.js
}