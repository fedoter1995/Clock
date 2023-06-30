using System.Collections;
using UnityEngine;

namespace Tools
{
    public sealed class Coroutines : MonoBehaviour
    {
        private static Coroutines instance
        {
            get
            {
                if(m_instance == null)
                {
                    var go = new GameObject("[COUROUTINE MANAGER]");
                    m_instance = go.AddComponent<Coroutines>();
                    DontDestroyOnLoad(go);
                }

                return m_instance;
            }
        
        }

        private static Coroutines m_instance;
        


        public static Coroutine Start(IEnumerator enumerator)
        {
            return instance.StartCoroutine(enumerator);
        }
        public static void Stop(Coroutine routine)
        {
            if(routine != null)
             instance.StopCoroutine(routine);
        }
    }
}

