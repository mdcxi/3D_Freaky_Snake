using FreakySnake.Control;
using FreakySnake.DamageSystem;
using FreakySnake.Helpers.Message;
using UnityEngine;
using UnityEngine.AI;

namespace FreakySnake.Enemies
{
    public class SlimeBehaviour : MonoBehaviour, MessageSystem.IMessageReceiver
{
    [SerializeField] private float distanceToAttack = 3f;
    [SerializeField] private float rotationSpeed = 3f;
    
    public static readonly int idleState = Animator.StringToHash("Idle");
    public static readonly int moveState = Animator.StringToHash("Move");
    public static readonly int attackState = Animator.StringToHash("Attack");
    public static readonly int deathState = Animator.StringToHash("Die");
    public static readonly int pursuitState = Animator.StringToHash("InPursuit");
    
    private float _distanceToSnake = Mathf.Infinity;
    private SnakeController _target;
    private NavMeshAgent _agent; 
    
    private Transform _snake;
    private Animator _animator;

    private void Awake()
    {
        _snake = FindObjectOfType<SnakeController>().transform;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (_snake == null)
        {
            _agent.enabled = false;
        }
        else
        {
            _distanceToSnake = Vector3.Distance(transform.position, _snake.position);
   
            FollowSnake();
        }
    }

    private void FollowSnake()
    {
        FaceTarget();
        
        if (_distanceToSnake > distanceToAttack)
        {
            ChaseTarget();
        }
        
        if (_distanceToSnake <= distanceToAttack)
        {
            TriggerAttack();
        }
    }

    private void ChaseTarget()
    {
        _animator.SetTrigger(pursuitState);
        _agent.SetDestination(_snake.position);
    }

    private void TriggerAttack()
    {
        _animator.SetTrigger(attackState);
    }
    
    private void FaceTarget()
    {
        Vector3 direction = (_snake.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void ApplyDamage(Damageable.DamageMessage message)
    {
        //Put something here whenever Slime gets attacked
    }

    private void Death(Damageable.DamageMessage message)
    {
        _animator.SetTrigger(deathState);
    }

    public void OnReceiveMessage(MessageSystem.MessageType type, object sender, object message)
    {
        switch (type)
        {
            case MessageSystem.MessageType.Dead:
                Death((Damageable.DamageMessage) message);
                break;
            case MessageSystem.MessageType.Damaged:
                ApplyDamage((Damageable.DamageMessage) message);
                break;
        }
    }
}
}

