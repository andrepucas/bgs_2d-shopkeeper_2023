using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIPanelShopkeeper : UIPanelAbstract
{
    // --- EVENTS --------------------------------------------------------------
    
    public static event Action OnDone;
    
    // --- VARIABLES -----------------------------------------------------------

    [SerializeField] private GameObject[] _itemPanels;
    [SerializeField] private TMP_Text _money;

    [Header("BUTTONS")]
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _previousButton;

    [Header("DATA")]
    [SerializeField] private GeneralDataSO _data;

    private int _currentItemPanel;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void OnEnable() => ShopItemCard.OnTransaction += UpdateMoney;
    private void OnDisable() => ShopItemCard.OnTransaction -= UpdateMoney;

    // --- METHODS -------------------------------------------------------------

    // Shows panel.
    public new void Open(float p_fade = 0)
    {
        foreach(GameObject f_panel in _itemPanels)
            f_panel.SetActive(false);
        
        _itemPanels[0].SetActive(true);
        _currentItemPanel = 0;
        UpdateButtons();
        UpdateMoney();

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

    private void UpdateMoney() => _money.text = "$" + _data.Money;

    public void DeselectAll() => EventSystem.current.SetSelectedGameObject(null);
}
