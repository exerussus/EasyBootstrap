using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plugins.Exerussus.EasyBootstrap
{
    [Serializable]
    public class GameShare
    {
        public GameShare()
        {
            _sharedData = new Dictionary<Type, DataPack>();
            
#if UNITY_EDITOR
            _dependencyDict = new Dictionary<Type, DependencyInfo>();
            dependenciesInfo = new List<DependencyInfo>();
#endif
        }
#if UNITY_EDITOR
        [SerializeField] private List<DependencyInfo> dependenciesInfo;
        private Dictionary<Type, DependencyInfo> _dependencyDict;

        public void AddToDependency(Type origin, Type dependency)
        {
            if (!_dependencyDict.ContainsKey(origin))
            {
                var dependencyInfo = new DependencyInfo(origin);
                _dependencyDict[origin] = dependencyInfo;
                dependenciesInfo.Add(dependencyInfo);
            }
            
            _dependencyDict[origin].Dependencies.Add(dependency.Name);
        }
#endif
        
        private Dictionary<Type, DataPack> _sharedData;
        public Dictionary<Type, DataPack> SharedData => _sharedData;
    }
}