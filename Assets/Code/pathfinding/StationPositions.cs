using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StationPositions : MonoBehaviour {

    // Private list to hold GameObjects
    private List<Transform> gameObjects = new List<Transform>();

    // Property to get and set the list of GameObjects
    public List<Transform> gameObjectsList {
        get { return gameObjects; }
        set { gameObjects = value; }
    }

    private void Start() {
        gameObjectsList.AddRange(this.GetComponentInChildren<Transform>());
        //Debug.Log(gameObjectsList.Count);
    }

};