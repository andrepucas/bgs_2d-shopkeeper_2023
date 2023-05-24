using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPanelShopkeeper : UIPanelAbstract
{
    // --- EVENTS --------------------------------------------------------------
    
    public static event Action OnDone;
    
    // --- VARIABLES -----------------------------------------------------------

    // --- METHODS -------------------------------------------------------------
    
    // Shows panel.
    public new void Open(float p_fade = 0) => base.Open(p_fade);

    // Hides panel.
    public new void Close(float p_fade = 0) => base.Close(p_fade);

    public void Done() => OnDone?.Invoke();

    public void DeselectAll() => EventSystem.current.SetSelectedGameObject(null);
}
