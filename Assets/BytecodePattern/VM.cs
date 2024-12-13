using System.Collections.Generic;
using UnityEngine;

namespace BytecodePattern
{
    public class VM
    {
        private GameController gameController;
        private Stack<int> stackMachine = new(); //Will store values for later use in the switch statement
        private const int MAX_STACK = 128; //The max size of the stack

        public VM(GameController gameController)
        {
            this.gameController = gameController;
        }

        public void Interpret(int[] bytecode)
        {
            stackMachine.Clear();

            // Read and execute the instructions
            for (var i = 0; i < bytecode.Length; i++)
            {
                // Convert from int to enum
                var instruction = (Instruction)bytecode[i];

                switch (instruction)
                {
                    case Instruction.INST_SET_HEALTH:
                    {
                        int amount = Pop();
                        int wizard = Pop();
                        gameController.SetHealth(wizard, amount);
                        break;
                    }
                    case Instruction.INST_SET_WISDOM:
                    {
                        int amount = Pop();
                        int wizard = Pop();
                        gameController.SetWisdom(wizard, amount);
                        break;
                    }
                    case Instruction.INST_SET_AGILITY:
                    {
                        int amount = Pop();
                        int wizard = Pop();
                        gameController.SetAgility(wizard, amount);
                        break;
                    }
                    case Instruction.INST_LITERAL:
                    {
                        Push(bytecode[++i]);
                        break;
                    }
                    case Instruction.INST_GET_HEALTH:
                    {
                        int wizard = Pop();
                        Push(gameController.GetHealth(wizard));
                        break;
                    }
                    case Instruction.INST_GET_WISDOM:
                    {
                        int wizard = Pop();
                        Push(gameController.GetWisdom(wizard));
                        break;
                    }
                    case Instruction.INST_GET_AGILITY:
                    {
                        int wizard = Pop();
                        Push(gameController.GetAgility(wizard));
                        break;
                    }
                    case Instruction.INST_ADD:
                    {
                        int b = Pop();
                        int a = Pop();
                        Push(a + b);
                        break;
                    }
                    case Instruction.INST_SUBTRACT:
                    {
                        int b = Pop();
                        int a = Pop();
                        Push(a - b);
                        break;
                    }
                    case Instruction.INST_MULTIPLY:
                    {
                        int b = Pop();
                        int a = Pop();
                        Push(a * b);
                        break;
                    }
                    case Instruction.INST_DIVIDE:
                    {
                        int b = Pop();
                        int a = Pop();
                        if (b != 0)
                        {
                            Push(a / b);
                        }
                        else
                        {
                            Debug.LogError("Division by zero error");
                        }

                        break;
                    }
                    case Instruction.INST_MODULO:
                    {
                        int b = Pop();
                        int a = Pop();
                        if (b != 0)
                        {
                            Push(a % b);
                        }
                        else
                        {
                            Debug.LogError("Modulo by zero error");
                        }

                        break;
                    }
                    default:
                    {
                        Debug.Log($"The VM couldn't find the instruction {instruction} :(");
                        break;
                    }
                }
            }
        }


        private int Pop()
        {
            if (stackMachine.Count == 0)
            {
                Debug.LogError("The stack is empty :(");
            }

            return stackMachine.Pop();
        }

        private void Push(int number)
        {
            //检查栈溢出，有人制作一个试图破坏你的游戏的模组时很有用
            if (stackMachine.Count + 1 > MAX_STACK)
            {
                Debug.LogError("Stack overflow is not just a place where you copy and paste code!");
            }

            stackMachine.Push(number);
        }
    }
}