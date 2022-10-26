using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{

    public class DialogManager
    {
        private static DialogManager _instance;

        public static DialogManager Instance
        {
            get
            {
                if (_instance == null) _instance = new DialogManager();
                return _instance;
            }
        }

    }

}