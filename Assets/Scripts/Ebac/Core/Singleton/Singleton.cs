using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.Core.Singleton {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance {
            get {
                _instance = FindAnyObjectByType<T>();
                if (_instance == null) {
                    var go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();

                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }

        protected virtual void Awake() {
            if (_instance == null) {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            } else if (_instance != this) {
                Destroy(gameObject);
            }
        }
    }
}

