namespace Lab4_WindowsForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.x = new System.Windows.Forms.TextBox();
            this.y = new System.Windows.Forms.TextBox();
            this.z = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Concat = new System.Windows.Forms.Button();
            this.s = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.TextBox();
            this.f1 = new System.Windows.Forms.TextBox();
            this.s1 = new System.Windows.Forms.TextBox();
            this.k1 = new System.Windows.Forms.TextBox();
            this.f2 = new System.Windows.Forms.TextBox();
            this.s2 = new System.Windows.Forms.TextBox();
            this.k2 = new System.Windows.Forms.TextBox();
            this.f3 = new System.Windows.Forms.TextBox();
            this.s3 = new System.Windows.Forms.TextBox();
            this.k3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(38, 65);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(100, 22);
            this.x.TabIndex = 0;
            this.x.Text = "number";
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(204, 37);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(100, 22);
            this.y.TabIndex = 1;
            this.y.Text = "number";
            // 
            // z
            // 
            this.z.Location = new System.Drawing.Point(557, 37);
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(100, 22);
            this.z.TabIndex = 2;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(378, 37);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 3;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Concat
            // 
            this.Concat.Location = new System.Drawing.Point(378, 95);
            this.Concat.Name = "Concat";
            this.Concat.Size = new System.Drawing.Size(75, 23);
            this.Concat.TabIndex = 4;
            this.Concat.Text = "Concat";
            this.Concat.UseVisualStyleBackColor = true;
            this.Concat.Click += new System.EventHandler(this.Concat_Click);
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(204, 96);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(100, 22);
            this.s.TabIndex = 5;
            this.s.Text = "string";
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(557, 95);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(100, 22);
            this.result.TabIndex = 6;
            // 
            // f1
            // 
            this.f1.Location = new System.Drawing.Point(47, 267);
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(100, 22);
            this.f1.TabIndex = 12;
            this.f1.Text = "f1";
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(47, 211);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(100, 22);
            this.s1.TabIndex = 11;
            this.s1.Text = "s1";
            // 
            // k1
            // 
            this.k1.Location = new System.Drawing.Point(47, 239);
            this.k1.Name = "k1";
            this.k1.Size = new System.Drawing.Size(100, 22);
            this.k1.TabIndex = 10;
            this.k1.Text = "k1";
            // 
            // f2
            // 
            this.f2.Location = new System.Drawing.Point(246, 267);
            this.f2.Name = "f2";
            this.f2.Size = new System.Drawing.Size(100, 22);
            this.f2.TabIndex = 15;
            this.f2.Text = "f2";
            // 
            // s2
            // 
            this.s2.Location = new System.Drawing.Point(246, 211);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(100, 22);
            this.s2.TabIndex = 14;
            this.s2.Text = "s2";
            // 
            // k2
            // 
            this.k2.Location = new System.Drawing.Point(246, 239);
            this.k2.Name = "k2";
            this.k2.Size = new System.Drawing.Size(100, 22);
            this.k2.TabIndex = 13;
            this.k2.Text = "k2";
            // 
            // f3
            // 
            this.f3.Location = new System.Drawing.Point(557, 267);
            this.f3.Name = "f3";
            this.f3.Size = new System.Drawing.Size(100, 22);
            this.f3.TabIndex = 18;
            // 
            // s3
            // 
            this.s3.Location = new System.Drawing.Point(557, 211);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(100, 22);
            this.s3.TabIndex = 17;
            // 
            // k3
            // 
            this.k3.Location = new System.Drawing.Point(557, 239);
            this.k3.Name = "k3";
            this.k3.Size = new System.Drawing.Size(100, 22);
            this.k3.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Sum2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.f3);
            this.Controls.Add(this.s3);
            this.Controls.Add(this.k3);
            this.Controls.Add(this.f2);
            this.Controls.Add(this.s2);
            this.Controls.Add(this.k2);
            this.Controls.Add(this.f1);
            this.Controls.Add(this.s1);
            this.Controls.Add(this.k1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.s);
            this.Controls.Add(this.Concat);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.z);
            this.Controls.Add(this.y);
            this.Controls.Add(this.x);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.TextBox z;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Concat;
        private System.Windows.Forms.TextBox s;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.TextBox f1;
        private System.Windows.Forms.TextBox s1;
        private System.Windows.Forms.TextBox k1;
        private System.Windows.Forms.TextBox f2;
        private System.Windows.Forms.TextBox s2;
        private System.Windows.Forms.TextBox k2;
        private System.Windows.Forms.TextBox f3;
        private System.Windows.Forms.TextBox s3;
        private System.Windows.Forms.TextBox k3;
        private System.Windows.Forms.Button button1;
    }
}

