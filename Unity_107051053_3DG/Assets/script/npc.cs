using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class npc : MonoBehaviour
{
    [Header("NPCdata")]
    public Npcdata data;
    [Header("NPCword")]
    public GameObject word;
    public Text text;

    public bool playerin;
    public float sc = 0.31f;

    public enum Nstate
    {
        mision,inmision,outmision
    }
    public Nstate state = Nstate.mision;



private void OnTriggerEnter(Collider other)
    {
        if(other.name == "free_male_1")
        {
            playerin = true;
            StartCoroutine(talk());
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "free_male_1")
        {
            playerin = false;
            stoptalk();
        }
    }

    private void stoptalk()
    {
        word.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator talk ()
    {
        string nstring = data.ntalk1;

        switch (state)
        {
            case Nstate.mision:
                nstring = data.ntalk1;
                break;
            case Nstate.inmision:
                nstring = data.ntalk2;
                break;
            case Nstate.outmision:
                nstring = data.ntalk3;
                break;
        }

        text.text = "";
        word.SetActive(true);
        for (int i = 0; i < nstring.Length; i++)
        {
            yield return new WaitForSeconds(sc);
            text.text += nstring[i];
        }       
    }
}
