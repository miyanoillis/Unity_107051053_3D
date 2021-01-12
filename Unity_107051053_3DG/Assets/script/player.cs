using UnityEngine;
using Invector.vCharacterController;

public class player : MonoBehaviour
{
    public float hp = 10;
    public Animator pani;
    private int atkcount;

    private float timer;
    [Header("combo"), Range(0, 5)]
    public float combo = 1;

    [Header("distance"), Range(0f, 5f)]
    public float atkln;
    public Transform atkpt;
    private RaycastHit rhit;
    [Header("ATK"), Range(0f, 5f)]
    public float atk = 5;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(atkpt.position, atkpt.forward * atkln);
    }


    private void Awake()
    {
        pani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hp > 0)
        {
            attack();
        }

    }

    public void attack()
    {
        if (atkcount < 4)
        {
            if (timer < combo)
            {
                timer += Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    atkcount++;
                    timer = 0;
                    pani.SetInteger("atk", atkcount);
                    if (Physics.Raycast(atkpt.position, atkpt.forward, out rhit, atkln, 1 << 9))
                    {
                        rhit.collider.GetComponent<enmy>().dmg(atk);
                    }

                }
            }
            else
            {
                timer = 0;
                atkcount = 0;
            }
        }

        if (atkcount == 4)
        {
            atkcount = 0;
        }
            pani.SetInteger("atk", atkcount);
    }

    public void dmg(float damage)
    {
        hp -= damage;
        pani.SetTrigger("hrt");

        if (hp <= 0)
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
