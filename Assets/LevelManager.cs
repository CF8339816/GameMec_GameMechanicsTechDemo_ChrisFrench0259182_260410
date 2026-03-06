using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{




    public GameObject Main;
    //public GameObject Level02;
    //public GameObject Level03;
    //public GameObject Level04;
    //public GameObject Level05;
    //public GameObject Menu;
    //public GameObject Settings;
    public GameObject PauseScreen;
    private GameObject player;
    private GameObject currentActiveLevel;
    public Transform spawnLocation;
    public GameObject levelToLoad;
    //public GameObject level; 


    public void Start()
    {
        currentActiveLevel = Main;
        player = ServiceHub.Instance.playerController.gameObject;
    }
    public void CloseAllScreens()
    {
        //Menu.SetActive(false);
        // Settings.SetActive(false);
        PauseScreen.SetActive(false);
        Main.SetActive(false);
        // Level02.SetActive(false);
        // Level03.SetActive(false);
        // Level04.SetActive(false);
        //Level05.SetActive(false);






    }
    public void levelChange(GameObject levelToLoad, Transform spawnLocation)
    {
        CloseAllScreens();

        currentActiveLevel.SetActive(false);
        levelToLoad.SetActive(true);
        currentActiveLevel = levelToLoad;

        player.transform.position = spawnLocation.position;
    }


}
