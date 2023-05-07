using System;
using UI.DevPage.PageEnums;
using UnityEngine;

namespace Domain.Common.DevPagesRecords
{
    [Serializable]
    public struct RunningProjectsPageRecord
    {
        public RunningProjectsPages Name;
        public GameObject GameObject;
    }
}