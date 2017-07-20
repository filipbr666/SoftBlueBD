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
    public partial class Kondensatory : Form
    {
        public Kondensatory()
        {
            InitializeComponent();
        }
        SqlCommand komenda = new SqlCommand();
        string zapytanie;
        string items;
        bool WasChange = false;
        private void Kondensatory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elementyElektroniczneDataSetKondensatory.ElementyElektroniczne' table. You can move, or remove it, as needed.
            // this.elementyElektroniczneTableAdapter.Fill(this.elementyElektroniczneDataSetKondensatory.ElementyElektroniczne);
            //  fillByToolStripButton_Click(sender, e);
            CreateSQLCommand();
        }
        private void CreateSQLCommand()
        {
            //tworzenie zapytania;

            zapytanie = @"SELECT Identyfikator, Element, Wartość, Obudowa, Tolerancja, Napięcie, Typ, Producent, Lokalizacja, Ilość, Dostawca, Cena FROM ElementyElektroniczne WHERE Element=' ' OR ";
            try
            {
                foreach (string line in System.IO.File.ReadLines(@"KonfiguracjaKondensatory.ini"))
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
            FillByTEST(this.elementyElektroniczneDataSetKondensatory.ElementyElektroniczne);
        }
        public int FillByTEST(ElementyElektroniczneDataSetKondensatory.ElementyElektroniczneDataTable dataTable)
        {
            elementyElektroniczneTableAdapter.Adapter.SelectCommand = this.komenda;
            if ((elementyElektroniczneTableAdapter.ClearBeforeFill == true))
            {
                dataTable.Clear();
            }
            int returnValue = elementyElektroniczneTableAdapter.Adapter.Fill(dataTable);
            return returnValue;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                elementyElektroniczneBindingSource.EndEdit();
                elementyElektroniczneTableAdapter.Update(this.elementyElektroniczneDataSetKondensatory.ElementyElektroniczne);
            }
            catch (Exception)
            {

                throw;
            }
            Cursor.Current = Cursors.Default;
            Kondensatory_Load(sender, e);
            WasChange = false;
        }


        private void Kondensatory_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WasChange == true)
            {
                if (MessageBox.Show("Chcesz zapisać zmiany?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { SaveButton_Click(sender, e); }
            }

            Program.MainRef.Show();
        }

        private void advancedDataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            elementyElektroniczneBindingSource.Filter = advancedDataGridView.FilterString;
        }

        private void advancedDataGridView_SortStringChanged(object sender, EventArgs e)
        {
            elementyElektroniczneBindingSource.Sort = advancedDataGridView.SortString;
        }

        private void advancedDataGridView_KeyDown(object sender, KeyEventArgs e)
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

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.elementyElektroniczneTableAdapter.FillBy(this.elementyElektroniczneDataSetKondensatory.ElementyElektroniczne);
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
                this.elementyElektroniczneTableAdapter.FillByALL(this.elementyElektroniczneDataSetKondensatory.ElementyElektroniczne);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void advancedDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = advancedDataGridView.CurrentCell.ColumnIndex;
            TextBox auto_text = e.Control as TextBox;
            if (auto_text != null)
            {
                auto_text.AutoCompleteMode = AutoCompleteMode.Suggest;
                auto_text.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection sc = new AutoCompleteStringCollection();
                int i = 0;
                foreach (DataGridViewRow item in advancedDataGridView.Rows)
                {
                    if (!sc.Contains(item.Cells[column].Value.ToString()))
                        sc.Add(item.Cells[column].Value.ToString());
                    i = item.Index + 2;
                    if (i == advancedDataGridView.RowCount)
                        break;
                }
                auto_text.AutoCompleteCustomSource = sc;
            }
        }

        private void advancedDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("HOLA HOLA, tak nie wolno, zły format wpisany do komórki!");
        }

        private void advancedDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            WasChange = true;
        }
    }
}
