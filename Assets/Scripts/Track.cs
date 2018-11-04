using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Track {

    //----atributes----//

    [SerializeField]
    private string _trackName;
    [SerializeField]
    private Material _imageCover;
    [SerializeField]
    private AudioClip _song;
    [SerializeField]
    private AudioClip _preview;
    [SerializeField]
    private string _dificulty;
    [SerializeField]
    private string _author;
    
    //----Properties-----//

    public string trackName { get { return _trackName; } set { _trackName = value; } }
    public Material imageCover { get { return _imageCover; } set { _imageCover = value; } }
    public AudioClip song { get { return _song; } set { _song = value; } }
    public AudioClip preview { get { return _preview; } set { _preview = value; } }
    public string dificulty { get { return _dificulty; } set { _dificulty = value; } }
    public string author { get { return _author; } set { _author = value; } }

    //-----Consructors-----//

    Track() 
    {
        _trackName = "undefined";
        _imageCover = null;
        _song = null;
        _preview = null;
        _dificulty = "undefined";
        _author = "undefined";
    }

    Track(string trackName, Material imageCover, AudioClip song, AudioClip preview, string dificulty, string author)
    {
        _trackName = trackName;
        _imageCover = imageCover;
        _song = song;
        _preview = preview;
        _dificulty = dificulty;
        _author = author;
    }

    
}
