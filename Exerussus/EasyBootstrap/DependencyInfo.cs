using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plugins.Exerussus.EasyBootstrap
{
    [Serializable]
    public class DependencyInfo
    {
        public DependencyInfo(Type type)
        {
            _type = type;
            name = type.Name;
            dependencies = new List<string>();
        }
        
        private Type _type;
        [SerializeField] private string name;
        [SerializeField] private List<string> dependencies;
        public List<string> Dependencies => dependencies;
    }
}