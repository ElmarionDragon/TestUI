using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseModel: ComponentModel
    {
        Pose pose;
        public event Action<Pose> onPoseChanged;

        public PoseModel(): base()
        {
        }

        public void changeData(Pose v)
        {
            onPoseChanged(v);
        }
    }
}