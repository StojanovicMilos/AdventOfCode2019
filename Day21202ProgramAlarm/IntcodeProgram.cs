using System;

namespace Day21202ProgramAlarm
{

    public class Instructions
    {
        private const int InstructionSize = 4;
        private readonly Memory _memory;

        public Instructions(Memory memory)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        public void Execute()
        {
            for (int i = 0; i < _memory.Size - 1; i += InstructionSize)
            {
                var nextInstruction = new Instruction(_memory.GetInstructionStartingAt(i, InstructionSize), _memory);
                if (nextInstruction.IsBreakInstruction)
                    return;
                nextInstruction.Execute();
            }
        }
    }

    public class Instruction
    {
        private readonly int _instructionCode;
        private readonly int _firstOperandAddress;
        private readonly int _secondOperandAddress;
        private readonly int _resultAddress;
        private readonly Memory _memory;

        public Instruction(int[] code, Memory memory)
        {
            if (code == null) throw new ArgumentNullException(nameof(code));
            if (code.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(code));
            _instructionCode = code[0];
            if (!IsBreakInstruction)
            {
                _firstOperandAddress = code[1];
                _secondOperandAddress = code[2];
                _resultAddress = code[3];
            }

            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        public void Execute()
        {
            switch (_instructionCode)
            {
                case 1:
                    _memory.SetCellAt(_resultAddress, _memory.GetCellAt(_firstOperandAddress) + _memory.GetCellAt(_secondOperandAddress));
                    break;
                case 2:
                    _memory.SetCellAt(_resultAddress, _memory.GetCellAt(_firstOperandAddress) * _memory.GetCellAt(_secondOperandAddress));
                    break;
                default:
                    throw new Exception("provided instruction code isn't supported");
            }
        }

        public bool IsBreakInstruction => _instructionCode == 99;
    }
}

