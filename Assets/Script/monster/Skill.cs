using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Skill : MonoBehaviour
{
 
    public GameObject hostskill;

    [SerializeField] private Button mbutton;
    [SerializeField] private string debug;
    [SerializeField] private Text _text;
    [SerializeField] private int _gradeLevel;
    GameManager _gm;
    public int GredeLevel { get { return _gradeLevel; }  }
    public Color activeSkillColor;
    public Color LockSkillColor;
    private void Awake()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
        _text.text = GredeLevel.ToString();
    }
    public void ActiveSkill()
    {
  
        Debug.Log(debug);
        _gm.DiscutGradeLevel(_gradeLevel);
        Destroy(gameObject);
      
    }
    public void ActiveButtom(int Grade)
    {
        if (Grade == _gradeLevel)
        {
            mbutton.enabled = true;
        }
        else { mbutton.enabled = false; }
       
        
    }
    private void Update()
    {
        ActiveButtom(_gm.gradeLevel);
    }
}
