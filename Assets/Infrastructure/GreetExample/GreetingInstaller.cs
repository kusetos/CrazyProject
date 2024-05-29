using Assets._Scripts.Banana;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Infrastructure.GreetExample
{
    public class GreetingInstaller : MonoInstaller
    {
        [SerializeField] private BananaStateManager _banan;
        [SerializeField] private Transform _spawnPoint;
        public override void InstallBindings()
        {
            //Container.Bind<IGreeting>().To<Greeting>().AsSingle();
            Container.Bind<IGreeting>().AsSingle();
            //Container.Bind<Greeting>().AsSingle();


/*            var bananaInstance = Container
                .InstantiatePrefabForComponent<BananaStateManager>
                (_banan, _spawnPoint.position, _spawnPoint.rotation, null);*/
            //Container.Bind<BananaStateManager>().FromInstance(bananaInstance).AsTransient();
        }
    }

}