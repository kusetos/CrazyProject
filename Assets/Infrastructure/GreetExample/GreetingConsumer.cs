using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Infrastructure
{
    public class GreetingConsumer : MonoBehaviour
    {

       private IGreeting _greeting;
        
        private Greeting _greeting2;

        [Inject]
        public void Inject(Greeting greeting2, IGreeting greeting)
        {
            this._greeting2 = greeting2;
            this._greeting = greeting;
        }

        private void Update()
        {
            Debug.Log(_greeting.Message);
            Debug.Log(_greeting2.Message);
        }
    }
}