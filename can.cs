using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can : MonoBehaviour
{
    public Sprite blank;
    public Sprite num2;
    public Sprite num4;
    public Sprite num8;
    public Sprite num16;
    public Sprite num32;
    public Sprite num64;
    public Sprite num128;
    public Sprite num256;
    public Sprite num512;
    public Sprite num1024;
    public Sprite num2048;

    List <Sprite> canlist = new List<Sprite>();
    int[] numarr = new int[11];

    private SpriteRenderer sp;
    int[] numbers = new int[] { 0, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };
    public int y;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        
        canlist.Add(blank);
        canlist.Add(num2);
        canlist.Add(num4);
        canlist.Add(num8);
        canlist.Add(num16);
        canlist.Add(num32);
        canlist.Add(num64);
        canlist.Add(num128);
        canlist.Add(num256);
        canlist.Add(num512);
        canlist.Add(num1024);
        canlist.Add(num2048);

    }
    int which(int num)
    {
        for (int i=0; i<12;i++)
        {
            if (num==numbers[i])
            {
                return i;
            }
        }
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        sp = GetComponent<SpriteRenderer>();
        int this_num = GameManager.Instance.board[y, x];
        sp.sprite = canlist[which(this_num)];
    }
}
