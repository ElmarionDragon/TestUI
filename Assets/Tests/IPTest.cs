using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class IPTest
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
        GameObject obj = GameObject.Find("Painter(Clone)");
        if (obj) Object.Destroy(obj.gameObject);
    }

    [UnityTest]
    public IEnumerator Painter_color_red()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        Toggle painterToogle = togglesPanel.Q<Toggle>("PainterToggle");
        painterToogle.value = true;
        yield return null;

        VisualElement mainPanel = ui.getMainPanel();
        VisualElement painter = mainPanel.Q<VisualElement>("Painter");
        TextField rrggbb = painter.Q<TextField>("rrggbb");
        rrggbb.value = "ff0000";
        TextField alpha = painter.Q<TextField>("alpha");
        alpha.value = "100";
        Button btn = painter.Q<Button>("IP_OK");
        using (var e = new NavigationSubmitEvent() { target = btn })
            btn.SendEvent(e);
        yield return new WaitForSeconds(1);

        GameObject obj = GameObject.Find("Painter(Clone)");
        bool isOk = obj.GetComponent<MeshRenderer>().material.color == Color.red;
        Assert.True(isOk);
    }

    [UnityTest]
    public IEnumerator Painter_alpha_05()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        Toggle painterToogle = togglesPanel.Q<Toggle>("PainterToggle");
        painterToogle.value = true;
        yield return null;

        VisualElement mainPanel = ui.getMainPanel();
        VisualElement painter = mainPanel.Q<VisualElement>("Painter");
        TextField rrggbb = painter.Q<TextField>("rrggbb");
        rrggbb.value = "ff0000";
        TextField alpha = painter.Q<TextField>("alpha");
        alpha.value = "50";
        Button btn = painter.Q<Button>("IP_OK");
        using (var e = new NavigationSubmitEvent() { target = btn })
            btn.SendEvent(e);
        yield return new WaitForSeconds(1);

        GameObject obj = GameObject.Find("Painter(Clone)");
        bool isOk = obj.GetComponent<MeshRenderer>().material.color.a == 0.5f;
        Assert.True(isOk);
    }
}
