using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Windows;
using System.IO;

namespace Cooredraw
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd;
        SaveFileDialog sfd;

        //
        //
        ////
        ////
        //////
        ////// Setup
        Timer checkIncommingMessage;
        public Form1()
        {
            InitializeComponent();
            pbCanvas.Width = this.Width - gbTools.Width - 20;
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;
            btnClearCanvas.Enabled = false;
            btnSave.Enabled = false;
            btnSaveAs.Enabled = false;
            btnEraser.Enabled = false;

            fillCbAvailablePorts();
            fillCbBoudrates();
            fillPencilComboBox();

            btnCreateCanvas.Enabled = false;
            pbCanvas.BringToFront();

            ofd = new OpenFileDialog();
            sfd = new SaveFileDialog();

            Draw.PointsToDrawList.Add(new Draw.pointsToDraw(new Point(), new Pen(Color.Black)));
            Draw.Points.Add(new Point());

            foreach (PropertyInfo prop in typeof(Brushes).GetProperties())
            {
                
                lbCanvasBackGround.Items.Add(prop.Name);
            }

            tbFontThickness.Text = "3";

            tabCanvas.Enabled = false;

            checkIncommingMessage = new Timer();
            checkIncommingMessage.Interval = 10;
            checkIncommingMessage.Tick += new EventHandler(CheckIncommingMessage_Tick);

            pnlFontColor.BackColor = Color.Black;
        }        

        void fillPencilComboBox()
        {
            cbPencilTypes.Items.Add(pencil.Dot);
            cbPencilTypes.Items.Add(pencil.Polygon);
            cbPencilTypes.Items.Add(pencil.Line);
            cbPencilTypes.Items.Add(pencil.Bezier);
            cbPencilTypes.Items.Add(pencil.Beziers);
            cbPencilTypes.Items.Add(pencil.Curve);

            cbPencilTypes.SelectedIndex = 0;
        }

        void fillCbAvailablePorts()
        {
            foreach(string s in Port.portNames())
            {
                cbAvailablePorts.Items.Add(s);
            }
        }

        void fillCbBoudrates()
        {
            foreach(string s in Port.boudrates())
            {
                cbBoudrates.Items.Add(s);
            }
        }


        int x = 0;
        int y = 0;
        Image img;

        private void btnCreateCanvas_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbWidthResolution.Text) && !String.IsNullOrEmpty(tbHeightResolution.Text))
            {
                

                try { bool intWidth = int.TryParse(tbWidthResolution.Text, out x); }
                catch { MessageBox.Show("The entered width isn't valid.", "Resolution error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                try { bool intHeight = int.TryParse(tbHeightResolution.Text, out y); }
                catch { MessageBox.Show("The entered width isn't valid.", "Resolution error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                pbCanvas.Width = x;
                pbCanvas.Height = y;

                Draw.bmp = new Bitmap(x, y);
                pbCanvas.Image = Draw.bmp;
                img = pbCanvas.Image;

                sendBoundries();

                tabCanvas.Enabled = true;

                nextTab();
            }
            else
            {
                MessageBox.Show("Please enter a width and height for the resolution.", "Resolution error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string opendFileName;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //ofd.Filter = "Image Files (*.bmp)|*.bmp";
            ofd.ShowDialog();
            if (!String.IsNullOrEmpty(ofd.FileName))
            {
                opendFileName = ofd.FileName;
                Draw.bmp = new Bitmap(ofd.FileName);
                pbCanvas.Width = Draw.bmp.Width;
                pbCanvas.Height = Draw.bmp.Height;

                x = pbCanvas.Width;
                y = pbCanvas.Height;

                if (sendBoundries())
                {
                    pbCanvas.Image = Draw.bmp;
                    img = pbCanvas.Image;
                    tabCanvas.Enabled = true;
                    nextTab();
                }
            }
        }

        bool sendBoundries()
        {
            try
            {
                if (connection.connectionPort.IsOpen)
                {
                    messageSender.sendMessage("CANVAS_WIDTH:" + x);
                    messageSender.sendMessage("CANVAS_HEIGHT:" + y);
                }
                return true;
            }
            catch 
            {
                if (MessageBox.Show("The Arduino isn't connected.\nIf you just want to see the file, click OK.\nElse if you want to edit the file click cancel and connect the Arduino.", "No connection", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            finally
            {
                pnlPictureBoxShading.Width = x;
                pnlPictureBoxShading.Height = y;
            }
        }

        void nextTab()
        {
            try { tbTabControl.SelectedIndex++; }
            catch { tbTabControl.SelectedIndex = 0; }
        }
        //////
        //////
        ////
        ////
        //
        //



        //
        //
        ////
        ////
        //////
        ////// Make connection
        private void btnPortRefresh_Click(object sender, EventArgs e)
        {
            cbAvailablePorts.Items.Clear(); ;
            fillCbAvailablePorts();
        }

        private void cbAvailablePorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableConnectButton();
        }

        private void cbBoudrates_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableConnectButton();
        }

        void enableConnectButton()
        {
            if (cbAvailablePorts.SelectedItem != null && cbBoudrates.SelectedItem != null)
            {
                btnConnect.Enabled = true;
            }
        }

        Receive_message receiveMessage;
        Port connection;
        Send_message messageSender;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            connection = new Port();
            connection.connect(cbAvailablePorts.SelectedItem.ToString(), Convert.ToInt32(cbBoudrates.SelectedItem));
            if (connection.connectionPort.IsOpen)
            {
                receiveMessage = new Receive_message(connection.connectionPort);
                btnConnect.Enabled = false;
                messageSender = new Send_message(connection.connectionPort);
                btnDisconnect.Enabled = true;
                checkIncommingMessage.Start();

                btnCreateCanvas.Enabled = true;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (connection.disconnect())
            {
                btnDisconnect.Enabled = false;
                btnCreateCanvas.Enabled = false;
            }
            
        }
        //////
        //////
        ////
        ////
        //
        //



        //
        //
        ////
        ////
        //////
        ////// Read incomming message
        int X;
        int Y;
        int state;
        int fontR;
        int fontG;
        int fontB;
        private void CheckIncommingMessage_Tick(object sender, EventArgs e)
        {
            receiveMessage.readMessage();
            string message = receiveMessage.returnMessage();

            if (!String.IsNullOrEmpty(message))
            {
                if (MessageInterpreter.inerpretProgramState(message) == 1) { state = 1; }
                else if (MessageInterpreter.inerpretProgramState(message) == 2) { state = 2; }
                else if (MessageInterpreter.inerpretProgramState(message) == 3) { state = 3; }

                if (message.IndexOf("RED_VALUE") != -1)
                {
                    int fontRChecker = MessageInterpreter.interpretRedValue(message);
                    fontR = fontRChecker;
                    pnlFontColor.BackColor = Color.FromArgb(fontR, pnlFontColor.BackColor.G, pnlFontColor.BackColor.B);
                }
                if (message.IndexOf("GREEN_VALUE") != -1)
                {
                    int fontGChecker = MessageInterpreter.interpretGreenValue(message);
                    fontG = fontGChecker;
                    pnlFontColor.BackColor = Color.FromArgb(pnlFontColor.BackColor.R, fontG, pnlFontColor.BackColor.B);
                }
                if (message.IndexOf("BLUE_VALUE") != -1)
                {
                    int fontBChecker = MessageInterpreter.interpretBlueValue(message);
                    fontB = fontBChecker;
                    pnlFontColor.BackColor = Color.FromArgb(pnlFontColor.BackColor.R, pnlFontColor.BackColor.G, fontB);
                }

                lblRGBValues.Text = "R: " + pnlFontColor.BackColor.R.ToString() + " G: " + pnlFontColor.BackColor.G.ToString() + " B: " + pnlFontColor.BackColor.B.ToString();
            }

            if (state == 1) { draw(message); }
            if (state == 2) { btnClearCanvas.Enabled = true; btnSave.Enabled = true; btnSaveAs.Enabled = true; btnEraser.Enabled = true; }
            else { btnClearCanvas.Enabled = false; btnSave.Enabled = false; btnSaveAs.Enabled = false; btnEraser.Enabled = false; }
        }
        //////
        //////
        ////
        ////
        //
        //



        //
        //
        ////
        ////
        //////
        ////// Paint
        void draw(string Message) // Interprets the message to get coordinates.
        {
            int X1 = MessageInterpreter.interpretXCoordinate(Message);
            int Y1 = MessageInterpreter.interpretYCoordinate(Message);
            if (X1 != 0)
            {
                X = X1;
            }
            if (Y1 != 0)
            {
                Y = Y1;
            }
            pbCanvas.Invalidate();         
        }

        Graphics g;
        Color backColor;
        private void pbCanvas_Paint(object sender, PaintEventArgs e) // Draws the coordinates.
        {
            //g = e.Graphics;
            if (img != null)
            {
                g = Graphics.FromImage(img);
                Color color = Color.FromArgb(fontR, fontG, fontB);
                SolidBrush fontColor = new SolidBrush(color);
                backColor = pbCanvas.BackColor;
                Draw.drawPoint(backColor, fontColor, fontThickness, X, Y, g, whatToDraw);
                //pbCanvas.Image = Draw.bmp;
            }
        }
        //////
        //////
        ////
        ////
        //
        //



        //
        //
        ////
        ////
        //////
        ////// Paint tools
        private void lbCanvasBackGround_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color bkc = Color.FromName(lbCanvasBackGround.SelectedItem.ToString());
            pbCanvas.BackColor = bkc;
        }

        private void btnClearCanvas_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Everything you've drawn\non this canvas will be deleted.", "Clear canvas", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Draw.bmp = new Bitmap(x, y);
                pbCanvas.Image = Draw.bmp;
                img = pbCanvas.Image;

                Draw.PointsToDrawList.Clear();
                Draw.PointsToDrawList.Add(new Draw.pointsToDraw(new Point(), new Pen(Color.Black)));
                Draw.PointsList.Clear();
                Draw.Points.Clear();
                Draw.Points.Add(new Point());
                pbCanvas.Invalidate();
            }
        }

        string whatToDraw;
        private void cbPencilTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            whatToDraw = cbPencilTypes.SelectedItem.ToString();
        }

        int fontThickness;
        private void tbFontThickness_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbFontThickness.Text))
            {
                fontThickness = Convert.ToInt32(tbFontThickness.Text);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Image Files (*.bmp)|*.bmp";
            sfd.ShowDialog();
            if (!String.IsNullOrEmpty(sfd.FileName))
            {
                opendFileName = sfd.FileName;
                saveFile(opendFileName);
            }    
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFile(opendFileName);
        }

        void saveFile(string path)
        {
            Bitmap temp = new Bitmap(Draw.bmp.Width, Draw.bmp.Height);
            using (Graphics gr = Graphics.FromImage(temp))
            {
                gr.Clear(backColor);
                gr.DrawImage(Draw.bmp, 0, 0);
            }
            img = temp;

            string filePath = opendFileName;
            Draw.bmp.Dispose();
            if (File.Exists(path))
            {
                File.Delete(path);
                File.Create(filePath).Close();
            }

                img.Save(path, ImageFormat.Bmp);

            Draw.bmp = new Bitmap(filePath);
            pbCanvas.Width = Draw.bmp.Width;
            pbCanvas.Height = Draw.bmp.Height;

            x = pbCanvas.Width;
            y = pbCanvas.Height;

            if (sendBoundries())
            {
                pbCanvas.Image = Draw.bmp;
                img = pbCanvas.Image;
            }
        }

        

        bool eraserActive = false;
        private void btnEraser_Click(object sender, EventArgs e)
        {          
            if (!eraserActive)
            {               
                Cursor.Current = Cursors.Cross;
            }
            if (eraserActive)
            {
                Cursor.Current = Cursors.Default;
            }

            eraserActive = !eraserActive;
        }

        private void pbCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            int removeMargin = 20;

            Point pointToErase = e.Location;

            Draw.PointsToDrawList.Remove(Draw.PointsToDrawList.Find(p => p.PointValue.X <= pointToErase.X + removeMargin && p.PointValue.X >= pointToErase.X - removeMargin && p.PointValue.Y <= pointToErase.Y + removeMargin && p.PointValue.Y >= pointToErase.Y - removeMargin));

            Draw.PointsList.Remove(Draw.PointsList.Find(p => p.X <= pointToErase.X + removeMargin && p.X >= pointToErase.X - removeMargin && p.Y <= pointToErase.Y + removeMargin && p.Y >= pointToErase.Y - removeMargin));

            Draw.Points.Remove(Draw.Points.Find(p => p.X <= pointToErase.X + removeMargin && p.X >= pointToErase.X - removeMargin && p.Y <= pointToErase.Y + removeMargin && p.Y >= pointToErase.Y - removeMargin));
        }
        //////
        //////
        ////
        ////
        //
        //
    }
}
