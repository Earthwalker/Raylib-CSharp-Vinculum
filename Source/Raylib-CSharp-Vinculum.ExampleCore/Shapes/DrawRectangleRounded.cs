
//------------------------------------------------------------------------------
//
// Copyright 2022-2023 © Raylib-CSharp-Vinculum, Raylib-CsLo and Contributors. 
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project's root for more info.
//
// Raylib-CSharp-Vinculum, bindings for Raylib 4.5.
// Find Raylib-CSharp-Vinculum here: https://github.com/ZeroElectric/Raylib-CSharp-Vinculum
// Find Raylib here: https://github.com/raysan5/raylib
//
//------------------------------------------------------------------------------

namespace ZeroElectric.Vinculum.ExampleCore.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - draw rectangle rounded (with gui options)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class DrawRectangleRounded
{

	//#define RAYGUI_IMPLEMENTATION
	//# include "extras/raygui.h"                 // Required for GUI controls

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw rectangle rounded");

		float roundness = 0.2f;
		int width = 200;
		int height = 100;
		int segments = 0;
		int lineThick = 1;

		bool drawRect = false;
		bool drawRoundedRect = true;
		bool drawRoundedLines = false;

		RayGui.GuiLoadStyleDefault(); //init raygui


		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


		//--------------------------------------------------------------------------------------
		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			Rectangle rec = new Rectangle(((float)GetScreenWidth() - width - 250) / 2, (GetScreenHeight() - height) / 2.0f, (float)width, (float)height);
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawLine(560, 0, 560, GetScreenHeight(), Fade(LIGHTGRAY, 0.6f));
			DrawRectangle(560, 0, GetScreenWidth() - 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.3f));

			if (drawRect) DrawRectangleRec(rec, Fade(GOLD, 0.6f));
			if (drawRoundedRect) DrawRectangleRounded(rec, roundness, segments, Fade(MAROON, 0.2f));
			if (drawRoundedLines) DrawRectangleRoundedLines(rec, roundness, segments, (float)lineThick, Fade(MAROON, 0.4f));

			// Draw GUI controls
			//------------------------------------------------------------------------------
			width = (int)GuiSliderBar(new Rectangle(640, 40, 105, 20), "Width", width.ToString(), (float)width, 0, (float)GetScreenWidth() - 300);
			height = (int)GuiSliderBar(new Rectangle(640, 70, 105, 20), "Height", height.ToString(), (float)height, 0, (float)GetScreenHeight() - 50);
			roundness = GuiSliderBar(new Rectangle(640, 140, 105, 20), "Roundness", roundness.ToString(), roundness, 0.0f, 1.0f);
			lineThick = (int)GuiSliderBar(new Rectangle(640, 170, 105, 20), "Thickness", lineThick.ToString(), (float)lineThick, 0, 20);
			segments = (int)GuiSliderBar(new Rectangle(640, 240, 105, 20), "Segments", segments.ToString(), (float)segments, 0, 60);

			drawRoundedRect = GuiCheckBox(new Rectangle(640, 320, 20, 20), "DrawRoundedRect", drawRoundedRect);
			drawRoundedLines = GuiCheckBox(new Rectangle(640, 350, 20, 20), "DrawRoundedLines", drawRoundedLines);
			drawRect = GuiCheckBox(new Rectangle(640, 380, 20, 20), "DrawRect", drawRect);
			//------------------------------------------------------------------------------

			DrawText(TextFormat("MODE: %s", (segments >= 4) ? "MANUAL" : "AUTO"), 640, 280, 10, (segments >= 4) ? MAROON : DARKGRAY);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		CloseWindow();        // Close window and OpenGL context
							  //--------------------------------------------------------------------------------------
							  //RayGui.GuiDisable();
							  //RayGui.GuiEnable();
							  ////Raylib.unload
		return 0;
	}
}
