using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CargarBackrooms : MonoBehaviour
{
    public TextMeshProUGUI toysRemaining;
    int muñecos = 0;
    string numMuñecos = "";

    void Start()
    {
        PlayerPrefs.SetInt("2DCompletado", 0);

        PlayerPrefs.SetInt("MuñecosObtenidos", 0);
        toysRemaining.text = "0/5";
    }

    void Update()
    {
        muñecos = PlayerPrefs.GetInt("MuñecosObtenidos");
        if(muñecos >= 5)
        {
            toysRemaining.color = Color.green;
        }
        numMuñecos = muñecos.ToString();
        toysRemaining.text = numMuñecos +"/5";
    }
}
