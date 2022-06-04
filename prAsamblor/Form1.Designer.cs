using System;
namespace prAsamblor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.asmFileTB = new System.Windows.Forms.TextBox();
            this.parsedFileTB = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.parseBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.button_showCode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // asmFileTB
            // 
            this.asmFileTB.Location = new System.Drawing.Point(12, 33);
            this.asmFileTB.Name = "asmFileTB";
            this.asmFileTB.Size = new System.Drawing.Size(259, 27);
            this.asmFileTB.TabIndex = 0;
            this.asmFileTB.Text = "Search for the ASM file...";
            // 
            // parsedFileTB
            // 
            this.parsedFileTB.Location = new System.Drawing.Point(12, 88);
            this.parsedFileTB.Multiline = true;
            this.parsedFileTB.Name = "parsedFileTB";
            this.parsedFileTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.parsedFileTB.Size = new System.Drawing.Size(243, 358);
            this.parsedFileTB.TabIndex = 1;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(293, 31);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(94, 29);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // parseBtn
            // 
            this.parseBtn.Location = new System.Drawing.Point(293, 79);
            this.parseBtn.Name = "parseBtn";
            this.parseBtn.Size = new System.Drawing.Size(94, 29);
            this.parseBtn.TabIndex = 3;
            this.parseBtn.Text = "Parse";
            this.parseBtn.UseVisualStyleBackColor = true;
            this.parseBtn.Click += new System.EventHandler(this.parseBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // button_showCode
            // 
            this.button_showCode.Location = new System.Drawing.Point(293, 169);
            this.button_showCode.Name = "button_showCode";
            this.button_showCode.Size = new System.Drawing.Size(150, 29);
            this.button_showCode.TabIndex = 5;
            this.button_showCode.Text = "Show instr code";
            this.button_showCode.UseVisualStyleBackColor = true;
            this.button_showCode.Click += new System.EventHandler(this.button_showCode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 468);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_showCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parseBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.parsedFileTB);
            this.Controls.Add(this.asmFileTB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        Instructiuni2op[] instr2_Op = new Instructiuni2op[7];
        Instructiuni1op[] instr1_Op = new Instructiuni1op[15];
        InstructiuniSalt[] instr_salt = new InstructiuniSalt[9];
        UInt16[] registri = new UInt16[16];
        public void InitialiseInfo()
        {

            
            instr2_Op[0] = new Instructiuni2op(0, "MOV");
            instr2_Op[1] = new Instructiuni2op(4096, "ADD");
            instr2_Op[2] = new Instructiuni2op(8192, "SUB");
            instr2_Op[3] = new Instructiuni2op(12288, "CMP");
            instr2_Op[4] = new Instructiuni2op(16384, "AND");
            instr2_Op[5] = new Instructiuni2op(20480, "OR");
            instr2_Op[6] = new Instructiuni2op(24576, "XOR");
           
            for (UInt16 i = 0; i < 16; i++)
                registri[i] = i;


            instr1_Op[0] = new Instructiuni1op(32768, "CLR");
            instr1_Op[1] = new Instructiuni1op(32832, "NEG");
            instr1_Op[2] = new Instructiuni1op(32896, "INC");
            instr1_Op[3] = new Instructiuni1op(32960, "DEC");
            instr1_Op[4] = new Instructiuni1op(33024, "ASL");
            instr1_Op[5] = new Instructiuni1op(33088, "ASR");
            instr1_Op[6] = new Instructiuni1op(33152, "LSR");
            instr1_Op[7] = new Instructiuni1op(33216, "ROL");
            instr1_Op[8] = new Instructiuni1op(33280, "ROR");
            instr1_Op[9] = new Instructiuni1op(33344, "RLC");
            instr1_Op[10] = new Instructiuni1op(33408, "RRC");
            instr1_Op[11] = new Instructiuni1op(33472, "JMP");
            instr1_Op[12] = new Instructiuni1op(33536, "CALL");
            instr1_Op[13] = new Instructiuni1op(33600, "PUSH");
            instr1_Op[14] = new Instructiuni1op(33664, "POP");

             
              instr_salt[0] = new InstructiuniSalt(49152, "BR");
              instr_salt[1] = new InstructiuniSalt(49408, "BNE");
              instr_salt[2] = new InstructiuniSalt(49664, "BEQ");
              instr_salt[3] = new InstructiuniSalt(49920, "BPL");
              instr_salt[4] = new InstructiuniSalt(50176, "BMI");
              instr_salt[5] = new InstructiuniSalt(50432, "BCS");
              instr_salt[6] = new InstructiuniSalt(50688, "BCC");
              instr_salt[7] = new InstructiuniSalt(50944, "BVS");
              instr_salt[8] = new InstructiuniSalt(51200, "BVC");

          /*    InstructiuniDiverse[] instr_diverse = new InstructiuniDiverse[19];
              instr_diverse[0] = new InstructiuniDiverse(0xE000, "CLC");
              instr_diverse[1] = new InstructiuniDiverse(0xE001, "CLV");
              instr_diverse[2] = new InstructiuniDiverse(0xE002, "CLZ");
              instr_diverse[3] = new InstructiuniDiverse(0xE003, "CLS");
              instr_diverse[4] = new InstructiuniDiverse(0xE004, "CCC");
              instr_diverse[5] = new InstructiuniDiverse(0xE005, "SEC");
              instr_diverse[6] = new InstructiuniDiverse(0xE006, "SEV");
              instr_diverse[7] = new InstructiuniDiverse(0xE007, "SEZ");
              instr_diverse[8] = new InstructiuniDiverse(0xE008, "SES");
              instr_diverse[9] = new InstructiuniDiverse(0xE009, "SCC");
              instr_diverse[10] = new InstructiuniDiverse(0xE00A, "NOP");
              instr_diverse[11] = new InstructiuniDiverse(0xE00B, "RET");
              instr_diverse[12] = new InstructiuniDiverse(0xE00C, "RETI");
              instr_diverse[13] = new InstructiuniDiverse(0xE00D, "HALT");
              instr_diverse[14] = new InstructiuniDiverse(0xE00E, "WAIT");
              instr_diverse[15] = new InstructiuniDiverse(0xE00F, "PUSHPC");
              instr_diverse[16] = new InstructiuniDiverse(0xE010, "POPPC");
              instr_diverse[17] = new InstructiuniDiverse(0xE011, "PUSHF");
              instr_diverse[18] = new InstructiuniDiverse(0xE012, "POPF");  */





            //plan: luam primul cuvant din vectorul parsat, vedem ce instructiune e din vectorul instr2_Op, cream un nou obiect de tip Instructiuni 
            //pentru instructiunea respectiva( de ex instructiune1), cititm mai departe vin vectorul parsat si vedem ce mod de adresare/registri sunt si in functie de asta
            //modificam campul Code din instructiune1( prin shiftare si operatii de si/sau/xor etc)

            //pt fiecare tip de instr o sa avem alt vector( ex : instr1_Op)

        }
        #endregion

        private System.Windows.Forms.TextBox asmFileTB;
        private System.Windows.Forms.TextBox parsedFileTB;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button parseBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_showCode;
        private System.Windows.Forms.Label label2;
    }
}

