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

            posX = createInputField(window, "x", "pos");
            posY = createInputField(window, "y", "pos");
            posZ = createInputField(window, "z", "pos");


            title = new Label();
            title.AddToClassList(ussLabel);
            window.Add(title);
            title.text = "Rotation";

            rotX = createInputField(window, "x", "rot");
            rotY = createInputField(window, "y", "rot");
            rotZ = createInputField(window, "z", "rot");
        }
        

        private TextField createInputField(VisualElement parent, string label, string op)
        {
            TextField field = new TextField();
            field.AddToClassList(ussTextField);
            field.name = op + label; 
            field.label = label;
            field.SetValueWithoutNotify("0");
            field.RegisterValueChangedCallback(v =>
            {
                onValueChanged(this); 
            });
            parent.Add(field);
            return field;
        }

        public void onValueChanged(Pose v)
        {
            Debug.Log("onValueChanged: " + v);
            changed.Invoke(this);
        }

        public void update(Pose v)
        {
            posX.value = v.x.ToString();
            posY.value = v.y.ToString();
            posZ.value = v.z.ToString();
            rotX.value = v.rx.ToString();
            rotY.value = v.ry.ToString();
            rotZ.value = v.rz.ToString();
        }

        public void update(float vx, float vy, float vz, float vrx, float vry, float vrz)
        {
            posX.value = vx.ToString();
            posY.value = vy.ToString();
            posZ.value = vz.ToString();
            rotX.value = vrx.ToString();
            rotY.value = vry.ToString();
            rotZ.value = vrz.ToString();
        }
    }
}
