using UniRx;

namespace root
{

    public class GameplayInfo
    {
        public ReactiveProperty<bool> EndGame { get; } = new BoolReactiveProperty(false);
        public ReactiveProperty<int> EnemyCount { get; } = new IntReactiveProperty(5);
        public ReactiveProperty<int> EnemyKilled { get; } = new IntReactiveProperty();
        
    }
}