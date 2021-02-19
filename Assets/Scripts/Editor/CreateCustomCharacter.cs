using System;
using UnityEditor;
using UnityEngine;

public class CreateCustomCharacter : ScriptableWizard
{
    public string nickname = "default";
    public int maxHealth = 100;
    public Color colour = Color.blue;

    [MenuItem("/My Tools/Create NPC")]
    public static void CreateWizard()
    {
        DisplayWizard<CreateCustomCharacter>("Create Custom NPC", "Add New","Update Selected");
    }

    public void OnWizardCreate()
    {
        GameObject npcGO = new GameObject();
        npcGO.name = "NPC";
        NPCMoveController npcMove = npcGO.AddComponent<NPCMoveController>();
        NPCharacter npCharacter = npcGO.AddComponent<NPCharacter>();
        npCharacter.colour = colour;
        npCharacter.maxHealth = maxHealth;
        npCharacter.nickname = nickname;
        npCharacter.npcMove = npcMove;
        Rigidbody rb = npcGO.AddComponent<Rigidbody>();
        rb.useGravity = false;
        npCharacter.rb = rb;
    }

    private void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            NPCharacter npCharacter = Selection.activeTransform.GetComponent<NPCharacter>();
            if (npCharacter != null)
            {
                npCharacter.colour = colour;
                npCharacter.maxHealth = maxHealth;
                npCharacter.nickname = nickname;
            }
        }
    }

    public void OnWizardUpdate()
    {
    }
}