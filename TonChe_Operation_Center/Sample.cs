﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TonChe_Operation_Cneter
{
    public partial class Sample : Form
    {
        public Sample(string ART_NO)
        {
            InitializeComponent();
            this.Text = ART_NO;
        }
    }
}
