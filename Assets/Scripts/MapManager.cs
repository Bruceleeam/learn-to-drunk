using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public List<GameObject> _placeholders;
    public GameObject player;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    float speed = 50f;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        startMarker = player.transform;
        if (PlayerPrefs.HasKey("LastTown"))
        {
            index = _placeholders.FindIndex(a => a.name.Equals(PlayerPrefs.GetString("LastTown")));
            startMarker = _placeholders[index].gameObject.transform;
            index++;
        }
        
        endMarker = _placeholders[index].gameObject.transform;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, _placeholders[index].gameObject.transform.position) > 1f){
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            player.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }
        else
        {
           
            // Memorizza l'ultima posizione raggiunta
            PlayerPrefs.SetString("LastTown", _placeholders[index].name);
            // Passa alla scena di play
            SceneManager.LoadScene("TownIntro");
        }
        

    }
}
