using UnityEngine;

[CreateAssetMenu(fileName = "npcdata", menuName = "npc/talkdata")]
public class Npcdata : ScriptableObject
{
    [Header("talk1"), TextArea(1, 5)]
    public string ntalk1;
    [Header("talk2"), TextArea(1, 5)]
    public string ntalk2;
    [Header("talk3"), TextArea(1, 5)]
    public string ntalk3;

    [Header("need num")]
    public int num;
    public int neednum;
}
