using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Windows.Forms;
using System.Collections;

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
        //      The string representation of the node name which needs to be found in the 'nodeElement'
        //  attributeNames:
        //      The list of attribute names which should also be present in the matching node
        //  attributeValues:
        //      The values of the corresponding attributeNames
        //
        //Returns:
        //  Returns the first matching node in the immediate list of children
        //  OR returns null if known exceptions are thrown & handled.
        //
        public XmlNode findFirstNode(XmlElement nodeElement, string nodeName, String[] attributeNames, String[] attributeValues)
        {
            try
            {
                if (!arePairRefsValid(attributeNames, attributeValues))
                {
                    throw new NullReferenceException("Either 'Attribute names' or 'Attribute values' or both are null.");
                }
                if (!arePairLensValid(attributeNames, attributeValues))
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

        public XmlNode findFirstNode(XmlNode root, string nodeName, string textContent)
        {
            if (root.HasChildNodes)
            {
                IEnumerator rootEnumerator = root.ChildNodes.GetEnumerator();
                while(rootEnumerator.MoveNext())
                {
                    XmlNode innerNode = findFirstNode(((XmlNode)rootEnumerator.Current), nodeName, textContent);
                    if (innerNode != null)
                    {
                        return innerNode;
                    }
                }
            }
            if (root.InnerText.CompareTo("") != 0)
            {
                if (root.ParentNode.Name.CompareTo(nodeName)==0 && root.InnerText.CompareTo(textContent)==0)
                {
                    return root.ParentNode.ParentNode;
                }
                return null;
            }
            return null;
        }

        public void replaceElement(XmlNode parent, Hashtable nameValuePair)
        {
            foreach (String name in nameValuePair.Keys)
            {
                XmlNode node = parent;
                IEnumerator childNode = node.GetEnumerator();
                while(childNode.MoveNext())
                {
                    if (name.CompareTo(((XmlNode)childNode.Current).Name) == 0)
                    {
                        ((XmlNode)childNode.Current).InnerText = nameValuePair[name].ToString();
                        break;
                    }
                }
            }
        }

        public bool isNodeMatching(XmlNode node, Hashtable nameValuePair)
        {
            IEnumerator userParameter = node.ChildNodes.GetEnumerator();
            while(userParameter.MoveNext())
            {
                if( ((XmlNode)userParameter.Current) .Name.Equals("cost") && nameValuePair.ContainsKey("FromAmount"))
                {
                    double storedAmount = double.Parse(((XmlNode)userParameter.Current).InnerText);
                    double fromAmountFilter = (double)nameValuePair["FromAmount"];
                    double toAmountFilter = (double)nameValuePair["ToAmount"];
                    if (storedAmount < fromAmountFilter || storedAmount > toAmountFilter)
                        return false;
                }
                else if (((XmlNode)userParameter.Current).Name.Equals("category") && nameValuePair.ContainsKey("category"))
                {
                    ArrayList categoriesFilterItems = (ArrayList)nameValuePair["category"];
                    bool isCategoryFound = false;
                    foreach (string categoryFilter in categoriesFilterItems)
                    {
                        if (((XmlNode)userParameter.Current).InnerText.CompareTo(categoryFilter) == 0)
                        {
                            isCategoryFound = true;
                            break;
                        }
                    }
                    if (!isCategoryFound)
                    {
                        return false;
                    }
                }
                else
                {
                    if (!isInnerNodeMatched(((XmlNode)userParameter.Current), nameValuePair))
                        return false;
                }
            }
            return true;
        }

        private bool isInnerNodeMatched(XmlNode innerParameter, Hashtable nameValuePair)
        {
            if (nameValuePair.ContainsKey(innerParameter.Name))
            {
                if (innerParameter.InnerText.Equals(nameValuePair[innerParameter.Name].ToString()))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        private bool arePairRefsValid(String[] parameterOne, String[] parameterTwo)
        {
            if (parameterOne == null || parameterTwo == null)
            {
                return false;
            }
            return true;
        }

        private bool arePairLensValid(String[] parameterOne, String[] parameterTwo)
        {
            if (parameterOne.Length != parameterTwo.Length)
            {
                return false;
            }
            return true;
        }
    }
}
