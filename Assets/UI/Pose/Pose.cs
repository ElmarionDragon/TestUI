using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class Pose: VisualElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<Pose> { }

        private const string styleResource = "SliderUSS";

        private const string ussContainer = "container";
        private const string ussWindow = "pose-window";
        private const string ussTitle = "title";

        private const string ussLabel = "plabel";
        private const string ussTextField = "ptext";

        private TextField posX;
        private TextField posY;
        private TextField posZ;

        private TextField rotX;
        private TextField rotY;
        private TextField rotZ;

        public float x  { get { return float.Parse(posX.text); } }
        public float y { get { return float.Parse(posY.text); } }
        public float z { get { return float.Parse(posZ.text); } }

        public float rx { get { return float.Parse(rotX.text); } }
        public float ry { get { return float.Parse(rotY.text); } }
        public float rz { get { return float.Parse(rotZ.text); } }


        public event Action<Pose> changed;

        public Pose()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            AddToClassList(ussContainer);

            VisualElement window = new VisualElement();
            window.AddToClassList(ussWindow);
            hierarchy.Add(window);

            Label title = new Label();
            title.AddToClassList(ussTitle);
            window.Add(title);
            title.text = "Pose";

            title = new Label();
            title.AddToClassList(ussLabel);
            window.Add(title);
            title.text = "Position";

            posX = createInputField(window, "x");
            posY = createInputField(window, "y");
            posZ = createInputField(window, "z");


            title = new Label();
            title.AddToClassList(ussLabel);
            window.Add(title);
            title.text = "Rotation";

            rotX = createInputField(window, "x");
            rotY = createInputField(window, "y");
            rotZ = createInputField(window, "z");
        }
        

        private TextField createInputField(VisualElement parent, string label)
        {
            TextField field = new TextField();
            field.AddToClassList(ussTextField);
            parent.Add(field);
            field.label = label;
            field.SetValueWithoutNotify("0");
            field.RegisterValueChangedCallback(v =>
            {
                onValueChanged(this); 
            });
            return field;
        }

        public void onValueChanged(Pose v)
        {
            Debug.Log("onValueChanged: " + v);
            changed.Invoke(this);
        }
    }
}
