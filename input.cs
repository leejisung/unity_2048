using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    void row_reverse()
    {
        int[,] change = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                change[i, j] = GameManager.Instance.board[i, 3 - j];
            }
        }
        GameManager.Instance.board = change;
    }
    void loc_reverse()
    {
        int[,] change = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                change[i, j] = GameManager.Instance.board[j,i];
            }
        }
        GameManager.Instance.board = change;
    }
    void left_key()
    {
        int[,] change = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        for (int i = 0; i < 4; i++)
        {
            int xx = 0;
            for (int j = 0; j < 4; j++)
            {
                if (GameManager.Instance.board[i,j]!=0)
                {
                    change[i, xx] = GameManager.Instance.board[i, j];
                    xx += 1;
                }
            }
        }
        GameManager.Instance.board = change;
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.Instance.board[i, 0] == GameManager.Instance.board[i, 1] &&
                GameManager.Instance.board[i, 2] == GameManager.Instance.board[i, 3])
            {
                int num = GameManager.Instance.board[i, 0] * 2;
                int num2 = GameManager.Instance.board[i, 2] * 2;
                GameManager.Instance.board[i, 0] = num;
                GameManager.Instance.board[i, 1] = num2;
                GameManager.Instance.board[i, 2] = 0;
                GameManager.Instance.board[i, 3] = 0;
            }
            else if (GameManager.Instance.board[i, 0] == GameManager.Instance.board[i, 1])
            {
                int num = GameManager.Instance.board[i, 0] * 2;
                int num2 = GameManager.Instance.board[i, 2];
                int num3 = GameManager.Instance.board[i, 3];
                GameManager.Instance.board[i, 0] = num;
                GameManager.Instance.board[i, 1] = num2;
                GameManager.Instance.board[i, 2] = num3;
                GameManager.Instance.board[i, 3] = 0;
            }
            else if (GameManager.Instance.board[i, 1] == GameManager.Instance.board[i, 2])
            {
                int num2 = GameManager.Instance.board[i, 1] * 2;
                int num3 = GameManager.Instance.board[i, 3];
                GameManager.Instance.board[i, 1] = num2;
                GameManager.Instance.board[i, 2] = num3;
                GameManager.Instance.board[i, 3] = 0;
            }
            else if (GameManager.Instance.board[i, 2] == GameManager.Instance.board[i, 3])
            {
                int num3 = GameManager.Instance.board[i, 3] * 2;
                GameManager.Instance.board[i, 2] = num3;
                GameManager.Instance.board[i, 3] = 0;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left_key();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            row_reverse();
            left_key();
            row_reverse();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            loc_reverse();
            left_key();
            loc_reverse();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            loc_reverse();
            row_reverse();
            left_key();
            row_reverse();
            loc_reverse();
        }
    }
}
