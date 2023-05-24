using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    // --- EVENTS --------------------------------------------------------------

    public static event Action<Vector3> OnMovePlayer;
    
    // --- VARIABLES -----------------------------------------------------------

    [SerializeField] private Image _transitionPanel;
    [SerializeField] private float _transitionTime;

    [Header("DATA")]
    [SerializeField] private GeneralDataSO _data;
    [SerializeField] private Camera _camera;
    
    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void OnEnable() => GameManager.OnNewGameState += UpdateDisplayedUI;
    private void OnDisable() => GameManager.OnNewGameState -= UpdateDisplayedUI;

    // --- METHODS -------------------------------------------------------------

    private void UpdateDisplayedUI(GameStates p_gameState)
    {
        switch(p_gameState)
        {
            case GameStates.SHOP:
                StartCoroutine(TransitionToShop());
                break;
        }
    }

    private IEnumerator TransitionToShop()
    {
        float m_elapsedTime = 0;

        // Hide screen.
        while (_transitionPanel.fillAmount < 1)
        {
            _transitionPanel.fillAmount = Mathf.Lerp(
                0, 1, (m_elapsedTime / _transitionTime));

            m_elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        // Zoom in camera.
        _camera.orthographicSize = _data.CamZoomInSize;
        _camera.transform.localPosition = _data.CamZoomInPos;

        // Move player to shop.
        OnMovePlayer?.Invoke(_data.ShopPos);

        // Reveal screen.
        m_elapsedTime = 0;
        while (_transitionPanel.fillAmount != 0)
        {
            _transitionPanel.fillAmount = Mathf.Lerp(
                1, 0, (m_elapsedTime / _transitionTime));

            m_elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}
