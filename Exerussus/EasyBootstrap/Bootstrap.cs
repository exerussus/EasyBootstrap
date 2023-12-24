using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Plugins.Exerussus.EasyBootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private List<EasyMonoBehaviour> _awake;
        [SerializeField] private List<EasyMonoBehaviour> _start;
        [SerializeField] private List<EasyMonoBehaviour> _share;

        [SerializeField] private List<DataPack> bootQueue;
        [SerializeField] private GameShare gameShare;
        
        private void AddToDict(EasyMonoBehaviour initMonoBeh)
        {
            if (!gameShare.SharedData.ContainsKey(initMonoBeh.GetType()))
            {
                var newPack = new DataPack(initMonoBeh.GetType(), initMonoBeh);
                initMonoBeh.Initialize(gameShare, newPack);
                gameShare.SharedData[initMonoBeh.GetType()] = newPack;
            }
        }

        private void InitAll()
        {
            gameShare = new GameShare();
            bootQueue = new List<DataPack>();
                        
            foreach (var monoBeh in _share)
            {
                AddToDict(monoBeh);
            }
            
            foreach (var monoBeh in _awake)
            {
                AddToDict(monoBeh);
            }
            
            foreach (var monoBeh in _start)
            {
                AddToDict(monoBeh);
            }
        }
        
        private void Awake()
        {
            InitAll();
            
            foreach (var initMonoBeh in _awake)
            {
                initMonoBeh.Initialize();
                bootQueue.Add(gameShare.SharedData[initMonoBeh.GetType()]);
            }
        }

        private void Start()
        {
            foreach (var initMonoBeh in _start)
            {
                initMonoBeh.Initialize();
                bootQueue.Add(gameShare.SharedData[initMonoBeh.GetType()]);
            }
        }
    }
}