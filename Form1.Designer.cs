namespace VG_kr_dz
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
            this.ClearBox = new System.Windows.Forms.Button();
            this.SolveTask = new System.Windows.Forms.Button();
            this.RandomPolygon = new System.Windows.Forms.Button();
            this.NtextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearBox
            // 
            this.ClearBox.Location = new System.Drawing.Point(12, 12);
            this.ClearBox.Name = "ClearBox";
            this.ClearBox.Size = new System.Drawing.Size(394, 23);
            this.ClearBox.TabIndex = 2;
            this.ClearBox.Text = "Очистить график";
            this.ClearBox.UseVisualStyleBackColor = true;
            this.ClearBox.Click += new System.EventHandler(this.ClearBox_Click);
            // 
            // SolveTask
            // 
            this.SolveTask.Location = new System.Drawing.Point(8, 105);
            this.SolveTask.Name = "SolveTask";
            this.SolveTask.Size = new System.Drawing.Size(394, 53);
            this.SolveTask.TabIndex = 15;
            this.SolveTask.Text = "Нарисовать окружность максимального радиуса в полигоне";
            this.SolveTask.UseVisualStyleBackColor = true;
            this.SolveTask.Click += new System.EventHandler(this.SolveTask_Click);
            // 
            // RandomPolygon
            // 
            this.RandomPolygon.Location = new System.Drawing.Point(8, 69);
            this.RandomPolygon.Name = "RandomPolygon";
            this.RandomPolygon.Size = new System.Drawing.Size(394, 30);
            this.RandomPolygon.TabIndex = 16;
            this.RandomPolygon.Text = "Сгенерировать многоугольник";
            this.RandomPolygon.UseVisualStyleBackColor = true;
            this.RandomPolygon.Click += new System.EventHandler(this.RandomPolygon_Click);
            // 
            // NtextBox
            // 
            this.NtextBox.Location = new System.Drawing.Point(150, 41);
            this.NtextBox.Name = "NtextBox";
            this.NtextBox.Size = new System.Drawing.Size(100, 22);
            this.NtextBox.TabIndex = 17;
            this.NtextBox.Text = "20";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 16);
            this.label13.TabIndex = 18;
            this.label13.Text = "Количество точек =";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(418, 2);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(512, 512);
            this.pb.TabIndex = 19;
            this.pb.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 520);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.NtextBox);
            this.Controls.Add(this.RandomPolygon);
            this.Controls.Add(this.SolveTask);
            this.Controls.Add(this.ClearBox);
            this.Name = "Form1";
            this.Text = "Задача о наибольшей пустой окружности";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ClearBox;
        private System.Windows.Forms.Button SolveTask;
        private System.Windows.Forms.Button RandomPolygon;
        private System.Windows.Forms.TextBox NtextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pb;
    }
}

