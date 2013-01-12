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
        //
        //Summary:
        //  The method finds the first matching node in the immediate child nodes.
        //A node is said to be matching if the required nodeName is found and if all the attribute names and values passed to the method are found.
        //
        //Parameters:
        //  nodeElement:
        //      The xml file/nodes in which the required pattern needs to be searched
        //  nodeName:
        //      The nodeName which needs to be found in the 'nodeElement'
        //  attributeNames:
        //      The list of attribute names which should also be present in the matching node
        //  attributeValues:
        //      The values of the corresponding attributeNames
        //
        //Returns:
        //  Returns the first matching node in the immediate list of children
        //  OR returns null if known exceptions are thrown & handled.
        //
        public XmlNode findFirstNode(ref XmlElement nodeElement, string nodeName, String[] attributeNames, String[] attributeValues)
        {
            try
            {
                if (!areAttributeRefsValid(attributeNames, attributeValues))
                {
                    throw new NullReferenceException("Either 'Attribute names' or 'Attribute values' or both are null.");
                }
                if (!areAttributesLenValid(attributeNames, attributeValues))
                {
                    throw new ArgumentException("The number of attribute names & values do not match when searching for node");
                }
                if (nodeElement == null || nodeName == "")
                {
                    throw new ArgumentException("Either nodeName or node is empty");
                }
                XmlNode node = nodeElement.FirstChild;
                if (attributeNames.Length == 0)
                    return node;
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
                MessageBox.Show(e.Message, "Exception Occurred\n"+e.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.ToString(), "Exception Occurred\n"+e.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }

        private bool areAttributeRefsValid(String[] attributeOne, String[] attributeTwo)
        {
            if (attributeOne == null || attributeTwo == null)
            {
                return false;
            }
            return true;
        }

        private bool areAttributesLenValid(String[] attributeOne, String[] attributeTwo)
        {
            if (attributeOne.Length!=attributeTwo.Length)
            {
                return false;
            }
            return true;
        }
    }
}
