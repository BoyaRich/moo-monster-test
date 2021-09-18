using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleField : MonoBehaviour
{

    [SerializeField] private Transform PlayerField;
    [SerializeField] private Transform NpcField;
    [SerializeField] private Transform PlayerMonsterGroup;
    [SerializeField] private Transform NpcMonsterGroup;
    [SerializeField] private Vector3[] _playerMonsterPostion;
    [SerializeField] private Vector3[] _npcMonsterPosition;
    [SerializeField] private UI_Canvas _UICanvasManager;
    [SerializeField] private GameObject[] PlayerMonster;
    [SerializeField] private GameObject[] NpcMonster;
    [SerializeField] private SkillManager _SkillManager;
    [SerializeField] private GameObject[] slotskill;

    void Start()
    {
        _SkillManager = GameObject.FindObjectOfType<SkillManager>();
        _UICanvasManager = GameObject.FindObjectOfType<UI_Canvas>();
        slotskill = new GameObject[_UICanvasManager.SkillSlot.Length];
        GameManager gm = GameObject.FindObjectOfType<GameManager>();
        SetFieldPosition();
        SpawnMonsterOnPosition(gm.PlayerMonster,true,gm); //bool enum 
        SpawnMonsterOnPosition(gm.NpcMonster, false,gm); //bool enum
        SkillGenerate();
        
    }
    public void SkillGenerate()
    {
        for (int i = 0; i < slotskill.Length; i++)
        {
            if (slotskill[i] == null)
            {
                _SkillManager.LoadskillTeam(PlayerMonsterGroup,slotskill[i],i);
            }
        }
       
    }
    private void Update()
    {
      //  SkillGenerate();
    }

    public void SetFieldPosition()
    {
        _playerMonsterPostion = new Vector3[PlayerField.childCount];
        for (int i = 0; i < PlayerField.childCount; i++)
        {
            _playerMonsterPostion[i] = PlayerField.GetChild(i).transform.position;
          
        }
        
        _npcMonsterPosition = new Vector3[PlayerField.childCount];
        for (int i = 0; i < NpcField.childCount; i++)
        {
            _npcMonsterPosition[i] = NpcField.GetChild(i).transform.position;
        }
    }

    public void SpawnMonsterOnPosition(GameObject[] monster , bool Side,GameManager getClone)
    {
        if (Side)
        {
            PlayerMonster = new GameObject[monster.Length];
            getClone.PlayermonsterClone = new GameObject[monster.Length];
             for (int i = 0; i < monster.Length; i++)
             {
                 if (monster[i] != null)
                 {
                    PlayerMonster[i] =   Instantiate(monster[i],_playerMonsterPostion[i],Quaternion.identity);
                    PlayerMonster[i].transform.SetParent(PlayerMonsterGroup);
                    GameObject hpbar = Instantiate(_UICanvasManager.Hpbar);
                    hpbar.transform.SetParent(PlayerMonster[i].transform);
                    getClone.PlayermonsterClone[i] = PlayerMonster[i];
              
                 }
          
             }
        }
        if (!Side)
        {
            NpcMonster = new GameObject[monster.Length];
            getClone.NpcmonsterClone = new GameObject[monster.Length];
            for (int i = 0; i < monster.Length; i++)
            {
                if (monster[i] != null)
                {
                    NpcMonster[i] =  Instantiate(monster[i], _npcMonsterPosition[i], Quaternion.identity);
                    NpcMonster[i].transform.SetParent(NpcMonsterGroup);
                    GameObject hpbar = Instantiate(_UICanvasManager.Hpbar);
                    hpbar.transform.SetParent(NpcMonster[i].transform);
                    getClone.NpcmonsterClone[i] = NpcMonster[i];

                }

            }
        }
       
        
    }
}
