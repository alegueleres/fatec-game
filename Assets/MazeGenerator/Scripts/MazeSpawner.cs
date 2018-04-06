using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MazeSpawner : MonoBehaviour {
	public enum MazeGenerationAlgorithm{
		PureRecursive,
		RecursiveTree,
		RandomTree,
		OldestTree,
		RecursiveDivision,
	}

	public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
	public bool FullRandom = false;
	public GameObject Floor = null;
	public GameObject Wall = null;
	public GameObject Pillar = null;
	public int Rows = 5;
	public int Columns = 5;
	public float CellWidth = 5;
	public float CellHeight = 5;
	public bool AddGaps = true;
	public GameObject GoalPrefab = null;
    public List<GameObject> PotionPrefabs = null;
    public List<GameObject> EnemyPrefabs = null;
    public GameObject TrapPrefab = null;
    public Transform hero = null;

    private BasicMazeGenerator mMazeGenerator = null;

    void Start()
    {
        if (!FullRandom)
        {
            Random.seed = Random.Range(0, 20000);
        }
        switch (Algorithm)
        {
            case MazeGenerationAlgorithm.PureRecursive:
                mMazeGenerator = new RecursiveMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RecursiveTree:
                mMazeGenerator = new RecursiveTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RandomTree:
                mMazeGenerator = new RandomTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.OldestTree:
                mMazeGenerator = new OldestTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RecursiveDivision:
                mMazeGenerator = new DivisionMazeGenerator(Rows, Columns);
                break;
        }
        mMazeGenerator.GenerateMaze();
        int countSpawn = 0;
        int zombieCount = 0;
        int bruteCount = 0;
        int minionCount = 0;
        int trapCount = 0;
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                countSpawn++;
                float x = column * (CellWidth + (AddGaps ? .2f : 0));
                float z = row * (CellHeight + (AddGaps ? .2f : 0));
                MazeCell cell = mMazeGenerator.GetMazeCell(row, column);
                GameObject tmp;
                tmp = Instantiate(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                tmp.transform.parent = transform;
                if (cell.WallRight)
                {
                    if (Wall.tag == "Fence")
                    {
                        tmp = Instantiate(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;// right
                    }
                    else
                    {
                        tmp = Instantiate(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;// right
                    }
                    tmp.transform.parent = transform;
                }
                if (cell.WallFront)
                {
                    if (Wall.tag == "Fence")
                    {
                        tmp = Instantiate(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject;// front
                    }
                    else
                    {
                        tmp = Instantiate(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;// front
                    }
                    tmp.transform.parent = transform;
                }
                if (cell.WallLeft)
                {
                    if (Wall.tag == "Fence")
                    {
                        tmp = Instantiate(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;// left
                    }
                    else
                    {
                        tmp = Instantiate(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;// left
                    }
                    tmp.transform.parent = transform;
                }
                if (cell.WallBack)
                {
                    if (Wall.tag == "Fence")
                    {
                        tmp = Instantiate(Wall, new Vector3(x, 0, z - CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject;// back
                    }
                    else
                    {
                        tmp = Instantiate(Wall, new Vector3(x, 0, z - CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;// back
                    }
                    tmp.transform.parent = transform;
                }
                if (cell.IsGoal && GoalPrefab != null)
                {
                    int enemySpawner = Random.Range(0, 13);
                    if (Wall.tag == "Fence")
                    {
                        enemySpawner = Random.Range(0, 40);
                        if (Random.Range(0, 10) == 0)
                        {
                            tmp = Instantiate(PotionPrefabs[Random.Range(0, 2)], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                        }
                        else if (enemySpawner < 15 && countSpawn > 20)
                        {
                            if (Random.Range(0, 2) == 0)
                            {
                                tmp = Instantiate(TrapPrefab, new Vector3(x - 0.5f, -2f, z + 0.5f), Quaternion.Euler(0, 0, 0)) as GameObject;
                                trapCount++;
                            }
                            else
                            {
                                tmp = Instantiate(EnemyPrefabs[2], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 180, 0)) as GameObject;
                                minionCount++;
                                tmp.GetComponent<AIPath>().target = hero;
                            }
                        }
                        else if (enemySpawner < 25 && countSpawn > 200)
                        {
                            tmp = Instantiate(EnemyPrefabs[1], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 180, 0)) as GameObject;
                            tmp.GetComponent<AIPath>().target = hero;
                            zombieCount++;
                        }
                        else if (enemySpawner < 30 && countSpawn > 600)
                        {
                            tmp = Instantiate(EnemyPrefabs[0], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 180, 0)) as GameObject;
                            tmp.GetComponent<AIPath>().target = hero;
                            bruteCount++;
                        }
                        else
                        {
                            tmp = Instantiate(GoalPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                        }

                        tmp.transform.parent = transform;
                    } else if (Random.Range(0, 4) == 0)
                    {
                        tmp = Instantiate(PotionPrefabs[Random.Range(0, 2)], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                    }
                    else if (enemySpawner < 4 && countSpawn > 30)
                    {
                        tmp = Instantiate(EnemyPrefabs[2], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 180, 0)) as GameObject;
                        tmp.GetComponent<AIPath>().target = hero;
                        minionCount++;
                    }
                    else if (enemySpawner < 6 && countSpawn > 300)
                    {
                        tmp = Instantiate(EnemyPrefabs[1], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 180, 0)) as GameObject;
                        tmp.GetComponent<AIPath>().target = hero;
                        zombieCount++;
                    }
                    else if (enemySpawner < 7 && countSpawn > 700)
                    {
                        tmp = Instantiate(EnemyPrefabs[0], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 180, 0)) as GameObject;
                        tmp.GetComponent<AIPath>().target = hero;
                        bruteCount++;
                    }
                    else
                    {
                        tmp = Instantiate(GoalPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                    }

                    tmp.transform.parent = transform;
                }
                if (countSpawn == 900)
                {
                    tmp = Instantiate(EnemyPrefabs[Random.Range(0, 2)], new Vector3(x, -0.2f, z), Quaternion.Euler(0, 180, 0)) as GameObject;
                    tmp.GetComponent<AIPath>().target = hero;
                    bruteCount++;
                }
            }
        }
        Debug.Log("Minions: " + minionCount);
        Debug.Log("Trap: " + trapCount);
        Debug.Log("Zombies: " + zombieCount);
        Debug.Log("Brute: " + bruteCount);
        Debug.Log("Total Enemies: " + (minionCount + zombieCount + bruteCount + trapCount));
        if (Pillar != null)
        {
            for (int row = 0; row < Rows + 1; row++)
            {
                for (int column = 0; column < Columns + 1; column++)
                {
                    float x = column * (CellWidth + (AddGaps ? .2f : 0));
                    float z = row * (CellHeight + (AddGaps ? .2f : 0));
                    GameObject tmp = Instantiate(Pillar, new Vector3(x - CellWidth / 2, 0, z - CellHeight / 2), Quaternion.identity) as GameObject;
                    tmp.transform.parent = transform;
                }
            }
        }
    }
}
