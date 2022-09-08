using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public interface ComponentObserver
    {
        void updateObserver();
    }
}