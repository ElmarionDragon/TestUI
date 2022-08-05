using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class PoseTest
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
    public IEnumerator Positioner_x_2()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        Toggle positionerToggle = togglesPanel.Q<Toggle>("PositionerToggle");
        positionerToggle.value = true;
        yield return null;

        VisualElement positioner = togglesPanel.Q<Toggle>("Positioner");
        TextField posX = positioner.Q<TextField>("posx");
        posX.value = "2";
        yield return new WaitForSeconds(1);

        GameObject obj = GameObject.Find("Positioner");
        bool isOk = obj.transform.position.x == 2;
        Assert.True(isOk);
    }

    [UnityTest]
    public IEnumerator Positioner_rotatex_45()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        Toggle positionerToggle = togglesPanel.Q<Toggle>("PositionerToggle");
        positionerToggle.value = true;
        yield return null;

        VisualElement positioner = togglesPanel.Q<Toggle>("Positioner");
        TextField posX = positioner.Q<TextField>("rotx");
        posX.value = "45";
        yield return new WaitForSeconds(1);

        GameObject obj = GameObject.Find("Positioner");
        bool isOk = obj.transform.eulerAngles.x > 44;
        Assert.True(isOk);
    }
}
