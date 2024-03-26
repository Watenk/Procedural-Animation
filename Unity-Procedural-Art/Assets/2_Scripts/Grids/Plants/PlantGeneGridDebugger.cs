using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGeneGridDebugger : IPhysicsUpdateable
{
    private Text[,] mainDebugTexts;
    private Text[,] upDebugTexts;
    private Text[,] leftDebugTexts;
    private Text[,] downDebugTexts;
    private Text[,] rightDebugTexts;

    // Cache
    private GameObject plantGeneGridDebugPrefab;

    // Dependencies
    private IPlantGrid plantGrid;

    //-------------------------------------

    public PlantGeneGridDebugger(){
        plantGrid = GameManager.GetService<PlantManager>();
        plantGeneGridDebugPrefab = Settings.Instance.PlantGeneGridDebugPrefab;

        mainDebugTexts = new Text[plantGrid.GridSize.x, plantGrid.GridSize.y];
        upDebugTexts = new Text[plantGrid.GridSize.x, plantGrid.GridSize.y];
        leftDebugTexts = new Text[plantGrid.GridSize.x, plantGrid.GridSize.y];
        downDebugTexts = new Text[plantGrid.GridSize.x, plantGrid.GridSize.y];
        rightDebugTexts = new Text[plantGrid.GridSize.x, plantGrid.GridSize.y];
        for (int y = 0; y < plantGrid.GridSize.y; y++){
            for(int x = 0; x < plantGrid.GridSize.x; x++){
                GameObject gameObject = GameObject.Instantiate(plantGeneGridDebugPrefab, new Vector3(x, -y, 0), Quaternion.identity);
                Text[] texts = gameObject.GetComponentsInChildren<Text>();
                mainDebugTexts[x, y] = texts[0];
                upDebugTexts[x, y] = texts[1];
                leftDebugTexts[x, y] = texts[2];
                downDebugTexts[x, y] = texts[3];
                rightDebugTexts[x, y] = texts[4];
            }
        }
    }

    public void OnPhysicsUpdate(){
        for (int y = 0; y < plantGrid.GridSize.y; y++){
            for(int x = 0; x < plantGrid.GridSize.x; x++){

                PlantCell plant = plantGrid.GetCell(new Vector2Short(x, y));
                if (plant == null) continue;
                
                mainDebugTexts[x, y].text = plant.ThisGene.ToString();
                upDebugTexts[x, y].text = plant.Genome.GetDirectionChromosome(plant.ThisGene).GetGene(Vector2Short.Up).ToString();
                leftDebugTexts[x, y].text = plant.Genome.GetDirectionChromosome(plant.ThisGene).GetGene(Vector2Short.Left).ToString();;
                downDebugTexts[x, y].text = plant.Genome.GetDirectionChromosome(plant.ThisGene).GetGene(Vector2Short.Down).ToString();;
                rightDebugTexts[x, y].text = plant.Genome.GetDirectionChromosome(plant.ThisGene).GetGene(Vector2Short.Right).ToString();;
            }
        }
    }
}
