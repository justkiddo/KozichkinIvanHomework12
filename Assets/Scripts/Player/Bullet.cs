

using System;
using UnityEngine;
using Zenject;

namespace root
{


    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        private GameplayInfo _gameplayInfo;
        private EnemyInfo _enemyInfo;
        private Enemy _enemy;



        [Inject]
        private void Construct(GameplayInfo gameplayInfo, EnemyInfo enemyInfo, Enemy enemy)
        {
            _enemy = enemy;
            _enemyInfo = enemyInfo;
            _gameplayInfo = gameplayInfo;
        }




    }
}