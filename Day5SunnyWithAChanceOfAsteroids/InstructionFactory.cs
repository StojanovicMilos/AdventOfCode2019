using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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
        private const int AdjustRelativeBaseInstruction = 9;
        private const int BreakInstructionCode = 99;

        private static readonly Dictionary<int, Func<BigInteger, BigInteger, BigInteger>> OperationFuncs = new Dictionary<int, Func<BigInteger, BigInteger, BigInteger>>
        {
            {AdditionInstructionCode, (firstOperand, secondOperand) => firstOperand + secondOperand}, //addition
            {MultiplicationInstructionCode, (firstOperand, secondOperand) => firstOperand * secondOperand} //multiplication
        };

        private const int PositionMode = 0;
        private const int ImmediateMode = 1;
        private const int RelativeMode = 2;

        private static readonly Dictionary<int, Func<Memory, BigInteger, BigInteger>> FetchOperandFuncs = new Dictionary<int, Func<Memory, BigInteger, BigInteger>>
        {
            {PositionMode, (memory, address) => memory.GetCellAt(address)},
            {ImmediateMode, (memory, value) => value},
            {RelativeMode, (memory, relativeAddress) => memory.GetCellAtRelative(relativeAddress)}
        };

        private static readonly Dictionary<int, Action<Memory, BigInteger, BigInteger>> SaveResultFuncs = new Dictionary<int, Action<Memory, BigInteger, BigInteger>>
        {
            {PositionMode, (memory, address, data) => memory.SetCellAt(address, data)},
            {RelativeMode, (memory, relativeAddress, data) => memory.SetCellAtRelative(relativeAddress, data) }
        };

        public static IInstruction CreateInstruction(Memory memory)
        {
            BigInteger firstByte = memory.GetNextByte();
            int[] firstByteDigits = firstByte.ToString().PadLeft(5, '0').Select(c => int.Parse(c.ToString())).ToArray();
            int instructionCode = firstByteDigits[3] * 10 + firstByteDigits[4];

            if (instructionCode == BreakInstructionCode)
                return new BreakInstruction();

            BigInteger secondByte = memory.GetNextByte();
            BigInteger firstOperand = FetchOperandFuncs[firstByteDigits[2]](memory, secondByte);
            if (instructionCode == InputInstructionCode)
                return new InputInstruction(memory, secondByte, SaveResultFuncs[firstByteDigits[2]]);
            if (instructionCode == OutputInstructionCode)
                return new OutputInstruction(firstOperand);
            if (instructionCode == AdjustRelativeBaseInstruction)
                return new AdjustRelativeBaseInstruction(memory, firstOperand);
            
            BigInteger thirdByte = memory.GetNextByte();
            BigInteger secondOperand = FetchOperandFuncs[firstByteDigits[1]](memory, thirdByte);

            if (instructionCode == JumpIfTrueInstructionCode)
                return new JumpIfTrueInstruction(memory, firstOperand, secondOperand);
            if (instructionCode == JumpIfFalseInstruction)
                return new JumpIfFalseInstruction(memory, firstOperand, secondOperand);

            BigInteger fourthByte = memory.GetNextByte();

            if (instructionCode == LessThanInstruction)
                return new LessThanInstruction(memory, firstOperand, secondOperand, fourthByte, SaveResultFuncs[firstByteDigits[0]]);

            if (instructionCode == EqualsInstruction)
                return new EqualsInstruction(memory, firstOperand, secondOperand, fourthByte, SaveResultFuncs[firstByteDigits[0]]);

            if (OperationFuncs.ContainsKey(instructionCode))
            {
                return new FourByteInstruction(memory, firstOperand, secondOperand, fourthByte, SaveResultFuncs[firstByteDigits[0]], OperationFuncs[instructionCode]);
            }

            throw new Exception("unknown instruction code");
        }
    }
}