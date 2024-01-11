using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Player.Zenject
public class BallInstaller : MonoInstaller
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerBehaviour>()
                .FromInstance(_playerBehaviour)
                .AsSingle();
        }
    }
}
