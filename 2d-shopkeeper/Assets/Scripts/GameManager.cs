using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // --- EVENTS --------------------------------------------------------------

    public static event Action<GameStates> OnNewGameState;
    
    // --- VARIABLES -----------------------------------------------------------

    [Header("PLAYER")]
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInteraction _playerInteraction;

    // --- ON OBJECT STARTUP ---------------------------------------------------

    private void OnEnable()
    {
        PlayerInteraction.OnShopkeeperKnock += () => UpdateGameState(GameStates.SHOP);
        UIPanelShopkeeper.OnDone += () => UpdateGameState(GameStates.RESUME_ROAM);
        UserInterface.OnScreenRevealed += () => UpdateGameState(GameStates.ROAM);
        UserInterface.OnMovePlayer += MovePlayer;
    }

    private void OnDisable()
    {
        PlayerInteraction.OnShopkeeperKnock -= () => UpdateGameState(GameStates.SHOP);
        UIPanelShopkeeper.OnDone -= () => UpdateGameState(GameStates.RESUME_ROAM);
        UserInterface.OnScreenRevealed -= () => UpdateGameState(GameStates.ROAM);
        UserInterface.OnMovePlayer -= MovePlayer;
    }

    private void Start() => UpdateGameState(GameStates.SPAWN);

    // --- METHODS -------------------------------------------------------------
    
    private void UpdateGameState(GameStates p_gameState)
    {
        switch (p_gameState)
        {
            case GameStates.SPAWN:
                _playerMovement.enabled = false;
                _playerInteraction.enabled = false;
                break;

            case GameStates.ROAM:
                _playerMovement.enabled = true;
                _playerInteraction.enabled = true;
                break;

            case GameStates.RESUME_ROAM:
                break;

            case GameStates.SHOP:
                _playerMovement.Freeze();
                _playerMovement.enabled = false;
                _playerInteraction.enabled = false;
                break;
        }

        OnNewGameState?.Invoke(p_gameState);
    }

    private void MovePlayer(Vector3 p_pos)
    {
        _player.transform.position = p_pos;
        Debug.Log(1);
    }
}
