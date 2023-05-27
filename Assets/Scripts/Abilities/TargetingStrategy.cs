using System;
using UnityEngine;

namespace FreakySnake.Abilities
{
    public abstract class TargetingStrategy : ScriptableObject
    {
        public abstract void StartTargeting(AbilityData data, Action finished);
    }
}

