﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using SodukuBase;
using SodukuFactory;
using SodukuGenerator;

namespace SodukuUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private static readonly int numbers = 9;

        private static Soduku sdk = new Soduku();

        private static SodukuBuilder sdkBuilder = new SodukuBuilder();

        private static SodukuQuestion sdkGenerator = new SodukuQuestion();

        private static SodukuMarket currentMarket;

        private static List<List<int>> questions;

        private static readonly List<string> vaildValues =
            new List<string> {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

      

        private void noticeNumberChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(noticeNumber.Text))
            //{
            //    noticeNumber.Text = "30";
            //}

            //int value = 0;
            //if (int.TryParse(noticeNumber.Text,out value))
            //{
            //    if (value<17)
            //    {
            //        noticeNumber.Text += "17";
            //    }

            //    if (value > 81)
            //    {
            //        noticeNumber.Text += "80";
            //    }
            //}
            //else
            //{
            //    noticeNumber.Text = "30";
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(this, true, null);
            locationClues = new Dictionary<string, CtlNoticePanel>();
            this.tableLayoutPanel1.GetType()
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(tableLayoutPanel1, true, null);
            helpMessage.Text = null;
            resultMessage.Text = null;
            TextBoxdic.Add("postion_0_0", postion_0_0);
            TextBoxdic.Add("postion_0_1", postion_0_1);
            TextBoxdic.Add("postion_0_2", postion_0_2);
            TextBoxdic.Add("postion_0_3", postion_0_3);
            TextBoxdic.Add("postion_0_4", postion_0_4);
            TextBoxdic.Add("postion_0_5", postion_0_5);
            TextBoxdic.Add("postion_0_6", postion_0_6);
            TextBoxdic.Add("postion_0_7", postion_0_7);
            TextBoxdic.Add("postion_0_8", postion_0_8);
            TextBoxdic.Add("postion_1_0", postion_1_0);
            TextBoxdic.Add("postion_1_1", postion_1_1);
            TextBoxdic.Add("postion_1_2", postion_1_2);
            TextBoxdic.Add("postion_1_3", postion_1_3);
            TextBoxdic.Add("postion_1_4", postion_1_4);
            TextBoxdic.Add("postion_1_5", postion_1_5);
            TextBoxdic.Add("postion_1_6", postion_1_6);
            TextBoxdic.Add("postion_1_7", postion_1_7);
            TextBoxdic.Add("postion_1_8", postion_1_8);
            TextBoxdic.Add("postion_2_0", postion_2_0);
            TextBoxdic.Add("postion_2_1", postion_2_1);
            TextBoxdic.Add("postion_2_2", postion_2_2);
            TextBoxdic.Add("postion_2_3", postion_2_3);
            TextBoxdic.Add("postion_2_4", postion_2_4);
            TextBoxdic.Add("postion_2_5", postion_2_5);
            TextBoxdic.Add("postion_2_6", postion_2_6);
            TextBoxdic.Add("postion_2_7", postion_2_7);
            TextBoxdic.Add("postion_2_8", postion_2_8);
            TextBoxdic.Add("postion_3_0", postion_3_0);
            TextBoxdic.Add("postion_3_1", postion_3_1);
            TextBoxdic.Add("postion_3_2", postion_3_2);
            TextBoxdic.Add("postion_3_3", postion_3_3);
            TextBoxdic.Add("postion_3_4", postion_3_4);
            TextBoxdic.Add("postion_3_5", postion_3_5);
            TextBoxdic.Add("postion_3_6", postion_3_6);
            TextBoxdic.Add("postion_3_7", postion_3_7);
            TextBoxdic.Add("postion_3_8", postion_3_8);
            TextBoxdic.Add("postion_4_0", postion_4_0);
            TextBoxdic.Add("postion_4_1", postion_4_1);
            TextBoxdic.Add("postion_4_2", postion_4_2);
            TextBoxdic.Add("postion_4_3", postion_4_3);
            TextBoxdic.Add("postion_4_4", postion_4_4);
            TextBoxdic.Add("postion_4_5", postion_4_5);
            TextBoxdic.Add("postion_4_6", postion_4_6);
            TextBoxdic.Add("postion_4_7", postion_4_7);
            TextBoxdic.Add("postion_4_8", postion_4_8);
            TextBoxdic.Add("postion_5_0", postion_5_0);
            TextBoxdic.Add("postion_5_1", postion_5_1);
            TextBoxdic.Add("postion_5_2", postion_5_2);
            TextBoxdic.Add("postion_5_3", postion_5_3);
            TextBoxdic.Add("postion_5_4", postion_5_4);
            TextBoxdic.Add("postion_5_5", postion_5_5);
            TextBoxdic.Add("postion_5_6", postion_5_6);
            TextBoxdic.Add("postion_5_7", postion_5_7);
            TextBoxdic.Add("postion_5_8", postion_5_8);
            TextBoxdic.Add("postion_6_0", postion_6_0);
            TextBoxdic.Add("postion_6_1", postion_6_1);
            TextBoxdic.Add("postion_6_2", postion_6_2);
            TextBoxdic.Add("postion_6_3", postion_6_3);
            TextBoxdic.Add("postion_6_4", postion_6_4);
            TextBoxdic.Add("postion_6_5", postion_6_5);
            TextBoxdic.Add("postion_6_6", postion_6_6);
            TextBoxdic.Add("postion_6_7", postion_6_7);
            TextBoxdic.Add("postion_6_8", postion_6_8);
            TextBoxdic.Add("postion_7_0", postion_7_0);
            TextBoxdic.Add("postion_7_1", postion_7_1);
            TextBoxdic.Add("postion_7_2", postion_7_2);
            TextBoxdic.Add("postion_7_3", postion_7_3);
            TextBoxdic.Add("postion_7_4", postion_7_4);
            TextBoxdic.Add("postion_7_5", postion_7_5);
            TextBoxdic.Add("postion_7_6", postion_7_6);
            TextBoxdic.Add("postion_7_7", postion_7_7);
            TextBoxdic.Add("postion_7_8", postion_7_8);
            TextBoxdic.Add("postion_8_0", postion_8_0);
            TextBoxdic.Add("postion_8_1", postion_8_1);
            TextBoxdic.Add("postion_8_2", postion_8_2);
            TextBoxdic.Add("postion_8_3", postion_8_3);
            TextBoxdic.Add("postion_8_4", postion_8_4);
            TextBoxdic.Add("postion_8_5", postion_8_5);
            TextBoxdic.Add("postion_8_6", postion_8_6);
            TextBoxdic.Add("postion_8_7", postion_8_7);
            TextBoxdic.Add("postion_8_8", postion_8_8);
            locationClues.Add("postion_0_0", clue_0_0);
            locationClues.Add("postion_0_1", clue_0_1);
            locationClues.Add("postion_0_2", clue_0_2);
            locationClues.Add("postion_0_3", clue_0_3);
            locationClues.Add("postion_0_4", clue_0_4);
            locationClues.Add("postion_0_5", clue_0_5);
            locationClues.Add("postion_0_6", clue_0_6);
            locationClues.Add("postion_0_7", clue_0_7);
            locationClues.Add("postion_0_8", clue_0_8);
            locationClues.Add("postion_1_0", clue_1_0);
            locationClues.Add("postion_1_1", clue_1_1);
            locationClues.Add("postion_1_2", clue_1_2);
            locationClues.Add("postion_1_3", clue_1_3);
            locationClues.Add("postion_1_4", clue_1_4);
            locationClues.Add("postion_1_5", clue_1_5);
            locationClues.Add("postion_1_6", clue_1_6);
            locationClues.Add("postion_1_7", clue_1_7);
            locationClues.Add("postion_1_8", clue_1_8);
            locationClues.Add("postion_2_0", clue_2_0);
            locationClues.Add("postion_2_1", clue_2_1);
            locationClues.Add("postion_2_2", clue_2_2);
            locationClues.Add("postion_2_3", clue_2_3);
            locationClues.Add("postion_2_4", clue_2_4);
            locationClues.Add("postion_2_5", clue_2_5);
            locationClues.Add("postion_2_6", clue_2_6);
            locationClues.Add("postion_2_7", clue_2_7);
            locationClues.Add("postion_2_8", clue_2_8);
            locationClues.Add("postion_3_0", clue_3_0);
            locationClues.Add("postion_3_1", clue_3_1);
            locationClues.Add("postion_3_2", clue_3_2);
            locationClues.Add("postion_3_3", clue_3_3);
            locationClues.Add("postion_3_4", clue_3_4);
            locationClues.Add("postion_3_5", clue_3_5);
            locationClues.Add("postion_3_6", clue_3_6);
            locationClues.Add("postion_3_7", clue_3_7);
            locationClues.Add("postion_3_8", clue_3_8);
            locationClues.Add("postion_4_0", clue_4_0);
            locationClues.Add("postion_4_1", clue_4_1);
            locationClues.Add("postion_4_2", clue_4_2);
            locationClues.Add("postion_4_3", clue_4_3);
            locationClues.Add("postion_4_4", clue_4_4);
            locationClues.Add("postion_4_5", clue_4_5);
            locationClues.Add("postion_4_6", clue_4_6);
            locationClues.Add("postion_4_7", clue_4_7);
            locationClues.Add("postion_4_8", clue_4_8);
            locationClues.Add("postion_5_0", clue_5_0);
            locationClues.Add("postion_5_1", clue_5_1);
            locationClues.Add("postion_5_2", clue_5_2);
            locationClues.Add("postion_5_3", clue_5_3);
            locationClues.Add("postion_5_4", clue_5_4);
            locationClues.Add("postion_5_5", clue_5_5);
            locationClues.Add("postion_5_6", clue_5_6);
            locationClues.Add("postion_5_7", clue_5_7);
            locationClues.Add("postion_5_8", clue_5_8);
            locationClues.Add("postion_6_0", clue_6_0);
            locationClues.Add("postion_6_1", clue_6_1);
            locationClues.Add("postion_6_2", clue_6_2);
            locationClues.Add("postion_6_3", clue_6_3);
            locationClues.Add("postion_6_4", clue_6_4);
            locationClues.Add("postion_6_5", clue_6_5);
            locationClues.Add("postion_6_6", clue_6_6);
            locationClues.Add("postion_6_7", clue_6_7);
            locationClues.Add("postion_6_8", clue_6_8);
            locationClues.Add("postion_7_0", clue_7_0);
            locationClues.Add("postion_7_1", clue_7_1);
            locationClues.Add("postion_7_2", clue_7_2);
            locationClues.Add("postion_7_3", clue_7_3);
            locationClues.Add("postion_7_4", clue_7_4);
            locationClues.Add("postion_7_5", clue_7_5);
            locationClues.Add("postion_7_6", clue_7_6);
            locationClues.Add("postion_7_7", clue_7_7);
            locationClues.Add("postion_7_8", clue_7_8);
            locationClues.Add("postion_8_0", clue_8_0);
            locationClues.Add("postion_8_1", clue_8_1);
            locationClues.Add("postion_8_2", clue_8_2);
            locationClues.Add("postion_8_3", clue_8_3);
            locationClues.Add("postion_8_4", clue_8_4);
            locationClues.Add("postion_8_5", clue_8_5);
            locationClues.Add("postion_8_6", clue_8_6);
            locationClues.Add("postion_8_7", clue_8_7);
            locationClues.Add("postion_8_8", clue_8_8);



            for (int i = 0; i < numbers; i++)
            {
                for (int j = 0; j < numbers; j++)
                {
                    var location = "postion_" + i + "_" + j;
                    TextBox testBox = TextBoxdic[location];
                    testBox.Dock = DockStyle.None;
                    testBox.Margin = new Padding(2);
                    testBox.BorderStyle = BorderStyle.None;
                    testBox.Multiline = true;
                    testBox.Size = new Size(50, 50);
                    testBox.TabIndex = 0;
                    testBox.TextAlign = HorizontalAlignment.Center;
                    testBox.Font = new Font("Dotum", 30f, FontStyle.Regular, GraphicsUnit.Point, ((byte) (134)));
                    testBox.TextChanged += new EventHandler(textChanged);
                    testBox.MouseEnter += new EventHandler(MouseEntere);
                    CtlNoticePanel cluePanel = locationClues[location];
                    cluePanel.Dock = DockStyle.None;
                    cluePanel.Margin = new Padding(2);
                    cluePanel.BorderStyle = BorderStyle.None;

                    cluePanel.Size = new Size(50, 50);
                    cluePanel.TabIndex = 0;
                    cluePanel.Visible = false;


                }
            }

            //this.tableLayoutPanel1.Controls.Find("postion_8_8", true).First().Visible = false;

     
        }
        /// <summary>
        /// 提示面板的缓存
        /// </summary>
        public Dictionary<string, CtlNoticePanel> locationClues=new Dictionary<string, CtlNoticePanel>();

        private Dictionary<string, TextBox> TextBoxdic = new Dictionary<string, TextBox>();

     

        /// <summary>
        /// 显示提示信息
        /// </summary>
        private void ShowNoticeInfo()
        {
            Dictionary<string, CellInfo> cells = currentMarket.GetCellInfos();
            foreach (KeyValuePair<string, CellInfo> kv in cells)
            {
                var location = kv.Key;
                CellInfo cell = kv.Value;
                var clue = locationClues[location];
                var text = TextBoxdic[location];
                if (!cell.isInit)
                {
                

                    clue.Visible = true;
                    clue.SetClues(cell.initrest);
                    text.Visible = false;

                }
                else
                {
                    clue.Visible = false;
                    text.Visible = true;
                }

            }

        }

        private Color borderColor = Color.Black;


        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        private void MouseEntere(object sender, EventArgs e)
        {
            var ctx = (TextBox) sender;
            var keyword = ctx.Name;
            var thisValue = ctx.Text;

            if (sdk != null && string.IsNullOrEmpty(thisValue) && sdk.IsQuestion)
            {
                var cell = sdk.GetCellInfo(keyword);
                var rests = cell.GetRest();
                var message = "";
                foreach (var variable in rests)
                {
                    message += variable + ",";
                }

                if (message.Contains(","))
                {
                    message = message.Remove(message.LastIndexOf(","));
                }

                //SodukuMarket.rowDatas[cell.row].Sort();
                //SodukuMarket.columnDatas[cell.column].Sort();
                //SodukuMarket.blockDatas[cell.block].Sort();
                //var message2 = JsonConvert.SerializeObject(SodukuMarket.rowDatas[cell.row]);
                //var message3 = JsonConvert.SerializeObject(SodukuMarket.columnDatas[cell.column]);
                //var message4 = JsonConvert.SerializeObject(SodukuMarket.blockDatas[cell.block]);
                //helpMessage.Text = "当前鼠标位置为" + (cell.row + 1) + "行" + (cell.column + 1) + "列\r\n";
                //helpMessage.Text += @"可选值范围为：" + message + "\r\n行已经填充" + message2 + "\r\n列已经填充" + message3 +
                //                    "\r\n宫已经填充" + message4;
            }
            else
            {
                helpMessage.Text = null;
            }

            //if (string.IsNullOrEmpty(thisValue)) return;

            //var postion=    this.tableLayoutPanel1.GetCellPosition(ctx);


            for (int i = 0; i < numbers; i++)
            {
                for (int j = 0; j < numbers; j++)
                {
                    object obj = GetType().GetField("postion_" + i + "_" + j,
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                                                                     | System.Reflection.BindingFlags.IgnoreCase)
                        ?.GetValue(this);
                    TextBox testBox = (TextBox) obj;
                    if (testBox == null) continue;


                    testBox.BackColor = !string.IsNullOrEmpty(thisValue) && thisValue == testBox.Text.Trim()
                        ? Color.Orange
                        : Color.White;
                }
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            var ctx = (TextBox) sender;
            if (!vaildValues.Contains(ctx.Text.Trim()))
            {
                ctx.Text = null;
            }
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 2 || e.Row == 5)
            {
                ControlPaint.DrawBorder(e.Graphics,
                    e.CellBounds,
                    Color.Black,
                    0,
                    ButtonBorderStyle.Solid,
                    Color.Black,
                    0,
                    ButtonBorderStyle.Solid,
                    Color.Black,
                    0,
                    ButtonBorderStyle.Solid,
                    Color.Black,
                    2,
                    ButtonBorderStyle.Solid);
            }

            if (e.Column == 2 || e.Column == 5)
            {
                ControlPaint.DrawBorder(e.Graphics,
                    e.CellBounds,
                    Color.Black,
                    0,
                    ButtonBorderStyle.Solid,
                    Color.Black,
                    0,
                    ButtonBorderStyle.Solid,
                    Color.Black,
                    2,
                    ButtonBorderStyle.Solid,
                    Color.Black,
                    0,
                    ButtonBorderStyle.Solid);
            }
        }

        private void DrawBorder(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                tableLayoutPanel1.ClientRectangle,
                Color.Black,
                2,
                ButtonBorderStyle.Solid,
                Color.Black,
                2,
                ButtonBorderStyle.Solid,
                Color.Black,
                2,
                ButtonBorderStyle.Solid,
                Color.Black,
                2,
                ButtonBorderStyle.Solid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = sdkBuilder.MakeSoduku();
            for (int i = 0; i < result.Count; i++)
            {
                var list = result[i];
                for (int j = 0; j < list.Count; j++)
                {
                    var value = list[j];

                    object obj = GetType().GetField("postion_" + i + "_" + j,
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                                                                     | System.Reflection.BindingFlags.IgnoreCase)
                        ?.GetValue(this);
                    TextBox testBox = (TextBox) obj;
                    if (testBox == null) continue;
                    testBox.Text = "" + value;
                    testBox.BackColor = Color.White;
                    resultMessage.Text = null;
                }
            }

            var breakouot = 0;
        }


        private void makeQuestion_Click(object sender, EventArgs e)
        {

        }

        private void SolveSoduku_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void isShowHelp_CheckedChanged(object sender, EventArgs e)
        {
            ShowNoticeInfo();
        }

        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 完整数独ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = sdkBuilder.MakeSoduku();
            for (int i = 0; i < result.Count; i++)
            {
                var list = result[i];
                for (int j = 0; j < list.Count; j++)
                {
                    var value = list[j];

                    object obj = GetType().GetField("postion_" + i + "_" + j,
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                                                                     | System.Reflection.BindingFlags.IgnoreCase)
                        ?.GetValue(this);
                    TextBox testBox = (TextBox)obj;
                    if (testBox == null) continue;
                    testBox.Text = "" + value;
                    testBox.BackColor = Color.White;
                    resultMessage.Text = null;
                }
            }

            var breakouot = 0;
        }

        private void 标准数独ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentMarket = sdkGenerator.AutoQuestion(sdkBuilder.MakeSoduku(), int.Parse(noticeNumber.Text));
            questions = currentMarket.initValues;
            label4.Text = "平均候选数个数为：  " + Math.Round(currentMarket.difficult, 2);
            label5.Text = "实际提示数个数为:   " + currentMarket.initLists.Count;

            for (int i = 0; i < questions.Count; i++)
            {
                var list = questions[i];
                for (int j = 0; j < list.Count; j++)
                {
                    var value = list[j];

                    object obj = GetType().GetField("postion_" + i + "_" + j,
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                                                                     | System.Reflection.BindingFlags.IgnoreCase)
                        ?.GetValue(this);
                    TextBox testBox = (TextBox)obj;
                    if (testBox == null) continue;
                    testBox.Text = "" + value;
                    testBox.ForeColor = Color.Black;
                    testBox.BackColor = Color.White;
                    resultMessage.Text = null;
                }
            }

            ShowNoticeInfo();
            var breakouot = 0;
        }

        private void 锯齿数独ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void 导出图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bit = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height); //实例化一个和窗体一样大的bitmap

                tableLayoutPanel1.DrawToBitmap(bit,
                    new Rectangle(0, 0, tableLayoutPanel1.Width, tableLayoutPanel1.Height));
                var time = DateTime.Now.ToString("yyyyMMddHHmmss");
                var warpath = new DirectoryInfo("../").FullName + "QuestionImages";
                var path = warpath + time + ".png";
                if (!Directory.Exists(warpath))
                    Directory.CreateDirectory(warpath);
                bit.Save(path, ImageFormat.Png);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw new Exception("请检查文件夹权限！");
            }
        }

        private void 理论求解ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentMarket == null)
            {
                helpMessage.Text = "请提供数独题目";
                return;
            }
            new Solver.SodukuSolver().Solve(currentMarket);
            sdk.Solve(questions, true);
            for (int i = 0; i < questions.Count; i++)
            {
                var list = questions[i];
                for (int j = 0; j < list.Count; j++)
                {
                    var value = list[j];
                    var location = "postion_" + i + "_" + j;
                    var cellinfo = sdk.GetCellInfo(location);
                    object obj = GetType().GetField(location,
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
                                                                     | System.Reflection.BindingFlags.IgnoreCase)
                        ?.GetValue(this);
                    TextBox testBox = (TextBox)obj;
                    if (testBox == null) continue;
                    testBox.Text = "" + cellinfo.Value;
                    testBox.ForeColor = cellinfo.isInit ? Color.Black : Color.Blue;
                    testBox.BackColor = Color.White;
                }
            }

            resultMessage.Text = sdk.SolveMessage;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}