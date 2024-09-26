using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ammo : MonoBehaviour
{
    [SerializeField] private TMP_Text EggCountText;
    // Start is called before the first frame update
    void Start()
    {
        EggCountText.text = "24";
    }

    public void UpdateEggCount(int EggAmmo)
    {
        EggCountText.text = "" + EggAmmo;
    }
}
