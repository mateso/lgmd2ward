// This sample code is courtesy of http://www.gotreportviewer.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace RdlViewer
{
    public partial class ParameterDialog : Form 
    {
        private ReportViewer reportViewer = null;
        public string[] SelectionOption { get; set; }
        public string[] SelectedValues { get; set; }
        public ParameterDialog( string[] strSelectionOption )
        {
            InitializeComponent();
            SelectionOption = strSelectionOption;
        }
        public ParameterDialog()
        {
            InitializeComponent();
            
        }

        public ReportViewer ReportViewer
        {
            set
            {
                this.reportViewer = value;
            }
        }

        private void ParameterDialog_Load(object sender, EventArgs e)
        {
            ReportParameterInfoCollection p = null;
            try
            {
                p = this.reportViewer.LocalReport.GetParameters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            for (int i = 0; i < p.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].Tag = p[i];
                this.dataGridView1.Rows[i].Cells[0].Value = p[i].Prompt;
                this.dataGridView1.Rows[i].Cells[1].Value = p[i].DataType.ToString();
                IList<string> values = p[i].Values;
                if (values != null && values.Count > 0)
                {
                    this.dataGridView1.Rows[i].Cells[2].Value = values[0];
                }

                DataGridViewComboBoxCell _cell = this.dataGridView1.Rows[i].Cells[3] as DataGridViewComboBoxCell;
                this.dataGridView1.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].Visible = false;


                if (SelectionOption != null)
                {
                    if ((SelectionOption.Length > 1))
                    {
                        _cell.Items.AddRange(SelectionOption);

                        this.dataGridView1.Columns[2].Visible = false;
                        this.dataGridView1.Columns[3].Visible = true;
                    }
                    else
                        this.dataGridView1.Rows[i].Cells[2].Value = SelectionOption[0];




                    //SelectedValues
                }
                      
            }
        }


        public bool ParameterDialogLoad(string[] strSelectionOption)
        {
            SelectionOption = strSelectionOption;
            ReportParameterInfoCollection p = null;
            try
            {
                p = this.reportViewer.LocalReport.GetParameters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            for (int i = 0; i < p.Count; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i].Tag = p[i];
                this.dataGridView1.Rows[i].Cells[0].Value = p[i].Prompt;
                this.dataGridView1.Rows[i].Cells[1].Value = p[i].DataType.ToString();
                IList<string> values = p[i].Values;

                if (values != null && values.Count > 0)
                {
                    this.dataGridView1.Rows[i].Cells[2].Value = values[0];
                }

                DataGridViewComboBoxCell _cell = this.dataGridView1.Rows[i].Cells[3] as DataGridViewComboBoxCell;
                this.dataGridView1.Columns[3].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].Visible = false;

                if (SelectedValues == null)
                {
                    _cell.Items.AddRange(SelectionOption);

                    this.dataGridView1.Columns[2].Visible = false;
                    this.dataGridView1.Columns[3].Visible = true;
                }
                else
                {
                  
                    this.dataGridView1.Rows[i].Cells[2].Value = SelectedValues[i];

              
                }
            
            }

            //Auto adding the selected values to the report parameters

            DataGridViewElementStates states = DataGridViewElementStates.Visible;
            int count = this.dataGridView1.Rows.GetRowCount(states);
            ReportParameter[] parameters = new ReportParameter[count];
            for (int ii = 0; ii < count; ii++)
            {
                parameters[ii] = new ReportParameter();
                ReportParameterInfo pi = (ReportParameterInfo)dataGridView1.Rows[ii].Tag;
                parameters[ii].Name = pi.Name;
                Object val = dataGridView1.Rows[ii].Cells[2].Value;
                if (val != null)
                    parameters[ii].Values.Add(val.ToString());
            }
            this.reportViewer.LocalReport.SetParameters(parameters);

            return true;
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            DataGridViewElementStates states = DataGridViewElementStates.Visible;
            int count = this.dataGridView1.Rows.GetRowCount(states);
            ReportParameter[] parameters = new ReportParameter[count];
            for (int i = 0; i < count; i++)
            {
                parameters[i] = new ReportParameter();
                ReportParameterInfo pi = (ReportParameterInfo)dataGridView1.Rows[i].Tag;
                parameters[i].Name = pi.Name;
                Object val = dataGridView1.Rows[i].Cells[2].Value;

                DataGridViewComboBoxCell _cell = this.dataGridView1.Rows[i].Cells[3] as DataGridViewComboBoxCell;
             
                if (_cell.Items.Count > 0)
                {
                     val = dataGridView1.Rows[i].Cells[3].Value;
                }

                if (val != null)
                    parameters[i].Values.Add(val.ToString());
            }
            this.reportViewer.LocalReport.SetParameters(parameters);
        }
    }
}
