# Daydream-Locomotion-2018
Locomotion controls within VR for Google Daydream that layers both walking and teleportation simultaneously

This Unity project (now updated to work with Unity 2018.3) has layered locomotion controls using very simple input capture scripts. Simply rest the thumb on the track pad to indicate walk/strafe directionality (like WSAD). Centering the thumb stops all motion. Pressing down on the pad (button 1) activates a teleport raycast and hovering platform and arrests walking movement to make aim of the laser easier. Green beam indicates location of teleport when button is released. Red beam indicates teleport location is not suitable and cancels the intent.

### Installation

* Clone the repo and open it in Unity 2018.3 or later
* Open the project and load demo.unity into the editor
* Change your build platform to Android and ensure that Daydream is selected under XR options in player settings
* Ensure that your device is setup for developer builds and connect it by USB
* Build and Run

### Requirements

* Android device running Android 7+
* Google Daydream Headset and Controller

### Troubleshooting

GVR SDK continues to undergo an overhaul at Google to work with Unity's new methods for handling input. Some methods for GVR input will be flagged as deprecated until Google updates to the GVR for Unity 2018. This does not seem to affect the build or performance.
This version also has .NET 4 selected as .NET 3.5 has been deprecated. You may need to install .NET 4 or change this flag in project settings.

### License

Copyright 2018 Bradley Pizzimenti / Gennaker Systems LLC

This software is licensed under the MIT License
