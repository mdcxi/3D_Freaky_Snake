using System;
using FreakySnake.Control;
using UnityEngine;

namespace FreakySnake.Abilities
{
    [CreateAssetMenu(fileName = "Body Addition Effect", menuName = "Snake/Items/BodyAddition")]
    public class BodyPartAdditionEffect : EffectStrategy
    {
        [Tooltip("The amount of BodyParts you want to add")]
        [SerializeField] private int bodyPartsAmount = 1;

        public override void StartEffect(AbilityData data, Action finished)
        {
            foreach (var target in data.GetTargets())
            {
                var snake = target.GetComponent<SnakeController>();
               if (snake)
               {
                   for (int i = 0; i < bodyPartsAmount; i++)
                   {
                       snake.AddBodyPart();
                   }
               }
            }
            finished();
        }
    }
}

