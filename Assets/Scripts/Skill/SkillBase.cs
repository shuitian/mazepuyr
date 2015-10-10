using UnityEngine;
using System.Collections;

public class SkillBase : MonoBehaviour {

    public int skillNumber;
    public GameObject skillPrefab;

    public virtual  bool addSkill(BaseStatement statement)
    {
        return false;
    }
}
