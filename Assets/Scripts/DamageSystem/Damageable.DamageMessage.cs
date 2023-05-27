using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreakySnake.DamageSystem
{
    public partial class Damageable
    {
        public struct DamageMessage
        {
            public MonoBehaviour damager;
            public int amount;
        }
    }
}

