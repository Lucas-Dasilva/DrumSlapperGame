using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NotePlacer : MonoBehaviour
{
    public bool hasStarted;
    public AudioSource theSong;
    public GameObject noteObj;
    public float zPos;
    List<float> noteTime;
    float noteSpeed = 0f;
    bool spawned = false;
    bool firstNotePlayed = false;
    int noteCount = 0;
  
    

    // Start is called before the first frame update
    void Start()
    {
        
        noteTime = load();
        hasStarted = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted != false)
        {
            
            if (spawned == false)
            {
                noteSpeed = noteMovement(noteTime, noteCount);
                //Move object down the plane at tempo speed
                spawned = spawnNote(noteTime, noteCount);
                if(spawned == true)
                {
                    noteCount++;
                    spawned = false;
                }
            }

            noteObj.transform.position -= new Vector3(0f, 0f, (noteSpeed * Time.deltaTime));
        }
    }

    float noteMovement(List<float> noteTime, int i)
    {
        //First note hit at 3 + noteTime[0] == around 3.6 seconds
        //Speed == distance/time
        float speed = 0f;
        float time = 0f;
        float distance = 49.5f;//Distance between spawn location and center of button
        if (firstNotePlayed == false)
        {
            time = 3 + noteTime[i];
            firstNotePlayed = true;
        }
        if (firstNotePlayed == true)
        {
            time = noteTime[i];
        }

        speed = distance/time;
        
        time = distance / speed;
        
        return speed;
    }

    //Loads in record file and places into the noteTime arrayList
    List<float> load()
    {
        List<float> noteTime = new List<float>();
        string path = "Assets/NoteData/YellowTime.txt";
        StreamReader reader = new StreamReader(path);
        float temp = 0f;
        int i = 0;
        while (reader.Peek() > -1)
        {
            //Converts read line to fload and adds it to the array.
            temp = float.Parse(reader.ReadLine());
            noteTime.Add(temp);
            //Debug.Log(noteTime[i]);
            i++;
        }
        return noteTime;

    }
    bool spawnNote(List<float> noteTime, int i)
    {
        //if the song time + how long it takes to travel is equal to the note time. instantiate
        /* 0.0080045
         * 0.013333
         * 0.007982
         *  <= 0.01
         * */
         //if the song[Time] is equal to the note time
        if (((theSong.time - noteTime[i]) + noteTime[i]) <= (0.015) && ((theSong.time - noteTime[i]) + noteTime[i] >= (-0.015 )))
        {

            noteObj = Instantiate(noteObj, new Vector3(4, 0, zPos), transform.rotation);

            return true;
        }
        return false;
    }


}
//ienumerator spawnnote(float noteSpeed)
//{
//    yield return new waitforseconds(1);


//    if (whichnote[notemark] == 1)
//    {
//        xpos = -4.0f;
//    }
//    if (whichnote[notemark] == 2)
//    {
//        xpos = -2.0f;
//    }
//    if (whichnote[notemark] == 3)
//    {
//        xpos = 0.0f;
//    }
//    if (whichnote[notemark] == 4)
//    {
//        xpos = 2.0f;
//    }
//    if (whichnote[notemark] == 5)
//    {
//        xpos = 4.0f;
//    }
//    notemark += 1;
//    timerreset = "y";
//    instantiate(noteobj, new vector3(xpos, 0, 20), noteobj.rotation);

//}