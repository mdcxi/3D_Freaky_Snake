using System;
using FreakySnake.Combat;
using UnityEngine;

namespace FreakySnake.Abilities
{
    [CreateAssetMenu(menuName = "Abilities/Effect/Attack", fileName = "Attack Effect")]
    public class AttackEffect : EffectStrategy
    {
        [SerializeField] private Bullet replacedBullet;
        public override void StartEffect(AbilityData data, Action finished)
        {
            foreach (var target in data.GetTargets())
            {
                var newBullet = target.GetComponent<CannonManager>();
                if (newBullet)
                {
                    newBullet.ChangeNewBulletInEachCannon(replacedBullet);
                }
            }
        }
    }
}

