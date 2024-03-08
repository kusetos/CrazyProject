using System.Collections;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Zenject.ReflectionBaking.Mono.Cecil;

namespace Assets._Scripts.Banana
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] private SpawnModel _model;
        [SerializeField] private GameObject _prefab;
         private SpawnView _view;
        //[SerializeField] private GameObject _prefab;

/*        [Inject]
        public void Cunstruct(SpawnModel model, SpawnView view)
        {
            _model = model;
            
            _view = view;
            Container.Bind<SpawnView>().AsSingle();
            Container.Bind<SpawnModel>().AsSingle();      asdad
        }
*/
        private void Start()
        {
            _model = new SpawnModel();
            _view = new SpawnView();  

            for(int i = 0; i < _model.Count; i++)
            {
                _view.SpawnObjectAtRandom(_prefab, _model.Radius);
            }

        }
    }
}