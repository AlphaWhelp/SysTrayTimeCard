# SysTrayTimeCard

SysTrayTimeCard is a lightweight time tracker designed to assist with note taking and organizing of how you spend your time, generally for work purposes, for Windows.

It runs as a Notification Icon in the System Tray. You can access the features by checking the context menu.  Adding time will add a date, a time spent, and a description of what you worked on into an XML file for your quick parsing later.

The application is fairly barebones right now.  All you can do is add time to the XML File.  While the XML is human-readable, there is room for improvement.

Here are a list of planned features.  These are not listed in any particular order of importance.

- Output a presentable report of time by day, week, month.
- Save the report to some form of document.
- Add the ability to choose to start this application on Startup. Make it easily toggled without having to go through the Startup UI from Task Manager.
- Add the ability to navigate directly to the XML File.
- Add the ability to archive the XML File and start over with a fresh one.
- Add the ability to perform a rolling archive that removes data from the XML itself instead of archiving the whole file.
- Add the ability to manually delete specific time entries.
- ~~Add the ability to quickly open the dialog to enter time through double-clicking the Notification Icon.~~ Completed: [Commit](https://github.com/AlphaWhelp/SysTrayTimeCard/commit/44ecc05a1aa8429a5a65bd87db7562c794f19553)

There is no installer at the moment. No special privileges are required for this application and the goal is to not change that.
