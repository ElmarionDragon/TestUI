using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class PoseModel : ComponentModel
    {
        public Pose pose;

        public PoseModel() : base()
        {
        }

        public void setPose(Pose v)
        {
            pose = v;
            notifyObservers();
        }

        override protected void Update()
        {
            if (prefabInstance != null)
            {
                Vector3 p = prefabInstance.transform.position;
                Vector3 r = prefabInstance.transform.rotation.eulerAngles;
                if (!(p.x == pose.x && p.y == pose.y && p.z == pose.z && r.x == pose.rx && r.y == pose.ry && r.z == pose.rz))
                {
                    pose.update(p.x, p.y, p.z, r.x, r.y, r.z);
                    notifyObservers();
                }
            }
        }
    }
}