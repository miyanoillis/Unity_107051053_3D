
using UnityEngine.AI;
using UnityEngine;

public class enmy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nav;
    public Animator ani;
    public float cd = 2f;
    private float timer;
    public player pal;
    public Transform trak;

    [Header("speed") ,Range(0f,50f)]
    public float spd = 3;
    [Header("distance"), Range(0f, 50f)]
    public float spdstop = 1;

    [Header("distance"), Range(0f, 5f)]
    public float atkln;
    public Transform atkpt;
    private RaycastHit rhit;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(atkpt.position, atkpt.forward * atkln);
    }

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        trak = GameObject.Find("01").transform;

        player = GameObject.Find("free_male_1").transform;
        nav.speed = spd;
        nav.stoppingDistance = spdstop;
    }

    public void Update()
    {
            track();
        if(pal.hp >0)
        {
            attack();
        }
        else
        {
            Vector3 pos = trak.position;
            pos.y = transform.position.y;
            transform.LookAt(pos);
        }
    }

    public void attack()
    {
        if(nav.remainingDistance < spdstop)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;
            pos.y = transform.position.y;
            transform.LookAt(pos);

            if (timer >= cd)
            {
            ani.SetTrigger("atk");
                timer = 0;

                if(Physics.Raycast(atkpt.position, atkpt.forward, out rhit, atkln, 1 << 8))
                {
                    rhit.collider.GetComponent<player>().dmg();
                }
            }
        }
    }

    public void track()
    {
        if(pal.hp >= 0)
        {
        nav.SetDestination(player.position);
        ani.SetBool("walk" ,nav.remainingDistance> spdstop);
        }
        else
        {
            nav.SetDestination(trak.position);
            ani.SetBool("walk", nav.remainingDistance > spdstop);
        }

    }
}
