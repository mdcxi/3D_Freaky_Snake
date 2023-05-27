using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FreakySnake.Abilities;
using FreakySnake.DamageSystem;
using UnityEngine;

namespace FreakySnake.Abilities
{
    [CreateAssetMenu(fileName = "Health Duration Effect", menuName = "Snake/Items/Health Duration Effect")]
    public class IncrementHealthDurationEffect : EffectStrategy
    {
        [SerializeField] private int healthIncreaseEverySeconds = 10;
        [SerializeField ]private int effectDuration = 8;
        public override void StartEffect(AbilityData data, Action finished)
        {
            foreach (var target in data.GetTargets())
            {
                var health = target.GetComponent<Damageable>();

                if (health)
                {
                    // health.StartCoroutine(health.IncreaseHealth(healthIncreaseEverySeconds, effectDuration));
                    health.IncreaseHealth(healthIncreaseEverySeconds, effectDuration).Forget();
                }
            }
        }
    }
}

