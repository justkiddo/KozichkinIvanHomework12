using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace root
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMove playerObject;
        [SerializeField] private Camera _camera;
        [SerializeField] private List<EnemyInfo> enemyInfos;
        [SerializeField] private Bullet bullet;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().WithId(BaseIds.GameCameraId).FromInstance(_camera);
            Container.Bind<IUnityLocalization>().To<UnityLocalization>().AsSingle().NonLazy();
            Container.Bind<IPlayer>().FromInstance(playerObject);
            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameplayController>().AsSingle().NonLazy();
            Container.Bind<GameplayInfo>().AsSingle().NonLazy();
            Container.BindFactory<Enemy, EnemyFactory>();
            foreach (var enemyInfo in enemyInfos)
            {
                Container.Bind<EnemyInfo>().FromInstance(enemyInfo);
            }
            Container.Bind<Bullet>().FromInstance(bullet);
            
            
        }
    }
}
