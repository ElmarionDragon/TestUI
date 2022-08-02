using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private Button menuToggle;
    private VisualElement mainPanel;
    private VisualElement togglesPanel;

    private const string toggleUSS = "toggleTop";

    public UIPrefab[] uiPrefabs;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        menuToggle = root.Q<Button>("menuToggle");
        menuToggle.clicked += menuTogglePress;

        mainPanel = root.Q<VisualElement>("mainPanel");
        togglesPanel = root.Q<VisualElement>("togglesPanel");

        mainPanel.style.display = DisplayStyle.None;

        generateToggles();
    }

    private void generateToggles()
    {
        UIToggle toggle;
        UIPrefab uiPrefab;
        for (int i = 0; i < uiPrefabs.Length; i++)
        {
            uiPrefab = uiPrefabs[i];
            toggle = new UIToggle(uiPrefab);
            toggle.AddToClassList(toggleUSS);
            togglesPanel.Add(toggle);

            toggle.changed += togglePrefab;
        }
    }

    private void togglePrefab(UIPrefab uiPrefab, bool v)
    {
        string uiName = uiPrefab.ui;
        VisualElement ui = mainPanel.Q<VisualElement>(uiName);

        if (v) ui.style.display = DisplayStyle.Flex;
        else ui.style.display = DisplayStyle.None;

        GameObject prefab = uiPrefab.prefab;
        GameObject obj = Instantiate(prefab);
    }


    private void menuTogglePress()
    {
        if (mainPanel.style.display == DisplayStyle.None) StartCoroutine(menuOpen());
        else StartCoroutine(menuClose());
    }

    private IEnumerator menuOpen()
    {
        mainPanel.style.display = DisplayStyle.Flex;
        mainPanel.style.left = -420;
        yield return null;
        mainPanel.style.left = 0;
    }

    private IEnumerator menuClose()
    {
        mainPanel.style.left = 0;
        yield return null;
        mainPanel.style.left = -420;
        yield return new WaitForSeconds(1);
        mainPanel.style.display = DisplayStyle.None;
    }
}
