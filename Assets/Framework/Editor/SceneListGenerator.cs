using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Framework
{

	public class SceneListGenerator : AssetPostprocessor
	{
		readonly static string[] INVALID_CHARAS =
		 {
			" ", "!", "\"", "#", "$",
			"%", "&", "\'", "(", ")",
			"-", "=", "^",  "~", "\\",
			"|", "[", "{",  "@", "`",
			"]", "}", ":",  "*", ";",
			"+", "/", "?",  ".", ">",
			",", "<"
		};

		const string GENERATE_CS_PATH = "Assets/Scripts/DEF_Scene.cs";

		[MenuItem("Tools/Create/Scene Name")]
		public static void Generate()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("namespace DEF {");
			builder.AppendLine("public static class Scene { ");

			List<EditorBuildSettingsScene> scenes = new List<EditorBuildSettingsScene>();
			foreach (var guid in AssetDatabase.FindAssets("t:Scene"))
			{

				var path = AssetDatabase.GUIDToAssetPath(guid);

				if (!path.Contains("Assets/Scenes/"))
				{
					continue;
				}

				scenes.Add(new EditorBuildSettingsScene(new GUID(guid), true));
			}

			EditorBuildSettings.scenes = scenes.ToArray();
			foreach (var n in EditorBuildSettings.scenes
				  .Select(c => Path.GetFileNameWithoutExtension(c.path))
				  .Distinct()
				  .Select(c => new { var = RemoveInvalidChars(c), val = c }))
			{
				builder.Append("\t").AppendFormat(@"public const string {0} = ""{1}"";", n.var.ToUpper(), n.val).AppendLine();
			}
			builder.AppendLine("}");
			builder.AppendLine("}");

			var directoryName = Path.GetDirectoryName(GENERATE_CS_PATH);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}

			File.WriteAllText(GENERATE_CS_PATH, builder.ToString(), Encoding.UTF8);
			AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
		}


		/// <summary>
		/// 無効な文字を削除します
		/// </summary>
		public static string RemoveInvalidChars(string str)
		{
			Array.ForEach(INVALID_CHARAS, c => str = str.Replace(c, string.Empty));
			return str;
		}

		/// <summary>
		/// シーンに変更があった時は自動で作り直す
		/// </summary>
		/// <param name="importedAssets"></param>
		/// <param name="deletedAssets"></param>
		/// <param name="movedAssets"></param>
		/// <param name="movedFromAssetPaths"></param>
		static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
		{
			bool isScene = false;
			foreach (string str in importedAssets)
			{
				if (str.StartsWith("Assets/Scenes"))
				{
					isScene = true;
				}
			}
			foreach (string str in deletedAssets)
			{
				if (str.StartsWith("Assets/Scenes"))
				{
					isScene = true;
				}
			}

			foreach (string str in movedAssets)
			{
				if (str.StartsWith("Assets/Scenes"))
				{
					isScene = true;
				}
			}
			if (isScene)
			{
				Generate();
			}
		}

	}
}
