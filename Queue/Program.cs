﻿using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 


namespace Queue {
    class MyQueue {
        int[] x;
        int FrontPointer, RearPointer;

        public MyQueue(int Length) {
            x = new int[Length];
            FrontPointer = -1;
            RearPointer = 0;
        }

       private bool IsFull() {return (RearPointer == x.Length);}

        private bool IsEmpty() {return Math.Abs(FrontPointer - RearPointer) == 1;}

        public void DeQueue() {
            if (IsEmpty()) {
                throw new Exception("Queue is empty");
            }
            FrontPointer++;
            x[FrontPointer] = 0;
        }

        public void EnQueue(int n) {
            if (IsFull()) {
                throw new Exception("Queue is full");
            }
            x[RearPointer] = n;
            RearPointer++;
        }

        public int[] GetList() {
            int size = Math.Abs(FrontPointer - RearPointer) - 1;
            int[] returned = new int[size];
            for (int i = FrontPointer + 1; i < RearPointer; i++) {
                returned[i - FrontPointer - 1] = x[i];
            }
            return returned;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How big do you want the queue to be? ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] list;

            MyQueue n = new MyQueue(size);
            list = n.GetList();
            foreach (int i in list) {
                Console.Write($"{i}, ");
            }

            while (true) {
                Console.WriteLine("\nWhat do you want to do? ");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "ENQUEUE") {
                    Console.WriteLine("Enter a number: ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    try {
                        n.EnQueue(x);
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                } else if (answer == "DEQUEUE") {
                    try {
                        n.DeQueue();
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);
                    }
                }

                list = n.GetList();
                foreach (int i in list) {
                    Console.Write($"{i}, ");
                }
            }

        }
    }

}