using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source.Scripts
{
    public class ClickFactory : MonoBehaviour
    {
        [SerializeField] ClickBody[] _clickObjectPrefabs;
        [SerializeField] private Clicker _clicker;
        [SerializeField] private HitPointsUI _hitPointsUI;
        private ClickBody _clickBody;
        private ClickerStats _clickerStats;

        private void SelectNextClickObject()
        {
            int index = Random.Range(0, _clickObjectPrefabs.Length);
            _clickBody = _clickObjectPrefabs[index];
        }

        private void CreateClickObject()
        {
            SelectNextClickObject();
            ClickBody clickBody = Instantiate(_clickBody);
            clickBody.OnDestroyed += CreateClickObject;
            _hitPointsUI.SetClickBody(clickBody);
            _clicker.SetClickObject(clickBody);

            clickBody.SetClickerStats(_clickerStats);

            _clickerStats.AddDifficultyMultiplier(_clickerStats.DifficultyMultiplier * 0.1f);
        }

        public void StartFactory(ClickerStats clickerStats)
        {
            _clickerStats = clickerStats;
            CreateClickObject();
        }
    }
}