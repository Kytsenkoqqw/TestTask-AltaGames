using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Button _pushBall;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;
    [Inject] private PushBall _push;
    [Inject] private PlayerBehaviour _playerBehaviour;

    private void Start()
    {
        _push.OnLoseMenu += LoseMenu;
        _push.OnWinMenu += WinMenu;
        _playerBehaviour.OnBallScaleDown += LoseMenu;
    }

    private void OnEnable()
    {
        _pushBall.onClick.AddListener(_push.StartMove);
        _nextLevelButton.onClick.AddListener(RestartGame);
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _pushBall.onClick.RemoveListener(_push.StartMove);
        _nextLevelButton.onClick.RemoveListener(RestartGame);
        _restartButton.onClick.RemoveListener(RestartGame);
    }

    private void OnDestroy()
    {
        _push.OnLoseMenu -= LoseMenu;
        _push.OnWinMenu -= WinMenu;
        _playerBehaviour.OnBallScaleDown -= LoseMenu;
    }

    private void WinMenu()
    {
        _winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LoseMenu()
    {
        _loseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        if (Time.timeScale !=1)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        Debug.Log("ReloadScene");
    }
}
