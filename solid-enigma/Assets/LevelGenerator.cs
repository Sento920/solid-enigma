using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private GameObject[] tiles;
    [SerializeField] private GameObject evac;
    [SerializeField] private float tileWidth = 10;
    [SerializeField] private float tileLength = 10;
    [SerializeField] private int width = 200;
    [SerializeField] private int height = 100;
    [SerializeField] private int fuelNum = 100;

    private int[] map;


    [SerializeField]
    private GameObject fuel;

    // Use this for initialization
    void Start() {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update() {

    }

    void RecursiveGenerateStreets(int startx, int endx, int starty, int endy, bool vertical) {
        //if (((endx - startx <= 2 && endy - starty <= 8) || (endy - starty <= 2 && endx - startx <= 8)))
        if ((endx - startx <= 2) || (endy - starty <= 2))
            return;

        int splitRoad;

        if (vertical)
            splitRoad = Random.Range(startx + 1, endx);
        else
            splitRoad = Random.Range(starty + 1, endy);

        // fill road
        if (vertical) {
            for (int i = starty; i < endy; i++) {
                map[(width * i) + splitRoad] = 0;
            }

            RecursiveGenerateStreets(startx, splitRoad, starty, endy, !vertical);
            RecursiveGenerateStreets(splitRoad, endx, starty, endy, !vertical);
        } else {
            //Debug.Log(splitRoad + " " + startx + " " + endx + " " + endy + " " + starty);
            for (int i = startx; i < endx; i++) {
                map[(width * splitRoad) + i] = 0;
            }

            RecursiveGenerateStreets(startx, endx, starty, splitRoad, !vertical);
            RecursiveGenerateStreets(startx, endx, splitRoad, endy, !vertical);
        }
    }

    void GenerateLevel()
    {
        map = new int[width * height];

        for (int i = 0; i < width * height; i++)
            map[i] = 1;

        RecursiveGenerateStreets(0, width, 0, height, true);

        map[(width * (height / 2)) + (width / 2)] = 2;

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (map[(width * y) + x] == 1)
                    Instantiate(tiles[Random.Range(0, tiles.Length)], new Vector3((x * tileWidth) - (tileWidth * width) / 2, gameObject.transform.position.y, (y * tileLength) - (tileLength * height) / 2), Quaternion.identity);
                else if (map[(width * y) + x] == 2)
                    Instantiate(evac, new Vector3((x * tileWidth) - (tileWidth * width) / 2, gameObject.transform.position.y, (y * tileLength) - (tileLength * height) / 2), Quaternion.identity);
            }
        }



        List<int> integers = new List<int>();
        for (int i = 0; i < map.Length; i++) {
            if (map[i] == 0)
            {
                integers.Add(i);
            }
        }
        for (int i = 0; i < fuelNum || integers.Count == 0; i++)
        {
            int rand = Random.Range(0, integers.Count);
            int x = integers[rand] %  height;
            int y = integers[rand] / width;
            integers.Remove(rand);
            Instantiate(fuel, new Vector3((x * tileWidth) - (tileWidth * width) / 2, 1, (y * tileLength) - (tileLength * height) / 2), Quaternion.identity);
        }

    }
}
