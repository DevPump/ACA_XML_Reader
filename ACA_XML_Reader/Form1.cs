using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ACA_XML_Reader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        //Error File Read considered working.
        private void readErrorFile() {
            //Load Error file
            XmlTextReader xmlTextRead_ErrorFile = new XmlTextReader(textBox_ErrorFile.Text);
            Boolean ErrorRecordID = false;
            while (xmlTextRead_ErrorFile.Read()) {
                //Record ID.
                if (xmlTextRead_ErrorFile.NodeType == XmlNodeType.Element) {
                    if (xmlTextRead_ErrorFile.Name.ToString() == "UniqueRecordId") {
                        ErrorRecordID = true;
                    }
                }
                if (xmlTextRead_ErrorFile.NodeType == XmlNodeType.Text && ErrorRecordID) {
                    string uniqueRecordID = xmlTextRead_ErrorFile.Value.ToString().Substring((xmlTextRead_ErrorFile.Value.ToString().IndexOf("|") + 1));
                    uniqueRecordID = uniqueRecordID.Substring(uniqueRecordID.IndexOf("|") + 1);
                    listBox_errorIDs.Items.Add(uniqueRecordID);//"Record ID: " + 
                    ErrorRecordID = false;
                }
            }
            //Close the readError file.
            xmlTextRead_ErrorFile.Close();
        }

        private void readSubmissionFile() {
            //Load submission file.
            XmlTextReader xmlTextRead_SubmissionFile = new XmlTextReader(textBox_SubmissionFile.Text);

            //XML Node Type
            XmlNodeType nodeType;

            //Status Variables.
            Boolean isRecordID = false,
                //Element field Type.
                isFirstName = false,
                isMiddleName = false,
                isLastName = false,
                isSSN = false,
                badRecord = false;

            string recordID = "";

            string persFirstName = "",
                persMiddleName = "",
                persLastName = "",
                persSSN = "",
                previousPersSSN = "";

            //Read IRS File
            while (xmlTextRead_SubmissionFile.Read()) {
                //Read the node type.
                nodeType = xmlTextRead_SubmissionFile.NodeType;

                //Information inside field
                if (nodeType == XmlNodeType.Text) {
                    //Get the current Value.
                    string elementValueText = xmlTextRead_SubmissionFile.Value;

                    if (isRecordID) {
                        if (elementValueText != "") {
                            foreach (string rowItem in listBox_errorIDs.Items) {
                                if (rowItem == xmlTextRead_SubmissionFile.Value) {
                                    recordID = rowItem;
                                    badRecord = true;
                                    break;
                                }
                            }
                        }
                        isRecordID = false;
                    }

                    if (badRecord) {
                        if (isFirstName) {
                            persFirstName = elementValueText;
                            isFirstName = false;
                        }
                        else if (isLastName) {
                            persLastName = elementValueText;
                            isLastName = false;
                        }
                        else if (isMiddleName) {
                            persMiddleName = elementValueText;
                            isMiddleName = false;
                        }
                        else if (isSSN) { //previousPersSSN != elementValueText && elementValueText.Length == 9
                            previousPersSSN = elementValueText;
                            persSSN = elementValueText;
                            isSSN = false;
                        }
                    }
                }
                else if (nodeType == XmlNodeType.Element) {
                    string elementNameText = xmlTextRead_SubmissionFile.Name;
                    /*
                     * Record ID is first row of a new employee and dependent(s).
                     * Only occurs once per set of employee and dependent(s)
                     */
                    if (elementNameText == "RecordId") {
                        isRecordID = true;
                        persFirstName = "";
                        persMiddleName = "";
                        persLastName = "";
                        persSSN = "";
                        badRecord = false;
                    }
                    if (badRecord) {
                        /*
                         * First name should appear second in the XML.
                         * After Record ID.
                         * Can be non-existant 
                         */
                        if (elementNameText == "PersonFirstNm") {
                            isFirstName = true;
                        }
                        if (elementNameText == "persMiddleName") {
                            isMiddleName = true;
                        }
                        /*
                         * First name should appear third in the XML.
                         * After First Name.
                         * Can be non-existant 
                         */
                        if (elementNameText == "PersonLastNm") {
                            isLastName = true;
                        }
                        /*
                         * First name should appear forth in the XML.
                         * After Last Name.
                         * Social appears twice for employee once before the first name and another a few fields before that.
                         * Can be non-existant for dependent.
                         */
                        if (elementNameText == "irs:SSN") {
                            isSSN = true;
                        }
                        if (elementNameText == "CoveredIndividualGrp") {
                            persFirstName = "{ERROR}";
                            persMiddleName = "{ERROR}";
                            persLastName = "{ERROR}";
                            persSSN = "{ERROR}";
                        }
                    }
                }
                else if (nodeType == XmlNodeType.EndElement) {
                    string elementNameText = xmlTextRead_SubmissionFile.Name;
                    if (elementNameText == "CoveredIndividualGrp") {
                        if (persFirstName != "" || persMiddleName != "" || persLastName != "" || persSSN != "")
                            //if (persFirstName != "{ERROR}" && persLastName != "{ERROR}" && persSSN != "{ERROR}")
                                dataGridView1.Rows.Add(recordID, persFirstName, persMiddleName, persLastName, persSSN);
                    }
                }
            }
            //File finished reading.
            xmlTextRead_SubmissionFile.Close();
        }

        private void button_Check_File_Click(object sender, EventArgs e) {
            readErrorFile();
            readSubmissionFile();
        }

        private void Form1_Load(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            textBox_ErrorFile.Text = ofd.FileName;
            ofd.ShowDialog();
            textBox_SubmissionFile.Text = ofd.FileName;
        }
    }
}
