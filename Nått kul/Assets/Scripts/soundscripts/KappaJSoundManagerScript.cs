using UnityEngine;

public class KappaJSoundManagerScript : MonoBehaviour
{

    public static AudioClip move, grab, quitSound, walk1, walk2, walk3, pickup;

    static AudioSource kappaSrc;

    float m_MySliderValue;

    // Use this for initialization
    void Start()
    {

        grab = Resources.Load<AudioClip>("magneticpickup");
        quitSound = Resources.Load<AudioClip>("nosound");
        pickup = Resources.Load<AudioClip>("winner");
        walk1 = Resources.Load<AudioClip>("kappaJwalk1");
        walk2 = Resources.Load<AudioClip>("kappaJwalk2");
        walk3 = Resources.Load<AudioClip>("kappaJwalk3");
        kappaSrc = GetComponent<AudioSource>();



        //Initiate the Slider value to half way
        m_MySliderValue = 0.5f;
        //Fetch the AudioSource from the GameObject
        kappaSrc = GetComponent<AudioSource>();
        //Play the AudioClip attached to the AudioSource on startup
        kappaSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
            { 
               case "pick":
                    if (!kappaSrc.isPlaying)
                    {
                        // audioSrc.Play();
                        kappaSrc.PlayOneShot(grab);
                    }
                break; 

              case "kappaJwalk1":
                   var number = Random.Range(1, 4);
                   if (!kappaSrc.isPlaying)    
                   {
                       Debug.Log(number);
                       switch(number)
                       {
                           case 1:
                               kappaSrc.PlayOneShot(walk1);

                               break;
                           case 2:
                               kappaSrc.PlayOneShot(walk2);
                               break;
                           case 3:
                               kappaSrc.PlayOneShot(walk3);
                               break;
                       }

                   }
                   break;
     
            case " ":
              
                    break;
        }
        
      }

    void OnGUI()
    {
        //Create a horizontal Slider that controls volume levels. Its highest value is 1 and lowest is 0
        m_MySliderValue = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), m_MySliderValue, 0.0F, 1.0F);
        //Makes the volume of the Audio match the Slider value
        kappaSrc.volume = m_MySliderValue;
    }
    /*
  public static void Pickup(string clip)
  {
      switch (clip)
      {
          case "ready":
              if (!kappaSrc.isPlaying)
              {
                  // audioSrc.Play();
                  kappaSrc.PlayOneShot(grab);
              }
              break;
      }
  }
  public static void Moving(string clip)
  {
      switch (clip)
      {
          case "kappaJwalk1":
              var number = Random.Range(1, 4);
              if (!kappaSrc.isPlaying)
              {
                  Debug.Log(number);
                  switch (number)
                  {
                      case 1:
                          kappaSrc.PlayOneShot(walk1);

                          break;
                      case 2:
                          kappaSrc.PlayOneShot(walk2);
                          break;
                      case 3:
                          kappaSrc.PlayOneShot(walk3);
                          break;
                  }

              }
              break;
      }
  }
  */

}

