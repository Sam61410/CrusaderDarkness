using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] CarController player;
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

    public int boxWidth;
    public int boxHeight;
    public int boxDepth;

    public bool playerFound = false;
    public bool waited = false;
    public bool loopPatrol = true;
    public bool shouldWait = false;

    //WaveManager waveManager;
    public Transform[] waypoints;

    public void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = FindFirstObjectByType<CarController>();
        //waveManager = FindFirstObjectByType<WaveManager>();
    }

    public void Update()
    {
        PlayerCheck();
        if (playerFound)
        {
            agent.SetDestination(player.transform.position);
            agent.acceleration = 7;
            agent.speed = 6f;
            // animator.speed = 2;
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance <= waypointTolerance && !playerFound)
            {
                AdvanceWaypoint();
                SetNextDestination();
            }
            else return;
        }
    }
    public void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (playerFound) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 playerRadius = new Vector3(boxDepth, boxHeight, boxWidth);
        Gizmos.DrawCube(
        new Vector3(transform.position.x, transform.position.y, transform.position.z), playerRadius);
    }
    private void PlayerCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 playerRadius = new Vector3(boxDepth, boxHeight, boxWidth);
        playerFound = Physics.CheckBox(spherePosition, playerRadius, Quaternion.identity, PlayerLayers);
    }

    public void Start()
    {
        currentWaypointIndex = UnityEngine.Random.Range(0, waypoints.Length);
        if (waypoints == null || waypoints.Length == 0)
        {
            enabled = false;
            return;
        }
        SetNextDestination();
    }
    public void SetNextDestination()
    {
        if (waypoints.Length == 0) return;
        agent.acceleration = 5;
        agent.speed = 5f;
        //  animator.speed = 1;

        Transform targetWaypoint = waypoints[currentWaypointIndex];

        if (waited = true && targetWaypoint != null)
        {
            waited = false;
            shouldWait = true;
            agent.SetDestination(targetWaypoint.position);
            // animator.Play("Crawl");
        }
    }
    private void AdvanceWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            if (loopPatrol)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                enabled = false;
            }
        }
    }

}
