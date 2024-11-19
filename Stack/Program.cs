using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

namespace stack_datatype 
{ 
    internal class Program 
    {

        // Reserve 0xFFFFFFF as an invalid input, so user can still add 0 to the stack.
        public const int invalidValue = 0xFFFFFFF;


        /*
            Stack logic
            Methods: 
              -- IsEmpty -> Checks if stack is empty
              -- IsFull -> Checks if stack is full
              -- Push -> Appends a new value to the stack
              -- Pop -> Removes last value from the stack
              -- Peek -> Returns the last element in the stack
        */
        static bool IsEmpty(int TopStack) { 
            return TopStack == 0; 
        }

        static bool IsFull(int[] Stack, int TopStack) {  
            return Stack.Length == TopStack; 
        }

        static void Push(int Value, int[] Stack, int TopStack) { 
            if (!IsFull(Stack, TopStack)) { 
                Stack[TopStack] = Value;
            } else { 
                throw new Exception("Stack is full. Cannot append new elements"); 
            } 
        }

        static void Pop(int[] Stack, int TopStack) { 
            if (!IsEmpty(TopStack)) {
                Stack[TopStack-1] = invalidValue; 
            } else {
                throw new Exception("Stack is empty. Cannot pop last last element.");
            }
        }

        static int Peek(int[] Stack, int TopStack) { 
            if (IsEmpty(TopStack)) { 
                throw new Exception("Stack is empty. Cannot peek last last element.");
            } 
            return Stack[TopStack-1]; 
        }


        /* 
            Miscellaneous functions
            Methods:
              -- PrintArray -> Prints all integers in the stack, excluding the reserved invalidValue
              -- PopulateArray -> Replaces all 0s in int[] array with a value
              -- ValidInt -> Checks if a string is all digits
        */

        static void PrintArray(int[] Array) { 
            Console.Write("{ ");
            for (int i = 0; i < Array.Length; i++) {
                if (Array[i] == invalidValue) {
                    continue;
                }
                Console.Write($"{Array[i]}"); 
                if (Array.Length - 1 > i && Array[i+1] != invalidValue) {
                    Console.Write(", ");
                }
            }
            Console.Write(" } \n");
        }

        static void PopulateArray(int[] Array, int Value) {
            for (int i = 0; i < Array.Length; i++) {
                Array[i] = Value;
            }
        }

        static bool ValidInt(string s) {
            foreach (char c in s) {
                if (!"0123456789".Contains(c))
                    return false;
            }
            return true;
        }

        static void Main() 
        {
            int[] stack = new int[4]; 
            PopulateArray(stack, invalidValue);
            int topStack = 0;
            string[] PossibleAnswers = { "PUSH", "POP", "PEEK" }; 

            while (true) { 
                Console.WriteLine("What do you want to do? (push, pop, peek)"); 
                string answer = Console.ReadLine().ToUpper(); 

                if (!PossibleAnswers.Contains(answer)) { 
                    Console.WriteLine("Invalid response. Try again."); 
                    continue; 
                } 

                if (answer == "PUSH")
                {
                    Console.WriteLine("What value do you want to push? "); 
                    string input = Console.ReadLine();
                    if (!ValidInt(input)) {
                        Console.WriteLine("Invalid number. Must only have digits 0-9");
                        continue;
                    }
                    int value = 0;
                    try {
                        value = Convert.ToInt32(input); 
                    } catch (System.OverflowException e) {
                        Console.WriteLine("Number cannot be represented in 32 bits");
                        continue;
                    }

                    try { 
                        Push(value, stack, topStack); 
                    } catch { 
                        Console.WriteLine("Could not add more elements to the list."); 
                        continue; 
                    }

                    Console.WriteLine("Successfully added to stack."); 
                    PrintArray(stack); 
                    topStack++; 
                } else if (answer == "PEEK") { 
                    try {
                        Console.WriteLine(Peek(stack, topStack)); 
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                } else if (answer == "POP") { 
                    try {
                        Pop(stack, topStack); 
                    } catch (Exception e) {
                        Console.WriteLine($"{e.Message}");                        
                        continue;
                    }
                    Console.WriteLine("Successfully removed last value"); 
                    PrintArray(stack); 
                    topStack--; 
                } 
            } 
        } 
    } 
}