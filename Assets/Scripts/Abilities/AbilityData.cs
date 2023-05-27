using System.Collections;
using System.Collections.Generic;
using FreakySnake.Core;
using UnityEngine;

namespace FreakySnake.Abilities
{
    public class AbilityData : IAction
    {
        private readonly GameObject _user;
        private Vector3 _targetedPoint;
        private IEnumerable<GameObject> _targets;
        private bool _cancelled;
    
        public AbilityData(GameObject user)
        {
            _user = user;
        }
    
        public IEnumerable<GameObject> GetTargets()
        {
            return _targets;
        }
    
        public void SetTargets(IEnumerable<GameObject> targets)
        {
            _targets = targets;
        }
    
        public Vector3 GetTargetedPoint()
        {
            return _targetedPoint;
        }
    
        public void SetTargetedPoint(Vector3 targetedPoint)
        {
            _targetedPoint = targetedPoint;
        }
    
        public GameObject GetUser()
        {
            return _user;
        }
        
        public void Cancel()
        {
            _cancelled = true;
        }
    
        public bool IsCancelled()
        {
            return _cancelled;
        }
    }
}

