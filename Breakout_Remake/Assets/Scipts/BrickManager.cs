using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    #region Singleton

    private static BrickManager _instance;

    public static BrickManager Instance => _instance;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    private int maxRows = 3;
    private int maxCols = 5;

    public Sprite[] sprites;

    [SerializeField] private LevelData levelData;

    public List<int[,]> LevelsData { get; set; }

    private void Start()
    {
        this.LevelsData = this.LoadLevelData();
    }

    private List<int[,]> LoadLevelData()
    {
        List<int[,]> levelsData = new List<int[,]>();
        int[,] currentLevel = new int[maxRows, maxCols];
        int correntRow = 0;

        for(int row = 0; row < levelData.blocks.Length; row++)
        {
            int correntBrick = levelData.blocks[row];
            
            for(int col = 0; col < levelData.blocks.Length; col++)
            {
                if (correntBrick == 1 || correntBrick == 0)
                {
                     
                }
                else
                {
                    correntRow++;
                }
            }            
        }

        return (levelsData);
    }
}
