﻿using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public enum AlertButton
    {
        Yes = 1,
        No = 2,
        Neutral = 3,
    }
    public class AlertParams
    {
        internal int alertId;
        public string title;
        public string message;
        public string yesButton;
        public string noButton;
        public string neutralButton;

        public OnAlertComplate onYesButtonPress;
        public OnAlertComplate onNoButtonPress;
        public OnAlertComplate onNeutralButtonPress;
        public OnAlertComplate onButtonPress;
    }
}