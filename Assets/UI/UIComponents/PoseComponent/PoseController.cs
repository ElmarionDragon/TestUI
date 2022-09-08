using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseController: ComponentController
    {
        public PoseView view;
        public PoseModel model;

        public PoseController(PoseModel m): base()
        {
            model = m;
        }

        public void PoseChanged(Pose v)
        {
            model.setPose(v);
        }
    }
}