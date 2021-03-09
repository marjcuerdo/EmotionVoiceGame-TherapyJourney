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

	public void Start()
	{
		audObj = GetComponent<AudioRec>();
		//GetEmotion();
	}

	public void Update() {
		if (audObj.recordingNew) {
			GetEmotion();
			audObj.recordingNew = false;
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

		req.Dispose();
	}

	public string DisplayEmotion(string emotion) {
		return currentEmotion;
	}

}

