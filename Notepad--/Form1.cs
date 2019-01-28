using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad__
{
    public partial class Form1 : Form
    {

        OpenFileDialog op = new OpenFileDialog();
        SaveFileDialog sv = new SaveFileDialog();
        FontDialog fd = new FontDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNotepad.Text))
            {

            }
            else
            {
                Dialog();
            }
        }

        private void Dialog()
        {
            var Mresult = MessageBox.Show("Do you want to save youre changes?", "", MessageBoxButtons.YesNoCancel);
            if (Mresult == DialogResult.No)
            {
                Environment.Exit(0);
            }
            if (Mresult == DialogResult.Yes)
            {
                Save();

            }
            if (Mresult == DialogResult.Cancel)
            {

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (String.IsNullOrEmpty(txtNotepad.Text))
            {
                Environment.Exit(0);
            }
            else
            {
                Dialog();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void Open()
        {
            if (op.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(op.FileName))
                {
                    Task<string> text = sr.ReadToEndAsync();
                    txtNotepad.Text = text.Result;
                }
            }
        }

        private void Save()
        {
            sv.DefaultExt = ".txt";
            sv.FileName = ".txt";
            sv.Filter = "Text file (*.txt)|*.txt";
            if (sv.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sv.FileName))
                {
                    sw.WriteLineAsync(txtNotepad.Text);
                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void exToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNotepad.Text))
            {
                Environment.Exit(0);
            }
            else
            {
                Dialog();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new About();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtNotepad.Font = fd.Font;
            }
        }
    }
}
