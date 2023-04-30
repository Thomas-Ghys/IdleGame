using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject companyName;
    public GameObject employeeState;
    public string employeeSpriteName;
    public GameObject companyBudget;
    public string companyBudgetSpriteName;
    public GameObject companyCashFlow;
    public string positiveCashFlowSpriteName;
    public string NegativeCashFlowSpriteName;
    private string cashFlowBase = "€/s";



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setCompanyName();
        setEmployeeState();
        setCompanyBudget();
        setCompanyCashFlow();
    }

    private void setCompanyName()
    {
        companyName.GetComponent<TMPro.TextMeshProUGUI>().text = gameManager.GetComponent<GameManager>().getCompanyName();

    }

    private void setEmployeeState()
    {
        employeeState.GetComponent<TMPro.TextMeshProUGUI>().text = $"<sprite name='{employeeSpriteName}'> " +
            gameManager.GetComponent<GameManager>().getUnAssignedEmployeesNumber() +
            "/" + 
            gameManager.GetComponent<GameManager>().getTotalEmployeesNumber();
    }

    private void setCompanyBudget()
    {
        companyBudget.GetComponent<TMPro.TextMeshProUGUI>().text = $"<sprite name='{companyBudgetSpriteName}'> " + 
            gameManager.GetComponent<GameManager>().getCompanyBudget();
    }

    private void setCompanyCashFlow()
    {
        double income = gameManager.GetComponent<GameManager>().getCashFlow();

        if (income >= 0)
        {
            companyCashFlow.GetComponent<TMPro.TextMeshProUGUI>().text = $"<sprite name='{positiveCashFlowSpriteName}'> ";
        }
        else
        {
            companyCashFlow.GetComponent<TMPro.TextMeshProUGUI>().text = $"<sprite name='{NegativeCashFlowSpriteName}'> ";
        }

        companyCashFlow.GetComponent<TMPro.TextMeshProUGUI>().text += income + cashFlowBase;
    }
}
