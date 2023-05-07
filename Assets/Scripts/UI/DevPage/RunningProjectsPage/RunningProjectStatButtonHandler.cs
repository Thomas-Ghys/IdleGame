using Domain.Projects;
using Domain.Projects.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.DevPage.RunningProjectsPage
{
    public class RunningProjectStatButtonHandler : MonoBehaviour, IButtonInfoHandler
    {
        [SerializeField] private TextMeshProUGUI progressText;
        [SerializeField] private TextMeshProUGUI text;

        private ProjectStat _buttonInfo;
        private Button _button;

        public IButtonInfo ButtonInfo
        {
            get => _buttonInfo;
            private set
            {
                _buttonInfo = value as ProjectStat;
                SetButtonAttributes();
            }
        }

        private void SetButtonAttributes()
        {
        }

        public void Initialize(IButtonInfo buttonInfo)
        {
            ButtonInfo = buttonInfo as ProjectStat;
            text.text = _buttonInfo.Name;
            progressText.text = _buttonInfo.Value.ToString();
        }
    }
}