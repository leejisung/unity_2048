using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //  Singleton Instance 선언
    private static GameManager instance = null;

    // Singleton Instance에 접근하기 위한 프로퍼티


    // GameManager 에서 사용 하는 데이터
    public bool isPause = false;
    public int[,] board = new int[4, 4] { { 2, 2, 2, 2 }, { 4, 2, 2, 2 }, { 8, 8, 16, 0 }, { 16, 0, 4, 4 } };
    public void row_reverse()
    {
        int[,] change = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                change[i, j] = board[i, 3 - j];
            }
        }
        board = change;
    }
    public void loc_reverse()
    {
        int[,] change = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                change[i, j] = board[j, i];
            }
        }
        board = change;
    }
    public void left_key()
    {
        int[,] change = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        for (int i = 0; i < 4; i++)
        {
            int xx = 0;
            for (int j = 0; j < 4; j++)
            {
                if (board[i, j] != 0)
                {
                    change[i, xx] = board[i, j];
                    xx += 1;
                }
            }
        }
        board = change;
        for (int i = 0; i < 4; i++)
        {
            if (board[i, 0] == board[i, 1] &&
                board[i, 2] == board[i, 3])
            {
                int num = board[i, 0] * 2;
                int num2 = board[i, 2] * 2;
                board[i, 0] = num;
                board[i, 1] = num2;
                board[i, 2] = 0;
                board[i, 3] = 0;
            }
            else if (board[i, 0] == board[i, 1])
            {
                int num = board[i, 0] * 2;
                int num2 = board[i, 2];
                int num3 = board[i, 3];
                board[i, 0] = num;
                board[i, 1] = num2;
                board[i, 2] = num3;
                board[i, 3] = 0;
            }
            else if (board[i, 1] == board[i, 2])
            {
                int num2 = board[i, 1] * 2;
                int num3 = board[i, 3];
                board[i, 1] = num2;
                board[i, 2] = num3;
                board[i, 3] = 0;
            }
            else if (board[i, 2] == board[i, 3])
            {
                int num3 = board[i, 3] * 2;
                board[i, 2] = num3;
                board[i, 3] = 0;
            }
        }
    }
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        // Scene에 이미 인스턴스가 존재 하는지 확인 후 처리
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

