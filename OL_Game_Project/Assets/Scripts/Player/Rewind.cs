using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    public MouseLook mouselook;  //# Lets me reference things from another C# file

    public GameObject boxSTART;
    public GameObject boxEND;

    // The maximum duration of time that can be rewind
    public float maxRewindDuration = 50f;

    // The speed at which the time is rewind
    public float rewindSpeed = 3f;

    // Boolean to check if the time rewind is currently active
    private bool isRewinding = false;

    public bool startclip = false;

    // A list to store the player's position and roation for each recorded frame
    private List<TimeSnapshot> timeSnapshots = new List<TimeSnapshot>();

    // Strucuture to store position and roation information for a frame
    private struct TimeSnapshot
    {
        public Vector3 position;
        public Quaternion roation;

        public TimeSnapshot(Vector3 pos, Quaternion rot)
        {
            position = pos;
            roation = rot;
        }
    }
    
    private void Update()
    {
         // Check for input to activate the rewind
        // if (Input.GetKeyDown(KeyCode.R))
        //{
        //    StartRewind();
        //}

         // Check if input to stop the time rewind
         //if (Input.GetKeyUp(KeyCode.R))
        //{
            //StopRewind();
        //}



    }

    private void FixedUpdate()
    {
        // Record the player's poition and rotation during normal gameplay
        if (!isRewinding)
        {
            if (startclip)
            {
                RecordSnapshot();
            }
        }

        // Rewind time if the time rewind is active
        if (isRewinding)
        {
            if (!startclip)
            {
                RewindTime();
            }
        }    
    }

    private void RecordSnapshot()
    {
        // Record the player's position and rotation in the timeSnapshots list
        timeSnapshots.Insert(0, new TimeSnapshot(transform.position, transform.rotation));
        // If the list exceeds the maxium duration, remove the oldest entry
        if (timeSnapshots.Count > Mathf.Round(maxRewindDuration / Time.fixedDeltaTime))
        {
            timeSnapshots.RemoveAt(timeSnapshots.Count - 1);
        }
    }

    //private void RewindTime()
    public void RewindTime()
    {
        // If there are recorded snapshots, rewind the player's position and rotation
        if(timeSnapshots.Count > 0)
        {
            TimeSnapshot snapshot = timeSnapshots[0];
            transform.position = snapshot.position;
            transform.rotation = snapshot.roation;

            // Remove the used snapshot from the list
            timeSnapshots.RemoveAt(0);
        }
        else
        {
            // If there are no more snapshots, stop the time rewind
            StopRewind();
        }
    }

    public void beginRewind()
    {
        startclip = true;
        if (boxSTART.GetComponent<BoxCollider>().enabled)
        {
            boxSTART.GetComponent<BoxCollider>().enabled = false;
        }
    }


    //private void StartRewind()
    public void StartRewind()
    {
        // Activate time rewind
        boxEND.GetComponent<BoxCollider>().enabled = true;
        isRewinding = true;
        mouselook.LookEnabled = false;
        startclip = false;

        // Optionally, pause any gameplay mechanics that shoudn't be active during rewind
        // For example: disable enemy AI, stop physics interactions, etc.
    }

    //private void StopRewind()
    public void StopRewind()
    {
        // Deactive time rewind
        isRewinding = false;
        mouselook.LookEnabled = true;

        boxEND.GetComponent<BoxCollider>().enabled = false;

        // Optionally, resume any paused gameplay mechanics after the rewind is stopped
        // For example: enabled enemy AI, resume physics interaction, etc.
    }
}
