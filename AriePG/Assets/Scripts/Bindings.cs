using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AriePG {
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Bindings", order = 1)]
    public class Bindings : ScriptableObject {
        public List<Binding> bindings;




        [System.Serializable]
        public class Binding{
            [SerializeField]
            public Action m_Action;
            [SerializeField]
            public KeyCode m_Key;
        }
    }
}