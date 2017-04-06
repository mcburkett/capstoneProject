using UnityEngine;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using WindowsInput;
using System;


public class leapMotionControls : MonoBehaviour
{
    public LeapProvider provider;

    public float[] currentPosition;
    Controller controller;
    InteractionBox interactionBox;
    public int frameCount = 0;

    void Start ()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
        print("Started");
        controller = new Controller();
        
        
        }

    void Update()
    {
        Frame frame = controller.Frame();
        //Debug.Log("Update");

        interactionBox = frame.InteractionBox;
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
            Hand firstHand = hands[0];

           
                //Debug.Log("foreach");
                //Debug.Break();
                frameCount = frameCount++;
                currentPosition = new float[3]; //create array for x,y,z coordinates
                currentPosition = firstHand.PalmPosition.ToFloatArray(); //move coordinates to the current postion

                float palmWidth = currentPosition[0]; // get the width, or X for the current position
                float palmDepth = currentPosition[2]; // get the depth, or Z for the current postition

                float boxWidth = interactionBox.Width; // gets the width for the current interactionBox
                float boxHeight = interactionBox.Height; // gets the height for the current interactionBox
                float boxDepth = interactionBox.Depth; //gets the depth for the current interaction box

                //define top area
                float topLine = (boxDepth / 3); //split depth into thirds
                topLine = topLine * 2; // anything past this line (2/3rd) the depth is considered "up"

                //define bottom area
                float bottomLine = (boxDepth / 3); //split depth into thirds, any position less than this line is considered down

                //define left area
                float leftLine = (boxWidth / 3); //split width into thirds, any position to the left of this line turns the car to the left

                //define right area
                float rightLine = (boxWidth / 3); //splits width into thirds
                rightLine = rightLine * 2; //anything past this line (2/3rd the width) turns the car to the right

                if (palmDepth > topLine)
                {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN); // Move car backwards
                Debug.Log("Using Down");

            }
            else if (palmDepth < bottomLine)
                {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.UP);  // Move car forward  
                Debug.Log("Using UP");
            }
                else if (palmDepth < topLine && palmDepth > bottomLine && palmWidth < leftLine)
                {
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
                    Debug.Log("Using Left");
                }
                else if (palmDepth < topLine && palmDepth > bottomLine && palmWidth > rightLine)
                {
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
                    Debug.Log("Using Right");
                }
            
        }

    }

    /*public void OnApplicationQuit()
    {
        Destroy(controller);
    }*/
}