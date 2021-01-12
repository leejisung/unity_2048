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

