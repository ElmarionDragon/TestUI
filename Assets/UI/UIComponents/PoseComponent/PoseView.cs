using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseView : ComponentView, ComponentObserver
    {
        Pose pose;
        PoseModel model;
        PoseController controller;

        public PoseView(PoseController c, PoseModel m) : base()
        {
            model = m;
            controller = c;
            model.registerObserver(this);
        }

        override public VisualElement createUIComponent()
        {
            pose = new Pose();
            pose.changed += PoseChanged;
            return pose;
        }

        override public void updateComponent()
        {
            PoseChanged(pose);
        }

        private void PoseChanged(Pose v)
        {
            controller.PoseChanged(v);
        }

        public void updateObserver()
        {
            Pose v = model.pose;
            pose.update(v);
            prefabInstance.transform.position = new Vector3(v.x, v.y, v.z);
            prefabInstance.transform.Rotate(new Vector3(v.rx, v.ry, v.rz));
        }
    }
}