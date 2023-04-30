using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    int interval = 1;
    float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        companyName = "Test Company name";
        assignedEmployees = 0;
        unAssignedEmployees = 1;
        TotalEmployees = assignedEmployees + unAssignedEmployees;
        budget = 0;
        cashFlow = Random.Range(-1000000000, 10000000000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            randomUpdateEmployees();
            updateBudget();
            nextTime += interval;
        }
        
    }

    private void randomUpdateEmployees()
    {
        float randomChance = Random.value;
        if (0.5 < randomChance && randomChance < .6)
        {
            assignedEmployees += 1;
        } else if (0.6 < randomChance && randomChance < .75)
        {
            unAssignedEmployees += 1;
        }
        TotalEmployees = assignedEmployees + unAssignedEmployees;
    }

    private void updateBudget()
    {
        budget = budget + cashFlow;
        cashFlow = (double)Random.Range(-1000000000, 10000000000);
    }
}
