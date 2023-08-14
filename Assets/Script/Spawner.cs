using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private TowerSelection[] selections;
    int spawnID=0;
    public Tilemap spawner;
    public Transform Towerroot;
    Color deselectionColor = new Color(0.5f, 0.5f, 0.5f);

    bool selected = false;
    void Update()
    {
        if(Canspawn())
            DetectSpawnPoint();
    }
    void DetectSpawnPoint()
    {
        
        if (selected && Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawner.WorldToCell(mousePos);
            var cellPosCentered = spawner.GetCellCenterWorld(cellPosDefault);
            if (spawner.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                int towercost = TowerCost();
                if (GameManager.Instance.currencySystem.EnoughCurrency(towercost))
                {
                    GameManager.Instance.currencySystem.Use(towercost);
                    SpawnTower(cellPosCentered);
                    spawner.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                    Debug.Log("Not Enough Currency");

            }
            
        }
    
    }
    int TowerCost()
    {
        switch(spawnID)
        {
            case 0:return selections[spawnID].prefab.GetComponent<TowerPink>().cost;
            case 1:return selections[spawnID].prefab.GetComponent<TowerMask>().cost;
            case 2:return selections[spawnID].prefab.GetComponent<TowerNinja>().cost;
            default:return -1;
        }
    }
   void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(selections[spawnID].prefab,Towerroot);
        tower.transform.position = position;
        DeslectTower();
    }
    bool Canspawn()
    {
        if (spawnID == -1)
            return false;
        else
            return true;
    }
    public void RevertCellState(Vector3Int pos)
    {
        spawner.SetColliderType(pos, Tile.ColliderType.Sprite);
    }

    public void SelectTower(int id)
    {
        if(selected)
        {
            DeslectTower();
            return;
        }
        
        DeslectTower();
        selected = true;
        spawnID = id;
        selections[spawnID].seem.color = Color.white;
    }
    public void DeslectTower()
    {
        selected = false;

        selections[spawnID].seem.color = deselectionColor;
    }
}
[System.Serializable]
public class TowerSelection
{
    public GameObject prefab;
    public Image seem;
}
