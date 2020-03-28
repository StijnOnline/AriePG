using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AriePG{
    [System.Serializable]
    public abstract class Action : ScriptableObject {
        [SerializeField]
        private string m_Name;
        public string name => m_Name;

        public abstract IEnumerator Execute(Player controller);
    }
}