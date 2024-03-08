using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Infrastructure
{
    public class GreetingConsumer : MonoBehaviour
    {

        [Inject]
       private IGreeting _greeting;
        
        private Greeting _greeting2;

/*        public void Inject(IGreeting greeting)
        {
      
            this._greeting = greeting;
        }
*/
        private void Update()
        {
            Debug.Log(_greeting.Message);

        }
    }
}