using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _BananaPrefab;

    public override void InstallBindings()
    {
        BananaStateManager stateManager = Container
            .InstantiatePrefabForComponent<BananaStateManager>(_BananaPrefab, _startPoint.position, Quaternion.identity, null);

        Container
            .Bind<BananaStateManager>()
            .FromInstance(stateManager).AsTransient();
    }
}
