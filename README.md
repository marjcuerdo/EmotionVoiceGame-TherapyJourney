# Emotional Voice Game Controller

### Marjorie Ann Cuerdo, Rebecca Lietz

We created this system that detects emotion from a player's voice to control events in a game through machine learning methods. This version was a final project for a class -- read our full project write-up [here](https://github.com/marjcuerdo/EmotionVoiceGame-TherapyJourney/blob/main/EmotionalVoiceGameController.ProjectWriteup.pdf) (note: assignment required writing in conference format, but this isn't an actual CHI paper!) for more details.

## Pre-Processing Audio Files

We used the RAVDESS Dataset [here](https://zenodo.org/record/1188976)
* 24 voice actors
* The dataset contains songs but we only used speech for training 
* Processed audio into spectrograms through Colab
* Downloaded sorted image data folder locally and uploaded to Google Drive

## Transfer Learning - Training

* Based on ResNet34, trained on processed voice data
* Google Colab training notebook [here](https://colab.research.google.com/drive/1EAiBsLM4tR_qleUBn7aUoPoQzQG82i9j)
* Achieved about 80% accuracy of emotion recognition from voice
* Independent from content of speech
* Learning rate was manually adjusted through observation of graphs
* Downloaded model locally and uploaded to archive.org for easier access

## Emotion Prediction API

* Turned trained model into API for easier integration with Unity
* Google Colab emotion prediction notebook [here](https://colab.research.google.com/drive/1MDd3MM1uU9i_jHZu__Y3eHh__pIcZo-x?authuser=1#scrollTo=cNxIt4eGPLxW)
* Current version must be running while the game is playing in Unity

## Game: Journey to Therapy* 
[tentative name]

* Connected Unity project to Emotion API on Google Colab
* Github (this repository)
* Simple narrative sidescroller for demo purposes
* Used free assets 

## Potential future

* Improve the backend flow connecting emotion prediction model to game engine 
* Improve quality of voice recording before processing
* Figure out how to run local on Mac without GPU
* Improve the game and/or make a new one for better application/synchronization with game mechanics
* Research how this type of game input affects the psychosocial and functional aspects of player experience and/or affordances for learning
