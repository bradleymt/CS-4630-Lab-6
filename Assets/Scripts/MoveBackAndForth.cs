using System.Diagnostics;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    [Header("Movement Points")]
    public Transform pointA; //starting position transform
    public Transform pointB; //ending position transform

    [Header("Settings")]
    public float speed = 2f; //movement speed
    public bool useLocalPosition = false; //use local instead of world space

    private Vector3 startPos; //cached start position
    private Vector3 endPos; //cached end position
    private float journeyLength; //distance between points

    void Start()
    {
        if (pointPointsAreValid()) //check if points are assigned
        {
            UpdatePositions(); //update positions
        }
        else
        {
            UnityEngine.Debug.LogWarning("Point A or Point B not assigned"); //warning log
            startPos = useLocalPosition ? transform.localPosition : transform.position; //fallback start pos
            endPos = startPos + new Vector3(5f, 0f, 0f); //fallback end pos
            journeyLength = Vector3.Distance(startPos, endPos); //calculate distance
        }
    }

    bool pointPointsAreValid()
    {
        return pointA != null && pointB != null; //return validity
    }

    void UpdatePositions()
    {
        if (useLocalPosition) //check local space
        {
            startPos = pointA.localPosition; //get local start
            endPos = pointB.localPosition; //get local end
        }
        else
        {
            startPos = pointA.position; //get world start
            endPos = pointB.position; //get world end
        }
        journeyLength = Vector3.Distance(startPos, endPos); //update length
    }

    void Update()
    {
        if (pointPointsAreValid()) //check valid transforms
        {
            UpdatePositions(); //refresh positions
        }

        if (journeyLength <= 0f) return; //exit if zero distance

        float time = (Time.time * speed) / journeyLength; //calculate time factor
        float fracJourney = Mathf.PingPong(time, 1.0f); //pingpong ratio

        if (useLocalPosition) //apply local movement
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, fracJourney); //lerp local pos
        }
        else
        {
            transform.position = Vector3.Lerp(startPos, endPos, fracJourney); //lerp world pos
        }
    }
}