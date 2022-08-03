using System;
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
        private const string ussWindow = "ip-window";
        private const string ussTitle = "title";

        private const string ussTextField = "ip-text";

        private TextField rrggbb;
        private TextField alpha;

        public event Action<string> changed;

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
            rrggbb.name = "rrggbb";
            window.Add(rrggbb);
            rrggbb.SetValueWithoutNotify("000000");

            alpha = new TextField();
            alpha.AddToClassList(ussTextField);
            window.Add(alpha);
            alpha.name = "alpha";
            alpha.SetValueWithoutNotify("0");

            Button button = new Button();
            button.AddToClassList(ussTextField);
            window.Add(button);
            button.name = "IP_OK";
            button.text = "OK";
            button.clicked += onClick;
        }

        private void onClick()
        {
            Debug.Log("onClick: " + rrggbb.text + ":" + alpha.text);
            changed.Invoke(rrggbb.text + ":" + alpha.text);
        }
    }
}
