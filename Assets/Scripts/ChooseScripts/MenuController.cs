using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject _musicMenu;
    [SerializeField] private MusicListManager _musicList;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Text songName;
    [SerializeField] private Slider songProgression;
    [SerializeField] private MeshColor meshColor;
    [SerializeField] private Animator anim;

    private bool showMenu = true;

    private float musicSeconds;

    // Start is called before the first frame update

    private void Start()
    {
        _musicMenu.SetActive(true);
       
        songProgression.minValue = 0;
        
        _musicList = GetComponentInChildren<MusicListManager>();
        //songName.text = audioSource.clip.name.ToString();

    }
    public void Update()
    {

       songProgression.value = audioSource.time;
    }
    public void PlaySong()
    {
        songProgression.maxValue = audioSource.clip.length;
        meshColor.change = true;


        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
            
    }
    public void StopSong()
    {
        audioSource.Stop();
        meshColor.change = false;
        meshColor.resetColor();
    }
    public void UpdateSongName(string song)
    {
        songName.text = song;
    }


    public void Refresh()
    {
        _musicList.ShowMusics();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void ShowMenu()
    {
        showMenu = !showMenu;
        anim.SetBool("showMenu", showMenu);
    }

}
