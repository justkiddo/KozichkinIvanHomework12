using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace root
{


    public class EnemyFactory : PlaceholderFactory<Enemy>
    {
        private DiContainer _diContainer;
        private List<EnemyInfo> _enemyInfos;


        public EnemyFactory(DiContainer diContainer, List<EnemyInfo> enemyInfos)
        {
            _diContainer = diContainer;
            _enemyInfos = enemyInfos;
        }

        public override Enemy Create()
        {
            var enemyInfo = _enemyInfos[Random.Range(0, _enemyInfos.Count)];
            var enemy = Object.Instantiate(enemyInfo.Prefab).GetComponent<Enemy>();
            enemy.Init(enemyInfo);
            _diContainer.Inject(enemy);
            return enemy;
        }
    }
}