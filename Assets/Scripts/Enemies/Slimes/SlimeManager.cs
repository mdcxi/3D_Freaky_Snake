using System;
using System.Collections.Generic;
using UnityEngine;

namespace FreakySnake.Enemies
{
    [DefaultExecutionOrder(1000)]
    public class SlimeManager : SingletonMonobehaviour<SlimeManager>
    {
        public List<SlimeBehaviour> _slimes = new List<SlimeBehaviour>();
       
        public event Action<SlimeBehaviour> OnSlimeAdded;
        public event Action<SlimeBehaviour> OnSlimeRemoved;
        
        private void Start()
        {
            // EnemySpawnManager.Instance.NotifySlimeSpawned();
            FindSlimes();
        }

        public void FindSlimes()
        {
            var slimeObjects = FindObjectsOfType<SlimeBehaviour>();
            _slimes.AddRange(slimeObjects);
        }

        public void AddSlime(SlimeBehaviour slime)
        {
            if (!_slimes.Contains(slime))
            {
                _slimes.Add(slime);
                OnSlimeAdded?.Invoke(slime);
            }
        }

        public void RemoveSlime(SlimeBehaviour slime)
        {
            if (_slimes.Contains(slime))
            {
                _slimes.Remove(slime);
                OnSlimeRemoved?.Invoke(slime);
            }
        }

        public SlimeBehaviour[] GetSlimes()
        {
            return _slimes.ToArray();
            // return _slimes.Select(slime => slime.gameObject).ToArray();
        }
    }
}

