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
    public int[,] board = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
    public bool gameover = false;
    public int score;
    public void new_game()
    {
        score = 0;
        board = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        num_gen();
        num_gen();
    }
    public void num_gen()
    {
        int num_count = 0;
        List<int[]> zero_switch = new List<int[]>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i,j]==0)
                {
                    int[] ij = { i, j };
                    zero_switch.Add(ij);
                    num_count++;
                }
            }
        }
        if (num_count==0)
        {
            gameover = true;
            Debug.Log("gameover");
        }
        else
        {
            int num = Random.Range(1, 3) * 2;
            int s = Random.Range(0, num_count);
            int y = zero_switch[s][0];
            int x = zero_switch[s][1];
            board[y, x] = num;
        }

    }
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

    public bool arr_eq(int[,]copy, int[,]board)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i, j] != copy[i,j])
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void left_key()
    {
        int[,] copy = new int[4, 4]; 
        copy = board;
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
                score += num;
                score += num2;
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
                score += num;
            }
            else if (board[i, 1] == board[i, 2])
            {
                int num2 = board[i, 1] * 2;
                int num3 = board[i, 3];
                board[i, 1] = num2;
                board[i, 2] = num3;
                board[i, 3] = 0;
                score += num2;
            }
            else if (board[i, 2] == board[i, 3])
            {
                int num3 = board[i, 3] * 2;
                board[i, 2] = num3;
                board[i, 3] = 0;
                score += num3;
            }
        }
        if (arr_eq(copy,board)==false)
        {
            num_gen();
        }

        Debug.Log(score);

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

