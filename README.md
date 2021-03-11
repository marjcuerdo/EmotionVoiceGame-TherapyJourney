# Emotional Voice Game Controller

### Marjorie Ann Cuerdo, Rebecca Lietz

## Pre-Processing Audio Files

We used the RAVDESS Dataset: https://zenodo.org/record/1188976
* 24 voice actors
* This set contains songs but we only used speech for training
* Processed audio through Colab
* Downloaded sorted data folder locally

## Transfer Learning - Training

* Based on ResNet34, trained on processed voice data
* Achieved about 80% accuracy of emotion recognition from voice
* Independent from content of speech
* Learning rate was manually adjusted through observation
* Downloaded model locally and uploaded to archive.org for easier access

## Emotion Prediction API

* Turned trained model into API for easier integration with Unity
* Google Colab: https://colab.research.google.com/drive/1MDd3MM1uU9i_jHZu__Y3eHh__pIcZo-x?authuser=1#scrollTo=cNxIt4eGPLxW
* Current version must be running while the game is playing

## Game: Anxiety/Therapy Quest/Journey* 
[tentative name]

* Connected Unity project to Emotion API on Google Colab
* Github: https://github.com/marjcuerdo/EmotionVoiceGame-TherapyJourney
* Simple narrative sidescroller for demo purposes
* Used free assets 

## Potential future

* Improve the backend flow and quality of recording
* Figure out how to run local on Mac without GPU
* Improve the game and/or make a new one for better application/synchronization with game mechanics
* Research how this type of game input affects the psychosocial and functional aspects of player experience and/or affordances for learning

