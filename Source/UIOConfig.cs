﻿using ImGuiNET;
using UnityEngine;

namespace UImGui
{
	/// <summary>
	/// TODO: Write more.
	/// TODO: Make default button or make struct with default on editor (not the SetDefault() already here).
	/// </summary>
	[System.Serializable]
	internal struct IOConfig
	{
		// TODO: Test all flags.
		[Tooltip("For more info look the imgui.h:1380(~). (default=NavEnableKeyboard | DockingEnable)")]
		public ImGuiConfigFlags ImGuiConfig;

		[Tooltip("Time for a double-click, in seconds. (default=0.30f)")]
		public float DoubleClickTime;

		[Tooltip("Distance threshold to stay in to validate a double-click, in pixels. (default=6.0f)")]
		public float DoubleClickMaxDist;

		[Tooltip("Distance threshold before considering we are dragging. (default=6.0f)")]
		public float DragThreshold;

		[Tooltip("When holding a key/button, time before it starts repeating, in seconds. (default=0.250f)")]
		public float KeyRepeatDelay;

		[Tooltip("When holding a key/button, rate at which it repeats, in seconds. (default=0.050f)")]
		public float KeyRepeatRate;

		[Tooltip("Global scale all fonts. (default=1.0f)")]
		public float FontGlobalScale;

		[Tooltip("Allow user scaling text of individual window with CTRL+Wheel. (default=false)")]
		public bool FontAllowUserScaling;

		[Tooltip("[TEST] For retina display or other situations where window coordinates are different from framebuffer coordinates. " +
			"This generally ends up in ImDrawData::FramebufferScale. (default=1, 1)")]
		public System.Numerics.Vector2 DisplayFramebufferScale;

		[Tooltip("Request ImGui to draw a mouse cursor for you (if you are on a platform without a mouse cursor). " +
			"Cannot be easily renamed to 'io.ConfigXXX' because this is frequently used by backend implementations. " +
			"(default=false)")]
		public bool MouseDrawCursor;

		[Tooltip("Set to false to disable blinking cursor.")]
		public bool TextCursorBlink;

		[Tooltip("Enable resizing from the edges and from the lower-left corner.")]
		public bool ResizeFromEdges;

		[Tooltip("Set to true to only allow moving windows when clicked+dragged from the title bar. Windows without a title bar are not affected.")]
		public bool MoveFromTitleOnly;

		[Tooltip("Compact window memory usage when unused. Set to -1.0f to disable.")]
		public float ConfigMemoryCompactTimer;

		// TODO: Use this!
		// Store your own data for retrieval by callbacks.
		//void* UserData;

		public void SetDefaults()
		{
			System.IntPtr context = ImGui.CreateContext();
			ImGui.SetCurrentContext(context);
			SetFrom(ImGui.GetIO());
			ImGui.DestroyContext(context);
		}

		public void ApplyTo(ImGuiIOPtr io)
		{
			io.ConfigFlags = ImGuiConfig;

			io.MouseDoubleClickTime = DoubleClickTime;
			io.MouseDoubleClickMaxDist = DoubleClickMaxDist;
			io.MouseDragThreshold = DragThreshold;

			io.KeyRepeatDelay = KeyRepeatDelay;
			io.KeyRepeatRate = KeyRepeatRate;

			io.FontGlobalScale = FontGlobalScale;
			io.FontAllowUserScaling = FontAllowUserScaling;

			io.DisplayFramebufferScale = DisplayFramebufferScale;
			io.MouseDrawCursor = MouseDrawCursor;

			io.ConfigInputTextCursorBlink = TextCursorBlink;
			io.ConfigWindowsResizeFromEdges = ResizeFromEdges;
			io.ConfigWindowsMoveFromTitleBarOnly = MoveFromTitleOnly;
			io.ConfigMemoryCompactTimer = ConfigMemoryCompactTimer;
		}

		public void SetFrom(ImGuiIOPtr io)
		{
			ImGuiConfig = io.ConfigFlags;

			DoubleClickTime = io.MouseDoubleClickTime;
			DoubleClickMaxDist = io.MouseDoubleClickMaxDist;
			DragThreshold = io.MouseDragThreshold;

			KeyRepeatDelay = io.KeyRepeatDelay;
			KeyRepeatRate = io.KeyRepeatRate;

			FontGlobalScale = io.FontGlobalScale;
			FontAllowUserScaling = io.FontAllowUserScaling;

			TextCursorBlink = io.ConfigInputTextCursorBlink;
			ResizeFromEdges = io.ConfigWindowsResizeFromEdges;
			MoveFromTitleOnly = io.ConfigWindowsMoveFromTitleBarOnly;
			ConfigMemoryCompactTimer = io.ConfigMemoryCompactTimer;
		}
	}
}