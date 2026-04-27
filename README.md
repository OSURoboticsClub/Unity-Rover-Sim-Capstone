# Unity-Rover-Sim-Capstone

## Project Description and Value Proposition

#### What is this?
A physics based simulation designed for the DAM Robotics Rover Team to emulate controlling their rover on virtual competition terrain.
#### What does this solve?
Every year the OSU Rover Team participates in a competition against other rover teams to simulate tasks befitting a Mars rover. These tasks often involve driving the rover manually or autonomously from point A to point B. However, the team sometimes has issues with tipping the rover during competition, usually by driving over steep terrain. This matters because it costs the team points on the tasks at hand, especially during autonomous tasks where manual operation or adjustments are prohibited. This simulation provides rover operators with a better intuition on what terrain should be avoided and what terrain is safe to scale.
#### So what?
The rover requires a lot of testing in preparation for the competitions that it participates in. This simulation provides members of the team with another way to test the rover without having physical access to the rover, potentially enhancing the workflow for rover testing.

## Key Features or Highlights

#### Features
* Atomically accurate and articulate rover model.
* Terrain generation based on competition terrain height map data.
* Color coded terrain grade for identifying and avoiding steep slopes.
* User input via an xbox controller.
  
<img width="665" height="396" alt="Screenshot of simulation with camera centered on the rover model on generated competition terrain." src="https://github.com/user-attachments/assets/de045e3f-130b-49eb-87a3-df17ed3f8fdf" />

_Screenshot of simulation with camera centered on the rover model on generated competition terrain._

<img width="552" height="454" alt="Screenshot of rover model used in the simulation." src="https://github.com/user-attachments/assets/b70f613d-ab75-47a2-9751-439765f7521c" />

_Screenshot of rover model used in the simulation._

## How to Access or Try It

#### Necessary Tools
* Linux Environment
* Unity (2022.3.32f1) ([Install](https://docs.unity.com/en-us/hub))
* ROS2 Humble ([Install](https://docs.ros.org/en/humble/Installation.html))
* Unity ROS Bridge ([Github](https://github.com/HenryDalrymple53/custom_msg_unity_ros_bridge))
#### Setup Process
1. Set up a Linux environment.
2. Clone this repository using the command "git clone https://github.com/OSURoboticsClub/Unity-Rover-Sim-Capstone.git".
3. Open Unity Hub and add a project from disk (the Unity project from the repository you cloned in step 2).
4. Set up the Unity ROS Bridge to allow communication between ROS and the simulation.
5. Run the simulation.

## Credits

#### Team Members
* Tristan Vosburg ([Github](https://github.com/Battle-Potato))
* Maximilian Wolfe ([Github](https://github.com/Diamond117))
* Tej Singh ([Github](https://github.com/CompSciBenny))
#### Project Partner
* Jared Northrop
#### Other Contributors
* Henry Dalrymple ([Github](https://github.com/HenryDalrymple53))
