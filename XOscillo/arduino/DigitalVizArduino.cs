﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace XOscillo
{
   public partial class DigitalVizArduino : VizForm
   {
      DigitalArduino oscillo = new DigitalArduino();

      public DigitalVizArduino()
      {
      }

      override public void Form_Load(object sender, EventArgs e)
      {
         Autodetection<DigitalArduino> au = new Autodetection<DigitalArduino>();
         DigitalArduino oscillo = au.Detection();
         m_Acq = new Acquirer();
         m_Acq.Open(oscillo, graphControl.GetConsumer());
         SetToolbar(new DigitalArduinoToolStrip(oscillo, graphControl));

         commonToolStrip = new CommonToolStrip(this, m_Acq, graphControl);

         commonToolStrip.time.Items.Add(1.0);
         commonToolStrip.time.Items.Add(0.5);
         commonToolStrip.time.Items.Add(0.2);
         commonToolStrip.time.Items.Add(0.1);
         commonToolStrip.time.Items.Add(0.05);
         commonToolStrip.time.Items.Add(0.02);
         commonToolStrip.time.Items.Add(0.01);
         commonToolStrip.time.Items.Add(0.005);
         commonToolStrip.time.Items.Add(0.002);
         commonToolStrip.time.Items.Add(0.001);
         commonToolStrip.time.Items.Add(0.0005);
         commonToolStrip.time.Items.Add(0.0002);
         commonToolStrip.time.SelectedIndex = 10;

         SetToolbar(commonToolStrip);

         GraphDigital gd = new GraphDigital();

         gd.SetVerticalRange(0, 255, (float)(255.0 / 6.5), "Volts");

         graphControl.SetRenderer(gd);
      }

   }
}
