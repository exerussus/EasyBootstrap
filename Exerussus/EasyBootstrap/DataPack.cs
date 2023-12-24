using System;
using UnityEngine;

namespace Plugins.Exerussus.EasyBootstrap
{
    [Serializable]
    public class DataPack
    {
        public DataPack(Type type, EasyMonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
            _type = type;
            name = _type.Name;
        }

        [SerializeField] private string name;
        private Type _type;
        private EasyMonoBehaviour _monoBehaviour;
        
        public string Name => name; 
        public EasyMonoBehaviour MonoBehaviour => _monoBehaviour;
    }
}