namespace Untangle
{
    partial class GameForm
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SolveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RulesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAppButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ExitStartMenuButton = new System.Windows.Forms.Button();
            this.RulesStartMenuButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.TitleUnderLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.Field = new System.Windows.Forms.PictureBox();
            this.MainMenu.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 1;
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuButton,
            this.SaveButton,
            this.toolStripSeparator1,
            this.SolveButton,
            this.toolStripSeparator2,
            this.ExitButton});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // MainMenuButton
            // 
            this.MainMenuButton.Enabled = false;
            this.MainMenuButton.Name = "MainMenuButton";
            this.MainMenuButton.Size = new System.Drawing.Size(177, 22);
            this.MainMenuButton.Text = "Main Menu";
            this.MainMenuButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(177, 22);
            this.SaveButton.Text = "Save Current Image";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // SolveButton
            // 
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(177, 22);
            this.SolveButton.Text = "Solve Level";
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // ExitButton
            // 
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(177, 22);
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RulesButton,
            this.AboutAppButton});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // RulesButton
            // 
            this.RulesButton.Name = "RulesButton";
            this.RulesButton.Size = new System.Drawing.Size(132, 22);
            this.RulesButton.Text = "Rules";
            this.RulesButton.Click += new System.EventHandler(this.RulesButton_Click);
            // 
            // AboutAppButton
            // 
            this.AboutAppButton.Name = "AboutAppButton";
            this.AboutAppButton.Size = new System.Drawing.Size(132, 22);
            this.AboutAppButton.Text = "About App";
            this.AboutAppButton.Click += new System.EventHandler(this.AboutAppButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.ExitStartMenuButton);
            this.MainPanel.Controls.Add(this.RulesStartMenuButton);
            this.MainPanel.Controls.Add(this.StartButton);
            this.MainPanel.Controls.Add(this.TitleUnderLabel);
            this.MainPanel.Controls.Add(this.TitleLabel);
            this.MainPanel.Controls.Add(this.Field);
            this.MainPanel.Controls.Add(this.MainMenu);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(784, 561);
            this.MainPanel.TabIndex = 0;
            // 
            // ExitStartMenuButton
            // 
            this.ExitStartMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ExitStartMenuButton.FlatAppearance.BorderSize = 4;
            this.ExitStartMenuButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.ExitStartMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitStartMenuButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitStartMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitStartMenuButton.Location = new System.Drawing.Point(395, 373);
            this.ExitStartMenuButton.Name = "ExitStartMenuButton";
            this.ExitStartMenuButton.Size = new System.Drawing.Size(139, 56);
            this.ExitStartMenuButton.TabIndex = 7;
            this.ExitStartMenuButton.Text = "EXIT";
            this.ExitStartMenuButton.UseVisualStyleBackColor = false;
            this.ExitStartMenuButton.Click += new System.EventHandler(this.ExitStartMenuButton_Click);
            // 
            // RulesStartMenuButton
            // 
            this.RulesStartMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.RulesStartMenuButton.FlatAppearance.BorderSize = 4;
            this.RulesStartMenuButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.RulesStartMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RulesStartMenuButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesStartMenuButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RulesStartMenuButton.Location = new System.Drawing.Point(294, 373);
            this.RulesStartMenuButton.Name = "RulesStartMenuButton";
            this.RulesStartMenuButton.Size = new System.Drawing.Size(95, 56);
            this.RulesStartMenuButton.TabIndex = 6;
            this.RulesStartMenuButton.Text = "RULES";
            this.RulesStartMenuButton.UseVisualStyleBackColor = false;
            this.RulesStartMenuButton.Click += new System.EventHandler(this.RulesStartMenuButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.StartButton.FlatAppearance.BorderSize = 4;
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.Control;
            this.StartButton.Location = new System.Drawing.Point(294, 274);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(240, 93);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // TitleUnderLabel
            // 
            this.TitleUnderLabel.AutoSize = true;
            this.TitleUnderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TitleUnderLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleUnderLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TitleUnderLabel.Location = new System.Drawing.Point(418, 145);
            this.TitleUnderLabel.Name = "TitleUnderLabel";
            this.TitleUnderLabel.Size = new System.Drawing.Size(173, 30);
            this.TitleUnderLabel.TabIndex = 4;
            this.TitleUnderLabel.Text = "The Puzzle Game";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TitleLabel.Location = new System.Drawing.Point(229, 75);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(377, 86);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "UNTANGLE";
            // 
            // Field
            // 
            this.Field.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Field.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Field.Location = new System.Drawing.Point(0, 24);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(784, 537);
            this.Field.TabIndex = 2;
            this.Field.TabStop = false;
            this.Field.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Field_MouseDown);
            this.Field.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Field_MouseMove);
            this.Field.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Field_MouseUp);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.MainPanel);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GameForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Untangle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ClientSizeChanged += new System.EventHandler(this.GameForm_ClientSizeChanged);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainMenuButton;
        private System.Windows.Forms.ToolStripMenuItem SaveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RulesButton;
        private System.Windows.Forms.ToolStripMenuItem AboutAppButton;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox Field;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label TitleUnderLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button ExitStartMenuButton;
        private System.Windows.Forms.Button RulesStartMenuButton;
        private System.Windows.Forms.ToolStripMenuItem SolveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

