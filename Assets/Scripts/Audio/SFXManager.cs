using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour

{
    public bool debug;
    private static SFXManager instance = null;
    public static SFXManager Instance
    {
        get { return instance; }
    }

    public AudioMixer masterMixer;
    public AudioTrack[] tracks;

    private float masterLvl;
    public float MasterLvl
    {
        get { return masterLvl; }
    }

    private float musicLvl;
    public float MusicLvl
    {
        get { return musicLvl; }
    }

    private float sfxLvl;
    public float SfxLvl
    {
        get { return sfxLvl; }
    }


    

    private Hashtable audioTable;
    private Hashtable jobTable;
    private AudioJob lastJobExecuted;

    [System.Serializable]
    public class AudioObject {
        public AudioType type;
        public AudioClip clip;
    }

    [System.Serializable]
    public class AudioTrack {
        public AudioSource source;
        public AudioObject[] audio;
    }

    private class AudioJob
    {
        public AudioAction action;
        public AudioType type;

        public AudioJob(AudioAction action, AudioType type)
        {
            this.action = action;
            this.type = type;
        }
    }

    private enum AudioAction { 
        START,
        STOP,
        RESTART
    }
    
    private void EnsureSingleton()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    void Awake()
    {
        if (!instance)
        {
            Configure();
        }
        else { 
            Destroy(gameObject);
        }        
    }

    void Start() {
        PlayAudio(AudioType.ST_MAIN_MENU);
    }

    public void PlayAudio(AudioType type) {
        AddJob(new AudioJob(AudioAction.START, type));
    }
    public void StopAudio(AudioType type)
    {
        AddJob(new AudioJob(AudioAction.STOP, type));
    }
    public void RestartAudio(AudioType type)
    {
        AddJob(new AudioJob(AudioAction.RESTART, type));
    }

    public void StopAllSFX()
    {
        this.StopAudio(AudioType.SFX_CAMINAR_LIGERO);
        this.StopAudio(AudioType.SFX_CAMINAR_PESADO);
        this.StopAudio(AudioType.SFX_CORRER);
    }

    public void SetMasterLvl(float lvl)
    {
        masterLvl = lvl;
        masterMixer.SetFloat("MasterLvl", Mathf.Log(masterLvl) * 20);
    }

    public void SetSfxLvl(float lvl)
    {
        sfxLvl = lvl;
        masterMixer.SetFloat("SfxLvl", Mathf.Log(sfxLvl) * 20);
    }
    public void SetMusicLvl(float lvl)
    {
        musicLvl = lvl;
        masterMixer.SetFloat("MusicLvl", Mathf.Log(musicLvl) * 20);
    }

    public void playBotonmenu()
    {
        PlayAudio(AudioType.SFX_BOTON);
    }

    private void Configure() 
    {
        EnsureSingleton();
        audioTable = new Hashtable();
        jobTable = new Hashtable();
        lastJobExecuted = new AudioJob(AudioAction.START, AudioType.None);
        masterLvl = 1f;
        musicLvl = 1f;
        sfxLvl = 1f;
        GenerateAudioTable();
        DontDestroyOnLoad(this.gameObject);
    }

    private void AddJob(AudioJob job)
    {
        if (isTheSame(job)) return;

        this.lastJobExecuted = job;
        RemoveConflictingJobs(job.type);
        Coroutine jobRunner = StartCoroutine(RunAudioJob(job));
        jobTable.Add(job.type, jobRunner);
        Log("Comenzando trabajo en [" + job.type + "] con la accion: " + job.action);
    }

    private bool isTheSame(AudioJob job)
    {
        return this.lastJobExecuted.type == job.type && this.lastJobExecuted.action == job.action;
    }

    private void RemoveJob(AudioType conflictAudio)
    {
        if (!jobTable.ContainsKey(conflictAudio))
        {
            LogWarning("Estas intentando parar un Job que ni tan siquiera esta siendo lanzado");
            return;
        }
        Coroutine runningJob = (Coroutine)jobTable[conflictAudio];
        StopCoroutine(runningJob);
        jobTable.Remove(conflictAudio);
    }

    private void RemoveConflictingJobs(AudioType type)
    {
        if (jobTable.ContainsKey(type))
        {
            RemoveJob(type);
        }

        AudioType conflictAudio = AudioType.None;
        AudioTrack audioTrackNeeded = GetAudioTrack(type, "Get Audio Track Needed");
        foreach (DictionaryEntry entry in jobTable)
        {
            AudioType audioType = (AudioType)entry.Key;
            AudioTrack audioTrackInUse = GetAudioTrack(audioType, "Get Audio Track In Use");
            if (audioTrackInUse.source == audioTrackNeeded.source)
            {
                conflictAudio = audioType;
                break;
            }
        }
        if (conflictAudio != AudioType.None)
        {
            RemoveJob(conflictAudio);
        }
    }

    private IEnumerator RunAudioJob(AudioJob job)
    {
        AudioTrack track = (AudioTrack)audioTable[job.type];
        track.source.clip = GetAudioClipFromAudioTrack(job.type, track);

        switch (job.action)
        {
            case AudioAction.START:
                track.source.Play();
                break;
            case AudioAction.STOP:
                track.source.Stop();
                break;
            case AudioAction.RESTART:
                track.source.Stop();
                track.source.Play();
                break;
        }

        jobTable.Remove(job.type);
        Log("Job ejecutandose ahora mismo: " + jobTable.Count);

        yield return null;
    }

    private void GenerateAudioTable()
    {
        foreach (AudioTrack track in tracks)
        {
            foreach (AudioObject obj in track.audio)
            {
                if (audioTable.ContainsKey(obj.type))
                {
                    LogWarning("Estas intentando incluir un audio que ya está registrado");
                }
                else
                {
                    audioTable.Add(obj.type, track);
                    Log("Pista de audio registrada [" + obj.type + "].");
                }
            }
        }
    }

    private AudioTrack GetAudioTrack(AudioType type, string job = "")
    {
        if (!audioTable.ContainsKey(type))
        {
            LogWarning("Estas intendo acceder a  <color=#fff>" + job + "</color> para [" + type + "] pero no se ha encontrado nada.");
            return null;
        }
        return (AudioTrack)audioTable[type];
    }

    private AudioClip GetAudioClipFromAudioTrack(AudioType type, AudioTrack track)
    {
        foreach (AudioObject obj in track.audio)
        {
            if (obj.type == type)
            {
                return obj.clip;
            }
        }
        return null;
    }

    private void Log(string msg) {
        if (!debug) return;
        Debug.Log("SFX Manager: " + msg);
    }

    private void LogWarning(string msg) {
        if (!debug) return;
        Debug.LogWarning("SFX Manager: " + msg);
            
    }
}
