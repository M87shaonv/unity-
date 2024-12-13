using System.Collections.Generic;
using UnityEngine;

namespace BytecodePattern
{
    public class Wizard
    {
        public int Health { get; set; } = 0;
        public int Wisdom { get; set; } = 0;
        public int Agility { get; set; } = 0;
    }

    public class GameController : MonoBehaviour
    {
        private Dictionary<int, Wizard> wizards = new();

        private void Start()
        {
            wizards.Add(0, new Wizard());
            wizards.Add(1, new Wizard());


            var bytecode = new[] {
                (int)Instruction.INST_LITERAL, 0, // 加载索引 0 到栈顶
                (int)Instruction.INST_LITERAL, 75, // 加载常量值 75 到栈顶
                (int)Instruction.INST_SET_HEALTH, // 设置健康值
                (int)Instruction.INST_LITERAL, 1, // 加载索引 1 到栈顶
                (int)Instruction.INST_LITERAL, 50, // 加载常量值 50 到栈顶
                (int)Instruction.INST_SET_WISDOM, // 设置智慧值
                (int)Instruction.INST_LITERAL, 1, // 加载索引 1 到栈顶
                (int)Instruction.INST_LITERAL, 60, // 加载常量值 60 到栈顶
                (int)Instruction.INST_SET_AGILITY, // 设置敏捷值
                (int)Instruction.INST_LITERAL, 0, // 加载索引 0 到栈顶
                (int)Instruction.INST_GET_HEALTH, // 获取健康值并推送到栈顶
                (int)Instruction.INST_LITERAL, 5, // 加载常量值 5 到栈顶
                (int)Instruction.INST_ADD, // 执行加法操作
            };

            var vm = new VM(this);

            vm.Interpret(bytecode);
        }

        public void SetHealth(int wizardID, int amount)
        {
            wizards[wizardID].Health = amount;
            Debug.Log($"Wizard {wizardID} sets health {amount}");
        }

        public void SetWisdom(int wizardID, int amount)
        {
            wizards[wizardID].Wisdom = amount;
            Debug.Log($"Wizard {wizardID} sets wisdom {amount}");
        }

        public void SetAgility(int wizardID, int amount)
        {
            wizards[wizardID].Agility = amount;
            Debug.Log($"Wizard {wizardID} sets agility {amount}");
        }


        public int GetHealth(int wizardID)
        {
            Debug.Log($"Wizard {wizardID} has health {wizards[wizardID].Health}");
            return wizards[wizardID].Health;
        }

        public int GetWisdom(int wizardID)
        {
            Debug.Log($"Wizard {wizardID} has wisdom {wizards[wizardID].Wisdom}");
            return wizards[wizardID].Wisdom;
        }

        public int GetAgility(int wizardID)
        {
            Debug.Log($"Wizard {wizardID} has agility {wizards[wizardID].Agility}");
            return wizards[wizardID].Agility;
        }
    }
}