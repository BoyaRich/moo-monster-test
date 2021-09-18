using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] PlayerMonster;
    public GameObject[] PlayermonsterClone;

    public GameObject[] NpcMonster;
    public GameObject[] NpcmonsterClone;
    UI_Canvas _UICanvas;

    [Header("Time_Setting")]
    public float ClockTime = 120f; // 2 min
    float _counttime;


    int maxGradelevel = 5;

    public int gradeLevel;
    float _gradepower;
 

    public int monsterofplayer { get; set; }
    public int monsterofnpc { get; set; }
    private void Awake()
    {
        monsterofplayer = PlayerMonster.Length;
        monsterofnpc = NpcMonster.Length;
    }
    void Start()
    {
        _UICanvas = GameObject.FindObjectOfType<UI_Canvas>();
        _counttime = ClockTime;
    }

    // Update is called once per frame
    void Update()
    {
        Fight();
        GradePowerUpdate();
        DisplayTimecalculate();
        EndGame();
     
    }

    public void GradePowerUpdate()
    {
        if (gradeLevel != maxGradelevel)
        {
              _gradepower += Time.deltaTime * 5f;
             _UICanvas.GradeSlice.value = _gradepower;
        }
        if (_gradepower>=100)
        {
            _gradepower = 0;
            gradeLevel++;
            _UICanvas.GradeLevel.text = gradeLevel.ToString();
        }
    }
    public void DiscutGradeLevel(int value)
    {
        gradeLevel -= value;
        _UICanvas.GradeLevel.text = gradeLevel.ToString();
        Debug.Log(gradeLevel);
    }

    public void Fight()
    {
        Debug.Log("Fight state");
    }
    public void DisplayTimecalculate()
    {
        _counttime -= Time.deltaTime * 1;
        float minutes = Mathf.FloorToInt(_counttime / 60);
        float seconds = Mathf.FloorToInt(_counttime % 60);

        _UICanvas._timecount.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    public void EndGame()
    {
        if (_counttime <= 0)
        {
            Debug.Log("Player Lose");
        }

        foreach (GameObject playergroup in PlayermonsterClone)
        {
            if (playergroup == null)
            {
                Debug.Log("Player Lose");
            }
        }
        foreach (GameObject Npcmonstergroup in NpcmonsterClone)
        {
            if (Npcmonstergroup == null)
            {
                Debug.Log("Player Win");
            }

        }
        
        
    }
  
}
