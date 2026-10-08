using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] CarMovement player;
    [SerializeField] UnityEngine.AI.NavMeshAgent agent;
    //[SerializeField] Animator animator;
    //[SerializeField] ObjectGrab objectGrab;
    [SerializeField] public LayerMask PlayerLayers;
    //[SerializeField] EnemyHealth enemyHealth;

    //[SerializeField] Slider healthBar;

    //   [SerializeField] float playerRadius = 0.28f;
    public float waypointTolerance = 0.5f;

    public int currentPointIndex = 0;
    private int currentWaypointIndex = 0;

    public float boxWidth;
    public float boxHeight;
    public float boxDepth;

    public bool playerFound = false;
    public bool waited = false;
    public bool loopPatrol = true;
    public bool shouldWait = false;

    //WaveManager waveManager;

    public void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = FindFirstObjectByType<CarMovement>();
        //waveManager = FindFirstObjectByType<WaveManager>();
    }

    public void Update()
    {
        PlayerCheck();
        if (playerFound)
        {
            agent.SetDestination(player.transform.position);
        }
        else return;
    }

    private void PlayerCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 playerRadius = new Vector3(boxDepth, boxHeight, boxWidth);
        playerFound = Physics.CheckBox(spherePosition, playerRadius, Quaternion.identity, PlayerLayers);
    }

    
}
