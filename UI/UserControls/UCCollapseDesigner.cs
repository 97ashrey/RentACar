using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Design;

namespace UI.UserControls
{
    public class UCCollapseDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            Control panelContent = ((UCCollapse)this.Control).Content;
            // By calling EnableDesignMode method, 
            // we have enabled the contents panel 
            // at design time to allow user interaction with the contents panel.
            this.EnableDesignMode(panelContent, "ContentPanel");
        }

        // We override CanParent method to prevent 
        // user from dragging control of the form into the user control.
        public override bool CanParent(Control control)
        {
            return false;
        }

        /*
         * We override OnDragOver to show suitable mouse icon 
         * that shows dropping is not allowed on user control.
         */
        protected override void OnDragOver(DragEventArgs de)
        {
            de.Effect = DragDropEffects.None;
        }

        /*
        * We override CreateToolCore to 
        * prevent users from dropping 
        * controls from toolbox on the user control.
        */
        protected override IComponent[] CreateToolCore(ToolboxItem tool,
            int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            return null;
        }
    }
}
