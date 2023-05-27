using System;
using FreakySnake.Combat;
using UnityEngine;

namespace FreakySnake.Abilities
{
    [CreateAssetMenu(menuName = "Snake/Items/Cannon Upgrade", fileName = "Upgrade Cannon")]
    public class CannonModificationEffect : EffectStrategy
    {
        public Bullet bulletToUpgrade; 
        public override void StartEffect(AbilityData data, Action finished)
        {
            foreach (var target in data.GetTargets())
            {
                var cannon = target.GetComponent<CannonManager>();
                if (cannon)
                {
                    cannon.SelectARandomCannonToUpgrade(bulletToUpgrade);
                }
            }
        }
    }
}

