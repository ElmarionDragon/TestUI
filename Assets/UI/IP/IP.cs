using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestUI
{
    public class IP: VisualElement
    {
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<IP> { }

        private const string styleResource = "IPUSS";

        private const string ussContainer = "container";
        private const string ussWindow = "slider-window";
        private const string ussTitle = "title";

        private const string ussTextField = "ip-text";

        private TextField rrggbb;
        private TextField alpha;

        public IP()
        {
            styleSheets.Add(Resources.Load<StyleSheet>(styleResource));
            AddToClassList(ussContainer);

            VisualElement window = new VisualElement();
            window.AddToClassList(ussWindow);
            hierarchy.Add(window);

            Label title = new Label();
            title.AddToClassList(ussTitle);
            window.Add(title);
            title.text = "IP";

            rrggbb = new TextField();
            rrggbb.AddToClassList(ussTextField);
            window.Add(rrggbb);
            rrggbb.SetValueWithoutNotify("000000");

            alpha = new TextField();
            alpha.AddToClassList(ussTextField);
            window.Add(alpha);
            alpha.SetValueWithoutNotify("0");

            Button button = new Button();
            button.AddToClassList(ussTextField);
            window.Add(button);
            button.text = "OK";
            button.clicked += onClick;
        }

        private void onClick()
        {
            onValueChanged(rrggbb.text + ":" + alpha.text);
        }

        public void onValueChanged(string v)
        {
            Debug.Log("onValueChanged: " + v);
        }
    }
}
