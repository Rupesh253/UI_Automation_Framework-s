using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Xceed.Words.NET;

namespace SomeTestingInAutomation.TestReporter.TestAuditFiles
{
    public class AuditFile
    {
        public void LoadDictionary()
        {
            Dictionary<int, string> loginDictionary = new Dictionary<int, string>();
            loginDictionary.Add(1, "Welcome to Login");
            loginDictionary.Add(2, "Enter All your details");


            Dictionary<int, string> registrationDictionary = new Dictionary<int, string>();
            registrationDictionary.Add(1, "Welcome to Regitsration Page");
            registrationDictionary.Add(2, "Enter your all details to do registration");

        }

        public void Generate(string methodName, int setNumber, string fileName)
        {
            LoadDictionary();
            Dictionary<int, string> loginDictionary = new Dictionary<int, string>();
            loginDictionary.Add(1, "Welcome to Login");
            loginDictionary.Add(2, "Enter All your details");


            Dictionary<int, string> registrationDictionary = new Dictionary<int, string>();
            registrationDictionary.Add(1, "Welcome to Regitsration Page");
            registrationDictionary.Add(2, "Enter your all details to do registration");

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string tempDirectory = baseDirectory.Replace("bin", "TestReporter").Replace("Debug", "TestPics");
            string finalDirectoryForPics = tempDirectory + @"\" + methodName + @"\" + "set" + setNumber.ToString() + @"\";
            string docxPath = finalDirectoryForPics.Replace("TestPics","TestAuditFiles") + "Audit_Document" + ".docx";
           

            try
            {
                if (!Directory.Exists(finalDirectoryForPics))
                {
                    switch (methodName)
                    {
                        case "Login":
                            using (DocX doc = DocX.Create(docxPath))
                            {
                                for (int i=1;i<=loginDictionary.Count;i++)
                                {
                                    Image image = doc.AddImage(@"E:\Automation Frameworks\SomeThingInAutomation\SomeTestingInAutomation\TestReporter\TestPics\Rupi4.PNG");
                                    Picture picture = image.CreatePicture();
                                    doc.InsertParagraph(loginDictionary[i]).AppendLine().AppendPicture(picture).AppendLine();
                                }
                                    doc.Save();
                            }
                            break;
                        case "Registration":
                            using (DocX doc = DocX.Create(docxPath))
                            {
                                for (int i = 1; i <= registrationDictionary.Count; i++)
                                {
                                    Image image = doc.AddImage("imagepath");
                                    Picture picture = image.CreatePicture();
                                    doc.InsertParagraph(registrationDictionary[i]).AppendLine().AppendPicture(picture).AppendLine();
                                }
                                doc.Save();
                            }
                            break;



                    }





                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
