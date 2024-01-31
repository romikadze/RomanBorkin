using UnityEngine;
using UnityEngine.AI;

namespace Source.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Navigation : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    _navMeshAgent.SetDestination(hit.point);
                }
            }
        }
    }
}
