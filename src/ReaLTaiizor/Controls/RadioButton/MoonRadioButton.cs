﻿#region Imports

using System.Drawing;
using ReaLTaiizor.Util;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

#endregion

namespace ReaLTaiizor.Controls
{
    #region MoonRadioButton

    [DefaultEvent("CheckedChanged")]
    public class MoonRadioButton : MoonControl
    {

        Color BG;
        Color FC;

        private bool _Checked;
        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                InvalidateControls();
                CheckedChanged?.Invoke(this);
                Invalidate();
            }
        }

        private Color _CheckedColor = Color.Gray;
        public Color CheckedColor
        {
            get { return _CheckedColor; }
            set
            {
                _CheckedColor = value;
                Invalidate();
            }
        }

        private Color _HoverColor = Color.White;
        public Color HoverColor
        {
            get { return _HoverColor; }
            set
            {
                _HoverColor = value;
                Invalidate();
            }
        }

        private Color _HoverBackColor = Color.Gray;
        public Color HoverBackColor
        {
            get { return _HoverBackColor; }
            set
            {
                _HoverBackColor = value;
                Invalidate();
            }
        }

        private Color _CircleColorA = Color.White;
        public Color CircleColorA
        {
            get { return _CircleColorA; }
            set
            {
                _CircleColorA = value;
                Invalidate();
            }
        }

        private Color _CircleColorB = Color.LightGray;
        public Color CircleColorB
        {
            get { return _CircleColorB; }
            set
            {
                _CircleColorB = value;
                Invalidate();
            }
        }

        private Color _CircleColorC = Color.LightGray;
        public Color CircleColorC
        {
            get { return _CircleColorC; }
            set
            {
                _CircleColorC = value;
                Invalidate();
            }
        }

        private SmoothingMode _SmoothingType = SmoothingMode.HighQuality;
        public SmoothingMode SmoothingType
        {
            get { return _SmoothingType; }
            set
            {
                _SmoothingType = value;
                Invalidate();
            }
        }

        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        private void InvalidateControls()
        {
            if (!IsHandleCreated || !_Checked)
                return;

            foreach (Control C in Parent.Controls)
            {
                if (!object.ReferenceEquals(C, this) && C is MoonRadioButton)
                    ((MoonRadioButton)C).Checked = false;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_Checked)
                Checked = true;
            base.OnMouseDown(e);
        }

        public MoonRadioButton()
        {
            LockHeight = 22;
            Width = 130;
            SetColor("BG", Color.FromArgb(240, 240, 240));
            SetColor("FC", Color.Gray);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 9);
        }

        protected override void ColorHook()
        {
            BG = GetColor("BG");
            FC = GetColor("FC");
        }

        protected override void PaintHook()
        {
            G.Clear(BG);

            G.SmoothingMode = SmoothingType;

            if (_Checked)
                G.FillEllipse(new SolidBrush(CheckedColor), new Rectangle(new Point(7, 7), new Size(8, 8)));

            if (State == MouseStateMoon.Over)
            {
                G.FillEllipse(new SolidBrush(HoverColor), new Rectangle(new Point(4, 4), new Size(14, 14)));
                if (_Checked)
                    G.FillEllipse(new SolidBrush(HoverBackColor), new Rectangle(new Point(7, 7), new Size(8, 8)));
            }

            G.DrawEllipse(new Pen(new SolidBrush(CircleColorA)), new Rectangle(new Point(3, 3), new Size(16, 16)));
            G.DrawEllipse(new Pen(new SolidBrush(CircleColorB)), new Rectangle(new Point(2, 2), new Size(18, 18)));
            G.DrawEllipse(new Pen(new SolidBrush(CircleColorC)), new Rectangle(new Point(4, 4), new Size(14, 14)));

            G.DrawString(Text, Font, new SolidBrush(FC), 23, 3);
        }
    }

    #endregion
}