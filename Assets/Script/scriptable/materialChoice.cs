using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace script
{
    [CreateAssetMenu(fileName = "materials", menuName = "materialOption", order = 0)]
    public class materialChoice : ScriptableObject
    { 
        public List<materialSingle> objs = new List<materialSingle>();
    }

    [Serializable]
    public class materialSingle
    {
        public bool eye;
        public string name;
        public Material obj;
    }
}