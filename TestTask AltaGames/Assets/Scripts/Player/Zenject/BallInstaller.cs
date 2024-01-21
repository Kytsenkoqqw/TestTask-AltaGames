using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Player;
using UnityEngine;
using Zenject;


public class BallInstaller : MonoInstaller
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private PushBall _pushBall;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesTo<PlayerBehaviour>()
            .FromInstance(_playerBehaviour)
            .AsSingle();

        Container
            .Bind<PushBall>()
            .FromInstance(_pushBall)
            .AsSingle();

    }
    
}
