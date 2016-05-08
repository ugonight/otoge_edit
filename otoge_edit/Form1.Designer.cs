namespace otoge_edit
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.quantize = new System.Windows.Forms.ComboBox();
            this.bpm = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notetype = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jaketName = new System.Windows.Forms.TextBox();
            this.demoName = new System.Windows.Forms.TextBox();
            this.musicName = new System.Windows.Forms.TextBox();
            this.saveScore = new System.Windows.Forms.Button();
            this.loadScore = new System.Windows.Forms.Button();
            this.jaket = new System.Windows.Forms.PictureBox();
            this.demoPlay = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.musicPlay = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.levelName = new System.Windows.Forms.TextBox();
            this.level = new System.Windows.Forms.NumericUpDown();
            this.artist = new System.Windows.Forms.TextBox();
            this.genre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.correction = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.新規作成NToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.開くOToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.上書き保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.Cursor = new System.Windows.Forms.ToolStripButton();
            this.pencil = new System.Windows.Forms.ToolStripButton();
            this.eraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.initialPlay = new System.Windows.Forms.ToolStripButton();
            this.play = new System.Windows.Forms.ToolStripButton();
            this.stop = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpm)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jaket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.level)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.correction)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 545);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 604);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(996, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(655, 45);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(22, 545);
            this.vScrollBar1.SmallChange = 10;
            this.vScrollBar1.TabIndex = 3;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // quantize
            // 
            this.quantize.FormattingEnabled = true;
            this.quantize.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "64",
            "128"});
            this.quantize.Location = new System.Drawing.Point(146, 64);
            this.quantize.Name = "quantize";
            this.quantize.Size = new System.Drawing.Size(121, 23);
            this.quantize.TabIndex = 8;
            this.quantize.Text = "8";
            // 
            // bpm
            // 
            this.bpm.Location = new System.Drawing.Point(146, 30);
            this.bpm.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.bpm.Name = "bpm";
            this.bpm.Size = new System.Drawing.Size(120, 22);
            this.bpm.TabIndex = 6;
            this.bpm.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "クオンタイズ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "BPM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "ノートタイプ:";
            // 
            // notetype
            // 
            this.notetype.FormattingEnabled = true;
            this.notetype.Items.AddRange(new object[] {
            "nomal",
            "holdS",
            "holdE",
            "slideL",
            "slideR",
            "touch",
            "holdE_L",
            "holdE_R"});
            this.notetype.Location = new System.Drawing.Point(146, 102);
            this.notetype.Name = "notetype";
            this.notetype.Size = new System.Drawing.Size(121, 23);
            this.notetype.TabIndex = 10;
            this.notetype.Text = "nomal";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jaketName);
            this.groupBox1.Controls.Add(this.demoName);
            this.groupBox1.Controls.Add(this.musicName);
            this.groupBox1.Controls.Add(this.saveScore);
            this.groupBox1.Controls.Add(this.loadScore);
            this.groupBox1.Controls.Add(this.jaket);
            this.groupBox1.Controls.Add(this.demoPlay);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.musicPlay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.levelName);
            this.groupBox1.Controls.Add(this.level);
            this.groupBox1.Controls.Add(this.artist);
            this.groupBox1.Controls.Add(this.genre);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.title);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(700, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 370);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "譜面設定";
            // 
            // jaketName
            // 
            this.jaketName.Enabled = false;
            this.jaketName.Location = new System.Drawing.Point(77, 234);
            this.jaketName.Name = "jaketName";
            this.jaketName.Size = new System.Drawing.Size(95, 22);
            this.jaketName.TabIndex = 14;
            // 
            // demoName
            // 
            this.demoName.Enabled = false;
            this.demoName.Location = new System.Drawing.Point(84, 172);
            this.demoName.Name = "demoName";
            this.demoName.Size = new System.Drawing.Size(88, 22);
            this.demoName.TabIndex = 13;
            // 
            // musicName
            // 
            this.musicName.Enabled = false;
            this.musicName.Location = new System.Drawing.Point(84, 138);
            this.musicName.Name = "musicName";
            this.musicName.Size = new System.Drawing.Size(88, 22);
            this.musicName.TabIndex = 13;
            // 
            // saveScore
            // 
            this.saveScore.Location = new System.Drawing.Point(77, 325);
            this.saveScore.Name = "saveScore";
            this.saveScore.Size = new System.Drawing.Size(61, 30);
            this.saveScore.TabIndex = 12;
            this.saveScore.Text = "セーブ";
            this.saveScore.UseVisualStyleBackColor = true;
            this.saveScore.Click += new System.EventHandler(this.saveScore_Click);
            // 
            // loadScore
            // 
            this.loadScore.Location = new System.Drawing.Point(10, 325);
            this.loadScore.Name = "loadScore";
            this.loadScore.Size = new System.Drawing.Size(61, 30);
            this.loadScore.TabIndex = 11;
            this.loadScore.Text = "ロード";
            this.loadScore.UseVisualStyleBackColor = true;
            this.loadScore.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // jaket
            // 
            this.jaket.Location = new System.Drawing.Point(178, 202);
            this.jaket.Name = "jaket";
            this.jaket.Size = new System.Drawing.Size(90, 90);
            this.jaket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.jaket.TabIndex = 10;
            this.jaket.TabStop = false;
            // 
            // demoPlay
            // 
            this.demoPlay.Location = new System.Drawing.Point(178, 169);
            this.demoPlay.Name = "demoPlay";
            this.demoPlay.Size = new System.Drawing.Size(90, 27);
            this.demoPlay.TabIndex = 9;
            this.demoPlay.Text = "再生";
            this.demoPlay.UseVisualStyleBackColor = true;
            this.demoPlay.Click += new System.EventHandler(this.demoPlay_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "ジャケット:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "デモ音源:";
            // 
            // musicPlay
            // 
            this.musicPlay.Location = new System.Drawing.Point(178, 135);
            this.musicPlay.Name = "musicPlay";
            this.musicPlay.Size = new System.Drawing.Size(90, 27);
            this.musicPlay.TabIndex = 7;
            this.musicPlay.Text = "再生";
            this.musicPlay.UseVisualStyleBackColor = true;
            this.musicPlay.Click += new System.EventHandler(this.musicPlay_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "音源:";
            // 
            // levelName
            // 
            this.levelName.Location = new System.Drawing.Point(148, 325);
            this.levelName.Name = "levelName";
            this.levelName.Size = new System.Drawing.Size(120, 22);
            this.levelName.TabIndex = 5;
            // 
            // level
            // 
            this.level.Location = new System.Drawing.Point(148, 297);
            this.level.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(120, 22);
            this.level.TabIndex = 4;
            this.level.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.level.ValueChanged += new System.EventHandler(this.level_ValueChanged);
            // 
            // artist
            // 
            this.artist.Enabled = false;
            this.artist.Location = new System.Drawing.Point(84, 93);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(184, 22);
            this.artist.TabIndex = 3;
            // 
            // genre
            // 
            this.genre.Enabled = false;
            this.genre.Location = new System.Drawing.Point(84, 62);
            this.genre.Name = "genre";
            this.genre.Size = new System.Drawing.Size(184, 22);
            this.genre.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "レベル:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "アーティスト:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "ジャンル:";
            // 
            // title
            // 
            this.title.Enabled = false;
            this.title.Location = new System.Drawing.Point(84, 30);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(184, 22);
            this.title.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "タイトル:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.correction);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.notetype);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.bpm);
            this.groupBox2.Controls.Add(this.quantize);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(700, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 169);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "編集設定";
            // 
            // correction
            // 
            this.correction.Enabled = false;
            this.correction.Location = new System.Drawing.Point(146, 141);
            this.correction.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.correction.Name = "correction";
            this.correction.Size = new System.Drawing.Size(120, 22);
            this.correction.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "補正:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新規作成NToolStripButton,
            this.開くOToolStripButton,
            this.上書き保存SToolStripButton,
            this.toolStripSeparator,
            this.Cursor,
            this.pencil,
            this.eraser,
            this.toolStripSeparator1,
            this.initialPlay,
            this.play,
            this.stop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(996, 27);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 新規作成NToolStripButton
            // 
            this.新規作成NToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.新規作成NToolStripButton.Enabled = false;
            this.新規作成NToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("新規作成NToolStripButton.Image")));
            this.新規作成NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新規作成NToolStripButton.Name = "新規作成NToolStripButton";
            this.新規作成NToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.新規作成NToolStripButton.Text = "新規作成(&N)";
            // 
            // 開くOToolStripButton
            // 
            this.開くOToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.開くOToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("開くOToolStripButton.Image")));
            this.開くOToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.開くOToolStripButton.Name = "開くOToolStripButton";
            this.開くOToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.開くOToolStripButton.Text = "開く(&O)";
            this.開くOToolStripButton.Click += new System.EventHandler(this.開くOToolStripButton_Click);
            // 
            // 上書き保存SToolStripButton
            // 
            this.上書き保存SToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.上書き保存SToolStripButton.Enabled = false;
            this.上書き保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("上書き保存SToolStripButton.Image")));
            this.上書き保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.上書き保存SToolStripButton.Name = "上書き保存SToolStripButton";
            this.上書き保存SToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.上書き保存SToolStripButton.Text = "上書き保存(&S)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // Cursor
            // 
            this.Cursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cursor.Image = ((System.Drawing.Image)(resources.GetObject("Cursor.Image")));
            this.Cursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cursor.Name = "Cursor";
            this.Cursor.Size = new System.Drawing.Size(24, 24);
            this.Cursor.Text = "選択";
            this.Cursor.Click += new System.EventHandler(this.Cursor_Click);
            // 
            // pencil
            // 
            this.pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pencil.Image = ((System.Drawing.Image)(resources.GetObject("pencil.Image")));
            this.pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pencil.Name = "pencil";
            this.pencil.Size = new System.Drawing.Size(24, 24);
            this.pencil.Text = "編集";
            this.pencil.Click += new System.EventHandler(this.pencil_Click);
            // 
            // eraser
            // 
            this.eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraser.Image = ((System.Drawing.Image)(resources.GetObject("eraser.Image")));
            this.eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraser.Name = "eraser";
            this.eraser.Size = new System.Drawing.Size(24, 24);
            this.eraser.Text = "削除";
            this.eraser.Click += new System.EventHandler(this.eraser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // initialPlay
            // 
            this.initialPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.initialPlay.Image = ((System.Drawing.Image)(resources.GetObject("initialPlay.Image")));
            this.initialPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.initialPlay.Name = "initialPlay";
            this.initialPlay.Size = new System.Drawing.Size(24, 24);
            this.initialPlay.Text = "最初から再生";
            this.initialPlay.Click += new System.EventHandler(this.initialPlay_Click);
            // 
            // play
            // 
            this.play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.play.Image = ((System.Drawing.Image)(resources.GetObject("play.Image")));
            this.play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(24, 24);
            this.play.Text = "現在位置から再生";
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // stop
            // 
            this.stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stop.Image = ((System.Drawing.Image)(resources.GetObject("stop.Image")));
            this.stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(24, 24);
            this.stop.Text = "停止";
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 626);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bpm)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jaket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.level)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.correction)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ComboBox quantize;
        private System.Windows.Forms.NumericUpDown bpm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox notetype;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button loadScore;
        private System.Windows.Forms.PictureBox jaket;
        private System.Windows.Forms.Button demoPlay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button musicPlay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox levelName;
        private System.Windows.Forms.NumericUpDown level;
        private System.Windows.Forms.TextBox artist;
        private System.Windows.Forms.TextBox genre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 新規作成NToolStripButton;
        private System.Windows.Forms.ToolStripButton 開くOToolStripButton;
        private System.Windows.Forms.ToolStripButton 上書き保存SToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton Cursor;
        private System.Windows.Forms.ToolStripButton pencil;
        private System.Windows.Forms.ToolStripButton eraser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton initialPlay;
        private System.Windows.Forms.ToolStripButton play;
        private System.Windows.Forms.ToolStripButton stop;
        private System.Windows.Forms.NumericUpDown correction;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button saveScore;
        private System.Windows.Forms.TextBox jaketName;
        private System.Windows.Forms.TextBox demoName;
        private System.Windows.Forms.TextBox musicName;
    }
}

