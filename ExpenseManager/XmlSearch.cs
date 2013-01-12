using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;

namespace XmlOperations
{
    class XmlSearch
    {
        public XmlNode findFirstNode(ref XmlElement nodeElement, string nodeName, String[] attributeNames, String[] attributeValues)
        {
            try
            {
                if (attributeNames.Length != attributeValues.Length)
                {
                    throw new ArgumentException("The number of attribute names & values do not match when searching for node");
                }
                if (nodeElement == null || nodeName == "")
                {
                    throw new ArgumentException("Either nodeName or node is empty");
                }
                XmlNode node = nodeElement.FirstChild;
                do
                {
                    if (node != null && node.Name.Equals(nodeName))
                    {
                        bool mismatch = false;
                        XPathNavigator nodeNavigator = node.CreateNavigator();
                        for (int i = 0; i < attributeNames.Length; i++)
                        {
                            if (nodeNavigator.GetAttribute(attributeNames[i], "") != attributeValues[i])
                            {
                                mismatch = true;
                                break;
                            }
                        }
                        if (!mismatch)
                            return node;
                    }
                } while (node != null && (node = node.NextSibling) != null);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.ToString(), "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }
    }
}
