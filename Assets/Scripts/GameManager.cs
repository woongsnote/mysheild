using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject square;
    public GameObject gameOverTxt;

    public Text timeTxt;
    float aliveTime = 0.0f;

    public static GameManager I;

    public Animator anim;

    public GameObject balloon;

     void Awake()
    { 
        I= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(MakeSquare), 0.0f, 0.5f);
        
    }

    void MakeSquare() { 
        Instantiate(square);
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime += Time.deltaTime;    
        timeTxt.text = aliveTime.ToString("N2");

    }


    public void GameOver() 
    {
        anim.SetBool("isDie",true);
        gameOverTxt.SetActive(true);
        Invoke(nameof(Death), 0.5f);
    }

    void Death()
    {
        Time.timeScale = 0.0f;
        Destroy(balloon);
    }
}
