using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameManagerObject;
    public GameObject companyNameObject;
    public GameObject employeeStateObject;
    public string employeeSpriteName;
    public GameObject companyBudgetObject;
    public string companyBudgetSpriteName;
    public GameObject companyCashFlowObject;
    public string positiveCashFlowSpriteName;
    public string NegativeCashFlowSpriteName;

    private const string CashFlowBase = "€/s";

    private GameManager _gameManager;

    private TextMeshProUGUI _companyNameText;
    private TextMeshProUGUI _employeeStateText;
    private TextMeshProUGUI _companyBudgetText;
    private TextMeshProUGUI _companyCashFlowText;

    private void Awake()
    {
        _gameManager = gameManagerObject.GetComponent<GameManager>();
        _companyNameText = companyNameObject.GetComponent<TextMeshProUGUI>();
        _employeeStateText = employeeStateObject.GetComponent<TextMeshProUGUI>();
        _companyBudgetText = companyBudgetObject.GetComponent<TextMeshProUGUI>();
        _companyCashFlowText = companyCashFlowObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCompanyName();
        SetEmployeeState();
        SetCompanyBudget();
        SetCompanyCashFlow();
    }

    private void SetCompanyName()
    {
        _companyNameText.text = _gameManager.CompanyName;
    }

    private void SetEmployeeState()
    {
        _employeeStateText.text =
            $"<sprite name='{employeeSpriteName}'> {_gameManager.UnAssignedEmployees} / {_gameManager.TotalEmployees}";
    }

    private void SetCompanyBudget()
    {
        _companyBudgetText.text = $"<sprite name='{companyBudgetSpriteName}'> {_gameManager.Budget}";
    }

    private void SetCompanyCashFlow()
    {
        var income = _gameManager.CashFlow;

        if (income >= 0)
        {
            _companyCashFlowText.text = $"<sprite name='{positiveCashFlowSpriteName}'> ";
        }
        else
        {
            _companyCashFlowText.text = $"<sprite name='{NegativeCashFlowSpriteName}'> ";
        }

        _companyCashFlowText.text += income + CashFlowBase;
    }
}
