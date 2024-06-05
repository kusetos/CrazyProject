using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Assets._Scripts.GamePlay;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private Shooting player;
    public override void InstallBindings()
    {
        //Bind Player
        Container.Bind<Shooting>().FromInstance(player).AsSingle();

        // TIMER and SCORE in game
        Container.BindInterfacesAndSelfTo<GameTimer>().AsSingle();
        Container.Bind<GameScore>().AsSingle();

        //Managers
        Container.Bind<UIGameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
    }
}
