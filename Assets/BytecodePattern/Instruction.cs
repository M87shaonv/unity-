namespace BytecodePattern
{
    // 编程语言中可以选择的指令
    public enum Instruction
    {
        //Write stats
        INST_SET_HEALTH,
        INST_SET_WISDOM,
        INST_SET_AGILITY,

        //字面量
        INST_LITERAL,

        //Read stats
        INST_GET_HEALTH,
        INST_GET_WISDOM,
        INST_GET_AGILITY,

        //Arithmetic
        INST_ADD,
        INST_SUBTRACT,
        INST_MULTIPLY,
        INST_DIVIDE,
        INST_MODULO,
    }
}