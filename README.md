# DESCRIPTION

Unity project that contains a box prefab with a sphere and a cube.
The project purpose is to train the sphere object called `Agent` to touch the cube without giving the sphere any other information than a reward every time it gets close enough and a final reward for touching the ball in less than the desired moves.

## USAGE

First, open the unity project on your Unity Hub and load the Scene `Grid` under the `Assets > Scenes`

To use this project, please follow the Unity ML-Agent installation process found at their github repository:
[github repository]("https://github.com/Unity-Technologies/ml-agents/tree/0.15.0")

Once installed, run on your terminal:

	mlagents-learn <trainer-config-file> --env=<env_name> --run-id=<run-identifier> --train

Example:

if you choose to just clone the repo you will need to move to that folder:

	cd path/to/your/ml-agents

then:

	mlagents-learn config/trainer_config.yaml --run-id=box_collider --train

If you are able to see the Unity logo and a string asking to press the play button, it is time to go to your unity project and play the game.

You can check the progress by running on your terminal:

	tensorboard --logdir=summaries --port 6006

this will create a tensorboard at `localhost:6006`, but for it to work and see some statistics, you will need to name your samples with different id's!