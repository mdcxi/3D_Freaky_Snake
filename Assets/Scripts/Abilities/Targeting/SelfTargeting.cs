using System;
using UnityEngine;

namespace FreakySnake.Abilities
{
    [CreateAssetMenu(fileName = "Self Targeting", menuName = "Abilities/Targeting/Self")]
    public class SelfTargeting : TargetingStrategy
    {
        public override void StartTargeting(AbilityData data, Action finished)
        {
            data.SetTargets(
                new GameObject[]
                {
                    data.GetUser()
                });
            data.SetTargetedPoint(data.GetUser().transform.position);
            finished();
        }
    }
}

