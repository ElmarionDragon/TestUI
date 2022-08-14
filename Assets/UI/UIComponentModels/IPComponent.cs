using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IPComponent: BaseComponent
    {
        IPModel model;

        public IPComponent(): base()
        {
            model = new IPModel();
            view = new IPView(model);
        }

    }
}