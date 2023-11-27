using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotAmmo : MonoBehaviour
{
    [SerializeField] private ShotRubber _shotPoint;
    [SerializeField] private BirdsFactory _birdFactory;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _delay;
    [SerializeField] private int _maxAmmo;
    private int _currentAmmo;

    private void Awake()
    {
        _currentAmmo = _maxAmmo;
        NextBird();
        _shotPoint.OnShoot += NextBird;
    }
    private void NextBird() 
    {
        if (_currentAmmo <= 0)
            return;
        _currentAmmo--;
        StartCoroutine(ReloadDelay());
    }

    private void CreateBird()
    {
        Bird newBird = _birdFactory.CreateBird(_spawnPosition.position);
        newBird.Setup(_shotPoint.transform, _spawnPosition.position);
        _shotPoint.UpdateBird(newBird);
    }

    private IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(_delay);
        CreateBird();
    }
}
