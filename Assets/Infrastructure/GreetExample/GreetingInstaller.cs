using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Infrastructure.GreetExample
{
    public class GreetingInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<IGreeting>().To<Greeting>().AsSingle();
            Container.Bind<IGreeting>().AsSingle();
            Container.Bind<Greeting>().AsSingle();
        }
    }

}