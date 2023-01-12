using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavMeshManager : SingleTon<NavMeshManager>
{
    [Header("NPC")]
    [SerializeField]
    private NPC npcPrefabs;
    [SerializeField]
    private float spawnDelay;
    private Coroutine spawnRoutine;

    [Header("Way")]
    [SerializeField]
    private Transform way;
    public List<Transform> wayPoints { get; private set; }

    [Header("Goal")]
    [SerializeField]
    private Transform goal;
    public List<Transform> goalPoints { get; private set; }

    public override void Awake()
    {
        GetWayPoints();
    }

    private void Start()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void GetWayPoints()
    {
        wayPoints = new List<Transform>();
        for(int i =0;i<way.childCount;i++)
        {
            wayPoints.Add(way.GetChild(i));
        }
    }

    public Transform GetGoalPoint()
    {
        int rand = Random.Range(0, goal.childCount);
        Transform newGoal = goalPoints[rand];
        goalPoints.RemoveAt(rand);
        return newGoal;
    }

    public void SetGoalPoints(Transform newGoal)
    {
        goalPoints.Add(newGoal);
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(npcPrefabs, wayPoints.First().position, Quaternion.identity);
        }
    }
}
