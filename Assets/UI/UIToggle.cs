using System;
using UnityEngine.UIElements;

public class UIToggle : Toggle
{
    public UIPrefab uiPrefab;

    public event Action<UIPrefab, bool> changed;

    public UIToggle(UIPrefab p): base()
    {
        uiPrefab = p;
        label = uiPrefab.name;
        
        this.RegisterValueChangedCallback(v =>
        {
            bool newValue = v.newValue;
            changed.Invoke(uiPrefab, newValue);
        });
    }
}
