﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARKBreedingStats
{
    public partial class ARKOverlay : Form
    {
        private Control[] labels = new Control[10];
        public Timer inventoryCheckTimer = new Timer();
        public Form1 ExtractorForm;
        public bool OCRing = false;
        public List<TimerListEntry> timers = new List<TimerListEntry>();
        public static ARKOverlay theOverlay;
        private DateTime infoShownAt;
        public int InfoDuration;

        public ARKOverlay()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;

            infoShownAt = DateTime.Now.AddMinutes(-10);

            labels[0] = lblLevel;
            labels[1] = lblHealth;
            labels[2] = lblStamina;
            labels[3] = lblOxygen;
            labels[4] = lblFood;
            labels[5] = lblWeight;
            labels[6] = lblMeleeDamage;
            labels[7] = lblMovementSpeed;
            labels[8] = lblExtraText;
            labels[9] = lblBreedingProgress;

            foreach (Label l in labels)
                l.Text = "";
            lblStatus.Text = "Overlay";
            labelTimer.Text = "";

            this.Location = Point.Empty;
            this.Size = new Size(2000, 2000);

            inventoryCheckTimer.Interval = 1500;
            inventoryCheckTimer.Tick += inventoryCheckTimer_Tick;
            theOverlay = this;


            if (ArkOCR.OCR.currentResolutionW == 0 && !ArkOCR.OCR.setResolution())
                MessageBox.Show("Couldn't calibrate for the current resolution, sorry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            labelInfo.Location = new Point(ArkOCR.OCR.currentResolutionW - (labelInfo.Width + 30), 40); ;

            InfoDuration = 10;
        }

        void inventoryCheckTimer_Tick(object sender, EventArgs e)
        {
            if (OCRing == true)
                return;
            lblStatus.Text = "..";
            Application.DoEvents();
            OCRing = true;
            if (!ArkOCR.OCR.isDinoInventoryVisible())
            {
                for (int i = 0; i < labels.Count(); i++)
                    if (labels[i] != null)
                        labels[i].Text = "";
            }
            else
            {
                lblStatus.Text = "Reading Values";
                Application.DoEvents();
                if (ExtractorForm != null)
                    ExtractorForm.doOCR("", false);
            }
            OCRing = false;
            lblStatus.Text = "";
            Application.DoEvents();

            // info
            if (labelInfo.Text != "" && infoShownAt.AddSeconds(InfoDuration) < DateTime.Now)
                labelInfo.Text = "";

            return;
        }

        public void setValues(float[] wildValues, float[] tamedValues, Color[] colors = null)
        {
            foreach (KeyValuePair<string, int[]> kv in ArkOCR.OCR.statPositions)
            {
                if (kv.Key == "Torpor")
                    continue;

                int statIndex = -1;
                switch (kv.Key)
                {
                    case "NameAndLevel": statIndex = 0; break;
                    case "Health": statIndex = 1; break;
                    case "Stamina": statIndex = 2; break;
                    case "Oxygen": statIndex = 3; break;
                    case "Food": statIndex = 4; break;
                    case "Weight": statIndex = 5; break;
                    case "Melee Damage": statIndex = 6; break;
                    case "Movement Speed": statIndex = 7; break;
                    default: break;
                }

                if (statIndex == -1)
                    continue;

                labels[statIndex].Text = "[w" + wildValues[statIndex];
                if (tamedValues[statIndex] != 0)
                    labels[statIndex].Text += " + d" + tamedValues[statIndex];
                labels[statIndex].Text += "]";
                labels[statIndex].Location = this.PointToClient(ArkOCR.OCR.lastLetterPositions[kv.Key]);

                if (kv.Key != "NameAndLevel")
                    labels[statIndex].ForeColor = colors[statIndex];
            }
            lblStatus.Location = new Point(labels[0].Location.X - 100, 10);
            lblExtraText.Location = new Point(labels[0].Location.X - 100, 40);
            lblBreedingProgress.Text = "";
        }

        internal void setExtraText(string p)
        {
            if (ArkOCR.OCR.lastLetterPositions.ContainsKey("NameAndLevel"))
            {
                lblExtraText.Visible = true;
                labelInfo.Visible = false;
                //Point loc = this.PointToClient(ArkOCR.OCR.lastLetterPositions["NameAndLevel"]);
                Point loc = this.PointToClient(new Point(ArkOCR.OCR.statPositions["NameAndLevel"][0], ArkOCR.OCR.statPositions["NameAndLevel"][1]));

                loc.Offset(0, 30);

                lblExtraText.Text = p;
                lblExtraText.Location = loc;
            }
        }

        internal void setInfoText(string p)
        {
            lblExtraText.Visible = false;
            labelInfo.Visible = true;
            labelInfo.Text = p;
            infoShownAt = DateTime.Now;
        }

        public void setTimer()
        {
            //todo
            labelTimer.Text = "";
        }

        internal void setBreedingProgressValues(float percentage, int maxTime)
        {
            return;
            // current weight cannot be read in the new ui. TODO remove this function when current weight is confirmed to be not shown anymore
            if (percentage >= 1)
            {
                lblBreedingProgress.Text = "";
                return;
            }
            string text = "";
            text = string.Format(@"Progress: {0:P2}", percentage);
            TimeSpan ts;
            string tsformat = "";
            if (percentage <= 0.1)
            {
                ts = new TimeSpan(0, 0, (int)(maxTime * (0.1 - percentage)));
                tsformat = "";
                tsformat += ts.Days > 0 ? "d'd'" : "";
                tsformat += ts.Hours > 0 ? "hh'h'" : "";
                tsformat += ts.Minutes > 0 ? "mm'm'" : "";
                tsformat += "ss's'";

                text += "\r\n[juvenile: " + ts.ToString(tsformat) + "]";
            }
            if (percentage <= 0.5)
            {
                ts = new TimeSpan(0, 0, (int)(maxTime * (0.5 - percentage)));
                tsformat = "";
                tsformat += ts.Days > 0 ? "d'd'" : "";
                tsformat += ts.Hours > 0 ? "hh'h'" : "";
                tsformat += ts.Minutes > 0 ? "mm'm'" : "";
                tsformat += "ss's'";

                text += "\r\n[adolescent: " + ts.ToString(tsformat) + "]";
            }

            ts = new TimeSpan(0, 0, (int)(maxTime * (1 - percentage)));
            tsformat = "";
            tsformat += ts.Days > 0 ? "d'd'" : "";
            tsformat += ts.Hours > 0 ? "hh'h'" : "";
            tsformat += ts.Minutes > 0 ? "mm'm'" : "";
            tsformat += "ss's'";

            text += "\r\n[adult: " + ts.ToString(tsformat) + "]";

            lblBreedingProgress.Text = text;
            lblBreedingProgress.Location = this.PointToClient(ArkOCR.OCR.lastLetterPositions["CurrentWeight"]);
        }
    }
}
