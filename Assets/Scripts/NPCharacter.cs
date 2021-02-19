using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCharacter : MonoBehaviour
{
    public string nickname = "gordon";
    public int maxHealth = 100;
    public Color colour = Color.blue;
    [HideInInspector]
    public NPCMoveController npcMove;
    [HideInInspector]
    public Rigidbody rb;

}
