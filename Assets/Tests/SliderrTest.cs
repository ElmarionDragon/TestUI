using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class SliderTest
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
    public IEnumerator Painter_size_2()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        UIPrefabToggle painter = togglesPanel.Q<UIPrefabToggle>("PainterToggle");
        painter.value = true;
        yield return null;

        TextField size = painter.ui.Q<TextField>("textSize");
        size.value = "2";
        yield return new WaitForSeconds(1);

        bool isOk = painter.model.transform.localScale.x == 2;
        Assert.True(isOk);
    }

    [UnityTest]
    public IEnumerator Positioner_size_3()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        UIPrefabToggle positioner = togglesPanel.Q<UIPrefabToggle>("PositionerToggle");
        positioner.value = true;
        yield return null;

        TextField size = positioner.ui.Q<TextField>("textSize");
        size.value = "3";
        yield return new WaitForSeconds(1);

        bool isOk = positioner.model.transform.localScale.x == 3;
        Assert.True(isOk);
    }
}
