
namespace ChessBot
{
    partial class ChessForm
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
            this.buttonPrintChessBoard = new System.Windows.Forms.Button();
            this.textBoxPrintBoard = new System.Windows.Forms.TextBox();
            this.buttonPlayAsWhite = new System.Windows.Forms.Button();
            this.buttonPlayAsBlack = new System.Windows.Forms.Button();
            this.labelPlayAsWhite = new System.Windows.Forms.Label();
            this.labelPlayAsBlack = new System.Windows.Forms.Label();
            this.buttonPlayAsRandom = new System.Windows.Forms.Button();
            this.labelPlayAsRandom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPrintChessBoard
            // 
            this.buttonPrintChessBoard.Location = new System.Drawing.Point(883, 30);
            this.buttonPrintChessBoard.Name = "buttonPrintChessBoard";
            this.buttonPrintChessBoard.Size = new System.Drawing.Size(75, 23);
            this.buttonPrintChessBoard.TabIndex = 0;
            this.buttonPrintChessBoard.Text = "Print Board";
            this.buttonPrintChessBoard.UseVisualStyleBackColor = true;
            this.buttonPrintChessBoard.Click += new System.EventHandler(this.buttonPrintChessBoard_Click);
            // 
            // textBoxPrintBoard
            // 
            this.textBoxPrintBoard.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxPrintBoard.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPrintBoard.Location = new System.Drawing.Point(12, 89);
            this.textBoxPrintBoard.Multiline = true;
            this.textBoxPrintBoard.Name = "textBoxPrintBoard";
            this.textBoxPrintBoard.ReadOnly = true;
            this.textBoxPrintBoard.Size = new System.Drawing.Size(1700, 170);
            this.textBoxPrintBoard.TabIndex = 1;
            this.textBoxPrintBoard.Visible = false;
            // 
            // buttonPlayAsWhite
            // 
            this.buttonPlayAsWhite.Location = new System.Drawing.Point(333, 34);
            this.buttonPlayAsWhite.Name = "buttonPlayAsWhite";
            this.buttonPlayAsWhite.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayAsWhite.TabIndex = 3;
            this.buttonPlayAsWhite.Text = "Play";
            this.buttonPlayAsWhite.UseVisualStyleBackColor = true;
            this.buttonPlayAsWhite.Click += new System.EventHandler(this.buttonPlayAsWhite_Click);
            // 
            // buttonPlayAsBlack
            // 
            this.buttonPlayAsBlack.Location = new System.Drawing.Point(587, 34);
            this.buttonPlayAsBlack.Name = "buttonPlayAsBlack";
            this.buttonPlayAsBlack.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayAsBlack.TabIndex = 4;
            this.buttonPlayAsBlack.Text = "Play";
            this.buttonPlayAsBlack.UseVisualStyleBackColor = true;
            this.buttonPlayAsBlack.Click += new System.EventHandler(this.buttonPlayAsBlack_Click);
            // 
            // labelPlayAsWhite
            // 
            this.labelPlayAsWhite.AutoSize = true;
            this.labelPlayAsWhite.Location = new System.Drawing.Point(356, 64);
            this.labelPlayAsWhite.Name = "labelPlayAsWhite";
            this.labelPlayAsWhite.Size = new System.Drawing.Size(38, 15);
            this.labelPlayAsWhite.TabIndex = 5;
            this.labelPlayAsWhite.Text = "White";
            // 
            // labelPlayAsBlack
            // 
            this.labelPlayAsBlack.AutoSize = true;
            this.labelPlayAsBlack.Location = new System.Drawing.Point(608, 64);
            this.labelPlayAsBlack.Name = "labelPlayAsBlack";
            this.labelPlayAsBlack.Size = new System.Drawing.Size(35, 15);
            this.labelPlayAsBlack.TabIndex = 6;
            this.labelPlayAsBlack.Text = "Black";
            // 
            // buttonPlayAsRandom
            // 
            this.buttonPlayAsRandom.Location = new System.Drawing.Point(464, 34);
            this.buttonPlayAsRandom.Name = "buttonPlayAsRandom";
            this.buttonPlayAsRandom.Size = new System.Drawing.Size(75, 23);
            this.buttonPlayAsRandom.TabIndex = 7;
            this.buttonPlayAsRandom.Text = "Play";
            this.buttonPlayAsRandom.UseVisualStyleBackColor = true;
            this.buttonPlayAsRandom.Click += new System.EventHandler(this.buttonPlayAsRandom_Click);
            // 
            // labelPlayAsRandom
            // 
            this.labelPlayAsRandom.AutoSize = true;
            this.labelPlayAsRandom.Location = new System.Drawing.Point(474, 64);
            this.labelPlayAsRandom.Name = "labelPlayAsRandom";
            this.labelPlayAsRandom.Size = new System.Drawing.Size(52, 15);
            this.labelPlayAsRandom.TabIndex = 8;
            this.labelPlayAsRandom.Text = "Random";
            // 
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.labelPlayAsRandom);
            this.Controls.Add(this.buttonPlayAsRandom);
            this.Controls.Add(this.labelPlayAsBlack);
            this.Controls.Add(this.labelPlayAsWhite);
            this.Controls.Add(this.buttonPlayAsBlack);
            this.Controls.Add(this.buttonPlayAsWhite);
            this.Controls.Add(this.textBoxPrintBoard);
            this.Controls.Add(this.buttonPrintChessBoard);
            this.DoubleBuffered = true;
            this.Name = "ChessForm";
            this.Text = "Chess Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawGame);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChessForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChessForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPrintChessBoard;
        private System.Windows.Forms.TextBox textBoxPrintBoard;
        private System.Windows.Forms.Button buttonPlayAsWhite;
        private System.Windows.Forms.Button buttonPlayAsBlack;
        private System.Windows.Forms.Label labelPlayAsWhite;
        private System.Windows.Forms.Label labelPlayAsBlack;
        private System.Windows.Forms.Button buttonPlayAsRandom;
        private System.Windows.Forms.Label labelPlayAsRandom;
    }
}

