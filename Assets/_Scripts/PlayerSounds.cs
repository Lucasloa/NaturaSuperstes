using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip AudioClipHurt;
    [SerializeField] private AudioClip AudioClipLeveUP;
    [SerializeField] private AudioClip AudioClipExpPickup;
    [SerializeField] private AudioClip AudioClipElePickup;
    [SerializeField] private AudioClip AudioClipAttack;

    [SerializeField] private AudioSource AudioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void PlayClip(AudioClip clip)
    {
        {
            AudioSource.Stop();
            AudioSource.clip = clip;
            AudioSource.Play();
        }
    }
    public void PlayHurtSound()
    {
        PlayClip(AudioClipHurt);
    }
    public void PlayLevelUpSound()
    {
        PlayClip(AudioClipLeveUP);
    }
    public void PlayExpPickupSound()
    {
        PlayClip(AudioClipExpPickup);
    }
    public void PlayElePickupSound()
    {
        PlayClip(AudioClipElePickup);
    }
    public void PlayAttackSound()
    {
        PlayClip(AudioClipAttack);
    }

}
