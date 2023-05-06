using System;
using UI.DevPage.PageEnums;
using UnityEngine;

namespace Domain.Common.DevPagesRecords
{
    [Serializable]
    public struct DevPageRecord
    {
        public DevPages Name;
        public GameObject GameObject;
    }
}