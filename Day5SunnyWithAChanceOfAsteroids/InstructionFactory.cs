using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5SunnyWithAChanceOfAsteroids
{
    public static class InstructionFactory
    {
        private const int AdditionInstructionCode = 1;
        private const int MultiplicationInstructionCode = 2;
        private const int InputInstructionCode = 3;
        private const int OutputInstructionCode = 4;
        private const int JumpIfTrueInstructionCode = 5;
        private const int JumpIfFalseInstruction = 6;
        private const int LessThanInstruction = 7;
        private const int EqualsInstruction = 8;
        private const int BreakInstructionCode = 99;

        private static readonly Dictionary<int, Func<int, int, int>> OperationFuncs = new Dictionary<int, Func<int, int, int>>
        {
            {AdditionInstructionCode, (firstOperand, secondOperand) => firstOperand + secondOperand}, //addition
            {MultiplicationInstructionCode, (firstOperand, secondOperand) => firstOperand * secondOperand} //multiplication
        };

        private const int PositionMode = 0;
        private const int ImmediateMode = 1;

        private static readonly Dictionary<int, Func<Memory, int, int>> FetchOperandFuncs = new Dictionary<int, Func<Memory, int, int>>
        {
            {PositionMode, (memory, address) => memory.GetCellAt(address)},
            {ImmediateMode, (memory, value) => value}
        };

        private static readonly Dictionary<int, Action<Memory, int, int>> SaveResultFuncs = new Dictionary<int, Action<Memory, int, int>>
        {
            {PositionMode, (memory, address, data) => memory.SetCellAt(address, data)} //memory direct
        };

        public static IInstruction CreateInstruction(Memory memory)
        {
            int firstByte = memory.GetNextByte();
            int[] firstByteDigits = firstByte.ToString().PadLeft(5, '0').Select(c => int.Parse(c.ToString())).ToArray();
            int instructionCode = firstByteDigits[3] * 10 + firstByteDigits[4];

            if (instructionCode == BreakInstructionCode)
                return new BreakInstruction();

            int secondByte = memory.GetNextByte();
            if (instructionCode == InputInstructionCode)
                return new InputInstruction(memory, secondByte);
            if (instructionCode == OutputInstructionCode)
                return new OutputInstruction(memory, secondByte);

            int firstOperand = FetchOperandFuncs[firstByteDigits[2]](memory, secondByte);

            int thirdByte = memory.GetNextByte();
            int secondOperand = FetchOperandFuncs[firstByteDigits[1]](memory, thirdByte);

            if (instructionCode == JumpIfTrueInstructionCode)
                return new JumpIfTrueInstruction(memory, firstOperand, secondOperand);
            if (instructionCode == JumpIfFalseInstruction)
                return new JumpIfFalseInstruction(memory, firstOperand, secondOperand);

            int fourthByte = memory.GetNextByte();
            int thirdOperand = fourthByte;

            if(instructionCode == LessThanInstruction)
                return new LessThanInstruction(memory, firstOperand, secondOperand, thirdOperand);

            if (instructionCode == EqualsInstruction)
                return new EqualsInstruction(memory, firstOperand, secondOperand, thirdOperand);

            if (OperationFuncs.ContainsKey(instructionCode))
            {
                return new FourByteInstruction(memory, firstOperand, secondOperand, thirdOperand, SaveResultFuncs[firstByteDigits[0]], OperationFuncs[instructionCode]);
            }

            throw new Exception("unknown instruction code");
        }
    }
}