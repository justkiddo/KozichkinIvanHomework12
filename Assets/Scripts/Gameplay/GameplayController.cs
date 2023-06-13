using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

namespace root
{


    public class GameplayController : IInitializable, IDisposable
    {
        private  IPlayer _player;
        private  EnemyFactory _enemyFactory;
        private  GameplayInfo _gameplayInfo;
        private  InputHandler _inputHandler;

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
            _gameplayInfo.EndGame.Value = false;
            _enemyFactory.Create();
        }
        
        private void AddListeners()
        {
            _gameplayInfo.EndGame.Subscribe(_ => UpdateInfo());
            
        }
        private void UpdateInfo()
        {
            if (_gameplayInfo.EndGame.Value)
            {
                EndGame();
            }
        }
        private void EndGame()
        {
            _gameplayInfo.EndGame.Value = true;
            Time.timeScale = 0;
        }
        
        private void OnClickedMove(Vector3 pos)
        {
            _player.MoveTo(pos);
        }
        private void OnClickedShoot()
        {
            _player.Shoot();
        }
        
        public void Dispose()
        {
            _inputHandler.OnClickedMove -= OnClickedMove;
            _inputHandler.OnClickedShoot -= OnClickedShoot;
        }
    }
}