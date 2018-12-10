using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public GameObject mapa;

    private Camera camera;

    private BoxCollider2D wall_top;
    private BoxCollider2D wall_bottom;
    private BoxCollider2D wall_left;
    private BoxCollider2D wall_right;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start () 
    {
        camera = this.GetComponent<Camera>();
        camera_height = 2f * camera.orthographicSize;
        camera_width = camera_height * camera.aspect;
        
        wall_top = mapa.GetComponents<BoxCollider2D>()[0];
        wall_bottom = mapa.GetComponents<BoxCollider2D>()[1];
        wall_left = mapa.GetComponents<BoxCollider2D>()[2];
        wall_right = mapa.GetComponents<BoxCollider2D>()[3];
        
        print(wall_top.offset);
        print(wall_bottom.offset);
        print(wall_left.offset);
        print(wall_right.offset);

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if(player.transform.position.x + camera_width/2 < wall_right.offset.x || 
           player.transform.position.x - camera_width/2 > wall_left.offset.x ||
           player.transform.position.y + camera_height/2 < wall_top.offset.y ||
           player.transform.position.y - camera_height/2 > wall_bottom.offset.y)
            transform.position = player.transform.position + offset;
    }
}
