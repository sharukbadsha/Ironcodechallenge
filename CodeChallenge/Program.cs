using System;
using System.Reflection;


#region if the user key in the input 
//Console.WriteLine("Start typing (Press '#' to finish and show result):");

//string result = "";
//while (true)
//{
//    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true); // Read key without displaying it automatically
//    char keyChar = keyInfo.KeyChar;

//    // Stop input when '#' is pressed
//    if (keyChar == '#')
//        break;

//    // Allow only numbers (0-9) and special characters
//    if (char.IsDigit(keyChar) || (keyChar == ' ' || keyChar == '&' || keyChar == '\'' || keyChar == '(' || keyChar == '*'))
//    {
//        Console.Write(keyChar); // Display allowed character
//        result += keyChar;      // Store input
//    }
//}
//Console.WriteLine("\nActual Input: " + result);
//string outPut = OldPhonePad(result);
//Console.WriteLine("\nFinal output: " + outPut);
//Console.ReadKey();
#endregion

#region Hardcoded values print 
string testCase1 = "33#";
Console.WriteLine("\nActual Input: " + testCase1);
string outPut1 = OldPhonePad(testCase1);
Console.WriteLine("\nFinal output: " + outPut1);

string testCase2 = "227*#";
Console.WriteLine("\nActual Input: " + testCase2);
string outPut2 = OldPhonePad(testCase2);
Console.WriteLine("\nFinal output: " + outPut2);

string testCase3 = "4433555 555666#";
Console.WriteLine("\nActual Input: " + testCase3);
string outPut3 = OldPhonePad(testCase3);
Console.WriteLine("\nFinal output: " + outPut3);

string testCase4 = "8 88777444666*664#";
Console.WriteLine("\nActual Input: " + testCase4);
string outPut4 = OldPhonePad(testCase4);
Console.WriteLine("\nFinal output: " + outPut4);
Console.ReadKey();
#endregion

#region main program
string OldPhonePad(string input)
{
    try
    {
        //defining object for input
        string actualInput = string.Empty;
        //finding the lenght of the input
        int inputLength = input.Length;
        //Checking the value empty or not
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }
        //checking input value containes # 
        if (input[input.Length - 1] == '#')
        {
            //removing the # value from the input
            actualInput = input.Substring(0, input.Length - 1);
        }
        else
        {
            actualInput = input;
        }
        List<char> outputValue = new List<char>();
        char? currentChar = null;
        int currentCount = 0;
        // As per the old mobile formate, defining the key pad values to object list
        Dictionary<char, string> keypad = new Dictionary<char, string>
        {
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"}
        };

        try
        {
            //checking each charecter
            foreach (char digit in actualInput)
            {
                //checking the charecter numaric or not
                if (char.IsDigit(digit))
                {
                    if (currentChar == null)
                    {
                        currentChar = digit;
                        currentCount = 1;
                    }
                    else if (currentChar == digit)
                    {
                        currentCount++;
                    }
                    else
                    {
                        //finding the charecter exist in the object list or not and selecting the latters
                        if (keypad.TryGetValue((char)currentChar, out string letters))
                        {
                            //finding the index of the current charecter from the length of the selected charecter
                            int index = (currentCount - 1) % letters.Length;
                            //finding the value of the selected charecter
                            outputValue.Add(letters[index]);
                        }
                        currentChar = digit;
                        currentCount = 1;
                    }
                }
                else
                {
                    if (currentChar != null)
                    {
                        //finding the charecter exist in the object list or not and selecting the latters
                        if (keypad.TryGetValue((char)currentChar, out string letters))
                        {
                            //finding the index of the current charecter from the length of the selected charecter
                            int index = (currentCount - 1) % letters.Length;
                            //finding the value of the selected charecter
                            outputValue.Add(letters[index]);
                        }
                        currentChar = null;
                        currentCount = 0;
                    }
                    if (digit == '*')
                    {
                        if (outputValue.Count > 0)
                        {
                            outputValue.RemoveAt(outputValue.Count - 1);
                        }
                    }
                }


            }
            if (currentChar != null)
            {
                //finding the charecter exist in the object list or not and selecting the latters
                if (keypad.TryGetValue((char)currentChar, out string letters))
                {
                    //finding the index of the current charecter from the length of the selected charecter
                    int index = (currentCount - 1) % letters.Length;
                    //finding the value of the selected charecter
                    outputValue.Add(letters[index]);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "Something went wrong: " + ex.Message;
        }

        return new string(outputValue.ToArray());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return "Something went wrong: " + ex.Message;
    }

}
#endregion


