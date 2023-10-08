namespace Texture_Detection
{
    partial class MLForm
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
            groupBox = new GroupBox();
            resultGroupBox = new GroupBox();
            outputLabel = new Label();
            cameraOutput = new PictureBox();
            cameraComboBox = new ComboBox();
            fpsLabel = new Label();
            groupBox.SuspendLayout();
            resultGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cameraOutput).BeginInit();
            SuspendLayout();
            // 
            // groupBox
            // 
            groupBox.Controls.Add(resultGroupBox);
            groupBox.Controls.Add(cameraOutput);
            groupBox.Controls.Add(cameraComboBox);
            groupBox.Location = new Point(23, 23);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(686, 407);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Menu";
            // 
            // resultGroupBox
            // 
            resultGroupBox.Controls.Add(fpsLabel);
            resultGroupBox.Controls.Add(outputLabel);
            resultGroupBox.Location = new Point(441, 26);
            resultGroupBox.Name = "resultGroupBox";
            resultGroupBox.Size = new Size(239, 375);
            resultGroupBox.TabIndex = 2;
            resultGroupBox.TabStop = false;
            resultGroupBox.Text = "Result";
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(11, 28);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(0, 20);
            outputLabel.TabIndex = 0;
            // 
            // cameraOutput
            // 
            cameraOutput.BorderStyle = BorderStyle.FixedSingle;
            cameraOutput.Location = new Point(6, 70);
            cameraOutput.Name = "cameraOutput";
            cameraOutput.Size = new Size(424, 331);
            cameraOutput.TabIndex = 1;
            cameraOutput.TabStop = false;
            // 
            // cameraComboBox
            // 
            cameraComboBox.FormattingEnabled = true;
            cameraComboBox.Location = new Point(6, 31);
            cameraComboBox.Name = "cameraComboBox";
            cameraComboBox.Size = new Size(424, 28);
            cameraComboBox.TabIndex = 0;
            cameraComboBox.SelectedIndexChanged += cameraComboBox_SelectedIndexChanged;
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Location = new Point(11, 347);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(0, 20);
            fpsLabel.TabIndex = 1;
            // 
            // MLForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 453);
            Controls.Add(groupBox);
            MaximumSize = new Size(750, 500);
            MinimumSize = new Size(750, 500);
            Name = "MLForm";
            Padding = new Padding(20);
            Text = "Texture Detection";
            FormClosed += MLForm_FormClosed;
            groupBox.ResumeLayout(false);
            resultGroupBox.ResumeLayout(false);
            resultGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cameraOutput).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox;
        private PictureBox cameraOutput;
        private ComboBox cameraComboBox;
        private GroupBox resultGroupBox;
        private Label outputLabel;
        private Label fpsLabel;
    }
}