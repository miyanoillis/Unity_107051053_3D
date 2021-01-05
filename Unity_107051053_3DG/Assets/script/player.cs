using UnityEngine;
using Invector.vCharacterController;

public class player : MonoBehaviour
{
    public int hp = 10;
    public Animator pani;

    private void Awake()
    {
        pani = GetComponent<Animator>();
    }

    public void dmg()
    {
        hp -= 5;
        pani.SetTrigger("hrt");

        if(hp <= 0)
        {
            die();
        }

    }
    public void die()
    {
        pani.SetTrigger("die");
        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
            vt.lockRotation = true;

    }
}
