using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GarminLapMerger
{
    public partial class frmMain : Form
    {
        private String Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtPath.Text = Path;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            ProcessXMLFiles();
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Path = folderBrowserDialog.SelectedPath.ToString();
                txtPath.Text = Path;
                PopulateFileList();
            }  
        }

        private void PopulateFileList()
        {
            lstSelectedFiles.Items.Clear();

            try
            {         
                string[] Files = Directory.GetFiles(Path, "*.tcx");

                foreach (string File in Files)
                {
                    string[] FileName = File.Split('\\');

                    lstSelectedFiles.Items.Add(FileName[FileName.Length-1]);        
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        private void ProcessXMLFiles()
        {
            if (lstSelectedFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("No files selected!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lstSelectedFiles.SelectedItems.Count == 1)
            {
                MessageBox.Show("Select more than one file to merge!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else //ioif (lstSelectedFiles.SelectedItems.Count > 1) 
            {
                ListBox.SelectedObjectCollection SelectedItems = lstSelectedFiles.SelectedItems;

                //We are going to use a List<T> instead of ArrayList
                //also we are going to use Tuple<DateTime, String> for the items
                var LapsList = new List<Tuple<DateTime, String, String>>();

                foreach (String Selected in SelectedItems)
                {
                    String FullPath = Path + @"\" + Selected;
                    XmlDocument xDoc = new XmlDocument();

                    try
                    {
                        xDoc.Load(FullPath);

                        XmlNodeList Laps = xDoc.GetElementsByTagName("Lap");

                        foreach (XmlElement Lap in Laps)
                        {
                            DateTime StartTime = DateTime.Parse(Lap.Attributes[0].Value);
                            String XML = Lap.InnerXml.ToString();

                            //Here we create the tuple and add it
                            LapsList.Add(new Tuple<DateTime, String, String>(StartTime, XML, FullPath));
                        }

                    }
                    catch (IOException e)
                    {
                        MessageBox.Show("Error loading file: " + FullPath + "\r\n" + "Exception: " + e, "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //We are sorting with Linq
                LapsList = LapsList.OrderBy(lap => lap.Item1).ToList();

                StreamReader MetaDataXML = new StreamReader(LapsList[0].Item3);
                String XMLContentsString = MetaDataXML.ReadToEnd();

                int HeaderEndPosition = XMLContentsString.IndexOf("</Id>") + 5;
                int FooterStartPosition = XMLContentsString.IndexOf(@"<Creator xsi:type=""Device_t"">");

                String Header = XMLContentsString.Substring(0, HeaderEndPosition);
                String Footer = XMLContentsString.Substring(FooterStartPosition);

                XmlDocument NewXMLDocument = new XmlDocument();

                String NewFile = Header;

                foreach (Tuple<DateTime, String, String> Lap in LapsList)
                {

                    string CurrentLap = "<Lap StartTime=\"" + Lap.Item1.ToString("yyyy-MM-ddTHH:mm:ssZ") + "\">";
                    CurrentLap += Lap.Item2;
                    CurrentLap += "</Lap>";

                    NewFile += CurrentLap;

                }

                NewFile += Footer;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] ByteData = Encoding.ASCII.GetBytes(NewFile);
                        FileStream SaveFileStream = (FileStream)saveFileDialog.OpenFile();
                        SaveFileStream.Write(ByteData, 0, ByteData.Length);
                        SaveFileStream.Close();

                        MessageBox.Show("File written successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("File failed to write!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lnkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nerdthinking.com");
        }

    }
}
