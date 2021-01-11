using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardmaker : MonoBehaviour
{
    public GameObject can;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                GameObject cell = Instantiate(can, new Vector3(x, -y, 0), Quaternion.identity);
                cell.GetComponent<can>().x = x;
                cell.GetComponent<can>().y = y;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
