using System.Collections;
using UnityEngine;

using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class EmotionAPI : MonoBehaviour
{
	public string url; // API url
	public string filepath; // file path of .wav file in Assets folder (e.g. filepath should be '/Audio/POL-moonshine-piano-short.wav' to get to background music)
	public string audioFile;

	public string currentEmotion;

	public AudioRec audObj;

	public TextMeshProUGUI emoText;

	public string[] emotionRangeArray;
	public string[] emotionCorrectArray;
	public Sprite[] emojiArray;
	/*public Sprite neutralSpr;
	public Sprite calmSpr;
	public Sprite happySpr;
	public Sprite angrySpr;
	public Sprite fearfulSpr;
	public Sprite disgustSpr;
	public Sprite surprisedSpr;*/

	public Image imageObj;

	public int currentIndex = 0;

	public GameObject[] blocks;

	public void Start()
	{
		audObj = GetComponent<AudioRec>();
		emotionRangeArray = new string[]{"neutral", "calm", "happy", "sad", "angry", "fearful", "disgust", "surprised"};
		emotionCorrectArray = new string[]{"surprised","sad","angry","sad","fearful","disgust","sad","happy"};
		//emotionCorrectArray = new string[]{"sad","sad","sad","sad","sad","disgust","sad","happy"};
		/*
		Example statements to help (what you say doesn't matter though): 
		surprised = "What?! You can't fire me!"
		sad = "Oh no, I can't believe this is happening..."
		angry = "Fuck you, you can't do that!"
		fearful = "What am I gonna do?!" / "I'm never gonna get a job!"
		neutral = "Whatever I guess."
		disgust = "Ugh I don't wanna go to therapy."
		calm = "I feel better now."
		happy = "This is so much better!"
		*/
	}

	public void Update() {
		if (audObj.recordingNew) {
			GetEmotion();

			audObj.recordingNew = false;
		}

		// if the correct emotion is detected, then increment
		if ( DisplayEmotion(currentEmotion) == emotionCorrectArray[currentIndex]) {

			currentIndex += 1;
			
			Debug.Log("Index: " + currentIndex);
		}
	}

	public void GetEmotion()
	{
		StartCoroutine(GetEmotion(filepath));
	}

	IEnumerator GetEmotion(string filepath)
	{
		var fullPath = Application.dataPath + filepath + audioFile;
		var bytes = File.ReadAllBytes(fullPath);

		WWWForm form = new WWWForm();
		form.AddBinaryData("file", bytes, "voice_sample.wav", "audio/wav");

		var req = UnityWebRequest.Post(url, form);
		req.uploadHandler.contentType = "multipart/form-data; boundary=bb1dd256718c9887dfa07f71d1e0995c";

		yield return req.SendWebRequest();

		if (req.isNetworkError || req.isHttpError)
			Debug.Log(req.downloadHandler.text);
		else
		{
			Debug.Log("Successful file transmission");

			currentEmotion = req.downloadHandler.text;
			emoText.text = "Emotion Prediction: " + DisplayEmotion(currentEmotion);
			Debug.Log(DisplayEmotion(currentEmotion));
		}

		// display the correct emoji
			for (int i=0; i<emotionRangeArray.Length; i++) {
				if (DisplayEmotion(currentEmotion) == emotionRangeArray[i]) {
					Debug.Log("detecting correct emotion");
					imageObj.sprite = emojiArray[i];
				}
		}

		req.Dispose();
	}

	public string DisplayEmotion(string emotion) {
		return currentEmotion;
	}

}

