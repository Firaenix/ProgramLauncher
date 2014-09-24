using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProgramLauncher.CustomClasses
{
    class XMLHandler
    {

        public static void writeListAndStringToXML(List<OtherExeContainer> otherAppList, string origString, string origParams, string xmlLocation)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                //Creates XML for the Initial Exe location.
                XmlNode allExesNode = xmlDoc.CreateElement("Executables");
                XmlNode initExeNode = xmlDoc.CreateElement("InitExe");
                //Set the parameters to be the attribute of the node
                XmlAttribute parAttribute = xmlDoc.CreateAttribute("Params");
                parAttribute.Value = origParams; 
                //Inner text to be the location
                initExeNode.InnerText =  origString;

                initExeNode.Attributes.Append(parAttribute);
                allExesNode.AppendChild(initExeNode);
                xmlDoc.AppendChild(allExesNode);

                XmlNode otherExesNode = xmlDoc.CreateElement("OtherExes");

                //Loop through every element in the list and create XML for each Location
                foreach (OtherExeContainer exe in otherAppList)
                {
                    XmlNode otherExeNode = xmlDoc.CreateElement("OtherExe");
                    XmlAttribute paramsAttribute = xmlDoc.CreateAttribute("Params");

                    paramsAttribute.Value = exe.getParam();
                    otherExeNode.InnerText = exe.getExe();
                    
                    otherExeNode.Attributes.Append(paramsAttribute);
                    otherExesNode.AppendChild(otherExeNode);
                }
                allExesNode.AppendChild(otherExesNode);

                //Overwrite existing file on save.
                //File.Delete(xmlLocation);
                xmlDoc.Save(xmlLocation);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not save preferences \n\n" + e.ToString());
            }
        }


        public static string[] readStringFromXML()
        {
            string[] initExeStrings = new string[2];
            //If the XML file is not empty...
            if (System.IO.File.ReadAllText(ConfigForm.getXmlLocation()).ToString() != "")
            {
                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.Load(ConfigForm.getXmlLocation());

                XmlNodeList initExeNodes = xmlDoc.SelectNodes("//Executables");

                
                //Should only have one of these.
                foreach (XmlNode exeNode in initExeNodes)
                {
                    if (exeNode.HasChildNodes)
                    {
                        initExeStrings[0] = exeNode["InitExe"].InnerText;
                        initExeStrings[1] = exeNode["InitExe"].Attributes["Params"].Value;
                    }
                }
                return initExeStrings;
            }
            return initExeStrings;
        }

        public static List<OtherExeContainer> readArrayFromXML()
        {
            List<OtherExeContainer> exeArray = new List<OtherExeContainer>();
            //If the XML file is not empty...
            if (System.IO.File.ReadAllText(ConfigForm.getXmlLocation()).ToString() != "")
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigForm.getXmlLocation());
                XmlNodeList exeNodes = xmlDoc.SelectNodes("//Executables/OtherExes");

                foreach (XmlNode exeNode in exeNodes)
                {
                    if (exeNode.HasChildNodes)
                    {
                        OtherExeContainer oExeContainer = new OtherExeContainer();

                        oExeContainer.setExe(exeNode["OtherExe"].InnerText);
                        oExeContainer.setParam(exeNode["OtherExe"].Attributes["Params"].Value);

                        exeArray.Add(oExeContainer);
                    }
                }

                return exeArray;
            }

            return exeArray;
        }

    }

    

}
