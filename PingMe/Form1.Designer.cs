namespace PingMe
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbHostName = new System.Windows.Forms.TextBox();
            this.lblHostName = new System.Windows.Forms.Label();
            this.tbTimeMin = new System.Windows.Forms.TextBox();
            this.lblTimeMin = new System.Windows.Forms.Label();
            this.tbTimeMax = new System.Windows.Forms.TextBox();
            this.lblTimeMax = new System.Windows.Forms.Label();
            this.tbTimeAverage = new System.Windows.Forms.TextBox();
            this.lblTimeAverage = new System.Windows.Forms.Label();
            this.tbSendPackets = new System.Windows.Forms.TextBox();
            this.lblSendPackets = new System.Windows.Forms.Label();
            this.tbReceivedPackets = new System.Windows.Forms.TextBox();
            this.tbLostPackets = new System.Windows.Forms.TextBox();
            this.lblReceivedPackets = new System.Windows.Forms.Label();
            this.lblLostPackets = new System.Windows.Forms.Label();
            this.lblStability = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbLastSendPackets = new System.Windows.Forms.TextBox();
            this.tbLastTimeMin = new System.Windows.Forms.TextBox();
            this.tbLastTimeMax = new System.Windows.Forms.TextBox();
            this.tbLastTimeAverage = new System.Windows.Forms.TextBox();
            this.tbLastReceivedPackets = new System.Windows.Forms.TextBox();
            this.tbLastLostPackets = new System.Windows.Forms.TextBox();
            this.tbElapsedTime = new System.Windows.Forms.TextBox();
            this.tbStartTime = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblElapsedTime = new System.Windows.Forms.Label();
            this.pingTimer = new System.Windows.Forms.Timer(this.components);
            this.tableResults = new System.Windows.Forms.DataGridView();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPanel3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuffer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeToLive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPanel2 = new System.Windows.Forms.Button();
            this.btnPanel1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableResults)).BeginInit();
            this.tableLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbHostName
            // 
            this.tbHostName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHostName.Location = new System.Drawing.Point(286, 30);
            this.tbHostName.Name = "tbHostName";
            this.tbHostName.Size = new System.Drawing.Size(166, 20);
            this.tbHostName.TabIndex = 1;
            // 
            // lblHostName
            // 
            this.lblHostName.AutoSize = true;
            this.lblHostName.Location = new System.Drawing.Point(283, 12);
            this.lblHostName.Name = "lblHostName";
            this.lblHostName.Size = new System.Drawing.Size(63, 13);
            this.lblHostName.TabIndex = 2;
            this.lblHostName.Text = "Host Name:";
            // 
            // tbTimeMin
            // 
            this.tbTimeMin.Location = new System.Drawing.Point(385, 3);
            this.tbTimeMin.Name = "tbTimeMin";
            this.tbTimeMin.ReadOnly = true;
            this.tbTimeMin.Size = new System.Drawing.Size(50, 20);
            this.tbTimeMin.TabIndex = 4;
            // 
            // lblTimeMin
            // 
            this.lblTimeMin.AutoSize = true;
            this.lblTimeMin.Location = new System.Drawing.Point(244, 6);
            this.lblTimeMin.Name = "lblTimeMin";
            this.lblTimeMin.Size = new System.Drawing.Size(51, 13);
            this.lblTimeMin.TabIndex = 5;
            this.lblTimeMin.Text = "Ping Min:";
            // 
            // tbTimeMax
            // 
            this.tbTimeMax.Location = new System.Drawing.Point(385, 29);
            this.tbTimeMax.Name = "tbTimeMax";
            this.tbTimeMax.ReadOnly = true;
            this.tbTimeMax.Size = new System.Drawing.Size(50, 20);
            this.tbTimeMax.TabIndex = 6;
            // 
            // lblTimeMax
            // 
            this.lblTimeMax.AutoSize = true;
            this.lblTimeMax.Location = new System.Drawing.Point(244, 32);
            this.lblTimeMax.Name = "lblTimeMax";
            this.lblTimeMax.Size = new System.Drawing.Size(54, 13);
            this.lblTimeMax.TabIndex = 7;
            this.lblTimeMax.Text = "Ping Max:";
            // 
            // tbTimeAverage
            // 
            this.tbTimeAverage.Location = new System.Drawing.Point(385, 55);
            this.tbTimeAverage.Name = "tbTimeAverage";
            this.tbTimeAverage.ReadOnly = true;
            this.tbTimeAverage.Size = new System.Drawing.Size(50, 20);
            this.tbTimeAverage.TabIndex = 8;
            // 
            // lblTimeAverage
            // 
            this.lblTimeAverage.AutoSize = true;
            this.lblTimeAverage.Location = new System.Drawing.Point(244, 58);
            this.lblTimeAverage.Name = "lblTimeAverage";
            this.lblTimeAverage.Size = new System.Drawing.Size(74, 13);
            this.lblTimeAverage.TabIndex = 9;
            this.lblTimeAverage.Text = "Ping Average:";
            // 
            // tbSendPackets
            // 
            this.tbSendPackets.Location = new System.Drawing.Point(166, 3);
            this.tbSendPackets.Name = "tbSendPackets";
            this.tbSendPackets.ReadOnly = true;
            this.tbSendPackets.Size = new System.Drawing.Size(50, 20);
            this.tbSendPackets.TabIndex = 10;
            // 
            // lblSendPackets
            // 
            this.lblSendPackets.AutoSize = true;
            this.lblSendPackets.Location = new System.Drawing.Point(3, 6);
            this.lblSendPackets.Name = "lblSendPackets";
            this.lblSendPackets.Size = new System.Drawing.Size(77, 13);
            this.lblSendPackets.TabIndex = 11;
            this.lblSendPackets.Text = "Send Packets:";
            // 
            // tbReceivedPackets
            // 
            this.tbReceivedPackets.Location = new System.Drawing.Point(166, 29);
            this.tbReceivedPackets.Name = "tbReceivedPackets";
            this.tbReceivedPackets.ReadOnly = true;
            this.tbReceivedPackets.Size = new System.Drawing.Size(50, 20);
            this.tbReceivedPackets.TabIndex = 12;
            // 
            // tbLostPackets
            // 
            this.tbLostPackets.Location = new System.Drawing.Point(166, 55);
            this.tbLostPackets.Name = "tbLostPackets";
            this.tbLostPackets.ReadOnly = true;
            this.tbLostPackets.Size = new System.Drawing.Size(50, 20);
            this.tbLostPackets.TabIndex = 13;
            // 
            // lblReceivedPackets
            // 
            this.lblReceivedPackets.AutoSize = true;
            this.lblReceivedPackets.Location = new System.Drawing.Point(3, 32);
            this.lblReceivedPackets.Name = "lblReceivedPackets";
            this.lblReceivedPackets.Size = new System.Drawing.Size(98, 13);
            this.lblReceivedPackets.TabIndex = 14;
            this.lblReceivedPackets.Text = "Received Packets:";
            // 
            // lblLostPackets
            // 
            this.lblLostPackets.AutoSize = true;
            this.lblLostPackets.Location = new System.Drawing.Point(3, 58);
            this.lblLostPackets.Name = "lblLostPackets";
            this.lblLostPackets.Size = new System.Drawing.Size(72, 13);
            this.lblLostPackets.TabIndex = 15;
            this.lblLostPackets.Text = "Lost Packets:";
            // 
            // lblStability
            // 
            this.lblStability.AutoSize = true;
            this.lblStability.Location = new System.Drawing.Point(139, 12);
            this.lblStability.Name = "lblStability";
            this.lblStability.Size = new System.Drawing.Size(46, 13);
            this.lblStability.TabIndex = 16;
            this.lblStability.Text = "Stability:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(139, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(124, 20);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "No connection";
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Transparent;
            this.chart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.LabelAutoFitMaxFontSize = 6;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.Maximum = 20D;
            chartArea3.AxisX.Minimum = 1D;
            chartArea3.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.ScaleView.Zoomable = false;
            chartArea3.AxisY.LabelAutoFitMaxFontSize = 6;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Percent50;
            series3.BorderColor = System.Drawing.Color.CornflowerBlue;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series3.Color = System.Drawing.Color.LightSteelBlue;
            series3.EmptyPointStyle.MarkerBorderColor = System.Drawing.Color.Black;
            series3.EmptyPointStyle.MarkerColor = System.Drawing.Color.Red;
            series3.EmptyPointStyle.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series3.IsVisibleInLegend = false;
            series3.Name = "Time";
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(438, 108);
            this.chart.TabIndex = 18;
            this.chart.TabStop = false;
            this.chart.Text = "chart1";
            // 
            // tbLastSendPackets
            // 
            this.tbLastSendPackets.Location = new System.Drawing.Point(110, 3);
            this.tbLastSendPackets.Name = "tbLastSendPackets";
            this.tbLastSendPackets.ReadOnly = true;
            this.tbLastSendPackets.Size = new System.Drawing.Size(50, 20);
            this.tbLastSendPackets.TabIndex = 19;
            // 
            // tbLastTimeMin
            // 
            this.tbLastTimeMin.Location = new System.Drawing.Point(329, 3);
            this.tbLastTimeMin.Name = "tbLastTimeMin";
            this.tbLastTimeMin.ReadOnly = true;
            this.tbLastTimeMin.Size = new System.Drawing.Size(50, 20);
            this.tbLastTimeMin.TabIndex = 20;
            // 
            // tbLastTimeMax
            // 
            this.tbLastTimeMax.Location = new System.Drawing.Point(329, 29);
            this.tbLastTimeMax.Name = "tbLastTimeMax";
            this.tbLastTimeMax.ReadOnly = true;
            this.tbLastTimeMax.Size = new System.Drawing.Size(50, 20);
            this.tbLastTimeMax.TabIndex = 21;
            // 
            // tbLastTimeAverage
            // 
            this.tbLastTimeAverage.Location = new System.Drawing.Point(329, 55);
            this.tbLastTimeAverage.Name = "tbLastTimeAverage";
            this.tbLastTimeAverage.ReadOnly = true;
            this.tbLastTimeAverage.Size = new System.Drawing.Size(50, 20);
            this.tbLastTimeAverage.TabIndex = 22;
            // 
            // tbLastReceivedPackets
            // 
            this.tbLastReceivedPackets.Location = new System.Drawing.Point(110, 29);
            this.tbLastReceivedPackets.Name = "tbLastReceivedPackets";
            this.tbLastReceivedPackets.ReadOnly = true;
            this.tbLastReceivedPackets.Size = new System.Drawing.Size(50, 20);
            this.tbLastReceivedPackets.TabIndex = 23;
            // 
            // tbLastLostPackets
            // 
            this.tbLastLostPackets.Location = new System.Drawing.Point(110, 55);
            this.tbLastLostPackets.Name = "tbLastLostPackets";
            this.tbLastLostPackets.ReadOnly = true;
            this.tbLastLostPackets.Size = new System.Drawing.Size(50, 20);
            this.tbLastLostPackets.TabIndex = 24;
            // 
            // tbElapsedTime
            // 
            this.tbElapsedTime.Location = new System.Drawing.Point(329, 81);
            this.tbElapsedTime.Name = "tbElapsedTime";
            this.tbElapsedTime.ReadOnly = true;
            this.tbElapsedTime.Size = new System.Drawing.Size(106, 20);
            this.tbElapsedTime.TabIndex = 25;
            // 
            // tbStartTime
            // 
            this.tbStartTime.Location = new System.Drawing.Point(110, 81);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(106, 20);
            this.tbStartTime.TabIndex = 26;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(3, 84);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 27;
            this.lblStartDate.Text = "Start Time:";
            // 
            // lblElapsedTime
            // 
            this.lblElapsedTime.AutoSize = true;
            this.lblElapsedTime.Location = new System.Drawing.Point(244, 84);
            this.lblElapsedTime.Name = "lblElapsedTime";
            this.lblElapsedTime.Size = new System.Drawing.Size(74, 13);
            this.lblElapsedTime.TabIndex = 28;
            this.lblElapsedTime.Text = "Elapsed Time:";
            // 
            // pingTimer
            // 
            this.pingTimer.Interval = 1000;
            // 
            // tableResults
            // 
            this.tableResults.AllowUserToAddRows = false;
            this.tableResults.AllowUserToDeleteRows = false;
            this.tableResults.AllowUserToResizeColumns = false;
            this.tableResults.AllowUserToResizeRows = false;
            this.tableResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.tableResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colHost,
            this.colTime,
            this.colBuffer,
            this.colTimeToLive});
            this.tableResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableResults.Location = new System.Drawing.Point(0, 0);
            this.tableResults.Name = "tableResults";
            this.tableResults.ReadOnly = true;
            this.tableResults.RowHeadersVisible = false;
            this.tableResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableResults.Size = new System.Drawing.Size(438, 108);
            this.tableResults.TabIndex = 29;
            // 
            // tableLayout
            // 
            this.tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayout.AutoSize = true;
            this.tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayout.ColumnCount = 1;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.Controls.Add(this.panel2, 0, 3);
            this.tableLayout.Controls.Add(this.btnPanel2, 0, 2);
            this.tableLayout.Controls.Add(this.btnPanel3, 0, 4);
            this.tableLayout.Controls.Add(this.btnPanel1, 0, 0);
            this.tableLayout.Controls.Add(this.panel3, 0, 5);
            this.tableLayout.Controls.Add(this.panel1, 0, 1);
            this.tableLayout.Location = new System.Drawing.Point(12, 58);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 6;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.Size = new System.Drawing.Size(440, 399);
            this.tableLayout.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbLastTimeMin);
            this.panel1.Controls.Add(this.tbLastTimeMax);
            this.panel1.Controls.Add(this.tbLastTimeAverage);
            this.panel1.Controls.Add(this.tbTimeMin);
            this.panel1.Controls.Add(this.tbTimeMax);
            this.panel1.Controls.Add(this.tbTimeAverage);
            this.panel1.Controls.Add(this.tbElapsedTime);
            this.panel1.Controls.Add(this.tbStartTime);
            this.panel1.Controls.Add(this.lblTimeAverage);
            this.panel1.Controls.Add(this.lblElapsedTime);
            this.panel1.Controls.Add(this.tbLostPackets);
            this.panel1.Controls.Add(this.tbLastLostPackets);
            this.panel1.Controls.Add(this.lblStartDate);
            this.panel1.Controls.Add(this.lblTimeMax);
            this.panel1.Controls.Add(this.lblReceivedPackets);
            this.panel1.Controls.Add(this.lblTimeMin);
            this.panel1.Controls.Add(this.tbLastReceivedPackets);
            this.panel1.Controls.Add(this.tbReceivedPackets);
            this.panel1.Controls.Add(this.tbLastSendPackets);
            this.panel1.Controls.Add(this.tbSendPackets);
            this.panel1.Controls.Add(this.lblSendPackets);
            this.panel1.Controls.Add(this.lblLostPackets);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 110);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chart);
            this.panel2.Location = new System.Drawing.Point(0, 156);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 110);
            this.panel2.TabIndex = 2;
            // 
            // btnPanel3
            // 
            this.btnPanel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanel3.Image = global::PingMe.Properties.Resources.arrow_right;
            this.btnPanel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPanel3.Location = new System.Drawing.Point(0, 266);
            this.btnPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.btnPanel3.Name = "btnPanel3";
            this.btnPanel3.Size = new System.Drawing.Size(440, 23);
            this.btnPanel3.TabIndex = 4;
            this.btnPanel3.Text = "Pings";
            this.btnPanel3.Click += new System.EventHandler(this.btnPanel_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableResults);
            this.panel3.Location = new System.Drawing.Point(0, 289);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 110);
            this.panel3.TabIndex = 6;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Time";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDate.Width = 130;
            // 
            // colHost
            // 
            this.colHost.HeaderText = "Host";
            this.colHost.Name = "colHost";
            this.colHost.ReadOnly = true;
            this.colHost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHost.Width = 140;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Ping";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTime.Width = 50;
            // 
            // colBuffer
            // 
            this.colBuffer.HeaderText = "Octets";
            this.colBuffer.Name = "colBuffer";
            this.colBuffer.ReadOnly = true;
            this.colBuffer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBuffer.Width = 50;
            // 
            // colTimeToLive
            // 
            this.colTimeToLive.HeaderText = "TTL";
            this.colTimeToLive.Name = "colTimeToLive";
            this.colTimeToLive.ReadOnly = true;
            this.colTimeToLive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTimeToLive.Width = 50;
            // 
            // btnPanel2
            // 
            this.btnPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanel2.Image = global::PingMe.Properties.Resources.arrow_right;
            this.btnPanel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPanel2.Location = new System.Drawing.Point(0, 133);
            this.btnPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.btnPanel2.Name = "btnPanel2";
            this.btnPanel2.Size = new System.Drawing.Size(440, 23);
            this.btnPanel2.TabIndex = 3;
            this.btnPanel2.Text = "Graph";
            this.btnPanel2.Click += new System.EventHandler(this.btnPanel_Click);
            // 
            // btnPanel1
            // 
            this.btnPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPanel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPanel1.Image = global::PingMe.Properties.Resources.arrow_right;
            this.btnPanel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPanel1.Location = new System.Drawing.Point(0, 0);
            this.btnPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.btnPanel1.Name = "btnPanel1";
            this.btnPanel1.Size = new System.Drawing.Size(440, 23);
            this.btnPanel1.TabIndex = 5;
            this.btnPanel1.Text = "Stats";
            this.btnPanel1.Click += new System.EventHandler(this.btnPanel_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 473);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblStability);
            this.Controls.Add(this.lblHostName);
            this.Controls.Add(this.tbHostName);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PingMe";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableResults)).EndInit();
            this.tableLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbHostName;
        private System.Windows.Forms.Label lblHostName;
        private System.Windows.Forms.TextBox tbTimeMin;
        private System.Windows.Forms.Label lblTimeMin;
        private System.Windows.Forms.TextBox tbTimeMax;
        private System.Windows.Forms.Label lblTimeMax;
        private System.Windows.Forms.TextBox tbTimeAverage;
        private System.Windows.Forms.Label lblTimeAverage;
        private System.Windows.Forms.TextBox tbSendPackets;
        private System.Windows.Forms.Label lblSendPackets;
        private System.Windows.Forms.TextBox tbReceivedPackets;
        private System.Windows.Forms.TextBox tbLostPackets;
        private System.Windows.Forms.Label lblReceivedPackets;
        private System.Windows.Forms.Label lblLostPackets;
        private System.Windows.Forms.Label lblStability;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox tbLastSendPackets;
        private System.Windows.Forms.TextBox tbLastTimeMin;
        private System.Windows.Forms.TextBox tbLastTimeMax;
        private System.Windows.Forms.TextBox tbLastTimeAverage;
        private System.Windows.Forms.TextBox tbLastReceivedPackets;
        private System.Windows.Forms.TextBox tbLastLostPackets;
        private System.Windows.Forms.TextBox tbElapsedTime;
        private System.Windows.Forms.TextBox tbStartTime;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblElapsedTime;
        private System.Windows.Forms.Timer pingTimer;
        private System.Windows.Forms.DataGridView tableResults;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPanel2;
        private System.Windows.Forms.Button btnPanel3;
        private System.Windows.Forms.Button btnPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuffer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeToLive;
    }
}

