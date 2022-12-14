using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class Slider: VisualElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<Slider> { }

        private const string styleResource = "SliderUSS";

        private const string ussContainer = "container";
        private const string ussWindow = "slider-window";
        private const string ussTitle = "title";

        private const string ussSlider = "slider";
        private const string ussTextField = "slider-text";

        public UnityEngine.UIElements.Slider slider;
        public TextField textField;

        public event Action<float> changed;

        public Slider()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            AddToClassList(ussContainer);

            VisualElement window = new VisualElement();
            window.AddToClassList(ussWindow);
            hierarchy.Add(window);

            Label title = new Label();
            title.AddToClassList(ussTitle);
            window.Add(title);
            title.text = "Size";

            slider = new UnityEngine.UIElements.Slider(1,10);
            slider.AddToClassList(ussSlider);
            window.Add(slider);
            slider.RegisterValueChangedCallback(v =>
            {
                string newValue = v.newValue.ToString();
                textField.SetValueWithoutNotify(newValue);
                onValueChanged(v.newValue);
            });

            textField = new TextField();
            textField.AddToClassList(ussTextField);
            textField.name = "textSize";
            window.Add(textField);
            textField.SetValueWithoutNotify("1");
            textField.RegisterValueChangedCallback(v =>
            {
                float newValue = float.Parse(v.newValue);
                slider.SetValueWithoutNotify(newValue);
                onValueChanged(newValue);
            });
        }

        public void onValueChanged(float v)
        {
            Debug.Log("onValueChanged: " + v);
            changed.Invoke(v);
        }

        public void update(float v)
        {
            textField.value = v.ToString();
            slider.value = v;
        }
    }
}
