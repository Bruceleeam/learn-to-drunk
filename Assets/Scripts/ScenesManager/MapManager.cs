using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public List<GameObject> _placeholders;
    public GameObject player;
    public static GameData gameData;
    // Transforms to act as start and end markers for the journey.
    Transform startMarker;
    Transform endMarker;
    public GameObject _demoMessage;

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
        if (StaticGameData._gameData._lastTown != null)
        {
            index = _placeholders.FindIndex(a => a.name.Equals(StaticGameData._gameData._lastTown));
            player.transform.position = _placeholders[index].gameObject.transform.position;
        }

        startMarker = _placeholders[index].gameObject.transform;

        if(index < _placeholders.Count - 1)
        {
            index++;
            endMarker = _placeholders[index].gameObject.transform;

            // Keep a note of the time the movement started.
            startTime = Time.time;

            // Calculate the journey length.
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            StaticGameData._gameData._lastTown = _placeholders[index].name;
        }
        else
        {
            _demoMessage.SetActive(true);
        }
       
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
            StartCoroutine(Next());
        }
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);
        // Passa alla scena di play
        SceneManager.LoadScene("TownIntro");
    }
}
