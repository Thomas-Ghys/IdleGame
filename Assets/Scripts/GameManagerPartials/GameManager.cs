using UnityEngine;

namespace GameManagerPartials
{
    public partial class GameManager : MonoBehaviour
    {
        private int _interval = 1;
        private float _nextTime = 0;

        void Start()
        {
            _companyName = "Test Company name";
            _assignedEmployees = 0;
            _unAssignedEmployees = 1;
            _totalEmployees = _assignedEmployees + _unAssignedEmployees;
            _budget = 0;
            _cashFlow = Random.Range(-1000000000, 10000000000);
        }

        void Update()
        {
            if (Time.time >= _nextTime)
            {
                RandomUpdateEmployees();
                UpdateBudget();
                _nextTime += _interval;
            }
        }

        private void RandomUpdateEmployees()
        {
            float randomChance = Random.value;
            if (0.5 < randomChance && randomChance < .6)
            {
                _assignedEmployees += 1;
            }
            else if (0.6 < randomChance && randomChance < .75)
            {
                _unAssignedEmployees += 1;
            }

            _totalEmployees = _assignedEmployees + _unAssignedEmployees;
        }

        private void UpdateBudget()
        {
            _budget += _cashFlow;
            _cashFlow = (double)Random.Range(-1000000000, 10000000000);
        }
    }
}
