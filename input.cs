using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameManager.Instance.left_key();
            
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameManager.Instance.row_reverse();
            GameManager.Instance.left_key();
            GameManager.Instance.row_reverse();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameManager.Instance.loc_reverse();
            GameManager.Instance.left_key();
            GameManager.Instance.loc_reverse();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameManager.Instance.loc_reverse();
            GameManager.Instance.row_reverse();
            GameManager.Instance.left_key();
            GameManager.Instance.row_reverse();
            GameManager.Instance.loc_reverse();
        }
    }
}
