using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace KeyTermsToChecklistConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            string searchMode =  string.Empty;
            if (SearchModeCombobox.Text == "Simple")
            {
                searchMode = "simple";
            }
            else
            {
                searchMode = "regexp";
            }


            // get DateTime
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm";
            string datetime = time.ToString(format);

            //// declare variable to hold the category selection
            string category = CategoryTextBox.Text;
            if (category.Length > 0)
            {
                category = category.Replace("\"\"", "\"").Replace(" | ", " or ").Replace("|", "");
            }

            // declare variable to get input file
            string InputFile = InputFileTextBox.Text;

            // Check if file exists
            if (InputFile.Length < 1)
            {
                MessageBox.Show("No input file entered. Specify the full path to the Unicode text file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!File.Exists(InputFile))
            {
                MessageBox.Show("File selected does not exist. Specify the full path to an existing Unicode text file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (File.Exists(InputFile))
            {
                long countlines = CountLinesInFile(InputFile);
                if (countlines < 1)
                {
                    MessageBox.Show("File selected contains " + countlines + " lines. Specify the full path to a correct Unicode tab-delimited text file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // get directory, filename and extension
            string extension = Path.GetExtension(InputFile);
            string filename = Path.GetFileNameWithoutExtension(InputFile);
            string directory = Path.GetDirectoryName(InputFile);

            if (extension != ".txt")
            {
                MessageBox.Show("File extension is not .txt. Specify the full path to a correct Unicode tab-delimited text file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get file encoding
            Encoding encoding = GetFileEncoding(InputFile);
            if (encoding == Encoding.Default)
            {
                MessageBox.Show("File encoding is ANSI.\nSave key terms file as Unicode text file.", "Encoding error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool KTMismatchMode;
            if (KTMismatchCheckbox.Checked)
            {
                KTMismatchMode = true;
            }
            else
            {
                KTMismatchMode = false;
            }

            // Read input File and add strings to list
            List<Entry> list = SegmentList(InputFile, encoding, category, KTMismatchMode);

            string OutputFile = directory + "\\" + filename + ".xbckl";

            // If no list is empty
            if (list.Count() < 1)
            {
                MessageBox.Show(InputFile + " does not contain any entry.", "Error");
                return;
            }

            // Delete output file if exists
            if (File.Exists(OutputFile))
            {
                File.Copy(OutputFile, OutputFile + ".bak", true);
                File.Delete(OutputFile);
            }

            string name = Replacing(filename);
            XmlTextWriter xmlWriter = new XmlTextWriter(OutputFile, null)
            {
                Formatting = Formatting.Indented
            };

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("xbench-checklist");
            xmlWriter.WriteAttributeString("version", "1.0");

            xmlWriter.WriteStartElement("checklist");
            xmlWriter.WriteAttributeString("name", name);

            int counter = 0;
            foreach (Entry segment in list)
            {
                // Declare variable to hold the tags                
                string source = segment.SourceTerm;
                string target = segment.TargetTerm;
                string description = segment.Description;
                string checkname = segment.Checkname;

                if (source.Length < 1 && target.Length < 1) continue;

                // Write checklist entry start element
                xmlWriter.WriteStartElement("check");                
                xmlWriter.WriteAttributeString("name", checkname);
                xmlWriter.WriteAttributeString("categories", category);

                // Add source term and its parameters
                SourceParms(xmlWriter, source, searchMode);
                // Add target term and its parameters
                TargetParms(xmlWriter, target, searchMode);
                // Add description entry
                Description(xmlWriter, description);

                // Convert string to UTF8 encoding and write to checklist.
                // timestamp tag
                xmlWriter.WriteStartElement("timestamp");
                xmlWriter.WriteString(datetime);
                xmlWriter.WriteEndElement();
                // Add final tag
                xmlWriter.WriteEndElement();

                // increment counter if checklist entry is created
                counter++;
            }

            // Convert string to UTF8 encoding and write to checklist.
            // closing end tags
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            string message = OutputFile + " has beem created successfully. It contains " + counter.ToString() + " entries.";

            MessageBox.Show(message, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start("explorer.exe", "/select, \"" + OutputFile + "\"");

            InputFileTextBox.Clear();
        }

        static string RemoveUnnecessaryQuotes(string text)
        {
            string[] split = text.Split('\t');
            string source = split[0];
            string target = split[1];
            // Check if source and target start and end with quotes
            if (source.Length > 2 && source.StartsWith("\"") && source.EndsWith("\""))
            {
                // Remove initial and final quotes
                source = source.Substring(1, source.Length - 2);
            }
            if (target.Length > 2 && target.StartsWith("\"") && target.EndsWith("\""))
            {
                // Remove initial and final quotes
                target = target.Substring(1, target.Length - 2);
            }

            return source + "\t" + target;
        }

        static string SourceItem(string text)
        {
            string source;

            if (text.StartsWith("|"))
            {
                source = text.Replace(" | ", "&quot; OR &quot;");
                source = source.Replace("| ", "&quot;");
                source = source.Insert(source.Length, "&quot;");
            }
            else if (text.Length > 0)
            {
                source = "&quot;" + text + "&quot;";
            }
            else
            {
                source = "";
            }
            return source;
        }

        static string TargetItem(string text, int SourceLength, Boolean KTMismatchMode)
        {
            string target;
           
            string ktmode1;
            string ktmode2;            

            if (SourceLength > 0)
            {
                if (KTMismatchMode == true)
                {
                    ktmode1 = "-";
                    ktmode2 = " -";
                }
                else
                {
                    ktmode1 = "";
                    ktmode2 = " OR ";
                }
                if (text.StartsWith("|"))
                {
                    target = text.Replace(" | ", "&quot;" + ktmode2 + "&quot;");
                    target = target.Replace("| ", ktmode1 + "&quot;");
                    target = target.Insert(target.Length, "&quot;");
                }
                else if (text.Length > 0)
                {
                    target = ktmode1 + "&quot;" + text + "&quot;";
                }
                else
                {
                    target = "";
                }
            }
            else if (SourceLength < 1)
            {
                ktmode1 = "";
                ktmode2 = " OR ";

                if (text.StartsWith("|"))
                {
                    target = text.Replace(" | ", "&quot;" + ktmode2 + "&quot;");
                    target = target.Replace("| ", ktmode1 + "&quot;");
                    target = target.Insert(target.Length, "&quot;");
                }
                else if (text.Length > 0)
                {
                    target = ktmode1 + "&quot;" + text + "&quot;";
                }
                else
                {
                    target = "";
                }
            }
            else
            {
                target = "";
            }
            return target;
        }

        static string SetDescriptionEntry(string source, string target, bool KTMismatchMode)
        {
            string desc = string.Empty;
            if (KTMismatchMode == true)
            {
                if (source.Length > 0 && target.Length > 0)
                {
                    desc = "Should be &quot;" + target.Replace(" | ", "&quot; or &quot;").Replace("| ", "") + "&quot;. ";
                }
                else if (source.Length < 1 && target.Length > 0)
                {
                    desc = "Is &quot;" + target.Replace(" | ", "&quot; or &quot;").Replace("| ", "") + "&quot; correct? ";
                }
                else if (source.Length > 0 && target.Length < 1)
                {
                    desc = source;
                }
            }
            else
            {                
                if (target.Length > 0)
                {
                    desc = "Is &quot;" + target.Replace(" | ", "&quot; or &quot;").Replace("| ", "") + "&quot; correct? ";
                }
                else if (source.Length > 0 && target.Length < 1)
                {
                    desc = source;
                }
            }

            desc = desc.Replace("&quot;&quot;", "&quot;");
            return desc;
        }

        // Read file and add strings to list
         static List<Entry> SegmentList(string file, Encoding encoding, string category, bool KTMismatchMode)
        {
            List<Entry> list = new List<Entry>();
            string line;
            string checkname = string.Empty;
            string source;
            string target;
            string description;

            StreamReader reader = new StreamReader(file, encoding);
            while ((line = reader.ReadLine()) != null)
            {
                line = RemoveUnnecessaryQuotes(line);
                string[] split = line.Split('\t');
                if (split.Length < 2) continue;                

                if (split[0].Length > 0)
                {
                    checkname = split[0];                    
                }
                else if (split[1].Length > 0)
                {
                    checkname = split[1];                    
                }

                checkname = checkname.Replace(" | ", " or ").Replace("|", "");
                source = Replacing(split[0]);
                source = SourceItem(source);
                target = Replacing(split[1]);
                target = TargetItem(target, source.Length, KTMismatchMode);
                description = SetDescriptionEntry(Replacing(split[0]), Replacing(split[1]), KTMismatchMode);                
                list.Add(new Entry { Checkname = checkname, Category = category, SourceTerm = source, TargetTerm = target, Description = description});
            }

            return list;
        }

        // Replacing special characters
        public static string Replacing(string input)
        {
            // replace special characters
            input = input.Replace("&", "&amp;").Replace("'", "&apos;").Replace("\"", "&quot;&quot;").Replace(">", "&gt;").Replace("<", "&lt;");
            return input;
        }
        
        //Count lines in file
        static long CountLinesInFile(string file)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(file))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }

        // Function to get input file code page
        public static Encoding GetFileEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        // Open file dialog to add input tab-delimited text file
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            //Create an instance of the open dialog box
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //Set filter options and filter index
                Filter = "Unicode Tab-delimited Text File (.txt)|*.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Multiselect = false,
                Title = "Select a Key Terms File"
            };

            //ONce the dialog properties are set, it is ready to present the user
            if (openFileDialog1.ShowDialog() == DialogResult.OK) InputFileTextBox.Text = openFileDialog1.FileName;
        }

        public void SourceParms(XmlWriter xmlWriter, string SourceTerm, string searchMode)
        {
            xmlWriter.WriteStartElement("term");
            xmlWriter.WriteAttributeString("type", "source");
            xmlWriter.WriteAttributeString("xml", "space", null, "preserve");

            if (SourceCaseSensitive.Checked)
            {
                xmlWriter.WriteAttributeString("casecheck", "yes");
            }
            if (SourceMatchWholeWord.Checked)
            {
                xmlWriter.WriteAttributeString("wholeword", "yes");
            }
            if (SourceNoWhitespaceTrimming.Checked)
            {
                xmlWriter.WriteAttributeString("notrim", "yes");
            }
            if (SourceNormalizeWhitespaces.Checked)
            {
                xmlWriter.WriteAttributeString("normalizewhitespace", "yes");
            }
            if (SourceNormalizeNativeChars.Checked)
            {
                xmlWriter.WriteAttributeString("normalizeaccents", "yes");
            }
            xmlWriter.WriteAttributeString("powersearch", "yes");
            xmlWriter.WriteAttributeString("searchmode", searchMode);
            
            if (SourceTerm == "&quot;&quot;")
            {
                SourceTerm = "";
            }
            xmlWriter.WriteRaw(SourceTerm);
            xmlWriter.WriteEndElement();
        }


        public void TargetParms(XmlWriter xmlWriter, string TargetTerm, string searchMode)
        {

            xmlWriter.WriteStartElement("term");
            xmlWriter.WriteAttributeString("type", "target");
            xmlWriter.WriteAttributeString("xml", "space", null, "preserve");

            if (TargetCaseSensitive.Checked)
            {
                xmlWriter.WriteAttributeString("casecheck", "yes");
            }
            if (TargetMatchWholeWord.Checked)
            {
                xmlWriter.WriteAttributeString("wholeword", "yes");
            }
            if (TargetNoWhitespaceTrimming.Checked)
            {
                xmlWriter.WriteAttributeString("notrim", "yes");
            }
            if (TargetNormalizeWhitespaces.Checked)
            {
                xmlWriter.WriteAttributeString("normalizewhitespace", "yes");
            }
            if (TargetNormalizeNativeChars.Checked)
            {
                xmlWriter.WriteAttributeString("normalizeaccents", "yes");
            }
            xmlWriter.WriteAttributeString("powersearch", "yes");
            xmlWriter.WriteAttributeString("searchmode", searchMode);           
            if (TargetTerm == "&quot;&quot;")
            {
                TargetTerm = "";
            }
            xmlWriter.WriteRaw(TargetTerm);
            xmlWriter.WriteEndElement();
        }

        public void Description(XmlWriter xmlWriter, string description)
        {
            xmlWriter.WriteStartElement("description");
            xmlWriter.WriteAttributeString("xml", "space", null, "preserve");
            xmlWriter.WriteRaw(description);
            xmlWriter.WriteEndElement();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SearchModeCombobox.SelectedItem = "Simple";
        }



        private void SearchModeCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    class Entry
    {
        public string Checkname { get; set; }
        public string SourceTerm { get; set; }
        public string TargetTerm { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
