namespace alwfx.UI
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
            this.topControlsArea = new System.Windows.Forms.GroupBox();
            this.resetSwitch = new System.Windows.Forms.Button();
            this.emulationSwitch = new System.Windows.Forms.Button();
            this.speedButtonsArea = new System.Windows.Forms.GroupBox();
            this.oneMinuteEmulationIntervalLabel = new System.Windows.Forms.Label();
            this.decreaseSpeedButton = new System.Windows.Forms.Button();
            this.increaseSpeedButton = new System.Windows.Forms.Button();
            this.devicesArea = new System.Windows.Forms.FlowLayoutPanel();
            this.topControlsArea.SuspendLayout();
            this.speedButtonsArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // topControlsArea
            // 
            this.topControlsArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topControlsArea.Controls.Add(this.resetSwitch);
            this.topControlsArea.Controls.Add(this.emulationSwitch);
            this.topControlsArea.Location = new System.Drawing.Point(12, 12);
            this.topControlsArea.Name = "topControlsArea";
            this.topControlsArea.Size = new System.Drawing.Size(660, 101);
            this.topControlsArea.TabIndex = 0;
            this.topControlsArea.TabStop = false;
            // 
            // resetSwitch
            // 
            this.resetSwitch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.resetSwitch.Location = new System.Drawing.Point(367, 44);
            this.resetSwitch.Name = "resetSwitch";
            this.resetSwitch.Size = new System.Drawing.Size(75, 23);
            this.resetSwitch.TabIndex = 1;
            this.resetSwitch.Text = "Reset";
            this.resetSwitch.UseVisualStyleBackColor = true;
            this.resetSwitch.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // emulationSwitch
            // 
            this.emulationSwitch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emulationSwitch.BackColor = System.Drawing.Color.DarkGreen;
            this.emulationSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.emulationSwitch.ForeColor = System.Drawing.Color.White;
            this.emulationSwitch.Location = new System.Drawing.Point(192, 44);
            this.emulationSwitch.Name = "emulationSwitch";
            this.emulationSwitch.Size = new System.Drawing.Size(98, 23);
            this.emulationSwitch.TabIndex = 0;
            this.emulationSwitch.Text = "Start Emulation";
            this.emulationSwitch.UseVisualStyleBackColor = false;
            this.emulationSwitch.Click += new System.EventHandler(this.emulationTimer_Click);
            // 
            // speedButtonsArea
            // 
            this.speedButtonsArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedButtonsArea.Controls.Add(this.oneMinuteEmulationIntervalLabel);
            this.speedButtonsArea.Controls.Add(this.decreaseSpeedButton);
            this.speedButtonsArea.Controls.Add(this.increaseSpeedButton);
            this.speedButtonsArea.Location = new System.Drawing.Point(12, 469);
            this.speedButtonsArea.Name = "speedButtonsArea";
            this.speedButtonsArea.Size = new System.Drawing.Size(660, 101);
            this.speedButtonsArea.TabIndex = 1;
            this.speedButtonsArea.TabStop = false;
            // 
            // oneMinuteEmulationIntervalLabel
            // 
            this.oneMinuteEmulationIntervalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.oneMinuteEmulationIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.oneMinuteEmulationIntervalLabel.Location = new System.Drawing.Point(44, 44);
            this.oneMinuteEmulationIntervalLabel.Name = "oneMinuteEmulationIntervalLabel";
            this.oneMinuteEmulationIntervalLabel.Size = new System.Drawing.Size(87, 23);
            this.oneMinuteEmulationIntervalLabel.TabIndex = 0;
            this.oneMinuteEmulationIntervalLabel.Text = "min/sec";
            this.oneMinuteEmulationIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decreaseSpeedButton
            // 
            this.decreaseSpeedButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.decreaseSpeedButton.Location = new System.Drawing.Point(355, 44);
            this.decreaseSpeedButton.Name = "decreaseSpeedButton";
            this.decreaseSpeedButton.Size = new System.Drawing.Size(130, 23);
            this.decreaseSpeedButton.TabIndex = 1;
            this.decreaseSpeedButton.Text = "Decrease Speed";
            this.decreaseSpeedButton.UseVisualStyleBackColor = true;
            this.decreaseSpeedButton.Click += new System.EventHandler(this.decreaseSpeed_Click);
            // 
            // increaseSpeedButton
            // 
            this.increaseSpeedButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.increaseSpeedButton.Location = new System.Drawing.Point(180, 44);
            this.increaseSpeedButton.Name = "increaseSpeedButton";
            this.increaseSpeedButton.Size = new System.Drawing.Size(130, 23);
            this.increaseSpeedButton.TabIndex = 0;
            this.increaseSpeedButton.Text = "Increase Speed";
            this.increaseSpeedButton.UseVisualStyleBackColor = true;
            this.increaseSpeedButton.Click += new System.EventHandler(this.increaseSpeed_Click);
            // 
            // devicesArea
            // 
            this.devicesArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesArea.Location = new System.Drawing.Point(12, 119);
            this.devicesArea.Name = "devicesArea";
            this.devicesArea.Size = new System.Drawing.Size(660, 344);
            this.devicesArea.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 582);
            this.Controls.Add(this.devicesArea);
            this.Controls.Add(this.speedButtonsArea);
            this.Controls.Add(this.topControlsArea);
            this.MinimumSize = new System.Drawing.Size(700, 570);
            this.Name = "Form1";
            this.Text = "Form1";
            this.topControlsArea.ResumeLayout(false);
            this.speedButtonsArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox topControlsArea;
        private System.Windows.Forms.Button emulationSwitch;
        private System.Windows.Forms.Button resetSwitch;
        private System.Windows.Forms.GroupBox speedButtonsArea;
        private System.Windows.Forms.Button decreaseSpeedButton;
        private System.Windows.Forms.Button increaseSpeedButton;
        private System.Windows.Forms.Label oneMinuteEmulationIntervalLabel;
        private System.Windows.Forms.FlowLayoutPanel devicesArea;
    }
}

