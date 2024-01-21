using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Button _pushBall;
    [Inject] private PushBall _push;

    private void OnEnable()
    {
        _pushBall.onClick.AddListener(_push.StartMove);
    }

    private void OnDisable()
    {
        _pushBall.onClick.RemoveListener(_push.StartMove);
    }

    public void Resume()
    {
        if (Time.timeScale !=1)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void WinMennu()
    {
        
    }


}
