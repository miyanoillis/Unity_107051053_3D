using UnityEngine;
using UnityEngine.UI;

public class npc : MonoBehaviour
{
    [Header("NPCdata")]
    public Npcdata data;
    [Header("NPCword")]
    public GameObject word;
    public Text text;

    public bool playerin;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "free_male_1")
        {
            playerin = true;
            word.SetActive(true);
            talk();
        }
        else
        {
            playerin = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "free_male_1")
        {
            playerin = false;
        }
    }

    private void talk ()
    {
        for (int i = 0; i < data.ntalk1.Length; i++)
        {
            print(data.ntalk1[i]);
        }       
    }
}
