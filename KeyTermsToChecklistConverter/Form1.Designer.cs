namespace KeyTermsToChecklistConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.InputFileTextBox = new System.Windows.Forms.TextBox();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.SourceTermOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.SourceNoWhitespaceTrimming = new System.Windows.Forms.CheckBox();
            this.SourceNormalizeNativeChars = new System.Windows.Forms.CheckBox();
            this.SourceNormalizeWhitespaces = new System.Windows.Forms.CheckBox();
            this.SourceMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.SourceCaseSensitive = new System.Windows.Forms.CheckBox();
            this.TargetTermOptions = new System.Windows.Forms.GroupBox();
            this.TargetNoWhitespaceTrimming = new System.Windows.Forms.CheckBox();
            this.TargetNormalizeNativeChars = new System.Windows.Forms.CheckBox();
            this.TargetNormalizeWhitespaces = new System.Windows.Forms.CheckBox();
            this.TargetMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.TargetCaseSensitive = new System.Windows.Forms.CheckBox();
            this.KTMismatchCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CategoryTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchModeCombobox = new System.Windows.Forms.ComboBox();
            this.SourceTermOptionsGroupBox.SuspendLayout();
            this.TargetTermOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input file (Unicode text file):";
            // 
            // InputFileTextBox
            // 
            this.InputFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.InputFileTextBox.Location = new System.Drawing.Point(175, 22);
            this.InputFileTextBox.Name = "InputFileTextBox";
            this.InputFileTextBox.Size = new System.Drawing.Size(496, 21);
            this.InputFileTextBox.TabIndex = 1;
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.OpenFileButton.Location = new System.Drawing.Point(688, 22);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(32, 22);
            this.OpenFileButton.TabIndex = 2;
            this.OpenFileButton.Text = "...";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // SourceTermOptionsGroupBox
            // 
            this.SourceTermOptionsGroupBox.Controls.Add(this.SourceNoWhitespaceTrimming);
            this.SourceTermOptionsGroupBox.Controls.Add(this.SourceNormalizeNativeChars);
            this.SourceTermOptionsGroupBox.Controls.Add(this.SourceNormalizeWhitespaces);
            this.SourceTermOptionsGroupBox.Controls.Add(this.SourceMatchWholeWord);
            this.SourceTermOptionsGroupBox.Controls.Add(this.SourceCaseSensitive);
            this.SourceTermOptionsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SourceTermOptionsGroupBox.Location = new System.Drawing.Point(20, 68);
            this.SourceTermOptionsGroupBox.Name = "SourceTermOptionsGroupBox";
            this.SourceTermOptionsGroupBox.Size = new System.Drawing.Size(292, 166);
            this.SourceTermOptionsGroupBox.TabIndex = 3;
            this.SourceTermOptionsGroupBox.TabStop = false;
            this.SourceTermOptionsGroupBox.Text = "Source Term Options";
            // 
            // SourceNoWhitespaceTrimming
            // 
            this.SourceNoWhitespaceTrimming.AutoSize = true;
            this.SourceNoWhitespaceTrimming.Location = new System.Drawing.Point(5, 131);
            this.SourceNoWhitespaceTrimming.Name = "SourceNoWhitespaceTrimming";
            this.SourceNoWhitespaceTrimming.Size = new System.Drawing.Size(165, 19);
            this.SourceNoWhitespaceTrimming.TabIndex = 0;
            this.SourceNoWhitespaceTrimming.Text = "No Whitespace Trimming";
            this.SourceNoWhitespaceTrimming.UseVisualStyleBackColor = true;
            // 
            // SourceNormalizeNativeChars
            // 
            this.SourceNormalizeNativeChars.AutoSize = true;
            this.SourceNormalizeNativeChars.Location = new System.Drawing.Point(5, 106);
            this.SourceNormalizeNativeChars.Name = "SourceNormalizeNativeChars";
            this.SourceNormalizeNativeChars.Size = new System.Drawing.Size(182, 19);
            this.SourceNormalizeNativeChars.TabIndex = 0;
            this.SourceNormalizeNativeChars.Text = "Normalize Native Characters";
            this.SourceNormalizeNativeChars.UseVisualStyleBackColor = true;
            // 
            // SourceNormalizeWhitespaces
            // 
            this.SourceNormalizeWhitespaces.AutoSize = true;
            this.SourceNormalizeWhitespaces.Location = new System.Drawing.Point(5, 81);
            this.SourceNormalizeWhitespaces.Name = "SourceNormalizeWhitespaces";
            this.SourceNormalizeWhitespaces.Size = new System.Drawing.Size(156, 19);
            this.SourceNormalizeWhitespaces.TabIndex = 0;
            this.SourceNormalizeWhitespaces.Text = "Normalize Whitespaces";
            this.SourceNormalizeWhitespaces.UseVisualStyleBackColor = true;
            // 
            // SourceMatchWholeWord
            // 
            this.SourceMatchWholeWord.AutoSize = true;
            this.SourceMatchWholeWord.Location = new System.Drawing.Point(5, 55);
            this.SourceMatchWholeWord.Name = "SourceMatchWholeWord";
            this.SourceMatchWholeWord.Size = new System.Drawing.Size(130, 19);
            this.SourceMatchWholeWord.TabIndex = 0;
            this.SourceMatchWholeWord.Text = "Match Whole Word";
            this.SourceMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // SourceCaseSensitive
            // 
            this.SourceCaseSensitive.AutoSize = true;
            this.SourceCaseSensitive.Location = new System.Drawing.Point(6, 30);
            this.SourceCaseSensitive.Name = "SourceCaseSensitive";
            this.SourceCaseSensitive.Size = new System.Drawing.Size(106, 19);
            this.SourceCaseSensitive.TabIndex = 0;
            this.SourceCaseSensitive.Text = "Case Sensitive";
            this.SourceCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // TargetTermOptions
            // 
            this.TargetTermOptions.Controls.Add(this.TargetNoWhitespaceTrimming);
            this.TargetTermOptions.Controls.Add(this.TargetNormalizeNativeChars);
            this.TargetTermOptions.Controls.Add(this.TargetNormalizeWhitespaces);
            this.TargetTermOptions.Controls.Add(this.TargetMatchWholeWord);
            this.TargetTermOptions.Controls.Add(this.TargetCaseSensitive);
            this.TargetTermOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TargetTermOptions.Location = new System.Drawing.Point(346, 68);
            this.TargetTermOptions.Name = "TargetTermOptions";
            this.TargetTermOptions.Size = new System.Drawing.Size(292, 166);
            this.TargetTermOptions.TabIndex = 4;
            this.TargetTermOptions.TabStop = false;
            this.TargetTermOptions.Text = "Target Term Options";
            // 
            // TargetNoWhitespaceTrimming
            // 
            this.TargetNoWhitespaceTrimming.AutoSize = true;
            this.TargetNoWhitespaceTrimming.Location = new System.Drawing.Point(5, 131);
            this.TargetNoWhitespaceTrimming.Name = "TargetNoWhitespaceTrimming";
            this.TargetNoWhitespaceTrimming.Size = new System.Drawing.Size(165, 19);
            this.TargetNoWhitespaceTrimming.TabIndex = 0;
            this.TargetNoWhitespaceTrimming.Text = "No Whitespace Trimming";
            this.TargetNoWhitespaceTrimming.UseVisualStyleBackColor = true;
            // 
            // TargetNormalizeNativeChars
            // 
            this.TargetNormalizeNativeChars.AutoSize = true;
            this.TargetNormalizeNativeChars.Location = new System.Drawing.Point(5, 106);
            this.TargetNormalizeNativeChars.Name = "TargetNormalizeNativeChars";
            this.TargetNormalizeNativeChars.Size = new System.Drawing.Size(182, 19);
            this.TargetNormalizeNativeChars.TabIndex = 0;
            this.TargetNormalizeNativeChars.Text = "Normalize Native Characters";
            this.TargetNormalizeNativeChars.UseVisualStyleBackColor = true;
            // 
            // TargetNormalizeWhitespaces
            // 
            this.TargetNormalizeWhitespaces.AutoSize = true;
            this.TargetNormalizeWhitespaces.Location = new System.Drawing.Point(5, 81);
            this.TargetNormalizeWhitespaces.Name = "TargetNormalizeWhitespaces";
            this.TargetNormalizeWhitespaces.Size = new System.Drawing.Size(156, 19);
            this.TargetNormalizeWhitespaces.TabIndex = 0;
            this.TargetNormalizeWhitespaces.Text = "Normalize Whitespaces";
            this.TargetNormalizeWhitespaces.UseVisualStyleBackColor = true;
            // 
            // TargetMatchWholeWord
            // 
            this.TargetMatchWholeWord.AutoSize = true;
            this.TargetMatchWholeWord.Location = new System.Drawing.Point(5, 55);
            this.TargetMatchWholeWord.Name = "TargetMatchWholeWord";
            this.TargetMatchWholeWord.Size = new System.Drawing.Size(130, 19);
            this.TargetMatchWholeWord.TabIndex = 0;
            this.TargetMatchWholeWord.Text = "Match Whole Word";
            this.TargetMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // TargetCaseSensitive
            // 
            this.TargetCaseSensitive.AutoSize = true;
            this.TargetCaseSensitive.Location = new System.Drawing.Point(6, 30);
            this.TargetCaseSensitive.Name = "TargetCaseSensitive";
            this.TargetCaseSensitive.Size = new System.Drawing.Size(106, 19);
            this.TargetCaseSensitive.TabIndex = 0;
            this.TargetCaseSensitive.Text = "Case Sensitive";
            this.TargetCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // KTMismatchCheckbox
            // 
            this.KTMismatchCheckbox.AutoSize = true;
            this.KTMismatchCheckbox.Checked = true;
            this.KTMismatchCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KTMismatchCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.KTMismatchCheckbox.Location = new System.Drawing.Point(21, 245);
            this.KTMismatchCheckbox.Name = "KTMismatchCheckbox";
            this.KTMismatchCheckbox.Size = new System.Drawing.Size(176, 19);
            this.KTMismatchCheckbox.TabIndex = 5;
            this.KTMismatchCheckbox.Text = "Key Terms Mismatch Mode";
            this.KTMismatchCheckbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(20, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Category:";
            // 
            // CategoryTextBox
            // 
            this.CategoryTextBox.Location = new System.Drawing.Point(86, 274);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.Size = new System.Drawing.Size(227, 21);
            this.CategoryTextBox.TabIndex = 7;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CancelButton.Location = new System.Drawing.Point(629, 335);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 26);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConvertButton
            // 
            this.ConvertButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ConvertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ConvertButton.Location = new System.Drawing.Point(530, 335);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(94, 26);
            this.ConvertButton.TabIndex = 8;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search mode:";
            // 
            // SearchModeCombobox
            // 
            this.SearchModeCombobox.FormattingEnabled = true;
            this.SearchModeCombobox.Items.AddRange(new object[] {
            "Simple",
            "Regular Expressions"});
            this.SearchModeCombobox.Location = new System.Drawing.Point(441, 247);
            this.SearchModeCombobox.Name = "SearchModeCombobox";
            this.SearchModeCombobox.Size = new System.Drawing.Size(173, 23);
            this.SearchModeCombobox.TabIndex = 10;
            this.SearchModeCombobox.SelectedIndexChanged += new System.EventHandler(this.SearchModeCombobox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.ConvertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 373);
            this.Controls.Add(this.SearchModeCombobox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CategoryTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KTMismatchCheckbox);
            this.Controls.Add(this.TargetTermOptions);
            this.Controls.Add(this.SourceTermOptionsGroupBox);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.InputFileTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Key Terms to Checklist Converter ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SourceTermOptionsGroupBox.ResumeLayout(false);
            this.SourceTermOptionsGroupBox.PerformLayout();
            this.TargetTermOptions.ResumeLayout(false);
            this.TargetTermOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputFileTextBox;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.GroupBox SourceTermOptionsGroupBox;
        private System.Windows.Forms.CheckBox SourceNoWhitespaceTrimming;
        private System.Windows.Forms.CheckBox SourceNormalizeNativeChars;
        private System.Windows.Forms.CheckBox SourceNormalizeWhitespaces;
        private System.Windows.Forms.CheckBox SourceMatchWholeWord;
        private System.Windows.Forms.CheckBox SourceCaseSensitive;
        private System.Windows.Forms.GroupBox TargetTermOptions;
        private System.Windows.Forms.CheckBox TargetNoWhitespaceTrimming;
        private System.Windows.Forms.CheckBox TargetNormalizeNativeChars;
        private System.Windows.Forms.CheckBox TargetNormalizeWhitespaces;
        private System.Windows.Forms.CheckBox TargetMatchWholeWord;
        private System.Windows.Forms.CheckBox TargetCaseSensitive;
        private System.Windows.Forms.CheckBox KTMismatchCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CategoryTextBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SearchModeCombobox;
    }
}

