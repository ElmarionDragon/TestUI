using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class UITest
{
    private UIController ui;
    private VisualElement mainPanel;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("MainUI"));
        ui = gameGameObject.GetComponent<UIController>();
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
        yield return null;

        bool isDisplayed = mainPanel.style.display == DisplayStyle.None;
        Assert.True(isDisplayed);
    }

    [UnityTest]
    public IEnumerator Painter_color_red()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(2);

        VisualElement togglesPanel = ui.getTogglesPanel();
        UIPrefabToggle painter = togglesPanel.Q<UIPrefabToggle>("PainterToggle");
        painter.value = true;
        yield return null;

        TextField rrggbb = painter.ui.Q<TextField>("rrggbb");
        rrggbb.value = "ff0000";
        yield return new WaitForSeconds(1);

        bool isRed = painter.model.GetComponent<MeshRenderer>().material.color == Color.red;
        Assert.True(isRed);
    }
}
