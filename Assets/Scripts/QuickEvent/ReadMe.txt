Note: As is the case with most assets that require serialization, there is a chance that your event settings 
in the inspector could be lost or corrupted when updating the package or simply due to a bug in the code.

Visit the git repo to submit bugs and pull requests: https://bitbucket.org/ByteSheep/quickevent/

 - USAGE -

QuickEvents are used just like UnityEvents (http://docs.unity3d.com/Manual/UnityEvents.html) e.g.:

	public QuickEvent OnClickEvent;
	
	OnClickEvent.AddListener(() => Debug.Log("Non persistent listener"));
	int eventCount = OnClickEvent.GetPersistentEventCount();
	OnClickEvent.Invoke();

Use the AdvancedEvent class when you need multiple arguments support in the inspector e.g.:
	
	[System.Serializable] public class AdvancedStringEvent : AdvancedEvent<string> {}
	
	public AdvancedStringEvent OnSomeEvent;
	
	// Invoke event with default argument
	OnSomeEvent.Invoke("Hello, World!");

As of version 1.1.0 you can use the EventFilter attribute to constrain the members listed in the event dropdown:

	// Only show properties that match our dynamic event type

	[EventFilter(TargetFilter.DynamicProperty)]
	public QuickFloatEvent OnStartEvent;


---- QuickEvent v1.0.2 ----

Fixes:

	• AdvancedEventEditor class was using QuickSupportedTypes instead of AdvancedSupportedTypes enum


---- QuickEvent v1.0.3 ----

Changes:

	• Updated variable names and code style to closer match C# conventions


---- QuickEvent v1.1.0 ----

Fixes:

	• Arrays of QuickEvents will now display correctly in the inspector
	• Properties that only have a setter method will now appear in the dropdown list
	• The selected member should remain selected even when adding or removing fields from the target script
	• Fix EnsureRunningOnMainThread exceptions

Features:

	• Addition of the EventFilter attribute (thanks ZaZy36!)
