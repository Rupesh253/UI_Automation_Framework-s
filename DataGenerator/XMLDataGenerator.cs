using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DataGenerator
{
    public partial class XMLDataGenerator : Form
    {

        public XMLDataGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOfSetsRequired = Convert.ToInt16(textBox2.Text.ToString());
            string subStringUsed = textBox1.Text.ToString();

            label6.Text = AppDomain.CurrentDomain.BaseDirectory;
            string modify = (label6.Text.ToString()).
                            Replace("DataGenerator", "SomeTestingInAutomation").
                            Replace("bin", "TestData").
                            Replace("Debug\\", "");
            string news = label8.Text = modify + "TestXML_2" + ".xml";
            label9.Text = numberOfSetsRequired.ToString();

            if (numberOfSetsRequired > 0 && Convert.ToString(numberOfSetsRequired) != null)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                    doc.AppendChild(declaration);
                    XmlElement root = doc.CreateElement("Credentials");
                    doc.AppendChild(root);
                    XmlElement xmlElement = null;

                    for (int i = 1; i <= numberOfSetsRequired; i++)
                    {
                        StringBuilder sbSet = new StringBuilder("Set");
                        sbSet.Append(Convert.ToString(i));
                        string set = sbSet.ToString();

                        xmlElement = doc.CreateElement(set);
                        XmlElement subElementUsername = doc.CreateElement("Username");
                        subElementUsername.InnerText = "Rupesh";
                        XmlElement subElementPassword = doc.CreateElement("Password");
                        subElementPassword.InnerText = "123";
                        xmlElement.AppendChild(subElementUsername);
                        xmlElement.AppendChild(subElementPassword);
                        root.AppendChild(xmlElement);
                        xmlElement = null;
                    }

                    doc.Save(news);

                    MessageBox.Show("Generated.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (File.Exists(news))
                    {
                        XmlDocument docCreated = new XmlDocument();
                        docCreated.Load(news);
                        XmlNode nodeUsername = null;
                        XmlNode nodePassword = null;

                        for (int i = 1; i <= numberOfSetsRequired; i++)
                        {
                            StringBuilder sbSetUsername = new StringBuilder("Set");
                            sbSetUsername.Append(Convert.ToString(i));
                            sbSetUsername.Append("/Username");
                            string xpathUsername = lblName.Text = sbSetUsername.ToString();
                            nodeUsername = docCreated.DocumentElement.SelectSingleNode(xpathUsername);
                            lblNameValue.Text = nodeUsername.InnerText;

                            StringBuilder sbSetPassword = new StringBuilder("Set");
                            sbSetPassword.Append(Convert.ToString(i));
                            sbSetPassword.Append("/Password");
                            string xpathPassword = lblPass.Text = sbSetPassword.ToString();
                            nodePassword = docCreated.DocumentElement.SelectSingleNode(xpathPassword);
                            lblPassValue.Text = nodePassword.InnerText;

                            sbSetUsername = sbSetPassword = null;

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Source + "***\n" + ex.StackTrace + "%%%\n" + ex.Message);
                }
            }









        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void XMLDataGenerator_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.White;
            this.Opacity = 100;
            this.TransparencyKey = Color.White;
            this.SetStyle ( ControlStyles.UserPaint,true);
        }
    }
}
