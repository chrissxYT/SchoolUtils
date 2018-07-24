using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolUtils
{
    partial class Form1
    {
        IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        void InitializeComponent()
        {
            this.source = new System.Windows.Forms.TextBox();
            this.dest = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.Location = new System.Drawing.Point(12, 12);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(639, 20);
            this.source.TabIndex = 5;
            this.source.Text = "src";
            // 
            // dest
            // 
            this.dest.Location = new System.Drawing.Point(657, 12);
            this.dest.Name = "dest";
            this.dest.Size = new System.Drawing.Size(588, 20);
            this.dest.TabIndex = 6;
            this.dest.Text = "dest";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(965, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 290);
            this.listBox1.TabIndex = 7;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 38);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(342, 27);
            this.button6.TabIndex = 8;
            this.button6.Text = "cmd";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.cmd);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 71);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(342, 27);
            this.button7.TabIndex = 9;
            this.button7.Text = "7-zip";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.sevenzip);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 104);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(342, 27);
            this.button8.TabIndex = 10;
            this.button8.Text = "access program";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.aces_prg_dir);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(12, 176);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(342, 33);
            this.button10.TabIndex = 12;
            this.button10.Text = "gdrive";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.gdrive);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(12, 137);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(342, 33);
            this.button11.TabIndex = 13;
            this.button11.Text = "launch from list";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.strt_path);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(361, 38);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(598, 290);
            this.listBox2.TabIndex = 14;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(12, 215);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(342, 35);
            this.button12.TabIndex = 15;
            this.button12.Text = "dump registry";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.reg_dump);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(342, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "dump apps with uninstall";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.uninst_dump);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(342, 33);
            this.button2.TabIndex = 17;
            this.button2.Text = "dump apps with paths";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.path_dump);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 336);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(342, 33);
            this.button3.TabIndex = 18;
            this.button3.Text = "show desc";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.desc);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 383);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dest);
            this.Controls.Add(this.source);
            this.Name = "Form1";
            this.Text = "SchoolUtil[s]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        TextBox source;
        TextBox dest;
        ListBox listBox1;
        Button button6;
        Button button7;
        Button button8;
        Button button10;
        Button button11;
        ListBox listBox2;
        Button button12;
        Button button1;
        Button button2;
        private Button button3;
    }
}

