using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private static string PLAYER_PREFAB_PATH = "Prefabs/Player";
    private static string BOX_PREFAB_PATH = "Prefabs/Box";
    private static string TARGET_PREFAB_PATH = "Prefabs/Target";
    private static string WALL_PREFAB_PATH = "Prefabs/Wall";

    public void Start()
    {
        List<Box> boxes = GameConfiguration.CustomLevel
            ? ReadLevel.ReadCustom()
            : ReadLevel.Read();

        foreach(Box box in boxes)
        {
            GenerateBox(box);
        }
    }

    private void GenerateBox(Box box)
    {
        switch (box.boxStatus) {
            case BoxStatus.PLAYER:
                GeneratePlayer(box);
                break;
            case BoxStatus.BOX:
                GenerateBoxPrefab(box);
                break;
            case BoxStatus.WALL:
                GenerateWall(box);
                break;
            case BoxStatus.TARGET:
                GenerateTarget(box);
                break;
            case BoxStatus.EMPTY:
                break;
            default:
                break;
        }
    }

    private void GeneratePlayer(Box box)
    {
        GameObject Player = Instantiate(Resources.Load(PLAYER_PREFAB_PATH) as GameObject, transform.position + Vector3.up, Quaternion.identity);

        Player.transform.position = new Vector3(box.positionX-7, 0.25f, -(box.positionY-5));
        Player.transform.parent = transform;
    }

    private void GenerateWall(Box box)
    {
        GameObject Wall = Instantiate(Resources.Load(WALL_PREFAB_PATH) as GameObject, transform.position + Vector3.up, Quaternion.identity);

        Wall.transform.position = new Vector3(box.positionX-7, 1, -(box.positionY - 5));
        Wall.transform.parent = transform;
    }

    private void GenerateTarget(Box box)
    {
        GameObject Target = Instantiate(Resources.Load(TARGET_PREFAB_PATH) as GameObject, transform.position + Vector3.up, Quaternion.identity);

        Target.transform.position = new Vector3(box.positionX-7, -0.25f, -(box.positionY - 5));
        Target.transform.parent = transform;
    }

    private void GenerateBoxPrefab(Box box)
    {
        GameObject BoxPrefab = Instantiate(Resources.Load(BOX_PREFAB_PATH) as GameObject, transform.position + Vector3.up, Quaternion.identity);

        BoxPrefab.transform.position = new Vector3(box.positionX-7, 0.5f, -(box.positionY - 5));
        BoxPrefab.transform.parent = transform;
    }
}
