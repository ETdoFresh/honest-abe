﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static bool perkChosen;
	public static bool lost;
	public static bool win;
	private GameObject _camera;

    private CameraFollow cameraFollow;

	void Start(){
        perkChosen = false;
		lost = false;
		win = false;

		_camera = GameObject.Find("Main Camera");
        cameraFollow = _camera.GetComponent<CameraFollow>();
        if (!perkChosen) cameraFollow.lockRightEdge = true;
	}

	void Update(){
		CheckLost();
		CheckWin();
	}

	public void CheckLost(){
		if (lost) {
			UIManager.displayLost = true;
		}
	}

	public void CheckWin(){
		//Checks if the boss health is 0 -- for alpha
		if(win){
			UIManager.displayWin = true;
            PerkManager.UpdatePerkStatus(GlobalSettings.axe_dtVampirism_name, 1);
		}
	}

	public static void BossFight(){
		_camera.GetComponent<CameraFollow> ().lockRightEdge = GlobalSettings.bossFight;
	}
}
