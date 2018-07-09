namespace Arcanoid
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
            this.pFG = new Arcanoid.PanelForGaming();
            this.SuspendLayout();
            // 
            // pFG
            // 
            this.pFG.BackColor = System.Drawing.Color.Black;
            this.pFG.Game = null;
            this.pFG.Location = new System.Drawing.Point(138, 85);
            this.pFG.Name = "pFG";
            this.pFG.Size = new System.Drawing.Size(636, 363);
            this.pFG.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 529);
            this.Controls.Add(this.pFG);
            this.Name = "Form1";
            this.Text = "Arcanoid";
            this.ResumeLayout(false);

        }

        #endregion

        private PanelForGaming pFG;
       
    }
}

