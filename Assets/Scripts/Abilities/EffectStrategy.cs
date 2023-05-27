using System;
using UnityEngine;

namespace FreakySnake.Abilities
{
    public abstract class EffectStrategy : ScriptableObject
    {
        public abstract void StartEffect(AbilityData data, Action finished);
    }

}
