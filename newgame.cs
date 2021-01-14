using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newgame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Reset_board()
    {
        GameManager.Instance.new_game();
    }
}
