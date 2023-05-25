using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

/// <summary>
/// Class that holds and manages the information of each item card in the shop.
/// </summary>
public class ShopItemCard : MonoBehaviour
{
    // --- EVENTS --------------------------------------------------------------

    public static event Action<Sprite[], CustomizableParts> OnEquip;
    public static event Action OnTransaction;
    
    // --- VARIABLES -----------------------------------------------------------

    [Header("COMPONENTS")]
    [SerializeField] private Image[] _renderers;
    [SerializeField] private TMP_Text _buyText;
    [SerializeField] private TMP_Text _sellText;

    [Header("SETS")]
    [SerializeField] private GameObject _equipped;
    [SerializeField] private GameObject _owned;
    [SerializeField] private GameObject _locked;
    
    [Header("ITEM")]
    [SerializeField] private CustomizableParts _bodyPart;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private int _value;

    [Header("DATA")]
    [SerializeField] private GeneralDataSO _data;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void Awake()
    {
        // Assign item sprites to card image.
        for (int i = 0; i < _renderers.Length; i++)
            _renderers[i].sprite = _sprites[i];

        // Update buy/sell text based on value.
        _buyText.text = "BUY $" + _value;
        _sellText.text = "SELL $" + _value;

        // Set card as locked.
        _equipped.SetActive(false);
        _owned.SetActive(false);
        _locked.SetActive(true);
    }

    private void OnEnable() => ShopItemCard.OnEquip += CheckEquipped;
    private void OnDisable() => ShopItemCard.OnEquip -= CheckEquipped;

    private void Start()
    {
        // Set starter items as equipped.
        if (_data.Contains(_bodyPart, _sprites[0]))
        {
            _locked.SetActive(false);
            _equipped.SetActive(true);
        }
    }

    // METHODS -----------------------------------------------------------------

    private void CheckEquipped(Sprite[] p_sprites, CustomizableParts p_bodyPart)
    {
        if (p_bodyPart != _bodyPart) return;

        if (p_sprites[0] != _sprites[0])
        {
            _equipped.SetActive(false);
            _owned.SetActive(true);
        }
    }

    public void Equip()
    {
        _owned.SetActive(false);
        _equipped.SetActive(true);

        OnEquip?.Invoke(_sprites, _bodyPart);
    }

    public void Buy()
    {
        if (_data.Money < _value) return;

        _data.Money -= _value;
        OnTransaction?.Invoke();

        _locked.SetActive(false);
        _owned.SetActive(true);
    }

    public void Sell()
    {
        _data.Money += _value;
        OnTransaction?.Invoke();

        _owned.SetActive(false);
        _locked.SetActive(true);
    }

    public void DeselectAll() => EventSystem.current.SetSelectedGameObject(null);
}
