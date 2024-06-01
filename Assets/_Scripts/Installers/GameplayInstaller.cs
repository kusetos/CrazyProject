using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private Shooting player;
    public override void InstallBindings()
    {
        //Container.Bind<Shooting>().FromInstance(player).AsSingle();
        Container.BindInterfacesAndSelfTo<GameTimer>().AsSingle();
    }
}
