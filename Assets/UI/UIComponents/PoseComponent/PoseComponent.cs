using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseComponent: BaseComponent
    {
        public PoseComponent(): base()
        {
            model = new PoseModel();
            controller = new PoseController((PoseModel)model);
            view = new PoseView((PoseController)controller, (PoseModel)model);
        }

    }
}