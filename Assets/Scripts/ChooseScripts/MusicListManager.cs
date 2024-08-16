using System.Collections;
using System.IO;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MusicListManager : MonoBehaviour
{

    [SerializeField] private MenuController musicController;
    [SerializeField] private Dropdown musicDropdown;

    private bool usingMicrophone;


    [Header("AUDIO COMPONENT")]
    [SerializeField] private AudioSource sourceAudio;

    [Header("AUDIO LIST")]
    [SerializeField] private List<FileInfo> filesWAV =  new List<FileInfo>();
    [SerializeField] private List<FileInfo> filesMP3 = new List<FileInfo>();
    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();
    List<string> options = new List<string>();




    // Start is called before the first frame update
    void Awake()
    {
        ShowMusics();   
    }
  
    public void ShowMusics()
    {
        musicDropdown.ClearOptions();
        filesMP3.Clear();
        options.Clear();
        filesWAV.Clear();
        filesWAV = GetFiles("*.wav");
        filesMP3 = GetFiles("*.mp3");
        CheckMusic();
        int totalFiles = filesMP3.Count + filesWAV.Count;
        UpdateDropDown(options);
    }
    private void UpdateDropDown(List<string> _ops)
    {

        int currentResolutionIndex = 0;

        musicDropdown.AddOptions(_ops);
        musicDropdown.value = currentResolutionIndex;
        sourceAudio.clip = Resources.Load<AudioClip>(_ops[currentResolutionIndex]);
        musicController.UpdateSongName(sourceAudio.clip.name);
        musicDropdown.RefreshShownValue();
    }
    private void CheckMusic()
    {
        if (filesWAV.Count != 0)
        {
            for (int i = 0; i < filesWAV.Count; i++)
            {
                string filename = Path.GetFileNameWithoutExtension(filesWAV[i].Name);

                options.Add(filename);
            }
        }
        if (filesMP3.Count != 0)
        {
            for (int i = 0; i < filesMP3.Count; i++)
            {
                string filename = Path.GetFileNameWithoutExtension(filesMP3[i].Name);

                options.Add(filename);
            }
        }
    }



    private List<FileInfo> GetFiles(string _fileExt)
    {
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "\\Resources");
        FileInfo[] _files = dir.GetFiles(_fileExt);
        List<FileInfo> _filesList = new List<FileInfo>();
        foreach (FileInfo fi in _files)
        {
            _filesList.Add(fi);
        }
        return _filesList;
    }

    public void SetMusic(int _musicPicked)
    {
      
        sourceAudio.clip = Resources.Load<AudioClip>(options[_musicPicked]);
        musicController.UpdateSongName(sourceAudio.clip.name);
        //sourceAudio.Play();
    }

    


}
