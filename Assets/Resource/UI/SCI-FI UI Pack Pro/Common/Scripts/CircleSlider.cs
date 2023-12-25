using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleSlider : MonoBehaviour
{
    public bool isCoolDown=true;
	public float speed=0.5f;

	float time =0f;
	float Totaltime =5f;
	public Image image;

    // COMPONENT
    [SerializeField] Text progress;
	[SerializeField] Image Icon;

	// GRAPHIC
	[SerializeField] Color startColorIcon;
	[SerializeField] Color endColorIcon;
  
	void Start()
	{
        image = GetComponent<Image>();
		startCoolDown();
	}
  
	void Update()
	{
		if(isCoolDown)
		{
			time+=Time.deltaTime*speed;
            image.fillAmount= time/Totaltime;
			if(progress)
			{
				progress.text = ((int)time).ToString() ;
			}
			
			if(time>Totaltime)
			{	
				eventCoolDownEnd();
			}
		}
	}	
	
	public void startCoolDown()
	{
		isCoolDown = true;
		time = 0;
		Icon.color = startColorIcon;
        progress.enabled = true;
		image.enabled = true;
    }

	public void eventCoolDownEnd()
	{
        isCoolDown = false;
        Icon.color = endColorIcon;
		progress.enabled = false;
		image.enabled = false;
    }
}
