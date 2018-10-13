using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UGUIExtensions{


    public static void SetActive(this UIBehaviour self, bool value)
    {
        self.gameObject.SetActive(value);
    }

}
