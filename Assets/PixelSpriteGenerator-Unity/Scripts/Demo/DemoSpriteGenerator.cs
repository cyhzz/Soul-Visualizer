using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace PixelSpriteGenerator
{
	public class DemoSpriteGenerator : MonoBehaviour {

		[HideInInspector]
		public int[] templateData;

		[HideInInspector]
		public int width = 8;

		[HideInInspector]
		public int height = 8;

		[HideInInspector]
		public bool mirrorX;

		[HideInInspector]
		public bool mirrorY;

		public enum SpriteTemplate
		{
			spaceShipColored,
			spaceShipColoredLowSat,
			spaceShipManyColor,
			treeColored,
			dragonColored,
			shrubColored,
			robotBW
		}

		public SpriteTemplate SpriteTemplateSelection;

		private SpriteRenderer sr;

		private PsgOptions options;

		private PsgMask mask;

		private float spritePadding;

		private void CheckTemplateSelection()
		{
			switch (SpriteTemplateSelection) {

			case SpriteTemplate.spaceShipColored:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 1, 1,
					0, 0, 0, 0, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 1, 1, 1, -1,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 1, -1,
					0, 0, 0, 1, 1, 1,
					0, 0, 0, 0, 0, 0
				}, 6, 12, true, false);

				spritePadding = 1f;

				options = new PsgOptions () {
					Colored = true,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.2f,
					BrightnessNoise = 0.3f,
					Saturation = 0.5f
				};

				break;

			case SpriteTemplate.spaceShipColoredLowSat:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 1, 1,
					0, 0, 0, 0, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 1, 1, 1, -1,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 1, -1,
					0, 0, 0, 1, 1, 1,
					0, 0, 0, 0, 0, 0
				}, 6, 12, true, false);

				spritePadding = 1f;

				options = new PsgOptions () {
					Colored = true,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.2f,
					BrightnessNoise = 0.3f,
					Saturation = 0.2f
				};

				break;

			case SpriteTemplate.spaceShipManyColor:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 1, 1,
					0, 0, 0, 0, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 1, 1, 1, -1,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 1, -1,
					0, 0, 0, 1, 1, 1,
					0, 0, 0, 0, 0, 0
				}, 6, 12, true, false);

				spritePadding = 1f;

				options = new PsgOptions () {
					Colored = true,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.7f,
					BrightnessNoise = 0.8f,
					Saturation = 0.8f
				};

				break;

			case SpriteTemplate.shrubColored:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 1, 1, 2,
					0, 0, 0, 0, 0, 1, 0, 0, 2,
					0, 0, 0, 0, 1, 0, 0, -1, 2,
					0, 0, 0, 1, 0, 0, -1, 0, 2,
					0, 0, 0, 0, 0, -1, 0, 0, 2,
					0, 0, 0, 0, 0, 0, 0, 1, 2,
					0, 0, 0, 0, -1, -1, 2, 2, 2,
					0, 0, -1, -1, 0, 0, -1, -1, 2,
					0, -1, 0, -1, 0, 0, -1, 0, -1,
					0, 0, 0, 0, 0, -1, 0, 0, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 2,
					0, 0, 0, 0, 0, 0, 0, 0, 2,
					0, 0, 0, 0, 0, 0, 0, 0, 2,
					0, 0, -1, -1, 2, 0, 0, 0, 2,
					0, -1, 0, 0, -1, -1, 2, 0, 2,
					-1, 0, 0, 0, 0, 0, -1, -1, 2,
					0, 0, 0, 0, 0, 0, 0, 0, 2,
					0, 0, 0, 0, 0, 0, 0, -1, 2,
					0, 0, 0, 0, 0, 0, 0, -1, 2,
					0, 0, 0, 0, 0, 0, -1, -2, 2
				}, 9, 21, true, false);

				spritePadding = 1.7f;

				options = new PsgOptions () {
					Colored = true,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.2f,
					BrightnessNoise = 0.3f,
					Saturation = 0.5f
				};

				break;

			case SpriteTemplate.treeColored:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1,
					0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, -1,
					0, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0, 0, -1,
					0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 0, 0, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1,
					0, 0, 1, -1, 0, 0, 0, 0, 0, 0, 0, -1, -1,
					0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 1, -1,
					0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 1, -1,
					0, 0, 0, 1, 1, -1, -1, -1, 0, 0, 0, 1, -1,
					0, 0, 0, 0, 0, 0, 0, 1, -1, -1, -1, 1, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 1, -1, -1, -1,
					0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 1, -1,
					0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 1, -1,
					0, 0, 1, -1, -1, -1, -1, 0, 0, 0, 0, 1, -1,
					0, 1, 0, 0, 0, 1, -1, -1, -1, 0, 0, 1, -1,
					0, 0, 0, 0, 0, 0, 0, 1, -1, -1, 0, -1, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, -1, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, -1, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, -1, -1,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, -1, -1
				}, 13, 26, true, false);

				spritePadding = 2.1f;

				options = new PsgOptions () {
					Colored = true,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.2f,
					BrightnessNoise = 0.3f,
					Saturation = 0.5f
				};

				break;

			case SpriteTemplate.dragonColored:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0,
					0, 0, 0, 1, 1, 2, 2, 1, 1, 0, 0, 0,
					0, 0, 1, 1, 1, 2, 2, 1, 1, 1, 0, 0,
					0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0,
					0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0,
					0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0,
					0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0,
					0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
					0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0,
					0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
				}, 12, 12, false, false);

				spritePadding = 1f;

				options = new PsgOptions () {
					Colored = true,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.2f,
					BrightnessNoise = 0.3f,
					Saturation = 0.5f
				};

				break;

			case SpriteTemplate.robotBW:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0,
					0, 1, 1, 1,
					0, 1, 2, 2,
					0, 0, 1, 2,
					0, 0, 0, 2,
					1, 1, 1, 2,
					0, 1, 1, 2,
					0, 0, 0, 2,
					0, 0, 0, 2,
					0, 1, 2, 2,
					1, 1, 0, 0
				}, 4, 11, true, false);

				spritePadding = 1f;

				options = new PsgOptions () {
					Colored = false,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.2f,
					BrightnessNoise = 0.3f,
					Saturation = 0.5f
				};

				break;

			default:

				mask = new PsgMask (new int[] {
					0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 1, 1,
					0, 0, 0, 0, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 0, 1, 1, -1,
					0, 0, 1, 1, 1, -1,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 2, 2,
					0, 1, 1, 1, 1, -1,
					0, 0, 0, 1, 1, 1,
					0, 0, 0, 0, 0, 0
				}, 6, 12, true, false);

				spritePadding = 1f;

				options = new PsgOptions () {
					Colored = true,
					EdgeBrightness = 0.3f,
					ColorVariations = 0.2f,
					BrightnessNoise = 0.3f,
					Saturation = 0.5f
				};

				break;
			}
		}

		public void DemoButtonPressed(int idx,System.Random rd)
		{
			switch (idx) {

			case 0:
				SpriteTemplateSelection = SpriteTemplate.spaceShipColored;
				break;

			case 1:
				SpriteTemplateSelection = SpriteTemplate.spaceShipColoredLowSat;
				break;
			
			case 2:
				SpriteTemplateSelection = SpriteTemplate.spaceShipManyColor;
				break;

			case 3:
				SpriteTemplateSelection = SpriteTemplate.dragonColored;
				break;

			case 4:
				SpriteTemplateSelection = SpriteTemplate.treeColored;
				break;

			case 5:
				SpriteTemplateSelection = SpriteTemplate.shrubColored;
				break;

			case 6:
				SpriteTemplateSelection = SpriteTemplate.robotBW;
				break;

			default:
				SpriteTemplateSelection = SpriteTemplate.spaceShipColored;
				break;
			}

			GenerateSprites (rd);
		}
		public SpriteRenderer sp;
		private void GenerateSprites(System.Random rd)
		{
			CheckTemplateSelection ();

			var psgSprite = new PsgSprite (mask, options,rd);

					if (mask.mirrorX) {
						width = mask.width * 2;

					} else {
						width = mask.width;
					}

					if (mask.mirrorY) {
						height = mask.height * 2;
					} else {
						height = mask.height;
					}

					mirrorX = mask.mirrorX;
					mirrorY = mask.mirrorY;

					var tex = psgSprite.texture;
					tex.wrapMode = TextureWrapMode.Clamp;
					tex.filterMode = FilterMode.Point;
					sp.sprite = Sprite.Create(tex, new Rect(0, 0, (float)width, (float)height), new Vector2(0.5f, 0.5f), 32f);
					
		}
	}	
}