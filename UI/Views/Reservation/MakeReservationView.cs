using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Events.Messages;

namespace UI.Views.Reservation
{
    public partial class MakeReservationView : UserControl, IMakeReservationView
    {
        private Control carFilterView;
        private Control carSelectView;
        private Control createReservationView;

        public object Presenter { private get; set; }

        protected MakeReservationView()
        {
            InitializeComponent();
        }

        public MakeReservationView(
            Control carFilterView,
            Control carSelectView,
            Control createReservationView) : this()
        {
            this.carFilterView = carFilterView;
            this.carSelectView = carSelectView;
            this.createReservationView = createReservationView;
            
            //this.carFilterView.Dock = DockStyle.Top;
            ucCollapse.AddControl(this.carFilterView);
            this.carSelectView.Dock = DockStyle.Top;
            panelCarSelect.Controls.Add(this.carSelectView);
            this.createReservationView.Dock = DockStyle.Top;
            panelMakeReservation.Controls.Add(this.createReservationView);
        }

        public void ShowAlertMessage(AlertMessage alertMessage)
        {
            ucAlert.Display(alertMessage);
        }
    }
}
