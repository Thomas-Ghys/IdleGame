using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ClassExtension
    {
        public static IEnumerable<GameObject> GetAllChildren(this GameObject gameObject)
        {
            var list = new List<GameObject>();
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                list.Add(gameObject.transform.GetChild(i).gameObject);
            }

            return list;
        }
    }
}