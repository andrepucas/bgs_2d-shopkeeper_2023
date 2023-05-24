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

    [SerializeField] private GameObject[] _itemPanels;

    [Header("BUTTONS")]
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _previousButton;

    private int _currentItemPanel;

    // --- METHODS -------------------------------------------------------------
    
    // Shows panel.
    public new void Open(float p_fade = 0)
    {
        foreach(GameObject f_panel in _itemPanels)
            f_panel.SetActive(false);
        
        _itemPanels[0].SetActive(true);
        _currentItemPanel = 0;
        UpdateButtons();

        base.Open(p_fade);
    }

    // Hides panel.
    public new void Close(float p_fade = 0) => base.Close(p_fade);

    public void Done() => OnDone?.Invoke();

    public void NextItemPanel(int p_add)
    {
        _itemPanels[_currentItemPanel].SetActive(false);

        _currentItemPanel += p_add;
        _itemPanels[_currentItemPanel].SetActive(true);

        UpdateButtons();
    }

    private void UpdateButtons()
    {
        _previousButton.SetActive(_currentItemPanel != 0);
        _nextButton.SetActive(_currentItemPanel != _itemPanels.Length-1);
    }

    public void DeselectAll() => EventSystem.current.SetSelectedGameObject(null);
}
