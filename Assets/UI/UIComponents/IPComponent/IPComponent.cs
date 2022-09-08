using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPComponent: BaseComponent
    {
        public IPComponent(): base()
        {
            model = new IPModel();
            controller = new IPController((IPModel)model);
            view = new IPView((IPController)controller, (IPModel)model);
        }
    }
}