using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class UIPrefabController
    {
        public Toggle toggle;
        public UIPrefabView view;

        public UIPrefabController(UIPrefabView theView)
        {
            view = theView;
            toggle = view.toggle;

            toggle.RegisterValueChangedCallback(v =>
            {
                bool flag = v.newValue;
                if (flag)
                {
                    view.show();
                }
                else
                {
                    view.hide();
                }
            });
        }
    }
}