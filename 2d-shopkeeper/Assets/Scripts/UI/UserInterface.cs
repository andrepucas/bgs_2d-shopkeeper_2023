using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that manages all game UI, opening and closing panels.
/// </summary>
public class UserInterface : MonoBehaviour
{
    // --- EVENTS --------------------------------------------------------------

    public static event Action OnScreenRevealed;
    public static event Action<Vector3> OnMovePlayer;

    // --- VARIABLES -----------------------------------------------------------

    [Header("PANELS")]
    [SerializeField] private float _fadeTime;
    [SerializeField] private UIPanelShopkeeper _shopkeeperUI;
    
    [Header("RADIAL TRANSITION")]
    [SerializeField] private Image _radialPanel;
    [SerializeField] private float _fillTime;

    [Header("DATA")]
    [SerializeField] private Camera _camera;
    [SerializeField] private GeneralDataSO _data;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void OnEnable() => GameManager.OnNewGameState += UpdateDisplayedUI;
    private void OnDisable() => GameManager.OnNewGameState -= UpdateDisplayedUI;

    // --- METHODS -------------------------------------------------------------

    private void UpdateDisplayedUI(GameStates p_gameState)
    {
        switch(p_gameState)
        {
            case GameStates.SPAWN:

                _shopkeeperUI.Close();

                // Zoom out camera.
                _camera.orthographicSize = _data.CamZoomOutSize;
                _camera.transform.localPosition = _data.CamZoomOutPos;

                OnMovePlayer?.Invoke(_data.SpawnPos);

                StartCoroutine(RevealScreen());
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.None;
                break;

            case GameStates.RESUME_ROAM:

                StartCoroutine(TransitionToRoam());
                Cursor.visible = false;
                break;

            case GameStates.SHOP:

                StartCoroutine(TransitionToShop());
                Cursor.visible = true;
                break;
        }
    }

    private IEnumerator RevealScreen()
    {
        _radialPanel.fillAmount = 1;
        yield return new WaitForSeconds(.5f);
        
        // Reveal screen.
        float m_elapsedTime = 0;
        _radialPanel.fillClockwise = false;
        while (_radialPanel.fillAmount != 0)
        {
            _radialPanel.fillAmount = Mathf.Lerp(
                1, 0, (m_elapsedTime / _fillTime));

            m_elapsedTime += Time.deltaTime;
            yield return null;
        }

        OnScreenRevealed?.Invoke();
    }
    
    private IEnumerator TransitionToShop()
    {
        float m_elapsedTime = 0;

        // Hide screen.
        _radialPanel.fillClockwise = true;
        while (_radialPanel.fillAmount < 1)
        {
            _radialPanel.fillAmount = Mathf.Lerp(
                0, 1, (m_elapsedTime / _fillTime));

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
        _radialPanel.fillClockwise = false;
        while (_radialPanel.fillAmount != 0)
        {
            _radialPanel.fillAmount = Mathf.Lerp(
                1, 0, (m_elapsedTime / _fillTime));

            m_elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        // Reveal shopkeeper UI.
        _shopkeeperUI.Open(_fadeTime);
    }

    public IEnumerator TransitionToRoam()
    {
        float m_elapsedTime = 0;

        // Hide shopkeeper UI.
        _shopkeeperUI.Close(_fadeTime);

        // Hide screen.
        _radialPanel.fillClockwise = false;
        while (_radialPanel.fillAmount < 1)
        {
            _radialPanel.fillAmount = Mathf.Lerp(
                0, 1, (m_elapsedTime / _fillTime));

            m_elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        // Zoom out camera.
        _camera.orthographicSize = _data.CamZoomOutSize;
        _camera.transform.localPosition = _data.CamZoomOutPos;

        // Move player to shop.
        OnMovePlayer?.Invoke(_data.DoorPos);

        // Reveal screen.
        m_elapsedTime = 0;
        _radialPanel.fillClockwise = true;
        while (_radialPanel.fillAmount != 0)
        {
            _radialPanel.fillAmount = Mathf.Lerp(
                1, 0, (m_elapsedTime / _fillTime));

            m_elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        OnScreenRevealed?.Invoke();
    }
}
