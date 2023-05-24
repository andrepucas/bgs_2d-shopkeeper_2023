using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    // --- EVENTS --------------------------------------------------------------

    public static event Action OnShopkeeperKnock;
    
    // --- VARIABLES -----------------------------------------------------------

    [Header("COMPONENTS")]
    [SerializeField] private GameObject _notification;

    [Header("INPUT")]
    [SerializeField] private InputActionReference _interact;

    private const string HOME = "Home";
    private const string SHOPKEEPER = "Shopkeeper";

    private PlayerInput _input;
    private string _interactable;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void Awake()
    {
        _notification.SetActive(false);
        _interactable = "";

        _interact.action.performed += _ => Interact();
    }

    // --- ON TRIGGER ----------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D p_col)
    {
        if (p_col.tag == SHOPKEEPER || p_col.tag == HOME)
            _notification.SetActive(true);

        _interactable = p_col.tag;
    }

    private void OnTriggerExit2D(Collider2D p_col)
    {
        if (p_col.tag == SHOPKEEPER || p_col.tag == HOME)
            _notification.SetActive(false);

        _interactable = "";
    }

    // --- METHODS -------------------------------------------------------------

    private void Interact()
    {
        switch (_interactable)
        {
            case HOME:
                Debug.Log(1);
                break;
            
            case SHOPKEEPER:
                OnShopkeeperKnock?.Invoke();
                Debug.Log(2);
                break;
        }
    }
}
