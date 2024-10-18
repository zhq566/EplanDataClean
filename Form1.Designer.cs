namespace EplanCleanner
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Parts = new System.Windows.Forms.Button();
            this.textParts = new System.Windows.Forms.TextBox();
            this.textIMG = new System.Windows.Forms.TextBox();
            this.btn_img = new System.Windows.Forms.Button();
            this.textMacro = new System.Windows.Forms.TextBox();
            this.btn_macro = new System.Windows.Forms.Button();
            this.textDoc = new System.Windows.Forms.TextBox();
            this.btn_doc = new System.Windows.Forms.Button();
            this.btn_exc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Parts
            // 
            this.btn_Parts.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Parts.Location = new System.Drawing.Point(17, 26);
            this.btn_Parts.Name = "btn_Parts";
            this.btn_Parts.Size = new System.Drawing.Size(154, 57);
            this.btn_Parts.TabIndex = 0;
            this.btn_Parts.Text = "$(MD_PARTS)";
            this.btn_Parts.UseVisualStyleBackColor = true;
            this.btn_Parts.Click += new System.EventHandler(this.GetPartsPath);
            // 
            // textParts
            // 
            this.textParts.Location = new System.Drawing.Point(192, 26);
            this.textParts.Multiline = true;
            this.textParts.Name = "textParts";
            this.textParts.Size = new System.Drawing.Size(563, 57);
            this.textParts.TabIndex = 1;
            // 
            // textIMG
            // 
            this.textIMG.Location = new System.Drawing.Point(192, 190);
            this.textIMG.Multiline = true;
            this.textIMG.Name = "textIMG";
            this.textIMG.Size = new System.Drawing.Size(563, 57);
            this.textIMG.TabIndex = 3;
            // 
            // btn_img
            // 
            this.btn_img.Location = new System.Drawing.Point(17, 190);
            this.btn_img.Name = "btn_img";
            this.btn_img.Size = new System.Drawing.Size(154, 57);
            this.btn_img.TabIndex = 2;
            this.btn_img.Text = "$(MD_IMG)";
            this.btn_img.UseVisualStyleBackColor = true;
            this.btn_img.Click += new System.EventHandler(this.GetImgPath);
            // 
            // textMacro
            // 
            this.textMacro.Location = new System.Drawing.Point(192, 108);
            this.textMacro.Multiline = true;
            this.textMacro.Name = "textMacro";
            this.textMacro.Size = new System.Drawing.Size(563, 57);
            this.textMacro.TabIndex = 5;
            // 
            // btn_macro
            // 
            this.btn_macro.Location = new System.Drawing.Point(17, 108);
            this.btn_macro.Name = "btn_macro";
            this.btn_macro.Size = new System.Drawing.Size(154, 57);
            this.btn_macro.TabIndex = 4;
            this.btn_macro.Text = "$(MD_MACROS)";
            this.btn_macro.UseVisualStyleBackColor = true;
            this.btn_macro.Click += new System.EventHandler(this.GetMacroPath);
            // 
            // textDoc
            // 
            this.textDoc.Location = new System.Drawing.Point(192, 272);
            this.textDoc.Multiline = true;
            this.textDoc.Name = "textDoc";
            this.textDoc.Size = new System.Drawing.Size(563, 57);
            this.textDoc.TabIndex = 7;
            // 
            // btn_doc
            // 
            this.btn_doc.Location = new System.Drawing.Point(17, 272);
            this.btn_doc.Name = "btn_doc";
            this.btn_doc.Size = new System.Drawing.Size(154, 57);
            this.btn_doc.TabIndex = 6;
            this.btn_doc.Text = "$(MD_DOCUMENTS)";
            this.btn_doc.UseVisualStyleBackColor = true;
            this.btn_doc.Click += new System.EventHandler(this.GetDocPath);
            // 
            // btn_exc
            // 
            this.btn_exc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exc.Location = new System.Drawing.Point(538, 360);
            this.btn_exc.Name = "btn_exc";
            this.btn_exc.Size = new System.Drawing.Size(217, 62);
            this.btn_exc.TabIndex = 8;
            this.btn_exc.Text = "Clean";
            this.btn_exc.UseVisualStyleBackColor = true;
            this.btn_exc.Click += new System.EventHandler(this.ClickBtnClean);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_exc);
            this.Controls.Add(this.textDoc);
            this.Controls.Add(this.btn_doc);
            this.Controls.Add(this.textMacro);
            this.Controls.Add(this.btn_macro);
            this.Controls.Add(this.textIMG);
            this.Controls.Add(this.btn_img);
            this.Controls.Add(this.textParts);
            this.Controls.Add(this.btn_Parts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Parts;
        private System.Windows.Forms.TextBox textParts;
        private System.Windows.Forms.TextBox textIMG;
        private System.Windows.Forms.Button btn_img;
        private System.Windows.Forms.TextBox textMacro;
        private System.Windows.Forms.Button btn_macro;
        private System.Windows.Forms.TextBox textDoc;
        private System.Windows.Forms.Button btn_doc;
        private System.Windows.Forms.Button btn_exc;
    }
}

