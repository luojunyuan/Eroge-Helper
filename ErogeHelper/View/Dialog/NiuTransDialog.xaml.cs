﻿using ErogeHelper.Model;
using ModernWpf.Controls;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Caliburn.Micro;
using ErogeHelper.Model.Repository;

namespace ErogeHelper.View.Dialog
{
    /// <summary>
    /// NiuTransDialog.xaml 的交互逻辑
    /// </summary>
    public partial class NiuTransDialog : ContentDialog
    {
        public NiuTransDialog()
        {
            InitializeComponent();

            EhConfigRepository ehConfigRepository = IoC.Get<EhConfigRepository>();
            ApiKey.Text = ehConfigRepository.NiuTransApiKey;

            PrimaryButtonClick += (_, _) =>
            {
                // Condition here cause "Enter" key will cross this
                if (IsPrimaryButtonEnabled)
                {
                    ehConfigRepository.NiuTransApiKey = ApiKey.Text.Trim();
                }
            };

            Closing += (_, args) =>
            {
                // If the PrimaryButton is disabled, block the "Enter" key
                if (args.Result == ContentDialogResult.Primary && !IsPrimaryButtonEnabled)
                {
                    args.Cancel = true;
                }
            };
        }
    }
}
