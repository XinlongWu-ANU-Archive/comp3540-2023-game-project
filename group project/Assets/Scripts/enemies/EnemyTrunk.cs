using UnityEngine;

public class EnemyTrunk : Enemy
{ 
    public GameObject seed;
    public Transform shootPos;
    public float shootingInterval = 0.8f;
    public Transform shootingRange1;
    public Transform shootingRange2;
    private Transform player;
    private float timer = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();


       base.Update();

        if (player != null)
        {
            float playerX = player.position.x;

            // Check if the player is within the shooting area defined by shootingPoint1 and shootingPoint2
            if (playerX >= Mathf.Min(shootingRange1.position.x, shootingRange2.position.x) &&
                playerX <= Mathf.Max(shootingRange1.position.x, shootingRange2.position.x))
            {
                timer += Time.deltaTime;

                if (timer >= shootingInterval)
                {
                    Shoot();
                    timer = 0;
                }
            }
        }
    }
    


    void Shoot()
    {
        // Instantiate the seed at the trunk position
        Instantiate(seed, shootPos.position, Quaternion.identity);
    }
}
