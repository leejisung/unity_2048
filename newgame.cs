﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        GameManager.Instance.new_game();
    }
}