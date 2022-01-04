using DG.Tweening;

namespace Model.Targets
{
    public class BonusTarget : Target
    {
        protected override void Dead()
        {
            _moveTween.Pause();
            transform.DOScale(1.4f, 0.2f).OnComplete(Dispose);
        }
    }
}
