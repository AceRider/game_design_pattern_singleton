using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnviroment
{
    private static GameEnviroment instance;
    private List<GameObject> obstacles = new List<GameObject>();
    private List<GameObject> goals = new List<GameObject>();

    public List<GameObject> Obstacles { get { return obstacles; } }
    public List<GameObject> Goals { get { return goals; } }

    public static GameEnviroment Singleton
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEnviroment();
                instance.Goals.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            }
            return instance;
        }
    }

    public GameObject GetRandomGoal()
    {
        int index = Random.Range(0, goals.Count);
        return goals[index];
    }

    public void AddObstacles(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveObstacles(GameObject go)
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
        GameObject.Destroy(go);
    }
}
