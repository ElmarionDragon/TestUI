using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class Slider: VisualElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<Slider> { }

        public Slider()
        {

        }
    }
}
