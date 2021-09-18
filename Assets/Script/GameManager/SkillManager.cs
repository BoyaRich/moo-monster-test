using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkillManager : MonoBehaviour
{




    private void Update()
    {
        
    }

    public void LoadskillTeam(Transform monster , GameObject slot , int num)
    {

        int rand;
        rand = UnityEngine.Random.Range(0, monster.childCount);
        Debug.Log("Monster :" + rand); // someonerand
        InstaceSkill(Randomskill(monster.GetChild(rand).gameObject),monster.gameObject ,slot,num);

    }
    public Skill Randomskill(GameObject monster)
    {
        int rand;
        rand = UnityEngine.Random.Range(0, monster.GetComponent<SlotSkillOfMonster>().SkillMonster.Length);
        Debug.Log("SKILL :" + rand);
        monster.GetComponent<SlotSkillOfMonster>().SkillMonster[rand].GetComponent<Skill>().hostskill = monster;
        return monster.GetComponent<SlotSkillOfMonster>().SkillMonster[rand].GetComponent<Skill>();
    }
    public void InstaceSkill(Skill skill  ,GameObject monster , GameObject slot , int num)
    {
        UI_Canvas uislotpostion = GameObject.FindObjectOfType<UI_Canvas>();
        slot = Instantiate(skill.gameObject, uislotpostion.SkillSlot[num].position,Quaternion.identity);
        slot.transform.SetParent(uislotpostion.SkillSlot[num].transform);
    }

}
