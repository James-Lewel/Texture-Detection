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
            stopButton = new Button();
            predictButton = new Button();
            resultGroupBox = new GroupBox();
            fpsLabel = new Label();
            outputLabel = new Label();
            cameraOutput = new PictureBox();
            cameraComboBox = new ComboBox();
            groupBox.SuspendLayout();
            resultGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cameraOutput).BeginInit();
            SuspendLayout();
            // 
            // groupBox
            // 
            groupBox.Controls.Add(fpsLabel);
            groupBox.Controls.Add(stopButton);
            groupBox.Controls.Add(predictButton);
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
            // stopButton
            // 
            stopButton.Enabled = false;
            stopButton.Location = new Point(441, 223);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(239, 29);
            stopButton.TabIndex = 4;
            stopButton.Text = "Stop Predicting";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // predictButton
            // 
            predictButton.Enabled = false;
            predictButton.Location = new Point(441, 188);
            predictButton.Name = "predictButton";
            predictButton.Size = new Size(239, 29);
            predictButton.TabIndex = 3;
            predictButton.Text = "Start Predict";
            predictButton.UseVisualStyleBackColor = true;
            predictButton.Click += predictButton_Click;
            // 
            // resultGroupBox
            // 
            resultGroupBox.Controls.Add(outputLabel);
            resultGroupBox.Location = new Point(441, 70);
            resultGroupBox.Name = "resultGroupBox";
            resultGroupBox.Size = new Size(239, 112);
            resultGroupBox.TabIndex = 2;
            resultGroupBox.TabStop = false;
            resultGroupBox.Text = "Result";
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Location = new Point(441, 31);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(35, 20);
            fpsLabel.TabIndex = 1;
            fpsLabel.Text = "FPS:";
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(11, 39);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(115, 20);
            outputLabel.TabIndex = 0;
            outputLabel.Text = "Predicted Label:";
            // 
            // cameraOutput
            // 
            cameraOutput.BorderStyle = BorderStyle.FixedSingle;
            cameraOutput.Location = new Point(6, 70);
            cameraOutput.Name = "cameraOutput";
            cameraOutput.Size = new Size(424, 331);
            cameraOutput.SizeMode = PictureBoxSizeMode.StretchImage;
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
            groupBox.PerformLayout();
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
        private Button stopButton;
        private Button predictButton;
    }
}