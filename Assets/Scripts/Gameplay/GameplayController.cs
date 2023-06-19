using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace root
{


    public class GameplayController : IInitializable, IDisposable
    {
        private  IPlayer _player;
        private  EnemyFactory _enemyFactory;
        private  GameplayInfo _gameplayInfo;
        private  InputHandler _inputHandler;
        private int count;
        
        [Inject]
        private void Construct(IPlayer player, GameplayInfo gameplayInfo, InputHandler inputHandler, 
            EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _gameplayInfo = gameplayInfo;
            _inputHandler = inputHandler;
            _player = player;
        }

        public void Initialize()
        {
            AddListeners();
            _inputHandler.OnClickedMove += OnClickedMove;
            _inputHandler.OnClickedShoot += OnClickedShoot;
            StartSpawn();
        }
        
        private void StartSpawn()
        {
           Observable.Timer(TimeSpan.FromSeconds(3)).Repeat().Subscribe(_ => _enemyFactory.Create());
        }



        private void AddListeners()
        {
            _gameplayInfo.EndGame.Subscribe(_ => UpdateInfo());
            _gameplayInfo.EnemyKilled.Subscribe(_ => UpdateInfo());
        }



        private void UpdateInfo()
        {
            if (_gameplayInfo.EndGame.Value || _gameplayInfo.EnemyKilled.Value >= _gameplayInfo.EnemyCount.Value) // 
            {
                EndGame();
            }
        }
        
        private void EndGame()
        {
            _inputHandler.OnClickedMove -= OnClickedMove;
            _inputHandler.OnClickedShoot -= OnClickedShoot;
            var particles = GameObject.FindGameObjectsWithTag("Particle");
            foreach (var particle in particles)
            {
                Object.Destroy(particle);
            }
            Time.timeScale = 0;
        }
        
        private void OnClickedMove(Vector3 pos)
        {
            _player.MoveTo(pos);
        }
        private void OnClickedShoot(Vector3 pos)
        {
            _player.Shoot(pos);
        }
        
        public void Dispose()
        {
            _inputHandler.OnClickedMove -= OnClickedMove;
            _inputHandler.OnClickedShoot -= OnClickedShoot;
        }
    }
}