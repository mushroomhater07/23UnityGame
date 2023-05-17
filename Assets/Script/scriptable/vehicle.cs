using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace script
{
    [CreateAssetMenu(fileName = "Vehicle", menuName = "vehicleItem", order = 0)]
    public class vehicle : ScriptableObject
    {
        public List<vehicleSingle> obj = new List<vehicleSingle>();
    }

    [Serializable]
    public class vehicleSingle
    {
        public string name;
        public GameObject obj;
        
    }
}