using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseComponent: BaseComponent
    {
        PoseModel model;

        public PoseComponent(): base()
        {
            model = new PoseModel();
            view = new PoseView(model);
        }

    }
}