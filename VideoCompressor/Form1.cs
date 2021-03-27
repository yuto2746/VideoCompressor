using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoCompressor
{
    public partial class Form1 : Form
    {
        private string[] videoExt = new[] {
            ".mov",
            ".qt",
            ".wmv",
            ".asf",
            ".flv",
            ".m2ts",
            ".ts",
            ".mpeg",
            ".mpg",
            ".mp4",
            ".m4a",
            ".mkv",
            ".asf",
            ".wmv",
            ".wmv",
            ".webm",
            ".ogm"
        };

        private const string VideoExtFilter = "動画ファイル|*.mov;*.qt;*.wmv;*.asf;*.flv;*.m2ts;*.ts;*.mpeg;*.mpg;*.mp4;*.m4a;*.mkv;*.asf;*.wmv;*.wmv;*.webm;*.ogm";


        public Form1()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SelectedCodec = GetSelectedCodec();
            Properties.Settings.Default.Save();
        }

        private string GetSelectedCodec()
        {
            foreach (RadioButton rb in GroupBox_Codec.Controls)
            {
                if (rb.Checked)
                {
                    return rb.Tag.ToString();
                }
            }
            return null;
        }
        private void SelectCodec(string codec)
        {
            foreach (RadioButton rb in GroupBox_Codec.Controls)
            {
                if (rb.Tag.ToString().Equals(codec))
                {
                    rb.Select();
                }
            }
        }

        private void InitializeListView()
        {
            this.ListView.FullRowSelect = true;
            this.ListView.GridLines = true;
            this.ListView.Sorting = SortOrder.Ascending;
            this.ListView.View = View.Details;
            this.ListView.HeaderStyle = ColumnHeaderStyle.Clickable;

            ColumnHeader columnName = new ColumnHeader();
            columnName.Text = "ファイル名";
            columnName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            ColumnHeader columnPath = new ColumnHeader();
            columnPath.Text = "パス";
            columnName.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.ListView.Columns.Add(columnName);
            this.ListView.Columns.Add(columnPath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectCodec(Properties.Settings.Default.SelectedCodec);
        }

        private void ListView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string file in files)
            {
                AddItem(file);
            }

            ResizeListView();
        }

        private void AddItem(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            ListViewItem item = new ListViewItem(fileName);
            item.SubItems.Add(filePath);
            this.ListView.Items.Add(item);
        }

        private void ResizeListView()
        {
            foreach (ColumnHeader column in this.ListView.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Button_FolderSelect_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var folder = fbd.SelectedPath;
            var folderInfo = new DirectoryInfo(folder);
            var files = folderInfo.EnumerateFiles("*", SearchOption.AllDirectories)
                .Where(path => videoExt.Contains(Path.GetExtension(path.FullName)))
                .ToArray();

            var fileCnt = 0;
            foreach (FileInfo file in files)
            {
                AddItem(file.FullName);
                fileCnt++;
            }

            if (fileCnt == 0)
            {
                MessageBox.Show(
                    "動画ファイルが見つかりませんでした",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            ResizeListView();
        }

        private void Button_FileSelect_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = VideoExtFilter
            };
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            foreach (string file in ofd.FileNames)
            {
                AddItem(file);
            }
            ResizeListView();
        }

        private void Button_AllDelete_Click(object sender, EventArgs e)
        {
            this.ListView.Items.Clear();
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (this.ListView.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem item in ListView.SelectedItems)
            {
                item.Remove();
            }
        }

        private void Button_Execute_Click(object sender, EventArgs e)
        {
            if (ListView.Items.Count <= 0)
            {
                return;
            }

            if (!CheckFFmpegExe())
            {

                MessageBox.Show(
                    "ffmpeg.exe を VideoCompressor.exe と同じフォルダに格納してください",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var outputFiles = new Queue<string>();
            var outputFolder = "";

            if (ListView.Items.Count == 1)
            {
                var sfd = new SaveFileDialog
                {
                    FileName = ListView.Items[0].Text,
                    Filter = VideoExtFilter,
                    Title = "出力先のファイルを選択してください",
                    RestoreDirectory = true
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    outputFolder = Path.GetDirectoryName(sfd.FileName);
                    outputFiles.Enqueue(sfd.FileName);
                }
            }
            else
            {
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                outputFolder = fbd.SelectedPath;
                foreach (ListViewItem item in ListView.Items)
                {
                    var outputFile = Path.Combine(outputFolder, item.Text);
                    outputFiles.Enqueue(outputFile);
                }
            }
            bool overWrite = false;
            foreach(string outputFile in outputFiles)
            {
                if (File.Exists(outputFile))
                {
                    DialogResult result = MessageBox.Show("ファイルを上書きしますか？",
                        "質問",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.Yes)
                    {
                        Console.WriteLine("「はい」が選択されました");
                        overWrite = true;
                        break;
                    }
                    else if (result == DialogResult.No)
                    {
                        Console.WriteLine("「いいえ」が選択されました");
                        return;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        Console.WriteLine("「キャンセル」が選択されました");
                        return;
                    }
                }
            }
            if (overWrite)
            {
                foreach (string outputFile in outputFiles)
                {
                    if (File.Exists(outputFile))
                    {
                        File.Move(outputFile, $"{outputFile}.bak", true);
                        while (File.Exists(outputFile))
                        {
                            Thread.Sleep(100);
                        }
                    }
                }
            }
            var inputFiles = new Queue<string>();
            foreach (ListViewItem item in ListView.Items)
            {
                inputFiles.Enqueue(item.SubItems[1].Text);
            }
            int num = ListView.Items.Count;
            CompressTaskFinished();
            Task compressTask = new Task(() =>
            {
                string codec = GetSelectedCodec();
                var compressor = new Compressor();
                while(inputFiles.Count > 0)
                {
                    compressor.Compress(inputFiles.Dequeue(), outputFiles.Dequeue(), codec);
                }
                MessageBox.Show(
                    "動画ファイルの変換が完了しました。",
                    "完了",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                System.Diagnostics.Process.Start("EXPLORER.EXE", outputFolder);
                this.Invoke(new CompressTaskFinishedHandler(CompressTaskFinished));
            });
            compressTask.Start();
        }

        private bool CheckFFmpegExe()
        {
            var exeDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var ffmpegPath = Path.Combine(exeDirectory, "ffmpeg.exe");
            return File.Exists(ffmpegPath);
        }

        public delegate void CompressTaskFinishedHandler();
        public void CompressTaskFinished()
        {
            ProgressBar.Visible = !ProgressBar.Visible;
        }
    }
}
