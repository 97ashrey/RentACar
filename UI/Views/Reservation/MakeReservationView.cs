using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views.Reservation
{
    public partial class MakeReservationView : UserControl
    {
        private Control carFilterView;
        private Control carSelectView;
        private Control createReservationView;

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
            
            this.carFilterView.Dock = DockStyle.Fill;
            ucCollapse.Content.Controls.Add(this.carFilterView);
            this.carSelectView.Dock = DockStyle.Fill;
            panelCarSelect.Controls.Add(this.carSelectView);
            this.createReservationView.Dock = DockStyle.Fill;
            panelMakeReservation.Controls.Add(this.createReservationView);
        }
    }
}
