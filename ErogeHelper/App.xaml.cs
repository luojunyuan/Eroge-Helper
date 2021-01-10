﻿using Caliburn.Micro;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace ErogeHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(App));

        App()
        {
            // Set environment to App directory
            var currentDirectory = Path.GetDirectoryName(GetType().Assembly.Location)!;
            Directory.SetCurrentDirectory(currentDirectory);

            // Switch on Caliburn.Micro.ViewModelBinder debug monitor
            //var baseGetLog = LogManager.GetLog;
            //LogManager.GetLog = t => t == typeof(ViewModelBinder) ? new DebugLog(t) : baseGetLog(t);

            // Set i18n
            SetLanguageDictionary();

            // Set thread error handle
            AppDomain.CurrentDomain.UnhandledException += (s, eventArgs) =>
            {
                Dispatcher dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
                if (dispatcher != null)
                {
                    if(Dispatcher.CurrentDispatcher.Thread != Thread.CurrentThread)
                    {
                        Exception ex = (Exception) eventArgs.ExceptionObject;
                        log.Error(ex);
                        ModernWpf.MessageBox.Show(ex.Message, "Eroge Helper - Fatal Error");
                    }
                }
            };
            DispatcherUnhandledException += (s, eventArgs) =>
            {
                log.Error(eventArgs.Exception);
                ModernWpf.MessageBox.Show(eventArgs.Exception.Message, "Eroge Helper - Fatal Error");
            };
        }

        private static void SetLanguageDictionary()
        {
            Language.Strings.Culture = (Thread.CurrentThread.CurrentCulture.ToString()) switch
            {
                "zh-CN" => new System.Globalization.CultureInfo("zh-Hans"),
                "zh-Hans" => new System.Globalization.CultureInfo("zh-Hans"),
                // default english because there can be so many different system language, we rather fallback on 
                // english in this case.
                _ => new System.Globalization.CultureInfo(""),
            };
        }
    }
}
