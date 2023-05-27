using FreakySnake.Core;
using FreakySnake.Inventories;
using UnityEngine;

namespace FreakySnake.Abilities
{
    [CreateAssetMenu(fileName = "Ability Item", menuName = "Abilities/Ability")]
    public class Ability : ActionItem
    {
        [SerializeField] private TargetingStrategy targetingStrategy;
        [SerializeField] private EffectStrategy effectStrategy;
        
        public override bool Use(GameObject user)
        {
            var data = new AbilityData(user);
            Debug.Log(data);

            ActionScheduler scheduler = user.GetComponent<ActionScheduler>();
            scheduler.StartAction(data);

            targetingStrategy.StartTargeting(data, 
                () => {
                    TargetAcquired(data);
                });

            return true;
        }

        private void TargetAcquired(AbilityData data)
        {
            if (data.IsCancelled()) return;
            effectStrategy.StartEffect(data, EffectFinished);
        }

        private void EffectFinished()
        {
            
        }
    }
}

