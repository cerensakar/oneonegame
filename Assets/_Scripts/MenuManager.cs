using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject ContinueMenu, gameOverMenuUI;

    // Start is called before the first frame update

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameState;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameState;
    }

    private void GameManagerOnOnGameState(GameManager.GameState state)
    {
        gameOverMenuUI.SetActive (state == GameManager.GameState.GameOver);
        ContinueMenu.SetActive(state == GameManager.GameState.Continue);
    }

}
