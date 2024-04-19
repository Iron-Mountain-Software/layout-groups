using System;
using UnityEngine;

namespace IronMountain.LayoutGroups
{
    [Serializable]
    public struct PaddingFlags
    {
        [SerializeField] public bool left;
        [SerializeField] public bool right;
        [SerializeField] public bool top;
        [SerializeField] public bool bottom;
    }
}