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

        //Score
        Container.BindInterfacesAndSelfTo<GameScore>().AsSingle();

        // TIMER in game
        Container.BindInterfacesAndSelfTo<GameTimer>().AsSingle();

        //Managers
        Container.Bind<LevelDataManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UIGameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();

    }
}
