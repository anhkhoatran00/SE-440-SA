using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    // Start is called before the first frame update
   public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>

        private static T _instance;
    public static T Instance => _instance;
    [SerializeField] private bool isDontDestroyOnload;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = (T) this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (isDontDestroyOnload) 
        {
            DontDestroyOnLoad(this);
        }


    }
}
