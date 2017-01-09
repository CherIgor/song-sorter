namespace SongSorter
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.pnlForControls = new System.Windows.Forms.Panel();
            this.btnRemoveCharsInFileNames = new System.Windows.Forms.Button();
            this.chbxRemoveCharsInSubfolders = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCharsToRemove = new System.Windows.Forms.TextBox();
            this.chbxReplacePropertiesInSubfolders = new System.Windows.Forms.CheckBox();
            this.btnReplaceFileProperties = new System.Windows.Forms.Button();
            this.btnRenameFiles = new System.Windows.Forms.Button();
            this.btnDeleteHiddenFiles = new System.Windows.Forms.Button();
            this.chbxDeleteFilesInSubfolders = new System.Windows.Forms.CheckBox();
            this.chbxShowHiddenFiles = new System.Windows.Forms.CheckBox();
            this.lblCheckedFilesCount = new System.Windows.Forms.Label();
            this.btnCheckAllOrNone = new System.Windows.Forms.Button();
            this.btnOpenSourceFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStartFromNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxNumberSeparator = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudDigitsCount = new System.Windows.Forms.NumericUpDown();
            this.btnSequentualNames = new System.Windows.Forms.Button();
            this.btnClearNames = new System.Windows.Forms.Button();
            this.lblSourceFolder = new System.Windows.Forms.Label();
            this.btnRandomNames = new System.Windows.Forms.Button();
            this.pnlForTable = new System.Windows.Forms.Panel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.tbxProgress = new System.Windows.Forms.TextBox();
            this.isSelectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.beforeFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afterFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSourceFiles = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.pnlForControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFromNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDigitsCount)).BeginInit();
            this.pnlForTable.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSourceFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(12, 9);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(140, 42);
            this.btnSelectSourceFolder.TabIndex = 0;
            this.btnSelectSourceFolder.Text = "Выбрать\r\nпапку";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Выбор папки с песнями";
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isSelectedDataGridViewCheckBoxColumn,
            this.beforeFileNameDataGridViewTextBoxColumn,
            this.afterFileNameDataGridViewTextBoxColumn});
            this.dgvFiles.DataSource = this.bsSourceFiles;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFiles.Location = new System.Drawing.Point(0, 0);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFiles.RowHeadersWidth = 30;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFiles.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFiles.Size = new System.Drawing.Size(1178, 455);
            this.dgvFiles.TabIndex = 0;
            this.dgvFiles.TabStop = false;
            this.dgvFiles.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFiles_ColumnHeaderMouseClick);
            this.dgvFiles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_RowEnter);
            // 
            // pnlForControls
            // 
            this.pnlForControls.Controls.Add(this.btnRemoveCharsInFileNames);
            this.pnlForControls.Controls.Add(this.chbxRemoveCharsInSubfolders);
            this.pnlForControls.Controls.Add(this.label4);
            this.pnlForControls.Controls.Add(this.tbxCharsToRemove);
            this.pnlForControls.Controls.Add(this.chbxReplacePropertiesInSubfolders);
            this.pnlForControls.Controls.Add(this.btnReplaceFileProperties);
            this.pnlForControls.Controls.Add(this.btnRenameFiles);
            this.pnlForControls.Controls.Add(this.btnDeleteHiddenFiles);
            this.pnlForControls.Controls.Add(this.chbxDeleteFilesInSubfolders);
            this.pnlForControls.Controls.Add(this.chbxShowHiddenFiles);
            this.pnlForControls.Controls.Add(this.lblCheckedFilesCount);
            this.pnlForControls.Controls.Add(this.btnCheckAllOrNone);
            this.pnlForControls.Controls.Add(this.btnOpenSourceFolder);
            this.pnlForControls.Controls.Add(this.label3);
            this.pnlForControls.Controls.Add(this.nudStartFromNumber);
            this.pnlForControls.Controls.Add(this.label2);
            this.pnlForControls.Controls.Add(this.tbxNumberSeparator);
            this.pnlForControls.Controls.Add(this.label1);
            this.pnlForControls.Controls.Add(this.nudDigitsCount);
            this.pnlForControls.Controls.Add(this.btnSequentualNames);
            this.pnlForControls.Controls.Add(this.btnClearNames);
            this.pnlForControls.Controls.Add(this.lblSourceFolder);
            this.pnlForControls.Controls.Add(this.btnRandomNames);
            this.pnlForControls.Controls.Add(this.btnSelectSourceFolder);
            this.pnlForControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlForControls.Location = new System.Drawing.Point(0, 455);
            this.pnlForControls.Name = "pnlForControls";
            this.pnlForControls.Size = new System.Drawing.Size(1178, 178);
            this.pnlForControls.TabIndex = 0;
            this.pnlForControls.Enter += new System.EventHandler(this.pnlForControls_Enter);
            // 
            // btnRemoveCharsInFileNames
            // 
            this.btnRemoveCharsInFileNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCharsInFileNames.Location = new System.Drawing.Point(540, 89);
            this.btnRemoveCharsInFileNames.Name = "btnRemoveCharsInFileNames";
            this.btnRemoveCharsInFileNames.Size = new System.Drawing.Size(200, 63);
            this.btnRemoveCharsInFileNames.TabIndex = 18;
            this.btnRemoveCharsInFileNames.Text = "Стереть символы в названиях файлов в выбранной папке";
            this.btnRemoveCharsInFileNames.UseVisualStyleBackColor = true;
            this.btnRemoveCharsInFileNames.Click += new System.EventHandler(this.btnRemoveCharsInFileNames_Click);
            // 
            // chbxRemoveCharsInSubfolders
            // 
            this.chbxRemoveCharsInSubfolders.AutoSize = true;
            this.chbxRemoveCharsInSubfolders.Checked = true;
            this.chbxRemoveCharsInSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxRemoveCharsInSubfolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbxRemoveCharsInSubfolders.Location = new System.Drawing.Point(541, 151);
            this.chbxRemoveCharsInSubfolders.Name = "chbxRemoveCharsInSubfolders";
            this.chbxRemoveCharsInSubfolders.Size = new System.Drawing.Size(199, 20);
            this.chbxRemoveCharsInSubfolders.TabIndex = 19;
            this.chbxRemoveCharsInSubfolders.Text = "Стереть в т.ч. в подпапках";
            this.chbxRemoveCharsInSubfolders.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(803, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 32);
            this.label4.TabIndex = 16;
            this.label4.Text = "Стереть символы\r\nв названиях";
            this.label4.Visible = false;
            // 
            // tbxCharsToRemove
            // 
            this.tbxCharsToRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCharsToRemove.Location = new System.Drawing.Point(931, 14);
            this.tbxCharsToRemove.MaxLength = 15;
            this.tbxCharsToRemove.Name = "tbxCharsToRemove";
            this.tbxCharsToRemove.Size = new System.Drawing.Size(111, 24);
            this.tbxCharsToRemove.TabIndex = 17;
            this.tbxCharsToRemove.Text = "´`♫♪éú♥ő";
            this.tbxCharsToRemove.Visible = false;
            // 
            // chbxReplacePropertiesInSubfolders
            // 
            this.chbxReplacePropertiesInSubfolders.AutoSize = true;
            this.chbxReplacePropertiesInSubfolders.Checked = true;
            this.chbxReplacePropertiesInSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxReplacePropertiesInSubfolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbxReplacePropertiesInSubfolders.Location = new System.Drawing.Point(749, 151);
            this.chbxReplacePropertiesInSubfolders.Name = "chbxReplacePropertiesInSubfolders";
            this.chbxReplacePropertiesInSubfolders.Size = new System.Drawing.Size(209, 20);
            this.chbxReplacePropertiesInSubfolders.TabIndex = 21;
            this.chbxReplacePropertiesInSubfolders.Text = "Заменить в т.ч. в подпапках";
            this.chbxReplacePropertiesInSubfolders.UseVisualStyleBackColor = true;
            // 
            // btnReplaceFileProperties
            // 
            this.btnReplaceFileProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceFileProperties.Location = new System.Drawing.Point(748, 89);
            this.btnReplaceFileProperties.Name = "btnReplaceFileProperties";
            this.btnReplaceFileProperties.Size = new System.Drawing.Size(216, 63);
            this.btnReplaceFileProperties.TabIndex = 20;
            this.btnReplaceFileProperties.Text = "Заменить заголовок в свойствах на имя файла в выбранной папке";
            this.btnReplaceFileProperties.UseVisualStyleBackColor = true;
            this.btnReplaceFileProperties.Click += new System.EventHandler(this.btnReplaceFileProperties_Click);
            // 
            // btnRenameFiles
            // 
            this.btnRenameFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenameFiles.Location = new System.Drawing.Point(397, 124);
            this.btnRenameFiles.Name = "btnRenameFiles";
            this.btnRenameFiles.Size = new System.Drawing.Size(137, 42);
            this.btnRenameFiles.TabIndex = 9;
            this.btnRenameFiles.Text = "Переименовать файлы";
            this.btnRenameFiles.UseVisualStyleBackColor = true;
            this.btnRenameFiles.Click += new System.EventHandler(this.btnRenameFiles_Click);
            // 
            // btnDeleteHiddenFiles
            // 
            this.btnDeleteHiddenFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteHiddenFiles.Location = new System.Drawing.Point(972, 89);
            this.btnDeleteHiddenFiles.Name = "btnDeleteHiddenFiles";
            this.btnDeleteHiddenFiles.Size = new System.Drawing.Size(200, 63);
            this.btnDeleteHiddenFiles.TabIndex = 23;
            this.btnDeleteHiddenFiles.Text = "Удалить все скрытые файлы в выбранной папке";
            this.btnDeleteHiddenFiles.UseVisualStyleBackColor = true;
            this.btnDeleteHiddenFiles.Click += new System.EventHandler(this.btnDeleteHiddenFiles_Click);
            // 
            // chbxDeleteFilesInSubfolders
            // 
            this.chbxDeleteFilesInSubfolders.AutoSize = true;
            this.chbxDeleteFilesInSubfolders.Checked = true;
            this.chbxDeleteFilesInSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxDeleteFilesInSubfolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbxDeleteFilesInSubfolders.Location = new System.Drawing.Point(973, 151);
            this.chbxDeleteFilesInSubfolders.Name = "chbxDeleteFilesInSubfolders";
            this.chbxDeleteFilesInSubfolders.Size = new System.Drawing.Size(200, 20);
            this.chbxDeleteFilesInSubfolders.TabIndex = 0;
            this.chbxDeleteFilesInSubfolders.Text = "Удалить в т.ч. в подпапках";
            this.chbxDeleteFilesInSubfolders.UseVisualStyleBackColor = true;
            // 
            // chbxShowHiddenFiles
            // 
            this.chbxShowHiddenFiles.AutoSize = true;
            this.chbxShowHiddenFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbxShowHiddenFiles.Location = new System.Drawing.Point(12, 133);
            this.chbxShowHiddenFiles.Name = "chbxShowHiddenFiles";
            this.chbxShowHiddenFiles.Size = new System.Drawing.Size(129, 36);
            this.chbxShowHiddenFiles.TabIndex = 5;
            this.chbxShowHiddenFiles.Text = "Показывать\r\nскрытые файлы";
            this.chbxShowHiddenFiles.UseVisualStyleBackColor = true;
            this.chbxShowHiddenFiles.CheckedChanged += new System.EventHandler(this.chbxShowHiddenFiles_CheckedChanged);
            // 
            // lblCheckedFilesCount
            // 
            this.lblCheckedFilesCount.AutoSize = true;
            this.lblCheckedFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckedFilesCount.Location = new System.Drawing.Point(12, 106);
            this.lblCheckedFilesCount.Name = "lblCheckedFilesCount";
            this.lblCheckedFilesCount.Size = new System.Drawing.Size(165, 16);
            this.lblCheckedFilesCount.TabIndex = 4;
            this.lblCheckedFilesCount.Text = "Выбрано файлов: X из Y";
            // 
            // btnCheckAllOrNone
            // 
            this.btnCheckAllOrNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAllOrNone.Location = new System.Drawing.Point(12, 57);
            this.btnCheckAllOrNone.Name = "btnCheckAllOrNone";
            this.btnCheckAllOrNone.Size = new System.Drawing.Size(140, 43);
            this.btnCheckAllOrNone.TabIndex = 1;
            this.btnCheckAllOrNone.Text = "Выбрать все / ничего";
            this.btnCheckAllOrNone.UseVisualStyleBackColor = true;
            this.btnCheckAllOrNone.Click += new System.EventHandler(this.btnCheckAllOrNone_Click);
            // 
            // btnOpenSourceFolder
            // 
            this.btnOpenSourceFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSourceFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSourceFolder.Image")));
            this.btnOpenSourceFolder.Location = new System.Drawing.Point(158, 57);
            this.btnOpenSourceFolder.Name = "btnOpenSourceFolder";
            this.btnOpenSourceFolder.Size = new System.Drawing.Size(58, 43);
            this.btnOpenSourceFolder.TabIndex = 2;
            this.btnOpenSourceFolder.UseVisualStyleBackColor = true;
            this.btnOpenSourceFolder.Click += new System.EventHandler(this.btnOpenSourceFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(595, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Начать с номера";
            // 
            // nudStartFromNumber
            // 
            this.nudStartFromNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudStartFromNumber.Location = new System.Drawing.Point(715, 31);
            this.nudStartFromNumber.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudStartFromNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStartFromNumber.Name = "nudStartFromNumber";
            this.nudStartFromNumber.Size = new System.Drawing.Size(68, 24);
            this.nudStartFromNumber.TabIndex = 13;
            this.nudStartFromNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(595, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "Разделитель\r\n№ и названия";
            // 
            // tbxNumberSeparator
            // 
            this.tbxNumberSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNumberSeparator.Location = new System.Drawing.Point(715, 59);
            this.tbxNumberSeparator.MaxLength = 15;
            this.tbxNumberSeparator.Name = "tbxNumberSeparator";
            this.tbxNumberSeparator.Size = new System.Drawing.Size(68, 24);
            this.tbxNumberSeparator.TabIndex = 15;
            this.tbxNumberSeparator.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(595, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Цифр в номере";
            // 
            // nudDigitsCount
            // 
            this.nudDigitsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDigitsCount.Location = new System.Drawing.Point(715, 4);
            this.nudDigitsCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDigitsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDigitsCount.Name = "nudDigitsCount";
            this.nudDigitsCount.Size = new System.Drawing.Size(68, 24);
            this.nudDigitsCount.TabIndex = 11;
            this.nudDigitsCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnSequentualNames
            // 
            this.btnSequentualNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSequentualNames.Location = new System.Drawing.Point(232, 94);
            this.btnSequentualNames.Name = "btnSequentualNames";
            this.btnSequentualNames.Size = new System.Drawing.Size(162, 33);
            this.btnSequentualNames.TabIndex = 7;
            this.btnSequentualNames.Text = "Номера по порядку";
            this.btnSequentualNames.UseVisualStyleBackColor = true;
            this.btnSequentualNames.Click += new System.EventHandler(this.btnSequentualNames_Click);
            // 
            // btnClearNames
            // 
            this.btnClearNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearNames.Location = new System.Drawing.Point(232, 56);
            this.btnClearNames.Name = "btnClearNames";
            this.btnClearNames.Size = new System.Drawing.Size(162, 33);
            this.btnClearNames.TabIndex = 6;
            this.btnClearNames.Text = "Стереть номера";
            this.btnClearNames.UseVisualStyleBackColor = true;
            this.btnClearNames.Click += new System.EventHandler(this.btnClearNames_Click);
            // 
            // lblSourceFolder
            // 
            this.lblSourceFolder.AutoSize = true;
            this.lblSourceFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceFolder.Location = new System.Drawing.Point(158, 12);
            this.lblSourceFolder.Name = "lblSourceFolder";
            this.lblSourceFolder.Size = new System.Drawing.Size(68, 32);
            this.lblSourceFolder.TabIndex = 3;
            this.lblSourceFolder.Text = "Папка не\r\nвыбрана";
            // 
            // btnRandomNames
            // 
            this.btnRandomNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomNames.Location = new System.Drawing.Point(232, 133);
            this.btnRandomNames.Name = "btnRandomNames";
            this.btnRandomNames.Size = new System.Drawing.Size(162, 33);
            this.btnRandomNames.TabIndex = 8;
            this.btnRandomNames.Text = "Случайные номера";
            this.btnRandomNames.UseVisualStyleBackColor = true;
            this.btnRandomNames.Click += new System.EventHandler(this.btnRandomNames_Click);
            // 
            // pnlForTable
            // 
            this.pnlForTable.Controls.Add(this.pnlProgress);
            this.pnlForTable.Controls.Add(this.dgvFiles);
            this.pnlForTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForTable.Location = new System.Drawing.Point(0, 0);
            this.pnlForTable.Name = "pnlForTable";
            this.pnlForTable.Size = new System.Drawing.Size(1178, 455);
            this.pnlForTable.TabIndex = 4;
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlProgress.Controls.Add(this.tbxProgress);
            this.pnlProgress.Location = new System.Drawing.Point(316, 73);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(478, 132);
            this.pnlProgress.TabIndex = 1;
            // 
            // tbxProgress
            // 
            this.tbxProgress.BackColor = System.Drawing.SystemColors.Control;
            this.tbxProgress.Enabled = false;
            this.tbxProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxProgress.Location = new System.Drawing.Point(16, 15);
            this.tbxProgress.Multiline = true;
            this.tbxProgress.Name = "tbxProgress";
            this.tbxProgress.ReadOnly = true;
            this.tbxProgress.Size = new System.Drawing.Size(445, 98);
            this.tbxProgress.TabIndex = 0;
            this.tbxProgress.Text = "Progress messages for long operations will be here";
            // 
            // isSelectedDataGridViewCheckBoxColumn
            // 
            this.isSelectedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsSelected";
            this.isSelectedDataGridViewCheckBoxColumn.HeaderText = "Выбрано";
            this.isSelectedDataGridViewCheckBoxColumn.Name = "isSelectedDataGridViewCheckBoxColumn";
            this.isSelectedDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isSelectedDataGridViewCheckBoxColumn.Width = 91;
            // 
            // beforeFileNameDataGridViewTextBoxColumn
            // 
            this.beforeFileNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.beforeFileNameDataGridViewTextBoxColumn.DataPropertyName = "BeforeFileName";
            this.beforeFileNameDataGridViewTextBoxColumn.HeaderText = "Исходное имя";
            this.beforeFileNameDataGridViewTextBoxColumn.Name = "beforeFileNameDataGridViewTextBoxColumn";
            this.beforeFileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.beforeFileNameDataGridViewTextBoxColumn.Width = 115;
            // 
            // afterFileNameDataGridViewTextBoxColumn
            // 
            this.afterFileNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.afterFileNameDataGridViewTextBoxColumn.DataPropertyName = "AfterFileName";
            this.afterFileNameDataGridViewTextBoxColumn.HeaderText = "Новое имя";
            this.afterFileNameDataGridViewTextBoxColumn.Name = "afterFileNameDataGridViewTextBoxColumn";
            this.afterFileNameDataGridViewTextBoxColumn.Width = 96;
            // 
            // bsSourceFiles
            // 
            this.bsSourceFiles.AllowNew = false;
            this.bsSourceFiles.DataSource = typeof(SongSorter.Model.FileModel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 633);
            this.Controls.Add(this.pnlForTable);
            this.Controls.Add(this.pnlForControls);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сортировщик .mp3 и других файлов (v.1.1.3) by Igor Cheremushkin, Taganrog, Russia" +
    "";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.pnlForControls.ResumeLayout(false);
            this.pnlForControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFromNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDigitsCount)).EndInit();
            this.pnlForTable.ResumeLayout(false);
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsSourceFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.BindingSource bsSourceFiles;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Panel pnlForControls;
        private System.Windows.Forms.Button btnRandomNames;
        private System.Windows.Forms.Panel pnlForTable;
        private System.Windows.Forms.Label lblSourceFolder;
        private System.Windows.Forms.Button btnClearNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxNumberSeparator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDigitsCount;
        private System.Windows.Forms.Button btnSequentualNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudStartFromNumber;
        private System.Windows.Forms.Button btnOpenSourceFolder;
        private System.Windows.Forms.Button btnCheckAllOrNone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn beforeFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn afterFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblCheckedFilesCount;
        private System.Windows.Forms.CheckBox chbxShowHiddenFiles;
        private System.Windows.Forms.CheckBox chbxDeleteFilesInSubfolders;
        private System.Windows.Forms.Button btnDeleteHiddenFiles;
        private System.Windows.Forms.Button btnRenameFiles;
        private System.Windows.Forms.CheckBox chbxReplacePropertiesInSubfolders;
        private System.Windows.Forms.Button btnReplaceFileProperties;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.TextBox tbxProgress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxCharsToRemove;
        private System.Windows.Forms.Button btnRemoveCharsInFileNames;
        private System.Windows.Forms.CheckBox chbxRemoveCharsInSubfolders;
    }
}

