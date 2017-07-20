using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SoftBlueBD
{
    public partial class Mechaniczne : Form
    {
        public Mechaniczne()
        {
            InitializeComponent();
        }
        SqlCommand komenda = new SqlCommand();
        string zapytanie;
        string items;
        bool WasChange = false;
        private void Mechaniczne_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elementyElektroniczneDataSetMechaniczne.ElementyElektroniczne' table. You can move, or remove it, as needed.
            //this.elementyElektroniczneTableAdapter.Fill(this.elementyElektroniczneDataSetMechaniczne.ElementyElektroniczne);
            //fillByMechaniczneToolStripButton_Click(sender, e);
            CreateSQLCommand();
        }

        private void CreateSQLCommand()
        {
            //tworzenie zapytania;

            zapytanie = @"SELECT Identyfikator, Element, Typ, Producent, Oznaczenie, Opis, Lokalizacja, Ilość, Cena FROM ElementyElektroniczne WHERE Element=' ' OR ";
            try
            {
                foreach (string line in System.IO.File.ReadLines(@"KonfiguracjaMechaniczne.ini"))
                {
                    if (!DataGridComboBoxElement.Items.Contains(line))
                        DataGridComboBoxElement.Items.Add(line);
                    zapytanie = zapytanie + " (Element = N'" + line + "') OR ";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie odnaleziono pliku konfiguracyjnego");
            }
            zapytanie = zapytanie.Remove(zapytanie.Length - 3) + ";";
            //wysłanie komendy
            komenda.Connection = elementyElektroniczneTableAdapter.Connection;
            komenda.CommandText = zapytanie;
            FillByTEST(this.elementyElektroniczneDataSetMechaniczne.ElementyElektroniczne);
        }

        public int FillByTEST(ElementyElektroniczneDataSetMechaniczne.ElementyElektroniczneDataTable dataTable)
        {
            elementyElektroniczneTableAdapter.Adapter.SelectCommand = this.komenda;
            if ((elementyElektroniczneTableAdapter.ClearBeforeFill == true))
            {
                dataTable.Clear();
            }
            int returnValue = elementyElektroniczneTableAdapter.Adapter.Fill(dataTable);
            return returnValue;
        }

        private void fillByMechaniczneToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementyElektroniczneTableAdapter.FillByMechaniczne(this.elementyElektroniczneDataSetMechaniczne.ElementyElektroniczne);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByALLToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementyElektroniczneTableAdapter.FillByALL(this.elementyElektroniczneDataSetMechaniczne.ElementyElektroniczne);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                elementyElektroniczneBindingSource.EndEdit();
                elementyElektroniczneTableAdapter.Update(this.elementyElektroniczneDataSetMechaniczne.ElementyElektroniczne);
            }
            catch (Exception)
            {

                throw;
            }
            Cursor.Current = Cursors.Default;
            WasChange = false;
        }

        private void Mechaniczne_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WasChange == true)
            {
                if (MessageBox.Show("Chcesz zapisać zmiany?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { SaveButton_Click(sender, e); }
            }

            Program.MainRef.Show();
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            elementyElektroniczneBindingSource.Filter = advancedDataGridView1.FilterString;
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            elementyElektroniczneBindingSource.Sort = advancedDataGridView1.SortString;
        }

        private void advancedDataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Jesteś pewien, że chcesz usunąć ten element?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    elementyElektroniczneBindingSource.RemoveCurrent();
                    WasChange = true;
                }
            }
        }

        private void advancedDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            WasChange = true;
        }

        private void advancedDataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = advancedDataGridView1.CurrentCell.ColumnIndex;
            TextBox auto_text = e.Control as TextBox;
            if (auto_text != null)
            {
                auto_text.AutoCompleteMode = AutoCompleteMode.Suggest;
                auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
                int i = 0;
                foreach (DataGridViewRow item in advancedDataGridView1.Rows)
                {
                    if (!sc.Contains(item.Cells[column].Value.ToString()))
                        sc.Add(item.Cells[column].Value.ToString());
                    i = item.Index + 2;
                    if (i == advancedDataGridView1.RowCount)
                        break;
                }
                auto_text.AutoCompleteCustomSource = sc;
            }
        }

        private void advancedDataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("HOLA HOLA, tak nie wolno, zły format wpisany do komórki!");
        }

        private void advancedDataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            WasChange = true;
        }
    }
}
