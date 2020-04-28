namespace OngoingQuestInfoListMaker
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMake = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(12, 12);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(299, 23);
            this.buttonMake.TabIndex = 0;
            this.buttonMake.Text = "Make";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 46);
            this.Controls.Add(this.buttonMake);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "OngoingQuestListMaker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMake;
    }
}

