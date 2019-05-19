﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IonBeamMachining.PopWin
{
    /// <summary>
    /// NewItem.xaml 的交互逻辑
    /// </summary>
    public partial class NewItem : Window
    {
        public NewItem(string title)
        {
            InitializeComponent();
            Title = title;
        }

        public string Result { get { return NewName.Text; } }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
