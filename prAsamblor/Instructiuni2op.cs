using System;


namespace prAsamblor
{

    class Instructiuni2op
    {
        UInt16 instr_code;
        string nume;

        public Instructiuni2op(UInt16 Code, string Nume)
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
        public void setMAS(UInt16 cod)
        {
            int shiftCode = cod << 10;
            this.instr_code |= Convert.ToUInt16(shiftCode);
        }
        public void setMAD(UInt16 cod)
        {
            int shiftCode = cod << 4;
            this.instr_code |= Convert.ToUInt16(shiftCode);
        }
        public void setRS(UInt16 sourceReg)
        {
            int shiftReg = sourceReg << 6;
            this.instr_code |= Convert.ToUInt16(shiftReg);
        }
        public void setRD(UInt16 destReg)
        {
            this.instr_code |= Convert.ToUInt16(destReg);
        }
    }
}
