using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.Scripts
{
    public class Clicker : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private ClickBody _clickBody;
        private ClickerStats _clickerStats;
        private Coroutine AutoClicker;
        
        private void OnDisable()
        {
            if (AutoClicker != null)
            {
                StopCoroutine(AutoClicker);
            }
        }

        private IEnumerator AutoClickerTick()
        {
            while (true)
            {
                _clickerStats.AddMoney(_clickBody.Damage(_clickerStats.DamagePerSecond));
                yield return new WaitForSeconds(1);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _clickerStats.AddMoney(_clickBody.Damage(_clickerStats.DamagePerClick));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _clickBody.EndClick();
        }

        public void SetClickObject(ClickBody clickBody)
        {
            _clickBody = clickBody;
        }

        public void StartClicker(ClickerStats clickerStats)
        {
            _clickerStats = clickerStats;
            AutoClicker = StartCoroutine(AutoClickerTick());
        }
    }
}