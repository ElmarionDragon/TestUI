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
        UIPrefabToggle painter = togglesPanel.Q<UIPrefabToggle>("PainterToggle");
        painter.value = true;
        yield return null;

        painter.value = false;
        yield return null;

        bool isOk = painter.model == null;
        Assert.True(isOk);
    }
}