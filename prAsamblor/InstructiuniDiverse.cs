using System;

namespace prAsamblor
{
    class InstructiuniDiverse
    {

        UInt16 instr_code;
        string nume;

        public string getName()
        {
            return this.nume;
        }
        public UInt16 getCode()
        {
            return this.instr_code;
        }
    }
}
