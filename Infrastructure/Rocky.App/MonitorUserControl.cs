using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Rocky.Net;

namespace Rocky.App
{
    public partial class MonitorUserControl : UserControl
    {
        #region Win32API������װ
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);
        #endregion

        #region Fields
        private Monitor _objRef;
        private Bitmap _bitmap;
        #endregion

        #region Properties
        public bool DoControl { get; set; }
        #endregion

        #region Constructors
        public MonitorUserControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        public void Initialize(EndPoint endPoint)
        {
            _objRef = MonitorChannel.Client(endPoint);
            Size desktopWindowSize = _objRef.GetDesktopSize();
            _bitmap = new Bitmap(desktopWindowSize.Width, desktopWindowSize.Height);
            this.AutoScrollMinSize = desktopWindowSize;
            this.UpdateDisplay();
        }
        #endregion

        #region ��Ļ
        public void UpdateDisplay()
        {
            lock (this)
            {
                byte[] bitmapBytes = _objRef.GetDesktopBitmapBytes();
                if (bitmapBytes.Length == 0)
                {
                    return;
                }

                var stream = new MemoryStream(bitmapBytes, false);
                _bitmap = (Bitmap)Image.FromStream(stream);
                Point point = new Point(AutoScrollPosition.X, AutoScrollPosition.Y);
                CreateGraphics().DrawImage(_bitmap, point);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitorUserControl_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                if (_bitmap == null)
                {
                    return;
                }

                Point point = new Point(AutoScrollPosition.X, AutoScrollPosition.Y);
                e.Graphics.DrawImage(_bitmap, point);
            }
        }
        #endregion

        #region ���
        private void MonitorUserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.DoControl)
            {
                return;
            }

            _objRef.MoveMouse(e.X, e.Y);
        }

        private void MonitorUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            _objRef.PressOrReleaseMouse(true, e.Button == MouseButtons.Left, e.X, e.Y);
        }

        private void MonitorUserControl_MouseUp(object sender, MouseEventArgs e)
        {
            _objRef.PressOrReleaseMouse(false, e.Button == MouseButtons.Left, e.X, e.Y);
        }
        #endregion

        #region ����
        private void MonitorUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            _objRef.SendKeystroke((byte)e.KeyCode, (byte)MapVirtualKey((uint)e.KeyCode, 0), true, false);
        }

        private void MonitorUserControl_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            _objRef.SendKeystroke((byte)e.KeyCode, (byte)MapVirtualKey((uint)e.KeyCode, 0), false, false);
        }
        #endregion
    }
}