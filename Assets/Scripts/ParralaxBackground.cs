using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [System.Serializable]
    public class BackgroundLayer
    {
        public GameObject layer;
        public float speed;
    }

    public BackgroundLayer[] backgroundLayers;
    public float resetPosition = -20f; // Adjust based on your layer size
    public float startPosition = 20f;  // Adjust based on your layer size

    void Update()
    {
        foreach (BackgroundLayer bgLayer in backgroundLayers)
        {
            // Move the layer
            bgLayer.layer.transform.Translate(Vector2.left * bgLayer.speed * Time.deltaTime);

            // Reset the layer position if it moves out of view
            if (bgLayer.layer.transform.position.x <= resetPosition)
            {
                Vector3 newPos = new Vector3(startPosition, bgLayer.layer.transform.position.y, bgLayer.layer.transform.position.z);
                bgLayer.layer.transform.position = newPos;
            }
        }
    }
}
