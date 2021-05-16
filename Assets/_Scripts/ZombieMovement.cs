using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieMovement : MonoBehaviour
{
    public float lookRadius = 25f;
    public float attackingDistance = 2f;
    public float remainingDistance = 0.00001f;
    private float distance;
    public int MaxTime = 7;
    public int MinTime = 2;

    private int MaxDamage = 50;
    private int MinDamage = 30;

    private int ZombieHealth=100;
    private int Damage;
    private bool startRandom;
    private bool arriving;
    private bool Moving;
    private bool Died;
    public Transform Player;
    private Transform target;
    Vector3 startPosition;
    Quaternion startRotation;
    NavMeshAgent agent;
    private int selectedDestination;
    public ZombieHealth zombieHealth;

    public List<GameObject> AITransformPoint;
    public AudioSource ZombieAudio;

    RaycastHit hit;
    Vector3 rayDirection;

    enum ENEMY_STATE { S_RUN, S_IDLE,S_WALK,S_DIE,S_ATTACK };
    ENEMY_STATE state;
    Animator anim;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;       
        agent = GetComponent<NavMeshAgent>();
        ZombieAudio = GetComponent<AudioSource>();
        state = ENEMY_STATE.S_IDLE;
        anim = GetComponent<Animator>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        agent.enabled = false;
        startRandom = false;
        arriving = false;
        Moving = false;
        Died = false;


    }


    void Update()
    {
        Damage = Random.Range(30, 50);
        distance = Vector3.Distance(target.position, transform.position);
        switch (state)
        {
            case ENEMY_STATE.S_IDLE:

                anim.SetTrigger("Idle");
                if (distance>lookRadius&& startRandom == false)
                {
                    StartCoroutine(RandomMovement());
                    startRandom = true;
                }
               
               
                if (distance <= lookRadius && distance > attackingDistance)
                {                   
                    state = ENEMY_STATE.S_RUN;
                }
                if (ZombieHealth<=0)
                {
                    state = ENEMY_STATE.S_DIE;
                }
                
                break;

            case ENEMY_STATE.S_RUN:
                ZombieAudio.Play();
                agent.enabled = true;
                agent.SetDestination(target.position);
                this.GetComponent<NavMeshAgent>().speed = 4f;
                rayDirection = (target.transform.position + new Vector3(0, 1, 0)) - (transform.position + new Vector3(0, 1, 0));
                anim.SetTrigger("Run");
                bool raycastdown = Physics.Raycast((transform.position + new Vector3(0, 1, 0)), rayDirection, out hit);
                Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z),
                new Vector3(target.transform.position.x, transform.position.y + 1.5f, target.transform.position.z));
                if (raycastdown && hit.transform.name.Equals("Player"))
                {
                    agent.SetDestination(target.position);
                    //audioManager.updateAudio("attack");

                    if (distance <= agent.stoppingDistance)
                    {

                        FaceTarget();
                    }
                }
                if (distance > lookRadius)
                {                 
                    state = ENEMY_STATE.S_IDLE;
                }
               
                if (ZombieHealth <= 0)
                {
                    state = ENEMY_STATE.S_DIE;
                }
                break;

            case ENEMY_STATE.S_WALK:
                anim.SetTrigger("Walk");

                if (Moving == false)
                {
                    Moving = true;
                    agent.enabled = true;
                    selectedDestination = Random.Range(0, AITransformPoint.Count);
                    agent.SetDestination(AITransformPoint[selectedDestination].transform.position);
                    int lastDestination = selectedDestination;
                    while (AITransformPoint[selectedDestination].GetComponent<DestinationPoint>().isUsed == true)
                    {
                        //Debug.Log("changeDestination");
                        selectedDestination = Random.Range(0, AITransformPoint.Count);
                        StartCoroutine(RandomMovement());
                    }                   
                    agent.SetDestination(AITransformPoint[selectedDestination].transform.position);
                }           

                if (agent.enabled == true && arriving == true)
                {
                    agent.enabled = false;
                    Moving = false;
                    arriving = false;
                    state = ENEMY_STATE.S_IDLE;
                    StartCoroutine(RandomMovement());
                    //Debug.Log("arriving");
                }

              
                if (ZombieHealth <= 0)
                {
                    state = ENEMY_STATE.S_DIE;
                }
                break;

            case ENEMY_STATE.S_ATTACK:
                //Debug.Log("attack");
                ZombieAudio.Play();
                agent.enabled = true;
                FaceTarget();
                anim.SetTrigger("Attack");
                //agent.SetDestination(target.position);
                if (distance > lookRadius)
                {
                  
                    state = ENEMY_STATE.S_IDLE;
                }
                if (distance <= lookRadius &&distance>10f)
                {
                    
                    state = ENEMY_STATE.S_RUN;
                }
                if (ZombieHealth <= 0)
                {
                    state = ENEMY_STATE.S_DIE;
                }

                break;

            case ENEMY_STATE.S_DIE:
                ZombieAudio.Play();
                anim.SetTrigger("FallingBack");
                Destroy(gameObject, 2f);
                zombieHealth.updateHealth(1);
                //ZombieHealth.Health = 1;
                break;

             
        }
        

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            arriving = true;
            Debug.Log("arriving");
            other.gameObject.GetComponent<DestinationPoint>().isUsed = true;
        }
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            state = ENEMY_STATE.S_ATTACK;
        }
        if (other.gameObject.tag == "Plane")
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Bullet")
        {
            //Debug.Log("get it");
            ZombieHealth -= Damage;
            state= ENEMY_STATE.S_RUN;
        }
     
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("hit");
            state = ENEMY_STATE.S_ATTACK;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            other.gameObject.GetComponent<DestinationPoint>().isUsed = false;
        }
    }

    public IEnumerator RandomMovement()
    {

            int index = Random.Range(MinTime, MaxTime);
            //Debug.Log("RandomTime:" + index);
            yield return new WaitForSeconds(index);
            int index2 = Random.Range(1, 3);
            switch (index2)
            {

                case 1:

                    //Debug.Log("KeepIdle...");
         
                    state = ENEMY_STATE.S_IDLE;
                    startRandom = false;
                break;

                case 2:

                    //Debug.Log("Move...");
                 
                    state = ENEMY_STATE.S_WALK;

                    break;

            }

    }


}
