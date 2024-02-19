using System.Collections;
using UnityEngine;

namespace Assets.Infrastructure
{
    public class Greeting
    {
        private string _message = "Greet consumer";

        public string Message
        {
            get
            {
                return _message;
            }
        }
    }
}