using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class SliderTest
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
    public IEnumerator Painter_size_2()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        Toggle painterToogle = togglesPanel.Q<Toggle>("PainterToggle");
        painterToogle.value = true;
        yield return null;

        VisualElement painter = togglesPanel.Q<Toggle>("Painter");
        TextField size = painter.Q<TextField>("textSize");
        size.value = "2";
        yield return new WaitForSeconds(1);

        GameObject obj = GameObject.Find("Painter");
        bool isOk = obj.transform.localScale.x == 2;
        Assert.True(isOk);
    }

    [UnityTest]
    public IEnumerator Positioner_size_3()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        Toggle positionerToogle = togglesPanel.Q<Toggle>("PositionerToggle");
        positionerToogle.value = true;
        yield return null;

        VisualElement positioner = togglesPanel.Q<Toggle>("Positioner");
        TextField size = positioner.Q<TextField>("textSize");
        size.value = "3";
        yield return new WaitForSeconds(1);

        GameObject obj = GameObject.Find("Positioner");
        bool isOk = obj.transform.localScale.x == 3;
        Assert.True(isOk);
    }
}
