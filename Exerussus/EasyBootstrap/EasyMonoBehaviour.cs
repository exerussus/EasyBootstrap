
using UnityEngine;

namespace Plugins.Exerussus.EasyBootstrap
{
    public abstract class EasyMonoBehaviour : MonoBehaviour
    {
        private DataPack _dataPack;
        private bool _isInitialized = false;
        private GameShare _gameShare;
        
        public void Initialize(GameShare gameShare, DataPack dataPack)
        {
            if (_isInitialized) return;
            _gameShare = gameShare;
            _dataPack = dataPack;
            _isInitialized = true;
        }

        public virtual void Initialize(){}

        protected T GetSharedData<T>() where T : EasyMonoBehaviour
        {
            var type = typeof(T);
            var classPack = _gameShare.SharedData[type];
            var monoBeh = classPack.MonoBehaviour;

#if UNITY_EDITOR
            _gameShare.AddToDependency(GetType(), type);
#endif
            
            return (T)monoBeh;
        }
    }
}
