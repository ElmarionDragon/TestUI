using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class IPTest
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
    public IEnumerator Painter_color_red()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        UIPrefabToggle painter = togglesPanel.Q<UIPrefabToggle>("PainterToggle");
        painter.value = true;
        yield return null;

        TextField rrggbb = painter.ui.Q<TextField>("rrggbb");
        rrggbb.value = "ff0000";
        TextField alpha = painter.ui.Q<TextField>("alpha");
        alpha.value = "100";
        Button btn = painter.ui.Q<Button>("IP_OK");
        using (var e = new NavigationSubmitEvent() { target = btn })
            btn.SendEvent(e);
        yield return new WaitForSeconds(1);

        bool isOk = painter.model.GetComponent<MeshRenderer>().material.color == Color.red;
        Assert.True(isOk);
    }

    [UnityTest]
    public IEnumerator Painter_alpha_05()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        UIPrefabToggle painter = togglesPanel.Q<UIPrefabToggle>("PainterToggle");
        painter.value = true;
        yield return null;

        TextField rrggbb = painter.ui.Q<TextField>("rrggbb");
        rrggbb.value = "ff0000";
        TextField alpha = painter.ui.Q<TextField>("alpha");
        alpha.value = "50";
        Button btn = painter.ui.Q<Button>("IP_OK");
        using (var e = new NavigationSubmitEvent() { target = btn })
            btn.SendEvent(e);
        yield return new WaitForSeconds(1);

        bool isOk = painter.model.GetComponent<MeshRenderer>().material.color.a == 0.5f;
        Assert.True(isOk);
    }
}
