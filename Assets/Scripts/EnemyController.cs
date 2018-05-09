using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform targetPlayer;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isWalking = true;

    // Use this for initialization
    void Start()
    {
        //it's not looking for every player object
        targetPlayer = PlayerManager.instance.player.transform;
        
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetPlayer.position);
        Animating();
    }

    void Animating()
    {
        anim.SetBool("IsWalking", isWalking);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.score -= 50;
            isWalking = false;
            anim.SetBool("IsWalking", isWalking);
            anim.SetTrigger("Die");
            //destroy the monster after the anination is over.
//            Destroy(this.gameObject);
        }
    }
}