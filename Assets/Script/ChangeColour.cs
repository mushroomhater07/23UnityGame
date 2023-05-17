using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace script
{
    public class ChangeColour : MonoBehaviour
    {
        
        [SerializeField]private materialChoice _choice;
        private Material[] skin,skin_copy;
        private int CurrentBodypartindex = 0, CurrentColourIndex = 0; 
        private void Start()
        {
            skin_copy = GameObject.Find("Female").GetComponentInChildren<SkinnedMeshRenderer>().materials;
            skin = skin_copy;
        }

        public void NextBodyPart(bool forward)
        {
            if (forward) CurrentBodypartindex++;
            else CurrentBodypartindex--;
            CurrentBodypartindex %= 12;
            // Debug.Log("parts" + CurrentBodypartindex);
        }

        public void RunChangeColour(bool forward)
        {
            if (forward) CurrentColourIndex++;
            else CurrentColourIndex--;
            CurrentColourIndex %= _choice.objs.Count;
            int cbi = Mathf.Abs(CurrentBodypartindex), cci = Mathf.Abs(CurrentColourIndex);
            if (cbi >= 3) skin[cbi + 1] = _choice.objs[cci].obj;
            else skin[cbi] = _choice.objs[cci].obj;
            GameObject.Find("Female").GetComponentInChildren<SkinnedMeshRenderer>().materials = skin;
            // Debug.Log("colour" + _choice.objs[cci].obj);
        }
    }
}