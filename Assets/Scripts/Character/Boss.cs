﻿using UnityEngine;

public class Boss : MonoBehaviour
{
    public string bossName;

	private CameraFollow _cameraFollow;
	private Vector3 _playerPosition;
    private LevelManager _levelManager;

    // Use this for initialization
    void Start()
	{
		_cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
		_playerPosition = GameObject.Find("Player").transform.position;
        if ((gameObject.transform.position.x - _playerPosition.x) < 10)
        {
			//The boss is in the scene with Abe so lock the camera
			_cameraFollow.lockRightEdge = true;
			GameObject.Find("UI").GetComponent<UIManager>().bossHealthUI.enabled = true;

            if (_levelManager.currentScene == 0)
                MusicPlayer.Play("Forest Boss");
            else if (_levelManager.currentScene == 1)
                MusicPlayer.Play("BattleField Boss");
            else if (_levelManager.currentScene == 2)
                MusicPlayer.Play("Ballroom Boss Intro", "Ballroom Boss Loop");
        }
    }
}
