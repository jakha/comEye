namespace CSTrackaccess
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ibOriginal = new Emgu.CV.UI.ImageBox();
            this.btnPauseOrResume = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // ibOriginal
            // 
            this.ibOriginal.Location = new System.Drawing.Point(13, 13);
            this.ibOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.ibOriginal.Name = "ibOriginal";
            this.ibOriginal.Size = new System.Drawing.Size(623, 490);
            this.ibOriginal.TabIndex = 2;
            this.ibOriginal.TabStop = false;
            // 
            // btnPauseOrResume
            // 
            this.btnPauseOrResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPauseOrResume.Location = new System.Drawing.Point(13, 511);
            this.btnPauseOrResume.Margin = new System.Windows.Forms.Padding(4);
            this.btnPauseOrResume.Name = "btnPauseOrResume";
            this.btnPauseOrResume.Size = new System.Drawing.Size(151, 53);
            this.btnPauseOrResume.TabIndex = 4;
            this.btnPauseOrResume.Text = "pause";
            this.btnPauseOrResume.UseVisualStyleBackColor = true;
            this.btnPauseOrResume.Click += new System.EventHandler(this.btnPauseOrResume_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 582);
            this.Controls.Add(this.btnPauseOrResume);
            this.Controls.Add(this.ibOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kinect";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibOriginal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibOriginal;
        private System.Windows.Forms.Button btnPauseOrResume;
    }
}

