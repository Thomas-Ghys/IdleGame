using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager
{
    public string getCompanyName()
    {
        return companyName;
    }

    public int getUnAssignedEmployeesNumber()
    {
        return unAssignedEmployees;
    }

    public int getTotalEmployeesNumber()
    {
        return TotalEmployees;
    }

    public double getCompanyBudget()
    {
        return budget;
    }

    public double getCashFlow()
    {
        return cashFlow;
    }
}
