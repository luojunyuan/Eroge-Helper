﻿using ErogeHelper.Common.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ErogeHelper.Model.Service.Interface
{
    public interface ITextractorService
    {
        event EventHandler<object> TextEvent;

        event EventHandler<object> SelectedTextEvent;

        TextractorSetting Setting { get; set; } 

        /// <summary>
        /// Inject hooks into processes, also initialize Textractor service. This should be called only once
        /// </summary>
        /// <param name="gameProcesses"></param>
        /// <param name="setting">Textractor init callback functions depends on some parameters</param>
        void InjectProcesses(IEnumerable<Process> gameProcesses, TextractorSetting? setting = null);

        void InsertHook(string hookcode);

        void SearchRCode(string text);

        IEnumerable<string> GetConsoleOutputInfo();

        Task ReAttachProcesses();

        void RemoveHook(long address);

        void GetEngineName(long address);
    }
}
