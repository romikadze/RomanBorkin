using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Bird : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private protected float _damageMultiplier;
    private protected Rigidbody2D _rigidbody2D;

    private protected bool _isCanUseAbility;
    
    private bool _isLaunched;
    

    public Action OnReadyToLaunch;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true;
    }

    private void Update()
    {
        if (!_isLaunched)
        {
            transform.position = _shotPoint.position;
        }

        if (_isCanUseAbility && Input.GetKeyDown(KeyCode.Space))
        {
            UseAbility();
        }
    }

    public void Setup(Transform shotPoint, Vector2 startPosition)
    {
        _shotPoint = shotPoint;
        transform.DOJump(shotPoint.position, 1, 1, 1).OnComplete(() =>
        {
            OnReadyToLaunch?.Invoke();
        });
    }

    public void Launch(Vector2 direction)
    {
        _isLaunched = true;
        _isCanUseAbility = true;
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
        Destroy(gameObject, 10);
    }


    private protected abstract void UseAbility();

}
