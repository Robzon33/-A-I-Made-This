using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject menuUI;
    public AudioSource menuAudioSource;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            menuUI.SetActive(true);
            menuAudioSource.volume = 1.0f;
            menuAudioSource.Play();
        }
    }

    public void CloseMenu()
    {
        menuAudioSource.Play();
        menuUI.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
