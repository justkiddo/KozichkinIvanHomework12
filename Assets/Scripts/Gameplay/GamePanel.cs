using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace root
{

    public class GamePanel : MonoBehaviour, IInitializable
    {
        [SerializeField] private TextMeshProUGUI enemyCounterPanel;
        [SerializeField] private Button button;
        private GameplayInfo _gameplayInfo;
        private CompositeDisposable _disposable;
        private IUnityLocalization _localization;

        [Inject]
        private void Construct(GameplayInfo gameplayInfo, IUnityLocalization localization)
        {
            _localization = localization;
            _gameplayInfo = gameplayInfo;
        }
        

        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            AddListeners();
        }

        private void AddListeners()
        {
          button.onClick.AsObservable().Subscribe(_ => OnButtonCLick()).AddTo(_disposable);
        }

        private void UpdateInfo()
        {
        }

        private void OnButtonCLick()
        {
         //   enemyCounterPanel.text = "Clicked ";
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}