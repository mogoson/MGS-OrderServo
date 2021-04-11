# MGS-CommandServo

## Summary
- Command servo system for Unity project.
- This project just provide the framework for command servo system.
- You can use it to do more things.

## Environment
- Unity 5.0 or above.
- .Net Framework 3.0 or above.

## Platform
- WindowsPlayer.
- Android.

## Demand
1. Listener the command IO and read command buffer.
1. Parse the command buffer to Command.
1. Execute the Command and respond the result after complete.
1. Parse the respond result to buffer and write to command IO.

## Implemented
- Command: Define the command info.
- CommandIO: Read and write the command buffer.
- CommandParser: Parse buffer to Command and Parse Command to buffer.
- CommandManager: Manager of CommandIO and CommandParser.
- CommandUnit: The unit to execute command.
- CommandUnitManager: Manager of command units.
- CommandServoProcessor: Scheduling the whole command servo system base on CommandManager  and CommandUnitManager.

## Usage
1. Use CommandIO and CommandParser to create CommandManager.
1. Create CommandUnitManager, and register command unit inventory.
1. Use CommandManager and CommandUnitManager to initialize CommandServoProcessor.
1. Turn on the CommandServoProcessor.

## Demo
- Demos in the path "MGS-CommandServo/Scenes" provide reference to you.

## Source
- https://github.com/mogoson/MGS-CommandServo.

## Contact
- If you have any questions, feel free to contact me at mogoson@outlook.com.

Copyright © 2021 Mogoson. All rights reserved.