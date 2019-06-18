using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UserControls
{
    //[Designer(typeof(UCCollapseDesigner))]
    public partial class UCCollapse : UserControl
    {
        private int expandedHeight;
        private int collapsedHeight;
        int borderWidth = 1;
        private Padding ContentBorder;

        [
        Category("Collapse properties"),
        Description("Gets or sets the value indicating weather UCCollapse is in the collapsed state.")
        ]
        public bool Collapsed { get; set; }
        [
        Browsable(true),
        Category("Collapse properties"),
        Description("Gets or sets text asociated with this control")
        ]
        public string Heading { get => btnToggle.Text; set => btnToggle.Text = value; }
        
        public UCCollapse()
        {
            InitializeComponent();
            TypeDescriptor.AddAttributes(this.panelContent,
            new DesignerAttribute(typeof(UCCollapseContentDesigner)));
            SetToggleImages();
            ContentBorder = new Padding(borderWidth, 0, borderWidth, borderWidth);
            panelContentBorder.Padding = ContentBorder;
            panelContentBorder.BackColor = Color.LightGray;
        }
        
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel Content
        {
            get { return panelContent; }
        }

        public void AddControl(Control control)
        {
            control.Dock = DockStyle.Top;
            panelContent.Controls.Add(control);
            SetExpandedHeigth();
        }

        private void SetHeights()
        {
            collapsedHeight = btnToggle.Height;
            SetExpandedHeigth();
        }

        private void SetExpandedHeigth()
        {
            int height = 0;
            foreach(Control control in panelContent.Controls)
            {
                height += control.Height;
            }
            expandedHeight = height + collapsedHeight;
        }

        private void SetToggleImages()
        {
            ImageList imageList = new ImageList();
            Image upImg = Properties.Resources.arrow_up;
            Image downImg = Properties.Resources.arrow_down;
            imageList.Images.Add(downImg);
            imageList.Images.Add(upImg);
            btnToggle.ImageList = imageList;
            btnToggle.ImageIndex = 0;
        }

        private void ToggleCollapse()
        {
            Height = (Collapsed) ?  collapsedHeight : expandedHeight ;
        }

        private void ToggleImage()
        {
            btnToggle.ImageIndex = (Collapsed) ? 0 : 1;
        }

        private void UCCollapse_Load(object sender, EventArgs e)
        {
            SetHeights();
            ToggleCollapse();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            Collapsed = !Collapsed;
            ToggleCollapse();
            ToggleImage();
        }
    }
}
