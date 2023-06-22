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
        

        public void Init(EnemyInfo enemyInfo)
        {
            _enemyInfo = enemyInfo;
            health = _enemyInfo.Health;
        }


        private void Update()
        {
            followPlayer = true;
            DeathCheck();
            
            // DistanceCheck();
            if (followPlayer)
            {
                FollowingPlayer();
            }

            if (health <= 0)
            {
                _gameplayInfo.EnemyKilled.Value++;
                Destroy(this.gameObject);
            }
        }
        
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                health -= 5;
                Instantiate(DamagePrefab, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
        

        private void FollowingPlayer()
        {
            navMeshAgent.SetDestination(_player.GetCurrentPosition());
        }

        private void DistanceCheck()
        {
            _distanceFromPlayer = Vector3.Distance(_player.GetCurrentPosition(), transform.position);
            if (_distanceFromPlayer < _enemyInfo.FollowDistance)
            {
                followPlayer = true;
                //DeathCheck();
            }
            else
            {
                followPlayer = false;
            }
        }

        private void DeathCheck()
        {
            if (Vector3.Distance(_player.GetCurrentPosition(), transform.position) < 1.5f)
            {
                _gameplayInfo.EndGame.Value = true;
            }
        }
    }
}