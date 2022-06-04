using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace prAsamblor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialiseInfo();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        List<String> asmElements = new List<String>();
        private void parseBtn_Click(object sender, EventArgs e)
        {
            TextFieldParser parser = new TextFieldParser(asmFileTB.Text);
            String[] delimiters = { ":", ",", " ", "(", ")", " " };
            parser.SetDelimiters(delimiters);
            parser.TextFieldType = FieldType.Delimited;
            while (!parser.EndOfData)
            {
                /* Read an entire line in ASM file
                   and split this line in many strings delimited by delimiters */
                string[] asmFields = parser.ReadFields();
                /* Store each string as a single element in the list
                   if this string is not empty */
                foreach (string s in asmFields)
                {
                    if (!s.Equals(""))
                    {
                        asmElements.Add(s);
                    }
                }
            }
            parser.Close();
            foreach (String s in asmElements)
            {
                parsedFileTB.Text += s + Environment.NewLine;
            }
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open ASM File";
            theDialog.Filter = "ASM files(*.asm)|*.asm";
            theDialog.InitialDirectory = "..\\Debug";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                // MessageBox.Show(theDialog.FileName.ToString());
                asmFileTB.Text = theDialog.FileName.ToString();
            }
        }
        Instructiuni2op[] instr = new Instructiuni2op[100];
        Instructiuni1op[] instr1Op = new Instructiuni1op[100];
        bool e_numar(string sir, int i)
        {
            String substr = sir.Substring(0, i);
            return int.TryParse(substr, out _) ? true : false;
        }
        int e_numar(string sir, int limita_inf, int lung)
        {
            String substr = sir.Substring(limita_inf, lung);
            return int.TryParse(substr, out int n) ? n : 0;
        }
        string get_register(bool indexata, string s)
        {
            string substr;
            switch (indexata)
            {
                case true:
                    if (e_numar(s, s.Length - 3, 2) != 0)
                        substr = "r" + Convert.ToString(e_numar(s, s.Length - 3, 2));
                    else
                        substr = s.Substring(s.Length - 3, 2);//substr contine numele registrului ,ex r2
                    break;
                case false:
                    if (e_numar(s, s.Length - 3, 2) != 0)
                        substr = "r" + Convert.ToString(e_numar(s, s.Length - 3, 2));
                    else
                        substr = s.Substring(s.Length - 3, 2);//substr contine numele registrului ,ex r2
                    break;
            }
            return substr;
        }
        void set_register_indir_index(String substr, bool indexata, String tip_registru, int contor)
        {
            foreach (var R in registri)
            {
                if (substr == "r" + Convert.ToString(R))
                    if (indexata is true)
                    {
                        if (tip_registru == "destinatie")
                            instr[contor].setRD(R);
                        else instr[contor].setRS(R);
                        break;
                    }
                    else
                    {
                        if (tip_registru == "destinatie")
                        {
                            instr[contor].setMAD(2);//indirect
                            instr[contor].setRD(R);
                        }
                        else
                        {
                            instr[contor].setMAS(2);//indirect
                            instr[contor].setRS(R);
                        }
                        break;
                    }
            }
        }
        private bool instrCurenta = false;
        char tipInstr;
        void create_codeINSTRUCTION()
        {
            int contor = -1;
            int etapa_instructiune = -1;
            foreach (String s in asmElements)
            {
                etapa_instructiune++;
                while (instrCurenta == false && etapa_instructiune == 0)
                {
                    foreach (var s2 in instr1_Op)
                    {
                        if (s == s2.getName())
                        {
                            contor++;
                            instr1Op[contor] = new Instructiuni1op(s2.getCode(), s2.getName());
                            instrCurenta = true;
                            tipInstr = 'B';
                            etapa_instructiune = 0;
                            break;
                        }
                    }
                    foreach (var s2 in instr2_Op)
                    {
                        if (s == s2.getName())
                        {
                            contor++;
                            instr[contor] = new Instructiuni2op(s2.getCode(), s2.getName());
                            instrCurenta = true;
                            tipInstr = 'A';
                            etapa_instructiune = 0;
                            break;
                        }
                    }
                }
                switch (tipInstr)
                {
                    case 'A':
                        {
                            if (etapa_instructiune == 1)//setam codul pentru primul operand+ mod de adresare
                            {
                                bool indexata = false;
                                int i = s.Length;
                                if (e_numar(s, s.Length) is true)// daca tot stringul e un numar, atunci e indexare imediata
                                    instr[contor].setMAD(0);//imediata
                                else
                                if (s.Length > 2)//daca stringul are mai mult de 2 litere atunci clar e vorba de adresare indexata sau indirecta
                                {
                                    while (i >= 0)
                                    {
                                        if (e_numar(s, i) is true)//daca in string se gaseste un numar(la inceput), atunci adresarea e indexata
                                        {
                                            instr[contor].setMAD(3);//indexat
                                            indexata = true;
                                            break;
                                        }
                                        i--;
                                    }
                                    string substr = get_register(indexata, s);
                                    set_register_indir_index(substr, indexata, "destinatie", contor);
                                }
                                else//mai ramane adr directa
                                {
                                    instr[contor].setMAD(1);//directa
                                    if (s.Length == 3)
                                        instr[contor].setRD(Convert.ToUInt16(s.Substring(s.Length - 2, 2)));
                                    else
                                        instr[contor].setRD(Convert.ToUInt16(s.Substring(s.Length - 1, 1)));
                                }
                            }
                            if (etapa_instructiune == 2)//setam codul pentru al 2-lea operand+ mod de adresare
                            {
                                bool indexata = false;
                                int i = s.Length;
                                if (e_numar(s, s.Length) is true)
                                    instr[contor].setMAS(0);//imediata
                                else
                                if (s.Length > 2)
                                {
                                    while (i >= 0)
                                    {
                                        if (e_numar(s, i) is true)
                                        {
                                            instr[contor].setMAS(3);//indexat
                                            indexata = true;
                                            break;
                                        }
                                        i--;
                                    }
                                    string substr = get_register(indexata, s);
                                    set_register_indir_index(substr, indexata, "sursa", contor);
                                }
                                else
                                {
                                    instr[contor].setMAS(1);//directa
                                    if (s.Length == 3)
                                        instr[contor].setRS(Convert.ToUInt16(s.Substring(s.Length - 2, 2)));
                                    else
                                        instr[contor].setRS(Convert.ToUInt16(s.Substring(s.Length - 1, 1)));
                                }
                                instrCurenta = false;
                                etapa_instructiune = -1;
                            }
                            break;
                        }
                    case 'B':
                        {
                            if (etapa_instructiune == 1)
                            {
                                int indirecta = s.IndexOf('[');
                                if (indirecta == 0)             //adica '[' primul caracter
                                {
                                    instr1Op[contor].setMAD(2); //indirect
                                }
                                else if (indirecta != -1)         //'[' exista, dar nu e primul caracter => MA indexat
                                {
                                    instr1Op[contor].setMAD(3); //indexata
                                }
                                else if (indirecta == -1)        //'[' nu exista 
                                {
                                    instr1Op[contor].setMAD(1); //directa
                                }

                                int indexReg= s.IndexOf('r');
                                string aux = s.Substring(indexReg);
                                for (UInt16 r = 15; r >= 0; r--)
                                {
                                    String rr = r.ToString();
                                    if (aux.Contains(rr))
                                    {
                                        instr1Op[contor].setRD(r);  //registrul
                                        break;
                                    }
                                }
                                etapa_instructiune = -1;
                                instrCurenta = false;
                            }
                            break;
                        }
                }
            }
        }
        private void button_showCode_Click(object sender, EventArgs e)
        {
            create_codeINSTRUCTION();
            label1.Text = Convert.ToString(instr[0].getCode(), 2).PadLeft(16, '0').ToString();
            label2.Text = Convert.ToString(instr1Op[1].getCode(), 2).PadLeft(16, '0').ToString();
        }
    }
}
