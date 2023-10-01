using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    private Transform player;
    public float lineOfSite;
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
       float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

       if(distanceFromPlayer < lineOfSite){
       transform.position = Vector2.MoveTowards(this.transform.position, player.position, enemy.speed*Time.deltaTime); 
       }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
