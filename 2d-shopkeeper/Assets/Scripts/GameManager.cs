using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // --- VARIABLES -----------------------------------------------------------

    [Header("PLAYER")]
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _camera;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void Awake() => UpdateGameState(GameStates.SPAWN);
    
    private void OnEnable()
    {
        // Subscribe to events.
    }

    private void OnDisable()
    {
        // Unsubscribe to events.
    }

    // --- METHODS -------------------------------------------------------------
    
    private void UpdateGameState(GameStates p_gameState)
    {
        switch (p_gameState)
        {
            case GameStates.SPAWN:
                UpdateGameState(GameStates.ROAM);
                break;

            case GameStates.ROAM:
                TogglePlayer(true);
                break;

            case GameStates.CUSTOMIZE:
                TogglePlayer(false);
                break;

            case GameStates.SHOP:
                TogglePlayer(false);
                break;
        }
    }

    private void TogglePlayer(bool p_enable)
    {
        if (p_enable) _camera.transform.SetParent(_player.transform);
        else _camera.transform.SetParent(null);

        _player.SetActive(p_enable);
    }

    private IEnumerator Delay(float p_seconds, GameStates p_state)
    {
        yield return new WaitForSeconds(p_seconds);
        UpdateGameState(p_state);
    }
}
