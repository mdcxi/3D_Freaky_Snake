using System;
using Cysharp.Threading.Tasks;
using FreakySnake.Helpers.Message;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FreakySnake.DamageSystem
{
    public partial class Damageable : MonoBehaviour
    {
        [Header("Health Config")] 
        public int maxHealthLimit = 100;
        
        [Space(2)]
        [Header("Health Bar Config")] 
        [SerializeField] private Slider healthBar;
        
        public int CurrentHealth { get; set; }
        
        public UnityEvent onResetDamage, onReceiveDamage, onDeath;
        
        [Space(2)]
        [Tooltip("When this gameObject is damaged, these other gameObjects are notified.")]
        public MonoBehaviour onDamageMessageReceiver; 
        
        private Canvas _healthCanvas;
        private Action _action;
        
        private int _healthIncreaseEverySeconds = 10;
        private int _effectDuration = 8;
        private void Awake()
        {
            _healthCanvas = GetComponentInChildren<Canvas>();
        }

        private void Start()
        {
            ResetDamage();
        }

        private void Update()
        {
            UpdateSliderEffect();
        }

        private void LateUpdate()
        {
            if (_action != null)
            {
                _action();
                _action = null;
            }
        }

        private void ResetDamage()
        {
            CurrentHealth = maxHealthLimit;
            healthBar.value = CurrentHealth;
            onResetDamage.Invoke();
        }

        public void ApplyDamage(DamageMessage data)
        {
            if (CurrentHealth <= 0)
            {
                _healthCanvas.enabled = false;
                return;
            }

            CurrentHealth -= data.amount;
            healthBar.value = CurrentHealth;

            if (CurrentHealth <= 0)
            {
                _action += onDeath.Invoke;
            }
            else
            {
                onReceiveDamage.Invoke();
            }
            
            //Nếu CurrentHealth <= 0
            //messageType là DEAD, ngược là Damaged 
            var messageType = CurrentHealth <= 0 ? MessageSystem.MessageType.Dead : MessageSystem.MessageType.Damaged;
            
            //ép kiểu cho receiver về thành MessageSystem.IMessageReceiver
            var receiver = onDamageMessageReceiver as MessageSystem.IMessageReceiver;
            
            //Thông báo messageType của đối tượng đang gắn script này cho bất kỳ đối tượng nào được chỉ định là onDamageMessageReceiver.
            // Đối tượng đuược nhận sẽ thực hiện các hành động dựa trên messageType
            //onDamageMassageReceiver được xác định bằng việc kéo thả trên Inspector
            receiver?.OnReceiveMessage(messageType, this, data);
        }

        private void UpdateSliderEffect()
        {
            healthBar.value = CurrentHealth;
        }
        
        public async UniTask IncreaseHealth( int amount, float duration)
        {
            var timer = 0f;
        
            while (timer < duration)
            {
               
                if (CurrentHealth + amount > maxHealthLimit)
                {
                    CurrentHealth = maxHealthLimit;
                }
                else
                {
                    CurrentHealth += amount;
                }
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                timer += 1f; 
            }
        }
    }
}

