**************************
BeatDetect for Amplitude

Version 1.1.1
**************************

BeatDetect is a free add-on for Amplitude that allows you to easily create amplitude level event triggers. You can use these event to respond to sounds or music on the WebGL platform.

Crazy Minnow Studio, LLC
CrazyMinnowStudio.com

https://crazyminnowstudio.com/posts/beat-detect-for-amplitude/


Package Contents
-------------------------
Crazy Minnow Studio/Amplitude/Addons/Beat Detect
	Editor
		BeatDetectEditor.cs
			Custom inspector for the BeatDetect component.
	Examples
		Prefabs
			panel_BeatDetectLogUI
				Beat Detect event log UI prefab for visualizing event output in a WebGL build.
			panel_BeatDetectTriggersUI
				Beat Detect trigger manager UI prefab for adding triggers in a WebGL build.
			panel_BeatDetectTriggerUI
				Beat Detect trigger UI prefab for adjusting a trigger in a WebGL build.
		Scenes
			EventTesting
				A scene for testing and visualizing Beat Detect triggers.
		Scripts
			BeatDetectLog.cs
				Event listenter for Beat Detect Trigger events and outputing to the console.
			BeatDetectLogUI.cs
				Beat Detect event log script for the UI prefab panel_BeatDetectLogUI, for visualizing event output in a WebGL build.
			BeatDetectTriggersUI.cs
				Beat Detect trigger manager script for the UI prefab for adding triggers in a WebGL build.
			BeatDetectTriggerUI.cs
				Beat Detect trigger script for the UI prefab for adjusting a trigger in a WebGL build.
	BeatDetect.cs
		The component that provides amplitude level event triggers for the Amplitude asset.
	ReadMe.txt
		This readme file.


Installation Instructions
-------------------------
1. Install Amplitude into your project.
	Select [Window] -> [Asset Store]
	Once the Asset Store window opens, select the download icon, and download and import [Amplitude].
2. Install this Beat Detect add-on into your project.
	Select [Assets] -> [Import Package] -> [Custom Package...]
	Browse to this unitypackage.


Usage Instructions
-------------------------
1. Setup Amplitude as you normally would.

2. Add the BeatDetect component.

3. Link your Amplitude component to the BeatDetect [Amplitude] field.

4. Set the Data Type to match your Amplitude Data Type.

5. Add as many event triggers as you like:
	For Amplitude triggers, you only need to set the amplitude trigger level.
	For Frequency triggers, select the sample index you want to set a trigger for, and the triggle level amplitude level.

6. Setup an event listener script to recieve a Trigger parameter (see the included BeatDetectLog.cs script). 
	BeatDetect amplitude and frequency level events can be set to emit when the amplitude or frequency rises above, below, or both, the trigger value. 
	The Trigger parameter includes the following information:
	Trigger.average		// Forces trigger to monitor average value.
	Trigger.index		// Wich sample index you want to trigger from (Frequency only).
	Trigger.value		// Amplitude trigger value
	Trigger.currentDir	// When a trigger is set to Both, the event listener will know the currect direction (Over, Under).
	Trigger.triggerDir	// Used to determine when an event should be triggered (Over, Under, Both).
	Trigger.clipName	// Amplitude.audioSource.clip.name
	Trigger.clipLength	// Amplitude.audioSource.clip.length
	Trigger.clipTime	// Amplitude.audioSource.time
	Trigger.valuePrev	// Tracks the previous value to prevent duplicate triggers.

Code Example
-------------------------
See [BeatDetectLog.cs] in Crazy Minnow Studio/Amplitude/Addons/Beat Detect/Examples/Scripts.