using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SongSorter.Model;

using File = System.IO.File;

namespace SongSorter
{
    public partial class MainForm : Form
    {
        private const string Mp3Extension = ".mp3";
        private const char SortArrowAsc = '↓';
        private const char SortArrowDesc = '↑';
        private const string PathSeparator = "\\";
        private const string AllowedFileNameChars =
            "0123456789" +
            "abcdefghijklmnopqrstuvwxyz" +
            "абвгдеёжзийклмнопрстуфхцчшщъыьэюя" +
            " !@#№&()_-+=[]',.";

        private static Dictionary<Char, Char> FileNameCharsReplaceDict = new Dictionary<char, char>
        {
            ['~'] = '-',
            [';'] = ',',
        };

        public MainForm()
        {
            InitializeComponent();
        }

        #region Event handlers

        private void MainForm_Shown(object sender, EventArgs e)
        {
            EnableControls();
            UpdateCheckedFilesCountLabel();
            StopProgress();
        }

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                OpenSourceFolder();
            }
        }

        private void OpenSourceFolder()
        {
            try
            {
                var folderPath = folderDialog.SelectedPath;
                if (!Directory.Exists(folderPath))
                {
                    MessageBox.Show(string.Format("Папка {0} не найдена!", folderPath), @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var files = Directory.GetFiles(folderPath);
                var sourceFiles = new List<FileModel>(files.Length);
                foreach (var filePath in files)
                {
                    var beforefileName = Path.GetFileName(filePath);
                    bool isSystemOrHidden;
                    try
                    {
                        var attributes = File.GetAttributes(filePath);
                        isSystemOrHidden = (attributes & (FileAttributes.System | FileAttributes.Hidden)) != 0;
                    }
                    catch
                    {
                        continue;
                    }

                    var fileModel = new FileModel
                    {
                        BeforeFilePath = filePath,
                        BeforeFileName = beforefileName,
                        AfterFileName = beforefileName,
                        IsSystemOrHidden = isSystemOrHidden,
                    };
                    var extension = Path.GetExtension(filePath);
                    if (!string.IsNullOrWhiteSpace(extension) && string.Compare(extension, Mp3Extension, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        fileModel.IsSelected = true;
                    }
                    sourceFiles.Add(fileModel);
                }

                lblSourceFolder.Text = folderPath;
                _folderPath = folderPath;
                _sourceFilesAll = sourceFiles.OrderBy(x => x.BeforeFileName).ToList();
                _needFolderReopen = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Неожиданная ошибка: {0}", ex.Message), @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResetSourceList();
            SetInitialSorting();
        }

        private void btnOpenSourceFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_folderPath))
            {
                try
                {
                    Process.Start(_folderPath);
                }
                catch { }
            }
        }

        private void btnCheckAllOrNone_Click(object sender, EventArgs e)
        {
            if (_sourceFiles == null)
            {
                return;
            }

            var needSelect = !_sourceFiles.All(x => x.IsSelected);
            foreach (var fileModel in _sourceFiles)
            {
                fileModel.IsSelected = needSelect;
            }

            UpdateTable();
            EnableControls();
        }

        private void btnClearNames_Click(object sender, EventArgs e)
        {
            CleanNumbers();
            UpdateTable();
            EnableControls();
        }

        private void btnSequentualNames_Click(object sender, EventArgs e)
        {
            MakeNumberedNames(false);
            UpdateTable();
            EnableControls();
        }

        private void btnRandomNames_Click(object sender, EventArgs e)
        {
            MakeNumberedNames(true);
            UpdateTable();
            EnableControls();
        }

        private void btnRenameFiles_Click(object sender, EventArgs e)
        {
            EnableRenameButton();
            UpdateCheckedFilesCountLabel();

            if (!btnRenameFiles.Enabled || _sourceFiles == null)
            {
                return;
            }

            var selectedSourceFiles = _sourceFiles.Where(x => x.IsSelected).ToList();
            if (!selectedSourceFiles.Any())
            {
                return;
            }

            Action updateProgress = () =>
            {
                UpdateProgressText(string.Format("Переименование файлов.{2}Обработано файлов: {0} из {1}.", _filesCntProcessed, _foldersCntProcessed, Environment.NewLine));
            };
            StartProgress();
            _foldersCntProcessed = selectedSourceFiles.Count;

            try
            {
                var errors = new List<Tuple<string, string>>();
                foreach (var fileModel in selectedSourceFiles)
                {
                    try
                    {
                        var destFilePath = Path.Combine(_folderPath, fileModel.AfterFileName);
                        File.Move(fileModel.BeforeFilePath, destFilePath);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(new Tuple<string, string>(fileModel.BeforeFileName, fileModel.AfterFileName));
                    }

                    _filesCntProcessed++;
                    updateProgress();
                }

                if (errors.Any())
                {
                    var text = new StringBuilder();
                    var index = 1;
                    foreach (var error in errors)
                    {
                        text.AppendLine();
                        text.AppendLine(string.Format("{0}.  {1}\n->  {2}", index, error.Item1, error.Item2));
                        index++;
                    }
                    MessageBox.Show(string.Format("Переименование завершено.\nНе удалось переименовать следующие {0} файлов из {1}:\n",
                            errors.Count, selectedSourceFiles.Count) + text,
                        @"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(@"Файлы переименованы успешно!", @"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // To force user reselect a folder
                _needFolderReopen = true;

                EnableControls();
                btnSelectSourceFolder.Focus();
            }
            finally
            {
                StopProgress();
            }
        }

        private void btnReplaceFileProperties_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_folderPath))
            {
                return;
            }

            StartProgress();
            ReplaceFileProperties(_folderPath, chbxReplacePropertiesInSubfolders.Checked, true);
            StopProgress();
        }

        private void btnDeleteHiddenFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_folderPath))
            {
                return;
            }

            StartProgress();
            var fileCount = DeleteHiddenFiles(_folderPath, chbxDeleteFilesInSubfolders.Checked);
            MessageBox.Show(string.Format("Удалено скрытых файлов: {0}", fileCount), @"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StopProgress();

            OpenSourceFolder();
        }

        private void btnRemoveCharsInFileNames_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_folderPath))
            {
                return;
            }

            StartProgress();
            var fileCount = RemoveCharsInFileNames(_folderPath, chbxRemoveCharsInSubfolders.Checked);
            MessageBox.Show(string.Format("Символы удалены в именах {0} файлов", fileCount), @"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StopProgress();

            // To force user reselect a folder
            _needFolderReopen = true;

            EnableControls();
            btnSelectSourceFolder.Focus();
        }

        private void dgvFiles_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.ColumnIndex < 0)
            {
                return;
            }

            SortByColumn(e.ColumnIndex);
        }

        private void dgvFiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            EnableRenameButton();
            UpdateCheckedFilesCountLabel();
        }

        private void pnlForControls_Enter(object sender, EventArgs e)
        {
            EnableRenameButton();
            UpdateCheckedFilesCountLabel();
        }

        private void chbxShowHiddenFiles_CheckedChanged(object sender, EventArgs e)
        {
            ResetSourceList();
        }

        #endregion

        #region Private methods

        private void EnableControls()
        {
            var hasSourceFolderPath = !string.IsNullOrWhiteSpace(_folderPath);
            var hasAnySourceFiles = _sourceFiles != null && _sourceFiles.Any();
            var hasCheckedSourceFiles = hasAnySourceFiles && _sourceFiles.Any(x => x.IsSelected);
            var needFolderReopen = _needFolderReopen;

            btnCheckAllOrNone.Enabled = hasAnySourceFiles && !needFolderReopen;
            btnOpenSourceFolder.Enabled = hasSourceFolderPath;

            btnClearNames.Enabled = btnSequentualNames.Enabled = btnRandomNames.Enabled = hasAnySourceFiles && !needFolderReopen;
            btnRenameFiles.Enabled = hasCheckedSourceFiles && !needFolderReopen;

            btnReplaceFileProperties.Enabled = chbxReplacePropertiesInSubfolders.Enabled = hasSourceFolderPath && !needFolderReopen;
            btnDeleteHiddenFiles.Enabled = chbxDeleteFilesInSubfolders.Enabled = hasSourceFolderPath && !needFolderReopen;
            btnRemoveCharsInFileNames.Enabled = chbxRemoveCharsInSubfolders.Enabled = hasSourceFolderPath && !needFolderReopen;
        }

        private void EnableRenameButton()
        {
            var hasAnySourceFiles = _sourceFiles != null && _sourceFiles.Any();
            var hasCheckedSourceFiles = hasAnySourceFiles && _sourceFiles.Any(x => x.IsSelected);
            var needFolderReopen = _needFolderReopen;

            btnRenameFiles.Enabled = hasCheckedSourceFiles && !needFolderReopen;
        }

        private void UpdateCheckedFilesCountLabel()
        {
            var allCount = 0;
            var checkedCount = 0;
            if (_sourceFiles != null)
            {
                allCount = _sourceFiles.Count;
                checkedCount = _sourceFiles.Count(x => x.IsSelected);
            }
            lblCheckedFilesCount.Text = string.Format("Выбрано файлов: {0} из {1}", checkedCount, allCount);
        }

        private void UpdateTable()
        {
            var newFiles = (_sourceFiles == null) ? new List<FileModel>() : new List<FileModel>(_sourceFiles);
            bsSourceFiles.DataSource = newFiles;
            _sourceFiles = newFiles;
        }

        private void ResetSourceList()
        {
            if (_sourceFilesAll != null)
            {
                var query = _sourceFilesAll.AsQueryable();
                if (!chbxShowHiddenFiles.Checked)
                {
                    query = query.Where(x => !x.IsSystemOrHidden);
                }
                _sourceFiles = query.ToList();
            }

            UpdateTable();
            EnableControls();
            UpdateCheckedFilesCountLabel();
            Resort();
        }

        private void SortByColumn(int columnIndex)
        {
            // Ascending/descending order by special characters: ↑↓.

            if (_sourceFiles == null || !_sourceFiles.Any())
            {
                return;
            }

            ResetSortingDisplay();

            if (_columnSorting != ColumnSorting.None)
            {
                var colIndex = ((int)_columnSorting - 1) / 2;
                var col = dgvFiles.Columns[colIndex];
                col.HeaderText = col.HeaderText.TrimEnd(SortArrowAsc, SortArrowDesc, ' ');
            }

            var columnSorting = columnIndex * 2 + 1;
            var asc = true;
            if ((int)_columnSorting == columnSorting)
            {
                columnSorting += 1;
                asc = false;
            }
            _columnSorting = (ColumnSorting)columnSorting;

            IQueryable<FileModel> query = null;
            switch (_columnSorting)
            {
                case ColumnSorting.IsSelectedAsc:
                    query = _sourceFiles.OrderBy(x => x.IsSelected).AsQueryable();
                    break;
                case ColumnSorting.IsSelectedDesc:
                    query = _sourceFiles.OrderByDescending(x => x.IsSelected).AsQueryable();
                    break;
                case ColumnSorting.BeforeFileNameAsc:
                    query = _sourceFiles.OrderBy(x => x.BeforeFileName).AsQueryable();
                    break;
                case ColumnSorting.BeforeFileNameDesc:
                    query = _sourceFiles.OrderByDescending(x => x.BeforeFileName).AsQueryable();
                    break;
                case ColumnSorting.AfterFileNameAsc:
                    query = _sourceFiles.OrderBy(x => x.AfterFileName).AsQueryable();
                    break;
                case ColumnSorting.AfterFileNameDesc:
                    query = _sourceFiles.OrderByDescending(x => x.AfterFileName).AsQueryable();
                    break;
            }
            if (query != null)
            {
                _sourceFiles = query.ToList();
                UpdateTable();

                var col = dgvFiles.Columns[columnIndex];
                col.HeaderText = col.HeaderText + ' ' + (asc ? SortArrowAsc : SortArrowDesc);
            }
        }

        private void ResetSortingDisplay()
        {
            if (_columnSorting != ColumnSorting.None)
            {
                var colIndex = ((int)_columnSorting - 1) / 2;
                var col = dgvFiles.Columns[colIndex];
                col.HeaderText = col.HeaderText.TrimEnd(SortArrowAsc, SortArrowDesc, ' ');
            }
        }

        private void SetInitialSorting()
        {
            ResetSortingDisplay();
            _columnSorting = ColumnSorting.None;

            // 1 means "Original file name" column
            SortByColumn(1);
        }

        private void Resort()
        {
            if (_columnSorting != ColumnSorting.None)
            {
                var colIndex = ((int)_columnSorting - 1) / 2;

                // Do it twice to keep the same ordering direction (asc/desc)
                SortByColumn(colIndex);
                SortByColumn(colIndex);
            }
        }

        private void CleanNumbers()
        {
            const string numberPattern = @"^[\d\s\+\.\-\[\]\(\)_–=~,`'#]*";

            if (_sourceFiles == null)
            {
                return;
            }

            var regex = new Regex(numberPattern);

            var selectedSourceFiles = _sourceFiles.Where(x => x.IsSelected).ToList();
            foreach (var fileModel in selectedSourceFiles)
            {
                var beforeName = fileModel.BeforeFileName;
                if (string.IsNullOrWhiteSpace(beforeName))
                {
                    continue;
                }

                var match = regex.Match(beforeName);
                if (match.Success)
                {
                    var matchedValue = match.Value;
                    beforeName = beforeName.Substring(matchedValue.Length);
                }

                fileModel.AfterFileName = beforeName;
            }
        }

        private void MakeNumberedNames(bool randomly)
        {
            var startFromNumber = (int)nudStartFromNumber.Value;
            var digitsCount = (int)nudDigitsCount.Value;
            var pattern = tbxNumberSeparator.Text;

            if (_sourceFiles == null)
            {
                return;
            }

            var selectedSourceFiles = _sourceFiles.Where(x => x.IsSelected).ToList();
            var selectedCount = selectedSourceFiles.Count;
            if (selectedCount == 0)
            {
                return;
            }

            var numbers = new List<int>(selectedCount);
            for (var i = 0; i < selectedCount; i++)
            {
                numbers.Add(startFromNumber + i);
            }

            if (randomly)
            {
                var rnd = new Random();
                var mixedNumbers = new List<int>(selectedCount);
                for (var i = 0; i < selectedCount; i++)
                {
                    var randomPos = rnd.Next(0, numbers.Count);
                    mixedNumbers.Add(numbers[randomPos]);
                    numbers.RemoveAt(randomPos);
                }
                numbers = mixedNumbers;
            }

            var index = 0;
            foreach (var fileModel in selectedSourceFiles)
            {
                var afterName = string.Format("{0:D" + digitsCount + "}{1}{2}", numbers[index], pattern, fileModel.AfterFileName);
                fileModel.AfterFileName = afterName;
                index++;
            }
        }

        private void ReplaceFileProperties(string folderPath, bool alsoInSubfolders, bool mainCall)
        {
            Action updateProgress = () =>
            {
                UpdateProgressText(string.Format("Изменение свойств файлов.{2}Обработано {0} папок, {1} файлов.", _foldersCntProcessed, _filesCntProcessed, Environment.NewLine));
            };

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    return;
                }

                try
                {
                    var files = Directory.GetFiles(folderPath);
                    foreach (var filePath in files)
                    {
                        try
                        {
                            var extension = Path.GetExtension(filePath);
                            if (string.IsNullOrEmpty(extension) || Mp3Extension != extension.ToLower())
                            {
                                continue;
                            }

                            var fileName = Path.GetFileNameWithoutExtension(filePath);
                            using (var tlFile = TagLib.File.Create(filePath))
                            {
                                tlFile.Tag.Title = fileName;
                                tlFile.Save();
                            }
                        }
                        catch (Exception ex)
                        {
                            // Do nothing.
                        }

                        _filesCntProcessed++;
                        updateProgress();
                    }
                }
                catch
                {
                    // Do nothing.
                }

                _foldersCntProcessed++;
                updateProgress();

                if (alsoInSubfolders)
                {
                    try
                    {
                        var dirs = Directory.GetDirectories(folderPath);
                        foreach (var dir in dirs)
                        {
                            try
                            {
                                ReplaceFileProperties(dir, true, false);
                            }
                            catch
                            {
                                // Do nothing.
                            }
                        }
                    }
                    catch
                    {
                        // Do nothing.
                    }
                }

                if (mainCall)
                {
                    MessageBox.Show(@"Свойства файлов изменены успешно!", @"Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Неожиданная ошибка: {0}", ex.Message), @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int DeleteHiddenFiles(string folderPath, bool alsoInSubfolders)
        {
            Action updateProgress = () =>
            {
                UpdateProgressText(string.Format("Удаление скрытых файлов.{2}Обработано {0} папок, {1} файлов.", _foldersCntProcessed, _filesCntProcessed, Environment.NewLine));
            };

            var result = 0;
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    return result;
                }

                try
                {
                    var files = Directory.GetFiles(folderPath);
                    foreach (var filePath in files)
                    {
                        try
                        {
                            var attributes = File.GetAttributes(filePath);
                            if ((attributes & (FileAttributes.System | FileAttributes.Hidden)) != 0)
                            {
                                File.SetAttributes(filePath, attributes & ~FileAttributes.ReadOnly);
                                File.Delete(filePath);
                                result++;
                            }
                        }
                        catch (Exception ex)
                        {
                            // Do nothing.
                        }

                        _filesCntProcessed++;
                        updateProgress();
                    }
                }
                catch
                {
                    // Do nothing.
                }

                _foldersCntProcessed++;
                updateProgress();

                if (alsoInSubfolders)
                {
                    try
                    {
                        var dirs = Directory.GetDirectories(folderPath);
                        foreach (var dir in dirs)
                        {
                            try
                            {
                                result += DeleteHiddenFiles(dir, true);
                            }
                            catch
                            {
                                // Do nothing.
                            }
                        }
                    }
                    catch
                    {
                        // Do nothing.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Неожиданная ошибка: {0}", ex.Message), @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private int RemoveCharsInFileNames(string folderPath, bool alsoInSubfolders)
        {
            Action updateProgress = () =>
            {
                UpdateProgressText(string.Format("Стирание символов в именах файлов.{2}Обработано {0} папок, {1} файлов.", _foldersCntProcessed, _filesCntProcessed, Environment.NewLine));
            };

            var result = 0;
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    return result;
                }

                try
                {
                    var files = Directory.GetFiles(folderPath);
                    foreach (var filePath in files)
                    {
                        var pathWithClearedName = GetClearedFileName2(filePath);
                        if (filePath != pathWithClearedName)
                        {
                            try
                            {
                                File.Move(filePath, pathWithClearedName);
                                result++;
                            }
                            catch (Exception ex)
                            {
                                // Do nothing.
                            }
                        }

                        _filesCntProcessed++;
                        updateProgress();
                    }
                }
                catch
                {
                    // Do nothing.
                }

                _foldersCntProcessed++;
                updateProgress();

                if (alsoInSubfolders)
                {
                    try
                    {
                        var dirs = Directory.GetDirectories(folderPath);
                        foreach (var dir in dirs)
                        {
                            try
                            {
                                result += RemoveCharsInFileNames(dir, true);
                            }
                            catch
                            {
                                // Do nothing.
                            }
                        }
                    }
                    catch
                    {
                        // Do nothing.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Неожиданная ошибка: {0}", ex.Message), @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private string GetClearedFileName1(string filePath)
        {
            var pathParts = filePath.Split(PathSeparator.ToCharArray());
            var sb = new StringBuilder(pathParts.Last());
            foreach (var ch in tbxCharsToRemove.Text)
            {
                sb = sb.Replace(ch.ToString(), "");
            }

            pathParts[pathParts.Length - 1] = sb.ToString();
            var clearedPath = string.Join(PathSeparator, pathParts);
            return clearedPath;
        }

        private string GetClearedFileName2(string filePath)
        {
            var pathParts = filePath.Split(PathSeparator.ToCharArray());
            var lastPart = pathParts.Last();
            var sb = new StringBuilder(lastPart.Length);

            foreach (var ch in lastPart)
            {
                if (AllowedFileNameChars.Contains(ch.ToString().ToLower()))
                {
                    sb.Append(ch);
                }
                else if (FileNameCharsReplaceDict.ContainsKey(ch))
                {
                    sb.Append(FileNameCharsReplaceDict[ch]);
                }
            }

            pathParts[pathParts.Length - 1] = sb.ToString();
            var clearedPath = string.Join(PathSeparator, pathParts);
            return clearedPath;
        }

        private void StartProgress()
        {
            StartProgress(true);
        }

        private void StopProgress()
        {
            StartProgress(false);
        }

        private void StartProgress(bool start)
        {
            _foldersCntProcessed = 0;
            _filesCntProcessed = 0;

            pnlForTable.Enabled = !start;
            pnlForControls.Enabled = !start;

            pnlProgress.Visible = start;
            tbxProgress.Text = string.Empty;

            Application.DoEvents();
        }

        private void UpdateProgressText(string text)
        {
            tbxProgress.Text = text;
            Application.DoEvents();
        }

        #endregion

        #region  Private definitions

        private enum ColumnSorting
        {
            None = 0,
            IsSelectedAsc = 1,
            IsSelectedDesc = 2,
            BeforeFileNameAsc = 3,
            BeforeFileNameDesc = 4,
            AfterFileNameAsc = 5,
            AfterFileNameDesc = 6,
        }

        #endregion

        #region  Private fields

        private List<FileModel> _sourceFilesAll;
        private List<FileModel> _sourceFiles;
        private string _folderPath;
        private bool _needFolderReopen;
        private ColumnSorting _columnSorting = ColumnSorting.None;

        private int _foldersCntProcessed;
        private int _filesCntProcessed;

        #endregion
    }
}