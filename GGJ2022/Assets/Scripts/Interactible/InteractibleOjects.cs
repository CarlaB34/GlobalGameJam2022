using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractObjUtile", menuName = "ScriptableObjects/interactUtile")]
public class InteractibleOjects :ScriptableObject
{
    [SerializeField]
    private List<InteractibleObjectUtile> m_InteractObjUtile = new List<InteractibleObjectUtile>();

    public List<InteractibleObjectUtile> InteractObjUtile
    {
        get { return m_InteractObjUtile; }
    }
}

public enum InteractibleObjectUtile
{
    journal_intime,
    livre_dechirer,
    photo_papa,
    nothing
}