using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace root
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private GameObject DamagePrefab;
        [SerializeField] private NavMeshAgent navMeshAgent;
        private IPlayer _player;
        public bool followPlayer;
        private EnemyInfo _enemyInfo;
        private float _distanceFromPlayer;
        private GameplayInfo _gameplayInfo;
        private int health;

        [Inject]
        private void Construct(IPlayer player, GameplayInfo gameplayInfo)
        {
            _player = player;
            _gameplayInfo = gameplayInfo;
        }

        private void Awake()
        {
            
        }

        public void Init(EnemyInfo enemyInfo)
        {
            _enemyInfo = enemyInfo;
            health = _enemyInfo.Health;
        }


        private void Update()
        {
             DistanceCheck();
            if (followPlayer)
            {
                FollowingPlayer();
            }

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                health -= 5;
                Instantiate(DamagePrefab, transform.position, Quaternion.identity);
            }
        }
        

        private void FollowingPlayer()
        {
            // transform.position = Vector3.MoveTowards(transform.position, _player.GetCurrentPosition(),
            //     Time.deltaTime * _enemyInfo.Speed);
            navMeshAgent.SetDestination(_player.GetCurrentPosition());
            
        }

        private void DistanceCheck()
        {
            _distanceFromPlayer = Vector3.Distance(_player.GetCurrentPosition(), transform.position);
            if (_distanceFromPlayer < _enemyInfo.FollowDistance)
            {
                followPlayer = true;
                if (Vector3.Distance(_player.GetCurrentPosition(), transform.position) < 1f)
                {
                    _gameplayInfo.EndGame.Value = true;
                }
            }
            else
            {
                followPlayer = false;
            }
        }


    }
}