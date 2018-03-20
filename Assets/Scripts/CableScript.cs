using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
//[ExecuteInEditMode]
public class CableScript : MonoBehaviour
{


    LineRenderer line;

    //the Start of the cable will be the transform of the Gameobject that has this component.
    //The Transform of the Gameobject where the End of the cable is. This needs to be assigned in the inspector.
    [SerializeField] Transform endPointTransform;

    //How many points will be used to define the line.
    [SerializeField] int pointsInLineRenderer = 5;

    //How much the cable will sag by.
    [SerializeField] float sagAmplitude = 1;

    //How much wind will move the cable.
    [SerializeField] float swayMultiplier = 1;
    [SerializeField] float swayXMultiplier = 1;
    [SerializeField] float swayYMultiplier = .5f;
    //How fast the cable will go back and forth per second.
    [SerializeField] float swayFrequency = 1;


    //These are used later for calculations
    Vector3 vectorFromStartToEnd;
    Vector3 sagDirection;
    float swayValue;
    public void setEndPoint(GameObject t)
    {
        endPointTransform = t.transform;
    }
    void Start()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = pointsInLineRenderer;

        //The Direction of SAG is the direction of gravity
        sagDirection = Physics.gravity.normalized;

        //Start animation at random times
        swayValue = Random.Range(0, 3.14f);
    }



    void Update()
    {
        Animate();
    }

    void Animate()
    {
        if (!endPointTransform)
        {
            endPointTransform = transform;
        }
        else
        {
            //Get direction Vector.
            vectorFromStartToEnd = endPointTransform.position - transform.position;
            //Setting the Start object to look at the end will be used for making the wind be perpendicular to the cable later.
            transform.forward = vectorFromStartToEnd.normalized;
        }


        //what point is being calculated
        int i = 0;



        while (i < pointsInLineRenderer)
        {
            //This is the fraction of where we are in the cable and it accounts for arrays starting at zero.
            float pointForCalcs = (float)i / (pointsInLineRenderer - 1);
            //This is what gives the cable a curve and makes the wind move the center the most.
            float effectAtPointMultiplier = Mathf.Sin(pointForCalcs * Mathf.PI);

            //Calculate the position of the current point i
            Vector3 pointPosition = vectorFromStartToEnd * pointForCalcs;
            //Calculate the sag vector for the current point i
            Vector3 sagAtPoint = sagDirection * sagAmplitude;
            //Calculate the sway vector for the current point i

            //Calculate the postion with Sag.
            Vector3 currentPointsPosition =
                transform.position +
                pointPosition +
                (Vector3.ClampMagnitude(sagAtPoint, sagAmplitude)) * effectAtPointMultiplier;


            //Set point
            line.SetPosition(i, currentPointsPosition);
            i++;
        }
    }
}