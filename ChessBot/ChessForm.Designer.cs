
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
            this.textBoxPrintBoard.Location = new System.Drawing.Point(12, 59);
            this.textBoxPrintBoard.Multiline = true;
            this.textBoxPrintBoard.Name = "textBoxPrintBoard";
            this.textBoxPrintBoard.ReadOnly = true;
            this.textBoxPrintBoard.Size = new System.Drawing.Size(1700, 170);
            this.textBoxPrintBoard.TabIndex = 1;
            this.textBoxPrintBoard.Visible = false;
            // 
            // ChessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
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
    }
}

