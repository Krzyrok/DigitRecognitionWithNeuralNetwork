namespace Neural_Networks
{
    partial class NeuralNetworkGUI
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
            this.pictureBoxDrawingArea = new System.Windows.Forms.PictureBox();
            this.radioButtonTeaching = new System.Windows.Forms.RadioButton();
            this.radioButtonRecognition = new System.Windows.Forms.RadioButton();
            this.labelTypeOfNumber = new System.Windows.Forms.Label();
            this.labelDrawingNumber = new System.Windows.Forms.Label();
            this.buttonAddNumberOrRecognize = new System.Windows.Forms.Button();
            this.listBoxForChosingNumbers = new System.Windows.Forms.ListBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonTeachWithUserData = new System.Windows.Forms.Button();
            this.buttonTeachWithMNISTData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDrawingArea
            // 
            this.pictureBoxDrawingArea.BackColor = System.Drawing.Color.White;
            this.pictureBoxDrawingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDrawingArea.Location = new System.Drawing.Point(15, 63);
            this.pictureBoxDrawingArea.Name = "pictureBoxDrawingArea";
            this.pictureBoxDrawingArea.Size = new System.Drawing.Size(180, 200);
            this.pictureBoxDrawingArea.TabIndex = 0;
            this.pictureBoxDrawingArea.TabStop = false;
            this.pictureBoxDrawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDrawingArea_MouseDown);
            this.pictureBoxDrawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDrawingArea_MouseMove);
            this.pictureBoxDrawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDrawingArea_MouseUp);
            // 
            // radioButtonTeaching
            // 
            this.radioButtonTeaching.AutoSize = true;
            this.radioButtonTeaching.Location = new System.Drawing.Point(15, 12);
            this.radioButtonTeaching.Name = "radioButtonTeaching";
            this.radioButtonTeaching.Size = new System.Drawing.Size(57, 17);
            this.radioButtonTeaching.TabIndex = 11;
            this.radioButtonTeaching.TabStop = true;
            this.radioButtonTeaching.Text = "Nauka";
            this.radioButtonTeaching.UseVisualStyleBackColor = true;
            this.radioButtonTeaching.CheckedChanged += new System.EventHandler(this.radioButtonTeaching_CheckedChanged);
            // 
            // radioButtonRecognition
            // 
            this.radioButtonRecognition.AutoSize = true;
            this.radioButtonRecognition.Location = new System.Drawing.Point(78, 12);
            this.radioButtonRecognition.Name = "radioButtonRecognition";
            this.radioButtonRecognition.Size = new System.Drawing.Size(101, 17);
            this.radioButtonRecognition.TabIndex = 12;
            this.radioButtonRecognition.TabStop = true;
            this.radioButtonRecognition.Text = "Rozpoznawanie";
            this.radioButtonRecognition.UseVisualStyleBackColor = true;
            this.radioButtonRecognition.CheckedChanged += new System.EventHandler(this.radioButtonRecognition_CheckedChanged);
            // 
            // labelTypeOfNumber
            // 
            this.labelTypeOfNumber.AutoSize = true;
            this.labelTypeOfNumber.Location = new System.Drawing.Point(201, 63);
            this.labelTypeOfNumber.Name = "labelTypeOfNumber";
            this.labelTypeOfNumber.Size = new System.Drawing.Size(210, 13);
            this.labelTypeOfNumber.TabIndex = 6;
            this.labelTypeOfNumber.Text = "Wybierz liczbę, którą będziesz wprowadzał";
            // 
            // labelDrawingNumber
            // 
            this.labelDrawingNumber.AutoSize = true;
            this.labelDrawingNumber.Location = new System.Drawing.Point(12, 47);
            this.labelDrawingNumber.Name = "labelDrawingNumber";
            this.labelDrawingNumber.Size = new System.Drawing.Size(112, 13);
            this.labelDrawingNumber.TabIndex = 7;
            this.labelDrawingNumber.Text = "Narysuj cyfrę do nauki";
            // 
            // buttonAddNumberOrRecognize
            // 
            this.buttonAddNumberOrRecognize.Location = new System.Drawing.Point(204, 219);
            this.buttonAddNumberOrRecognize.Name = "buttonAddNumberOrRecognize";
            this.buttonAddNumberOrRecognize.Size = new System.Drawing.Size(117, 44);
            this.buttonAddNumberOrRecognize.TabIndex = 8;
            this.buttonAddNumberOrRecognize.Text = "Dodaj wzorzec do nauki";
            this.buttonAddNumberOrRecognize.UseVisualStyleBackColor = true;
            this.buttonAddNumberOrRecognize.Click += new System.EventHandler(this.buttonAddNumberOrRecognize_Click);
            // 
            // listBoxForChosingNumbers
            // 
            this.listBoxForChosingNumbers.FormattingEnabled = true;
            this.listBoxForChosingNumbers.Location = new System.Drawing.Point(201, 79);
            this.listBoxForChosingNumbers.Name = "listBoxForChosingNumbers";
            this.listBoxForChosingNumbers.Size = new System.Drawing.Size(120, 134);
            this.listBoxForChosingNumbers.TabIndex = 14;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(15, 269);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 34);
            this.buttonClear.TabIndex = 15;
            this.buttonClear.Text = "Wyczyść";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonTeachWithUserData
            // 
            this.buttonTeachWithUserData.Location = new System.Drawing.Point(41, 309);
            this.buttonTeachWithUserData.Name = "buttonTeachWithUserData";
            this.buttonTeachWithUserData.Size = new System.Drawing.Size(117, 34);
            this.buttonTeachWithUserData.TabIndex = 16;
            this.buttonTeachWithUserData.Text = "Nauczaj sieć danymi użytkownika";
            this.buttonTeachWithUserData.UseVisualStyleBackColor = true;
            this.buttonTeachWithUserData.Click += new System.EventHandler(this.buttonTeachWithUserData_Click);
            // 
            // buttonTeachWithMNISTData
            // 
            this.buttonTeachWithMNISTData.Location = new System.Drawing.Point(96, 269);
            this.buttonTeachWithMNISTData.Name = "buttonTeachWithMNISTData";
            this.buttonTeachWithMNISTData.Size = new System.Drawing.Size(99, 34);
            this.buttonTeachWithMNISTData.TabIndex = 17;
            this.buttonTeachWithMNISTData.Text = "Nauczaj sieć danymi MNIST";
            this.buttonTeachWithMNISTData.UseVisualStyleBackColor = true;
            this.buttonTeachWithMNISTData.Click += new System.EventHandler(this.buttonTeachWithMNISTData_Click);
            // 
            // NeuralNetworkGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(417, 368);
            this.Controls.Add(this.buttonTeachWithMNISTData);
            this.Controls.Add(this.buttonTeachWithUserData);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.listBoxForChosingNumbers);
            this.Controls.Add(this.buttonAddNumberOrRecognize);
            this.Controls.Add(this.labelDrawingNumber);
            this.Controls.Add(this.labelTypeOfNumber);
            this.Controls.Add(this.radioButtonRecognition);
            this.Controls.Add(this.radioButtonTeaching);
            this.Controls.Add(this.pictureBoxDrawingArea);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NeuralNetworkGUI";
            this.Text = "Rozpoznawanie liczb";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDrawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDrawingArea;
        private System.Windows.Forms.RadioButton radioButtonTeaching;
        private System.Windows.Forms.RadioButton radioButtonRecognition;
        private System.Windows.Forms.Label labelTypeOfNumber;
        private System.Windows.Forms.Label labelDrawingNumber;
        private System.Windows.Forms.Button buttonAddNumberOrRecognize;
        private System.Windows.Forms.ListBox listBoxForChosingNumbers;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonTeachWithUserData;
        private System.Windows.Forms.Button buttonTeachWithMNISTData;
    }
}

