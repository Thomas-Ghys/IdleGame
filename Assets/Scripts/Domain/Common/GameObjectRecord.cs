using System;
using UI.DevPage;
using UnityEngine;

namespace Domain.Common
{
    [Serializable]
    public struct GameObjectRecord
    {
        public DevPages Name;
        public GameObject GameObject;
    }
}