namespace WindowsFormsLabFour
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCards = new System.Windows.Forms.Button();
            this.buttonCopyrighter = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.AliceBlue;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonCards, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCopyrighter, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(163, 93);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(474, 264);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonCards
            // 
            this.buttonCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCards.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCards.FlatAppearance.BorderSize = 0;
            this.buttonCards.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.buttonCards.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCards.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(227)))), ((int)(((byte)(247)))));
            this.buttonCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCards.Font = new System.Drawing.Font("Gotham Medium", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonCards.Location = new System.Drawing.Point(252, 15);
            this.buttonCards.Margin = new System.Windows.Forms.Padding(15);
            this.buttonCards.Name = "buttonCards";
            this.buttonCards.Size = new System.Drawing.Size(207, 234);
            this.buttonCards.TabIndex = 1;
            this.buttonCards.Text = "Cards";
            this.buttonCards.UseVisualStyleBackColor = true;
            this.buttonCards.Click += new System.EventHandler(this.buttonCards_Click);
            // 
            // buttonCopyrighter
            // 
            this.buttonCopyrighter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCopyrighter.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCopyrighter.FlatAppearance.BorderSize = 0;
            this.buttonCopyrighter.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.buttonCopyrighter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCopyrighter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(227)))), ((int)(((byte)(247)))));
            this.buttonCopyrighter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopyrighter.Font = new System.Drawing.Font("Gotham Medium", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyrighter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonCopyrighter.Location = new System.Drawing.Point(15, 15);
            this.buttonCopyrighter.Margin = new System.Windows.Forms.Padding(15);
            this.buttonCopyrighter.Name = "buttonCopyrighter";
            this.buttonCopyrighter.Size = new System.Drawing.Size(207, 234);
            this.buttonCopyrighter.TabIndex = 0;
            this.buttonCopyrighter.Text = "Copyrighter";
            this.buttonCopyrighter.UseVisualStyleBackColor = true;
            this.buttonCopyrighter.Click += new System.EventHandler(this.buttonCopyrighter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void TableLayoutPanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonCards;
        private System.Windows.Forms.Button buttonCopyrighter;
    }
}

