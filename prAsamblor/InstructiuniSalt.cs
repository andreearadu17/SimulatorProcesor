using System;

namespace prAsamblor
{
    class InstructiuniSalt
    {
        UInt16 instr_code;
        string nume;
        public InstructiuniSalt(UInt16 Code, string Nume)
        {
            this.instr_code = Code;
            this.nume = Nume;
        }
        public string getName()
        {
            return this.nume;
        }
        public UInt16 getCode()
        {
            return this.instr_code;
        }
        public void setOFFSET(UInt16 offset)
        {
            this.instr_code |= Convert.ToUInt16(offset);
        }
    }
}
