using System;
using FreakySnake.DamageSystem;
using UnityEngine;

namespace FreakySnake.Abilities
{
    [CreateAssetMenu(fileName = "Health Effect", menuName = "Snake/Items/Health")]
    public class HealthEffect : EffectStrategy
    {
        [SerializeField] private int healthChange;
        
        public override void StartEffect(AbilityData data, Action finished)
        {
            Debug.Log("Start Health Effect");
            foreach (var target in data.GetTargets())
            {
                var health = target.GetComponent<Damageable>();
                if (health)
                {
                    if (health.CurrentHealth < health.maxHealthLimit)
                    {
                        if (health.CurrentHealth > healthChange)
                        {
                            health.CurrentHealth += (health.maxHealthLimit - health.CurrentHealth);
                        }
                        else
                        {
                            health.CurrentHealth += healthChange;
                        }
                    }
                    else
                    {
                        health.CurrentHealth = 100;
                    }
                }
            }

            finished();
        }
    }

}
