using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static Monopoly.Models.Player;

namespace Monopoly.Views
{
    public partial class PlayerSelector : UserControl
    {
        private bool _isActive = false;

        public PlayerColor Color { get; set; }

        public string PlayerName {
            get => tbxNamePlayer.Text;
            set { tbxNamePlayer.Text = value; }
        }

        public bool IsActive {
            get => _isActive;
            set
            {
                _isActive = value;

                if (value == false)
                    tbxNamePlayer.Text = string.Empty;

                // tbxNamePlayer.BorderStyle = IsActive ? BorderStyle.Fixed3D : BorderStyle.None;

                // tbxNamePlayer.BackColor = IsActive ? System.Drawing.Color.White : System.Drawing.Color.LightGray;
                tbxNamePlayer.Enabled = value;

                btnAddPlayer.Focus();
                btnAddPlayer.Text = value ? "-" : "+";

                Invalidate();
            }
        }

        public PlayerSelector()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            SolidBrush brush = IsActive
                ? new SolidBrush(Color.GetColor())
                : new SolidBrush(System.Drawing.Color.FromArgb(120, Color.GetColor()));

            base.OnPaintBackground(e);
            e.Graphics.FillEllipse(brush, 10, 10, 40, 40);

            RectangleF drawZone = e.Graphics.VisibleClipBounds;
            Pen pen = IsActive ? Pens.Gray : Pens.Silver;
            e.Graphics.DrawRectangle(pen, 0, 0, drawZone.Width - 1, drawZone.Height - 1);
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            IsActive = !IsActive;
        }
    }
}
