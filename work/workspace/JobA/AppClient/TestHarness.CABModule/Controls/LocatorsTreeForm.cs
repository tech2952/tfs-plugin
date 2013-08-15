using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaxApp.InterfacesAndConstants;

namespace TestHarness.CABModule.Controls
{
    public partial class LocatorsTreeForm : Form
    {
        private UserConfigurationItems myUserConfigurationItems;
        private List<LocatorInfo> mySelectedLocators = new List<LocatorInfo>();
        public List<LocatorInfo> SelectedLocators { get { return mySelectedLocators; } }
        private ITaxAppClientData myTaxAppClientData;

        public LocatorsTreeForm(UserConfigurationItems userConfigItems, ITaxAppClientData taxAppClientData, bool treeCheckMode)
        {
            InitializeComponent();
            myUserConfigurationItems = userConfigItems;
            myTaxAppClientData = taxAppClientData;
            if (treeCheckMode)
            {
                this.treeViewLocators.CheckBoxes = true;
                this.Text = "Delete Locators";
            }
            else
            {
                this.panelButtons.Visible = false;
                this.Text = "Open Locator";
            }
        }

        private void LocatorsTreeForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            treeViewLocators.BeginUpdate();
            treeViewLocators.Nodes.Clear();
            try
            {
                List<ClientIDAndNameWithLocatorDictionary> clients = myTaxAppClientData.GetAllClientNames();
                if (clients.Count == 0)
                {
                    treeViewLocators.Nodes.Add("DummyClientNode", "No Clients found in database", 0, 0);
                    return;
                }
                foreach (ClientIDAndNameWithLocatorDictionary c in clients)
                {
                    TreeNode clientNode = treeViewLocators.Nodes.Add(c.ClientID.ToString(), c.ClientName, 0, 0);
                    foreach (LocatorInfo locator in c.Locators)
                    {
                        TreeNode locatorNode = clientNode.Nodes.Add(locator.LocatorID.ToString(), locator.Year + " - " + locator.Name, 1, 1);
                        locatorNode.Tag = locator.Year;
                    }

                    if (c.ClientName == myUserConfigurationItems.ClientName)
                    {
                        clientNode.Expand();
                        treeViewLocators.SelectedNode = clientNode;
                    }
                }
            }
            finally
            {
                treeViewLocators.EndUpdate();
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            foreach (TreeNode clientNode in this.treeViewLocators.Nodes)
            {
                foreach (TreeNode locatorNode in clientNode.Nodes)
                {
                    if (locatorNode.Checked)
                    {
                        //delete this locator
                        LocatorInfo locator = new LocatorInfo(Int32.Parse(locatorNode.Name), "", short.Parse(locatorNode.Tag.ToString()));
                        mySelectedLocators.Add(locator);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void treeViewLocators_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 0)
            {
                //client node, should check/uncheck all the children 
                foreach (TreeNode locatorNode in e.Node.Nodes)
                    locatorNode.Checked = e.Node.Checked;
            }
        }

        private void treeViewLocators_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //delete mode
            if (this.treeViewLocators.CheckBoxes == true)
                return;

            //client node
            if (e.Node.ImageIndex == 0)
                return;
            myUserConfigurationItems.Year = Convert.ToInt16(e.Node.Tag);
            myUserConfigurationItems.LastOpenLocatorID = Convert.ToInt32(e.Node.Name);
            myUserConfigurationItems.LastOpenLocatorName = e.Node.Text.Substring(7);
            myUserConfigurationItems.SaveToXMLFile();

            mySelectedLocators.Add(new LocatorInfo(Int32.Parse(e.Node.Name), e.Node.Text.Substring(7), short.Parse(e.Node.Tag.ToString())));
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}