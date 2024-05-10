using BaursakRun.Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BaursakRun.Controllers
{
  public class EnvController : MonoBehaviour
  {
        [SerializeField] private GameObject _env;
        [SerializeField] private GameObject _envNew;
        [SerializeField] private float _mergeDistance;
        [SerializeField] private EnvData _envData;
      

        private Vector3 _startPosition;

        void Start()
        {                       
             _startPosition = _env.transform.localPosition;
                foreach (var Element in _envData.elements)
                {
                    var obj = Instantiate(Element, Vector3.zero, Quaternion.identity, transform);
                    obj.transform.localPosition = new Vector3(Random.Range(10, 12), Random.Range(0.7f, 5.2f), 0);
                }
        }
      
        void Update()
        {           
            _env.transform.localPosition += 3.5f * Time.deltaTime * -Vector3.right;

                 if (_env.transform.localPosition.x < 0.5)
                 {
                   if (!_envNew)
                   {
                    _envNew = Instantiate(_env, new Vector3(18, 3.48f, 0), Quaternion.identity, transform);
                    _envNew.transform.localPosition = new Vector3(_mergeDistance, 3.48f, 0);
                   }
                 }

                if (_envNew)
                {
                     _envNew.transform.localPosition += 3.5f * Time.deltaTime * -Vector3.right;
 
                    if (_envNew.transform.localPosition.x < 0.5)
                    {
                         Destroy(_envNew);
                         _env.transform.localPosition = _startPosition;
                    }
                }                                                                                        
        }


  }
}

