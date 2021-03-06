﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Aggregator;
using BaseComponents.BaseClasses.Forms;

namespace BL.PluginManager
{
    public interface IPlugin
    {
        // void ItemClicked(string itemName);
        Aggregate Aggregator { get; set; }

        BaseMainForm MainForm { get; set; }

        void StartUp(Aggregate Aggregator);

        void Unload();

        void ShowForm(object imapWin);

        void SetButton(object imapWin);

        // void ToolButtonClicked(string toolButtonName);

        void ToolButtonClicked(string toolButtonName, object[] args);

        void MenuButtonClicked(string menuItem);
    }
}
