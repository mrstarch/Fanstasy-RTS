using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Knight : GamePiece
{
    // Start is called before the first frame update
    void Start()
    {
        _health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Health.GetComponent<TextMeshProUGUI>().text = "HP " + _health;
    }
}
