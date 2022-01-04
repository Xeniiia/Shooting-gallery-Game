using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;
using Model.Spawner;

namespace Model.Targets
{
    public class Target : MonoBehaviour, ITarget
    {
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        private float _speed;
        public UnityEvent EdgeTouched { get; private set; }
        public UnityEvent Clicked { get; private set; }
        protected Tweener _moveTween;
        private SpriteRenderer _spriteRenderer;

        void Awake()
        {
            _speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
            EdgeTouched = new UnityEvent();
            Clicked = new UnityEvent();
            //_spriteRenderer = GetComponentInChildren<SpriteRenderer>() ?? throw new NullReferenceException();
            _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>() ?? throw new NullReferenceException();
        }

        private void Start()
        {
            Clicked.AddListener(Dead);
        }

        public void Move(Vector3 pos)
        {
            _spriteRenderer.flipX = pos.x < 0f;
            _moveTween = transform.DOMove(pos, _speed, false);
            _moveTween.OnComplete(() =>
            {
                EdgeTouched.Invoke();
                Dispose();
            });
        }

        private void OnMouseDown()
        {
            Clicked.Invoke();
        }

        protected virtual void Dead()
        {
            _moveTween.Pause();
            transform.DOScaleY(0, 1).OnComplete(Dispose);
        }

        protected void Dispose()
        {
            EdgeTouched.RemoveAllListeners();
            Clicked.RemoveAllListeners();
            _moveTween.Kill();
            Destroy(gameObject);
        }

    }
}
