using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseView : ComponentView
    {
        Pose pose;
        PoseModel model;

        public PoseView(PoseModel m) : base()
        {
            model = m;
            model.onPoseChanged += updateView;
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
            model.changeData(v);
        }

        public void updateView(Pose v)
        {
            pose.update(v);
            prefabInstance.transform.position = new Vector3(v.x, v.y, v.z);
            prefabInstance.transform.Rotate(new Vector3(v.rx, v.ry, v.rz));
        }
        override public void updateUI()
        {
            if (prefabInstance != null)
            { 
                Vector3 p = prefabInstance.transform.position;
                Vector3 r = prefabInstance.transform.rotation.eulerAngles;
                if (!(p.x == pose.x && p.y == pose.y && p.z == pose.z && r.x == pose.rx && r.y == pose.ry && r.z == pose.rz))
                {
                    pose.update(p.x, p.y, p.z, r.x, r.y, r.z);
                    model.changeData(pose);
                }
            }
        }
    }
}