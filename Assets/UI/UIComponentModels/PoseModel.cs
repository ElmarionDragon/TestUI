using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseModel: ComponentModel
    {
        Pose pose;

        public PoseModel(): base()
        {
        }

        override public VisualElement createUIComponent()
        {
            pose = new Pose();
            pose.changed += onPoseChanged;
            return pose;
        }

        override public void updateComponent()
        {
            onPoseChanged(pose);
        }

        private void onPoseChanged(Pose v)
        {
            prefabInstance.transform.position = new Vector3(v.x, v.y, v.z);
            prefabInstance.transform.Rotate(new Vector3(v.rx, v.ry, v.rz));
        }
    }
}