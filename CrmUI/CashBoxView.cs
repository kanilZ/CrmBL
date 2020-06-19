﻿using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public class CashBoxView
    {
        CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLenghth { get; set; }
        public Label LeaveCustomersCount { get; private set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {

            this.cashDesk = cashDesk;
            CashDeskName = new Label();
            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();

            Price = new NumericUpDown();
            Price.Location = new System.Drawing.Point(x + 70, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 1000000000000000;

            QueueLenghth = new ProgressBar();
            QueueLenghth.Location = new System.Drawing.Point(x + 250, y);
            QueueLenghth.Maximum = cashDesk.MaxQueueLenght;
            QueueLenghth.Name = "progressBar" + number;
            QueueLenghth.Size = new System.Drawing.Size(100, 23);
            QueueLenghth.TabIndex = number;
            QueueLenghth.Value = 0;

            LeaveCustomersCount = new Label();
            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            LeaveCustomersCount.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action)delegate
           {
               Price.Value += e.Summary;
               QueueLenghth.Value = cashDesk.Count;
               LeaveCustomersCount.Text = cashDesk.ExitCustomer.ToString();
           });
        }
    }
}
