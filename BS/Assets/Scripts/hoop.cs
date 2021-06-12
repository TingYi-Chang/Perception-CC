using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoop : MonoBehaviour
{
    int state;//0->stop 1->shake 2->reset
			  // Start is called before the first frame update
	[HeaderAttribute("Shake Setting")]
	public Vector3 positionShake;//震動幅度
	public Vector3 angleShake;   //震動角度
	public float cycleTime = 0.2f;//震動週期
	public int cycleCount = 6;    //震動次數
	public bool fixShake = false; //為真時每次幅度相同，反之則遞減
	public bool unscaleTime = false;//不考慮縮放時間
	public bool bothDir = true;//雙向震動
	public float fCycleCount = 0;//設定此引數，以此震動次數為主
	public bool autoreset = true;//自動disbale
	[HeaderAttribute("Audio Setting")]
	public AudioSource Hit;

	float currentTime;
	int curCycle;
	Vector3 curPositonShake;
	Vector3 curAngleShake;
	float curFovShake;
	Vector3 startPosition;
	Vector3 startAngles;
	Transform myTransform;
	int TrailCount, triggerShake, triggerAudio;


	void Start()
	{

		state = 0;
		currentTime = 0f;
		curCycle = 0;
		curPositonShake = positionShake;
		curAngleShake = angleShake;
		myTransform = transform;
		startPosition = myTransform.localPosition;
		startAngles = myTransform.localEulerAngles;
		if (fCycleCount > 0)
			cycleCount = Mathf.RoundToInt(fCycleCount);
	}
	void Shake()
    {
		if (curCycle >= cycleCount)
		{
			if (autoreset)
				state = 2;
			return;
		}
		float deltaTime = unscaleTime ? Time.unscaledDeltaTime : Time.deltaTime;
		currentTime += deltaTime;
		while (currentTime >= cycleTime)
		{
			currentTime -= cycleTime;
			curCycle++;
			if (curCycle >= cycleCount)
			{
				myTransform.localPosition = startPosition;
				myTransform.localEulerAngles = startAngles;
				return;
			}

			if (!fixShake)
			{
				if (positionShake != Vector3.zero)
					curPositonShake = (cycleCount - curCycle) * positionShake / cycleCount;
				if (angleShake != Vector3.zero)
					curAngleShake = (cycleCount - curCycle) * angleShake / cycleCount;
			}
		}

		if (curCycle < cycleCount)
		{
			float offsetScale = Mathf.Sin((bothDir ? 2 : 1) * Mathf.PI * currentTime / cycleTime);
			if (positionShake != Vector3.zero)
				myTransform.localPosition = startPosition + curPositonShake * offsetScale;
			if (angleShake != Vector3.zero)
				myTransform.localEulerAngles = startAngles + curAngleShake * offsetScale;
		}
	}
	// Update is called once per frame
	void Update()
	{
        if (state == 1)
        {
			Shake();
        }
		else if (state == 2)
        {
			Restart();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TrailCount = produce_ball.RoundCount;
			if (TrailCount < produce_ball.condition.Count)
			{
				triggerShake = produce_ball.condition[TrailCount][2];
				triggerAudio = produce_ball.condition[TrailCount][3];
				Debug.Log("Shake = " + triggerShake);
				Debug.Log("Audio = " + triggerAudio);
			}
			else
			{
				triggerShake = produce_ball.condition[0][2];
				triggerAudio = produce_ball.condition[0][3];
			}
			//Restart();
			
		}



	}
	//重置
	public void Restart()
	{
		state = 0;
			currentTime = 0f;
			curCycle = 0;
			curPositonShake = positionShake;
			curAngleShake = angleShake;
			myTransform.localPosition = startPosition;
			myTransform.localEulerAngles = startAngles;
			if (fCycleCount > 0)
				cycleCount = Mathf.RoundToInt(fCycleCount);

	}
	void OnCollisionEnter(Collision collision) //aaa為自定義碰撞事件
    {
        if (triggerShake == 1)
        {
			if (state == 0)
			{
				state = 1;
			}
		}
		if (triggerAudio == 1)
        {
			foreach (ContactPoint contact in collision.contacts)
			{
				Debug.DrawRay(contact.point, contact.normal, Color.white);
			}
			if (collision.relativeVelocity.magnitude > 1)
				Hit.Play();
		}
			
	}
}
