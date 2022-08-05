using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class UITest
{
    private UIMain ui;
    private VisualElement mainPanel;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("MainUI"));
        ui = gameGameObject.GetComponent<UIMain>();
        mainPanel = ui.getMainPanel();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(ui.gameObject);
    }

    [UnityTest]
    public IEnumerator MainPanel_display_none()
    {
        mainPanel = ui.getMainPanel();

        yield return null;

        bool isOk = mainPanel.style.display == DisplayStyle.None;
        Assert.True(isOk);
    }

    [UnityTest]
    public IEnumerator Painter_off_modelDestroyed()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        Toggle painter = togglesPanel.Q<Toggle>("PainterToggle");
        painter.value = true;
        yield return null;

        painter.value = false;
        yield return null;

        GameObject obj = GameObject.Find("Painter");
        bool isOk = obj == null;
        Assert.True(isOk);
    }
}
