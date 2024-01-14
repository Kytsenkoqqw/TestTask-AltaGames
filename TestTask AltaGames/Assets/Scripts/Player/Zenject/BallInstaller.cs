using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;


public class BallInstaller : MonoInstaller
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;

    public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<PlayerBehaviour>()
                .FromInstance(_playerBehaviour)
                .AsSingle();
        }
    
}
