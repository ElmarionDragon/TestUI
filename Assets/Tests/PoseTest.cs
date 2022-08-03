using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TestUI;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class PoseTest
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
    public IEnumerator Positioner_x_2()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        UIPrefabToggle positioner = togglesPanel.Q<UIPrefabToggle>("PositionerToggle");
        positioner.value = true;
        yield return null;

        TextField posX = positioner.ui.Q<TextField>("posx");
        posX.value = "2";
        yield return new WaitForSeconds(1);

        bool isOk = positioner.model.transform.position.x == 2;
        Assert.True(isOk);
    }

    [UnityTest]
    public IEnumerator Positioner_rotatex_45()
    {
        ui.menuTogglePress();
        yield return new WaitForSeconds(1);

        VisualElement togglesPanel = ui.getTogglesPanel();
        UIPrefabToggle positioner = togglesPanel.Q<UIPrefabToggle>("PositionerToggle");
        positioner.value = true;
        yield return null;

        TextField posX = positioner.ui.Q<TextField>("rotx");
        posX.value = "45";
        yield return new WaitForSeconds(1);

        bool isOk = positioner.model.transform.eulerAngles.x > 44;
        Assert.True(isOk);
    }
}
