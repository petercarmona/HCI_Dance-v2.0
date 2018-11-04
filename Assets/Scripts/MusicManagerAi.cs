using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.Audio;

public class MusicManagerAi : MonoBehaviour {

    public GameObject[] musicHolder; // 3d model for the music img
    public Track[] repertory; // List of Tracks ( Must be initialize in the inspector)
    public Material[] mat; // Temporary image placeholder

    public int holderSize = 1; // Indicates the number of tracks
    public float offSet = 8f; // Offset of the 3d models (MusicHolder)
    public int musicSelection = 0; // counter for the music to play

    public Dictionary<int, Track> trackList;
    public Dictionary<int, string> dificulty;

    public int dificultyLevel;
    public Color[] dificultyColor = new Color[3];

    public AudioSource audioSource;

    // Use this for initialization
    void Start() {

        if (repertory.Length > holderSize)
            holderSize = repertory.Length;
        musicHolder = new GameObject[holderSize];
        trackList = new Dictionary<int, Track>();
        
        for (int i = 0; i < holderSize; i++)
        {
            musicHolder[i] = Resources.Load("MusicHolder") as GameObject;
            trackList.Add(i, repertory[i]);
        }

        dificulty = new Dictionary<int, string>();
        dificulty.Add(0, "Easy");
        dificulty.Add(1, "Normal");
        dificulty.Add(2, "Hard");

        dificultyLevel = findDificulty(musicSelection);

        audioSource = GetComponent<AudioSource>();

        InstantiateTrackList();

        // Music Showcase

        audioSource.Play();
        audioSource.clip = trackList[musicSelection].song;
        audioSource.loop = true;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        selection();
	}

    void selection()
    {
        //-----INPUTS!-----//
        

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            Vector3 newPos = transform.position;
            newPos.x += offSet;
            transform.position = newPos;
            musicSelection--;

            dificultyLevel = findDificulty(musicSelection);

            audioSource.Stop();
            audioSource.clip = trackList[musicSelection].song;
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 newPos = transform.position;
            newPos.x -= offSet;
            transform.position = newPos;
            musicSelection++;

            dificultyLevel = findDificulty(musicSelection);

            audioSource.Stop();
            audioSource.clip = trackList[musicSelection].song;
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { 
            Transform selectable = transform.Find("Music " + musicSelection).Find("Image");
            Vector3 tmp = selectable.position;
            tmp.y += 2.5f;
            selectable.position = tmp;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dificultyLevel = findDificulty(musicSelection);
            dificultyLevel++;
            if (dificultyLevel > 2)
                dificultyLevel = 0;
            trackList[musicSelection].dificulty = dificulty[dificultyLevel];
            transform.Find("Music " + musicSelection).Find("Dificulty").GetComponent<TextMesh>().text = dificulty[dificultyLevel];
            changeTextColor(transform.Find("Music " + musicSelection).Find("Dificulty").GetComponent<TextMesh>(), transform.Find("Music " + musicSelection).Find("Dificulty").GetComponent<TextMesh>().text);
        }

    }

    void InstantiateTrackList()
    {
        Vector3 tmp = transform.position;
        for (int i = 0; i < holderSize; i++)
        {
            tmp.x = i * offSet;

            // Instantiate MusicHolder
            GameObject go = Instantiate(musicHolder[i], tmp, Quaternion.identity) as GameObject;
            go.transform.SetParent(transform);
            go.name = "Music " + (i);
            go.transform.Find("Image").GetComponent<Renderer>().material = trackList[i].imageCover;
            go.transform.Find("Name").GetComponent<TextMesh>().text = trackList[i].trackName;
            go.transform.Find("Author").GetComponent<TextMesh>().text = trackList[i].author;
            go.transform.Find("Dificulty").GetComponent<TextMesh>().text = trackList[i].dificulty;
            changeTextColor(go.transform.Find("Dificulty").GetComponent<TextMesh>(), go.transform.Find("Dificulty").GetComponent<TextMesh>().text);
        }
    }

    public void changeTextColor(TextMesh mesh, string text)
    {
        if (text == "Easy")
            mesh.color = dificultyColor[0]; // Green 009219FF
        else if (text == "Normal")
            mesh.color = dificultyColor[1]; // Blue 000151FF
        else if (text == "Hard")
            mesh.color = dificultyColor[2]; // Red 740B0BFF
    }

    int findDificulty(int trackIndex)
    {
        if (trackList[trackIndex].dificulty == "Easy")
            return 0;
        else if (trackList[trackIndex].dificulty == "Normal")
            return 1;
        else if (trackList[trackIndex].dificulty == "Hard")
            return 2;
        else
            return -1; 
    }
}
    