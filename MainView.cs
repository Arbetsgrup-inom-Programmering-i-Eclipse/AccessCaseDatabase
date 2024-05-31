using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Form
{
    public partial class MainView : System.Windows.Forms.Form
    {
        private XDocument doc { get; set; }

        private string path = @"PATH_TO_DATABASE_FOLDER\ExportDB.xml"; //Ändra till nya pathen när scriptet är granskat och OK

        public MainView()
        {
            InitializeComponent();

            doc = XDocument.Load(@path);

            listView_QueryResult.Columns.Add("Fall");
            listView_QueryResult.Columns.Add("Kategori");
            listView_QueryResult.Columns.Add("Sub-Kategori");
            listView_QueryResult.Columns.Add("Ordination");
            listView_QueryResult.Columns.Add("AriaUser");
            listView_QueryResult.Columns.Add("PatientSer");
            listView_QueryResult.Columns.Add("Course");
            listView_QueryResult.Columns.Add("Plan");
            listView_QueryResult.Columns.Add("Datum");
            listView_QueryResult.Columns.Add("Kommentar");

            string[] Categories = { "", "Prostata", "MAM", "H&N", "TC", "SRT", "SBRT", "GI", "Gyn", "Thorax", "Palliativ", "TBI", "Övrigt" };
            comboBox_Kategori.Items.AddRange(Categories);
            comboBox_Kategori.SelectedItem = comboBox_Kategori.Items[0];

            string[] Sub_Categories = { "", "Dosplan", "Behandling", "ARIA/CarePath", "Bilder", "EPID", "Mätning", "DoseCheck", "Undervisning", "Övrigt", "None" };
            comboBox_SubKategori.Items.AddRange(Sub_Categories);
            comboBox_SubKategori.SelectedItem = comboBox_SubKategori.Items[0]; 

            textBox_AriaUser.Text = "";
            textBox_Kommentar.Text = "";

        }

        private void button_Sök_Click(object sender, EventArgs e) //Sök databasen
        {
            UpdateList(doc);
        }

 
        private void listView_QueryResult_SelectedIndexChanged(object sender, EventArgs e) //Beroende på hur många rader man väljer, aktivera eller oaktivera knapparna för att hämta PatientId / Ta bort fallet från databasen
        {
            if (listView_QueryResult.SelectedItems.Count == 1)
            {
                button_Hämta_PatId.Enabled = true;
            }
            else
            {
                button_Hämta_PatId.Enabled = false;
            }

            if(listView_QueryResult.SelectedItems.Count >= 1)
            {
                button_TaBort.Enabled = true;
            }
            else
            {
                button_TaBort.Enabled = false;
            }
        }

        private void button_Hämta_Click(object sender, EventArgs e) //Hämta patient id
        {
            var patient = GetPatientId(listView_QueryResult.SelectedItems[0].SubItems[5].Text);

            if (patient.Rows.Count == 1)
            {
                Clipboard.SetText(patient.Rows[0].ItemArray[0].ToString());
                label_PatientId.Text = "Patient: " + patient.Rows[0].ItemArray[1].ToString() + " " + patient.Rows[0].ItemArray[2].ToString() + " - " + patient.Rows[0].ItemArray[0].ToString() + ". Id kopierades automatiskt till Clipboard ";
            }
            else
            {
                label_PatientId.Text = "Patienten hittades inte";
            }
        }

        private void button_TaBort_Click(object sender, EventArgs e) //Ta bort fall från databasen
        {
            ListView.SelectedListViewItemCollection Selection = listView_QueryResult.SelectedItems;

            Form2.Form2 DeleteQuestion = new Form2.Form2(Selection);
            DeleteQuestion.ShowDialog();

            if(DeleteQuestion.DialogResult == DialogResult.OK)
            {
                int UndeletedCases = 0;
                foreach (ListViewItem item in Selection)
                {
                    if(item.SubItems[4].Text == Environment.UserName) //Kolla att fallet har skapats av samma användaren som försöker ta bort det. Man får inte ta bort fall som man inte har skapat själv
                    {
                        doc.Element("DB").Elements().Where(x => x.Element("CaseNumber").Value == item.SubItems[0].Text).First().Remove();
                    }
                    else
                    {
                        UndeletedCases++;
                    }
                }
                doc.Save(@path);
                doc = XDocument.Load(@path);
                if (UndeletedCases == 0)
                {
                    UpdateList(doc);
                    MessageBox.Show("Klar");
                }
                else
                {
                    MessageBox.Show("Du saknar behörighet för att ta bort " + UndeletedCases.ToString() + " fall. " + (Selection.Count - UndeletedCases).ToString() + " fall togs bort");
                    UpdateList(doc);
                }
            }
        }

        private void button_AriaJag_Click(object sender, EventArgs e)
        {
            textBox_AriaUser.Text = Environment.UserName.ToLower();
            UpdateList(doc);
        }

        private void button_Återställ_Click(object sender, EventArgs e)
        {
            comboBox_Kategori.SelectedItem = comboBox_Kategori.Items[0];
            comboBox_SubKategori.SelectedItem = comboBox_SubKategori.Items[0];
            textBox_AriaUser.Text = "";
            textBox_Kommentar.Text = "";
        }


        static private DataTable GetPatientId(string patientSer)
        {
            (DataTable datatable, Exception exception) = AriaInterface.Query(AriaDatabase.Clinical, @"SELECT 
	                                                        Patient.PatientId,
                                                            Patient.FirstName,
                                                            Patient.LastName
                                                        FROM 
	                                                        Patient
                                                        WHERE 		           
                                                            Patient.PatientSer LIKE @patientSer", ("patientSer", patientSer));
            return datatable;
        }


        private void UpdateList(XDocument document)
        {
            string Category;
            if (comboBox_Kategori.SelectedItem != null)
            {
                Category = comboBox_Kategori.SelectedItem.ToString();
            }
            else
            {
                Category = "";
            }

            string Sub_Category;
            if (comboBox_SubKategori.SelectedItem != null)
            {
                Sub_Category = comboBox_SubKategori.SelectedItem.ToString();
            }
            else
            {
                Sub_Category = "";
            }
            string AriaUser = textBox_AriaUser.Text;
            string Keyword = textBox_Kommentar.Text;

            listView_QueryResult.Items.Clear();

            foreach (var Case in document.Descendants("NewCase").OrderByDescending(c => Convert.ToInt32(c.Element("CaseNumber").Value))) // Kolla vilka fall uppfyller valda kriterierna och lägg till dem i ListView
            {
                if (Category == "" || Case.Element("Kategori").Value.ToString() == Category)
                {
                    if (Sub_Category == "" || Case.Element("Sub-Kategori").Value.ToString() == Sub_Category || comboBox_SubKategori.SelectedItem == null)
                    {
                        if (AriaUser == "" || Case.Element("AriaUser").Value.ToString() == AriaUser)
                        {
                            if (Keyword == "" || Case.Element("Kommentar").Value.ToString().ToLower().Contains(Keyword.ToLower()))
                            {
                                ListViewItem item = new ListViewItem(new string[]
                                {
                                Case.Element("CaseNumber").Value,
                                Case.Element("Kategori").Value,
                                Case.Element("Sub-Kategori").Value,
                                Case.Element("Ordination").Value,
                                Case.Element("AriaUser").Value,
                                Case.Element("PatientSer").Value,
                                Case.Element("Course").Value,
                                Case.Element("Plan").Value,
                                Case.Element("Datum").Value,
                                Case.Element("Kommentar").Value
                                });
                                listView_QueryResult.Items.Add(item);
                            }

                        }
                    }
                }
            }

            listView_QueryResult.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView_QueryResult.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView_QueryResult.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView_QueryResult.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView_QueryResult.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView_QueryResult.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
            listView_QueryResult.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView_QueryResult.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView_QueryResult.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView_QueryResult.AutoResizeColumn(9, ColumnHeaderAutoResizeStyle.ColumnContent);
        }





        //Kopierade allt under från internet. Används för att sortera kolumner

        public class ListViewComparer : System.Collections.IComparer
        {
            private int ColumnNumber;
            private SortOrder SortOrder;

            public ListViewComparer(int column_number,
                SortOrder sort_order)
            {
                ColumnNumber = column_number;
                SortOrder = sort_order;
            }

            // Compare two ListViewItems.
            public int Compare(object object_x, object object_y)
            {
                // Get the objects as ListViewItems.
                ListViewItem item_x = object_x as ListViewItem;
                ListViewItem item_y = object_y as ListViewItem;

                // Get the corresponding sub-item values.
                string string_x;
                if (item_x.SubItems.Count <= ColumnNumber)
                {
                    string_x = "";
                }
                else
                {
                    string_x = item_x.SubItems[ColumnNumber].Text;
                }

                string string_y;
                if (item_y.SubItems.Count <= ColumnNumber)
                {
                    string_y = "";
                }
                else
                {
                    string_y = item_y.SubItems[ColumnNumber].Text;
                }

                // Compare them.
                int result;
                double double_x, double_y;
                if (double.TryParse(string_x, out double_x) &&
                    double.TryParse(string_y, out double_y))
                {
                    // Treat as a number.
                    result = double_x.CompareTo(double_y);
                }
                else
                {
                    DateTime date_x, date_y;
                    if (DateTime.TryParse(string_x, out date_x) &&
                        DateTime.TryParse(string_y, out date_y))
                    {
                        // Treat as a date.
                        result = date_x.CompareTo(date_y);
                    }
                    else
                    {
                        // Treat as a string.
                        result = string_x.CompareTo(string_y);
                    }
                }

                // Return the correct result depending on whether
                // we're sorting ascending or descending.
                if (SortOrder == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }


        // The column we are currently using for sorting.
        private ColumnHeader SortingColumn = null;

        // Sort on this column.
        private void listView_QueryResult_ColumnClick(object sender,
            ColumnClickEventArgs e)
        {
            // Get the new sorting column.
            ColumnHeader new_sorting_column = listView_QueryResult.Columns[e.Column];


            // Figure out the new sorting order.
            System.Windows.Forms.SortOrder sort_order;
            if (SortingColumn == null)
            {
                // New column. Sort ascending.
                sort_order = SortOrder.Ascending;
            }
            else
            {
                // See if this is the same column.
                if (new_sorting_column == SortingColumn)
                {
                    // Same column. Switch the sort order.
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        sort_order = SortOrder.Descending;
                    }
                    else
                    {
                        sort_order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }

                // Remove the old sort indicator.
                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            // Display the new sort order.
            SortingColumn = new_sorting_column;
            if (sort_order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            // Create a comparer.
            listView_QueryResult.ListViewItemSorter =
                new ListViewComparer(e.Column, sort_order);

            // Sort.
            listView_QueryResult.Sort();
        }
    }
}
