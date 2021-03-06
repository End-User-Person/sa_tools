using FraGag.Compression;
using Newtonsoft.Json;
using SonicRetro.SAModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SA_Tools.SAArc
{
	public static class sa2MiniEvent
	{
		static readonly string[] charbody = { "Head", "Mouth", "LHand", "RHand"};
		static List<string> nodenames = new List<string>();
		static Dictionary<string, MEModelInfo> modelfiles = new Dictionary<string, MEModelInfo>();
		static Dictionary<string, MEMotionInfo> motionfiles = new Dictionary<string, MEMotionInfo>();

		public static void Split(string filename)
		{
			nodenames.Clear();
			modelfiles.Clear();
			motionfiles.Clear();

			Console.WriteLine("Splitting file {0}...", filename);
			byte[] fc;
			if (Path.GetExtension(filename).Equals(".prs", StringComparison.OrdinalIgnoreCase))
				fc = Prs.Decompress(filename);
			else
				fc = File.ReadAllBytes(filename);
			MiniEventIniData ini = new MiniEventIniData() { Name = Path.GetFileNameWithoutExtension(filename) };
			string path = Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(Path.GetFullPath(filename)), Path.GetFileNameWithoutExtension(filename))).FullName;
			uint key;
			List<NJS_MOTION> motions = null;
			if (fc[4] == 0x81)
			{
				Console.WriteLine("File is in GC/PC format.");
				ByteConverter.BigEndian = true;
				key = 0x816DFE60;
				ini.Game = Game.SA2B;
			}
			else
			{
				Console.WriteLine("File is in DC format.");
				ByteConverter.BigEndian = false;
				key = 0xCB00000;
				ini.Game = Game.SA2;
			}
			int ptr = fc.GetPointer(8, key);
			if (ptr != 0)
			{
				Console.WriteLine("Sonic is in this Mini-Event");
				ini.SBodyAnims = GetMotion(fc, ptr, key, $"Sonic\\Body.saanim", motions, 62);
				for (int i = 0; i < 1; i++)
				{
					string upnam = charbody[i];
					string part = upnam;
					switch (i)
					{
						case 0:
							part = "Head";
							break;
						case 1:
							part = "Mouth";
							break;
						case 2:
							part = "LHand";
							break;
						case 3:
							part = "RHand";
							break;
					}
					MiniEventChars data = new MiniEventChars();
					int ptr2 = fc.GetPointer(ptr + 4, key);
					if (ptr2 != 0)
						data.Part = GetModel(fc, ptr + 4, key, $"Sonic\\{part}.sa2mdl");
					if (data.Part != null)
					{
						data.Anims = GetMotion(fc, ptr + 8, key, $"Sonic\\{part}.saanim", motions, modelfiles[data.Part].Model.CountAnimated());
						if (data.Anims != null)
							modelfiles[data.Part].Motions.Add(motionfiles[data.Anims].Filename);
						data.ShapeMotions = GetMotion(fc, ptr + 0xC, key, $"Sonic\\{part}Shape.saanim", motions, modelfiles[data.Part].Model.CountMorph());
						if (data.ShapeMotions != null)
							modelfiles[data.Part].Motions.Add(motionfiles[data.ShapeMotions].Filename);
					}
					ini.Sonic.Add(data);
					ptr2 += 0xC;
				}
			}
			ptr = fc.GetPointer(0xC, key);
			if (ptr != 0)
			{
				Console.WriteLine("Shadow is in this Mini-Event");
				ini.ShBodyAnims = GetMotion(fc, ptr, key, $"Shadow\\Body.saanim", motions, 62);
				for (int i = 0; i < 3; i++)
					{
						string upnam = charbody[i];
						string part = upnam;
						switch (i)
						{
							case 0:
								part = "Head";
								break;
							case 1:
								part = "Mouth";
								break;
							case 2:
								part = "LHand";
								break;
							case 3:
								part = "RHand";
								break;
						}
						MiniEventChars data = new MiniEventChars();
							int ptr2 = fc.GetPointer(ptr + 4, key);
							if (ptr2 != 0)
								data.Part = GetModel(fc, ptr + 4, key, $"Shadow\\{part}.sa2mdl");
							if (data.Part != null)
							{
								data.Anims = GetMotion(fc, ptr + 8, key, $"Shadow\\{part}.saanim", motions, modelfiles[data.Part].Model.CountAnimated());
								if (data.Anims != null)
									modelfiles[data.Part].Motions.Add(motionfiles[data.Anims].Filename);
								data.ShapeMotions = GetMotion(fc, ptr + 0xC, key, $"Shadow\\{part}Shape.saanim", motions, modelfiles[data.Part].Model.CountMorph());
								if (data.ShapeMotions != null)
									modelfiles[data.Part].Motions.Add(motionfiles[data.ShapeMotions].Filename);

							}
					ini.Shadow.Add(data);
					ptr2 += 0xC;
					}
				}
			ptr = fc.GetPointer(0x18, key);
			if (ptr != 0)
			{
				Console.WriteLine("Knuckles is in this Mini-Event");
				ini.KBodyAnims = GetMotion(fc, ptr, key, $"Knuckles\\Body.saanim", motions, 62);
				for (int i = 0; i < 4; i++)
				{
					string upnam = charbody[i];
					string part = upnam;
					switch (i)
					{
						case 0:
							part = "Head";
							break;
						case 1:
							part = "Mouth";
							break;
						case 2:
							part = "LHand";
							break;
						case 3:
							part = "RHand";
							break;
					}
					MiniEventChars data = new MiniEventChars();
					int ptr2 = fc.GetPointer(ptr + 4, key);
					if (ptr2 != 0)
						data.Part = GetModel(fc, ptr + 4, key, $"Knuckles\\{part}.sa2mdl");
					if (data.Part != null)
					{
						data.Anims = GetMotion(fc, ptr + 8, key, $"Knuckles\\{part}.saanim", motions, modelfiles[data.Part].Model.CountAnimated());
						if (data.Anims != null)
							modelfiles[data.Part].Motions.Add(motionfiles[data.Anims].Filename);
						data.ShapeMotions = GetMotion(fc, ptr + 0xC, key, $"Knuckles\\{part}Shape.saanim", motions, modelfiles[data.Part].Model.CountMorph());
						if (data.ShapeMotions != null)
							modelfiles[data.Part].Motions.Add(motionfiles[data.ShapeMotions].Filename);

					}
					ini.Knuckles.Add(data);
					ptr2 += 0xC;
				}
			}
			ptr = fc.GetPointer(0x1C, key);
			if (ptr != 0)
			{
				Console.WriteLine("Rouge is in this Mini-Event");
				ini.RBodyAnims = GetMotion(fc, ptr, key, $"Rouge\\Body.saanim", motions, 62);
				for (int i = 0; i < 4; i++)
				{
					string upnam = charbody[i];
					string part = upnam;
					switch (i)
					{
						case 0:
							part = "Head";
							break;
						case 1:
							part = "Mouth";
							break;
						case 2:
							part = "LHand";
							break;
						case 3:
							part = "RHand";
							break;
					}
					MiniEventChars data = new MiniEventChars();
					int ptr2 = fc.GetPointer(ptr + 4, key);
					if (ptr2 != 0)
						data.Part = GetModel(fc, ptr2, key, $"Rouge\\{part}.sa2mdl");
					if (data.Part != null)
					{
						data.Anims = GetMotion(fc, ptr2 + 4, key, $"Rouge\\{part}.saanim", motions, modelfiles[data.Part].Model.CountAnimated());
						if (data.Anims != null)
							modelfiles[data.Part].Motions.Add(motionfiles[data.Anims].Filename);
						data.ShapeMotions = GetMotion(fc, ptr2 + 8, key, $"Rouge\\{part}Shape.saanim", motions, modelfiles[data.Part].Model.CountMorph());
						if (data.ShapeMotions != null)
							modelfiles[data.Part].Motions.Add(motionfiles[data.ShapeMotions].Filename);

					}
					ini.Rouge.Add(data);
					ptr2 += 0xC;
				}
			}
			ptr = fc.GetPointer(0x24, key);
			if (ptr != 0)
			{
				Console.WriteLine("Mech Eggman is in this Mini-Event");
				ini.EWBodyAnims = GetMotion(fc, ptr, key, $"Mech Eggman\\Body.saanim", motions, 33);
			}
			ptr = fc.GetPointer(4, key);
			if (ptr != 0)
				ini.Camera = GetMotion(fc, ptr + 0x10, key, $"Camera.saanim", motions, 1);
			else
				Console.WriteLine("Mini-Event does not contain a camera.");
			foreach (var item in modelfiles.Values)
			{
				string fp = Path.Combine(path, item.Filename);
				ModelFile.CreateFile(fp, item.Model, item.Motions.ToArray(), null, null, null, item.Format);
				ini.Files.Add(item.Filename, HelperFunctions.FileHash(fp));
			}
			JsonSerializer js = new JsonSerializer
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			};
			using (var tw = File.CreateText(Path.Combine(path, Path.ChangeExtension(Path.GetFileName(filename), ".json"))))
				js.Serialize(tw, ini);
	
	}

		public static void Build(string filename)
		{
			nodenames.Clear();
			modelfiles.Clear();
			motionfiles.Clear();

			byte[] fc;
			if (Path.GetExtension(filename).Equals(".prs", StringComparison.OrdinalIgnoreCase))
				fc = Prs.Decompress(filename);
			else
				fc = File.ReadAllBytes(filename);
			string path = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(filename)), Path.GetFileNameWithoutExtension(filename));
			JsonSerializer js = new JsonSerializer();
			MiniEventIniData ini;
			using (TextReader tr = File.OpenText(Path.Combine(path, Path.ChangeExtension(Path.GetFileName(filename), ".json"))))
			using (JsonTextReader jtr = new JsonTextReader(tr))
				ini = js.Deserialize<MiniEventIniData>(jtr);
			uint key;
			if (fc[4] == 0x81)
			{
				ByteConverter.BigEndian = true;
				key = 0x816DFE60;
			}
			else
			{
				ByteConverter.BigEndian = false;
				key = 0xCB00000;
			}
			bool battle = ini.Game == Game.SA2B;
			List<byte> modelbytes = new List<byte>(fc);
			Dictionary<string, uint> labels = new Dictionary<string, uint>();
			foreach (string file in ini.Files.Where(a => a.Key.EndsWith(".sa2mdl", StringComparison.OrdinalIgnoreCase) && HelperFunctions.FileHash(Path.Combine(path, a.Key)) != a.Value).Select(a => a.Key))
				modelbytes.AddRange(new ModelFile(Path.Combine(path, file)).Model.GetBytes((uint)(key + modelbytes.Count), false, labels, out uint _));
				foreach (string file in ini.Files.Where(a => a.Key.EndsWith(".saanim", StringComparison.OrdinalIgnoreCase) && HelperFunctions.FileHash(Path.Combine(path, a.Key)) != a.Value).Select(a => a.Key))
				modelbytes.AddRange(NJS_MOTION.Load(Path.Combine(path, file)).GetBytes((uint)(key + modelbytes.Count), labels, out uint _));
			fc = modelbytes.ToArray();
			int ptr = fc.GetPointer(8, key);
			if (ptr != 0 && labels.ContainsKeySafer(ini.SBodyAnims))
				ByteConverter.GetBytes(labels[ini.SBodyAnims]).CopyTo(fc, ptr);
			int ptr2 = fc.GetPointer(ptr + 4, key);
			if (ptr2 != 0)
				for (int i = 0; i < 1; i++)
				{
					MiniEventChars info = ini.Sonic[i];
					if (info.Part != null)
					{
						if (labels.ContainsKeySafer(info.Part))
							ByteConverter.GetBytes(labels[info.Part]).CopyTo(fc, ptr2);
						if (labels.ContainsKeySafer(info.Anims))
							ByteConverter.GetBytes(labels[info.Anims]).CopyTo(fc, ptr2 + 4);
						if (labels.ContainsKeySafer(info.ShapeMotions))
							ByteConverter.GetBytes(labels[info.ShapeMotions]).CopyTo(fc, ptr2 + 8);
					}
					ptr2 += 0xC;
				}
			ptr = fc.GetPointer(0xC, key);
			if (ptr != 0 && labels.ContainsKeySafer(ini.ShBodyAnims))
				ByteConverter.GetBytes(labels[ini.ShBodyAnims]).CopyTo(fc, ptr);
			int ptr3 = fc.GetPointer(ptr + 4, key);
			if (ptr3 != 0)
				for (int i = 0; i < 4; i++)
				{
					MiniEventChars info = ini.Shadow[i];
					if (info.Part != null)
					{
						if (labels.ContainsKeySafer(info.Part))
							ByteConverter.GetBytes(labels[info.Part]).CopyTo(fc, ptr3);
						if (labels.ContainsKeySafer(info.Anims))
							ByteConverter.GetBytes(labels[info.Anims]).CopyTo(fc, ptr3 + 4);
						if (labels.ContainsKeySafer(info.ShapeMotions))
							ByteConverter.GetBytes(labels[info.ShapeMotions]).CopyTo(fc, ptr3 + 8);
					}
					ptr3 += 0xC;
				}
			ptr = fc.GetPointer(0x18, key);
			if (ptr != 0 && labels.ContainsKeySafer(ini.KBodyAnims))
				ByteConverter.GetBytes(labels[ini.KBodyAnims]).CopyTo(fc, ptr);
			int ptr4 = fc.GetPointer(ptr + 4, key);
			if (ptr4 != 0)
				for (int i = 0; i < 4; i++)
				{
					MiniEventChars info = ini.Knuckles[i];
					if (info.Part != null)
					{
						if (labels.ContainsKeySafer(info.Part))
							ByteConverter.GetBytes(labels[info.Part]).CopyTo(fc, ptr4);
						if (labels.ContainsKeySafer(info.Anims))
							ByteConverter.GetBytes(labels[info.Anims]).CopyTo(fc, ptr4 + 4);
						if (labels.ContainsKeySafer(info.ShapeMotions))
							ByteConverter.GetBytes(labels[info.ShapeMotions]).CopyTo(fc, ptr4 + 8);
					}
					ptr4 += 0xC;
				}
			ptr = fc.GetPointer(0x1C, key);
			if (ptr != 0 && labels.ContainsKeySafer(ini.RBodyAnims))
				ByteConverter.GetBytes(labels[ini.RBodyAnims]).CopyTo(fc, ptr);
			int ptr5 = fc.GetPointer(ptr + 4, key);
			if (ptr5 != 0)
				for (int i = 0; i < 4; i++)
				{
					MiniEventChars info = ini.Rouge[i];
					if (info.Part != null)
					{
						if (labels.ContainsKeySafer(info.Part))
							ByteConverter.GetBytes(labels[info.Part]).CopyTo(fc, ptr5);
						if (labels.ContainsKeySafer(info.Anims))
							ByteConverter.GetBytes(labels[info.Anims]).CopyTo(fc, ptr5 + 4);
						if (labels.ContainsKeySafer(info.ShapeMotions))
							ByteConverter.GetBytes(labels[info.ShapeMotions]).CopyTo(fc, ptr5 + 8);
					}
					ptr5 += 0xC;
				}
			ptr = fc.GetPointer(0x24, key);
			if (ptr != 0 && labels.ContainsKeySafer(ini.EWBodyAnims))
				ByteConverter.GetBytes(labels[ini.EWBodyAnims]).CopyTo(fc, ptr);
			ptr = fc.GetPointer(4, key);
			if (ptr != 0 && labels.ContainsKeySafer(ini.Camera))
				ByteConverter.GetBytes(labels[ini.Camera]).CopyTo(fc, ptr);
			if (Path.GetExtension(filename).Equals(".prs", StringComparison.OrdinalIgnoreCase))
				Prs.Compress(fc, filename);
			else
				File.WriteAllBytes(filename, fc);
		}

		//Get Functions
		private static string GetModel(byte[] fc, int address, uint key, string fn)
		{
			string name = null;
			int ptr = fc.GetPointer(address, key);
			if (ptr != 0)
			{
				name = $"object_{ptr:X8}";
				if (!nodenames.Contains(name))
				{
					NJS_OBJECT obj = new NJS_OBJECT(fc, ptr, key, ModelFormat.Chunk, null);
					name = obj.Name;
					List<string> names = new List<string>(obj.GetObjects().Select((o) => o.Name));
					foreach (string s in names)
						if (modelfiles.ContainsKey(s))
							modelfiles.Remove(s);
					nodenames.AddRange(names);
					modelfiles.Add(obj.Name, new MEModelInfo(fn, obj, ModelFormat.Chunk));
				}
			}
			return name;
		}

		private static string GetMotion(byte[] fc, int address, uint key, string fn, List<NJS_MOTION> motions, int cnt)
		{
			NJS_MOTION mtn = null;
			if (motions != null)
				mtn = motions[ByteConverter.ToInt32(fc, address)];
			else
			{
				int ptr = fc.GetPointer(address, key);
				if (ptr != 0)
					mtn = new NJS_MOTION(fc, ptr, key, cnt);
			}
			if (mtn == null) return null;
			if (!motionfiles.ContainsKey(mtn.Name) || motionfiles[mtn.Name].Filename == null)
				motionfiles[mtn.Name] = new MEMotionInfo(fn, mtn);
			return mtn.Name;
		}

		public static bool ContainsKeySafer<TValue>(this IDictionary<string, TValue> dict, string key)
		{
			return key != null && dict.ContainsKey(key);
		}
	}

	public class MEModelInfo
	{
		public string Filename { get; set; }
		public NJS_OBJECT Model { get; set; }
		public ModelFormat Format { get; set; }
		public List<string> Motions { get; set; } = new List<string>();

		public MEModelInfo(string fn, NJS_OBJECT obj, ModelFormat format)
		{
			Filename = fn;
			Model = obj;
			Format = format;
		}
	}

	public class MEMotionInfo
	{
		public string Filename { get; set; }
		public NJS_MOTION Motion { get; set; }

		public MEMotionInfo(string fn, NJS_MOTION mtn)
		{
			Filename = fn;
			Motion = mtn;
		}
	}

	public class MiniEventIniData
	{
		public string Name { get; set; }
		[JsonIgnore]
		public Game Game { get; set; }
		[JsonProperty(PropertyName = "Game")]
		public string GameString
		{
			get { return Game.ToString(); }
			set { Game = (Game)Enum.Parse(typeof(Game), value); }
		}
		public Dictionary<string, string> Files { get; set; } = new Dictionary<string, string>();
		public string Camera { get; set; }
		public string SBodyAnims { get; set; }
		public List<MiniEventChars> Sonic { get; set; } = new List<MiniEventChars>();
		public string ShBodyAnims { get; set; }
		public List<MiniEventChars> Shadow { get; set; } = new List<MiniEventChars>();
		public string KBodyAnims { get; set; }
		public List<MiniEventChars> Knuckles { get; set; } = new List<MiniEventChars>();
		public string RBodyAnims { get; set; }
		public List<MiniEventChars> Rouge { get; set; } = new List<MiniEventChars>();
		public string EWBodyAnims { get; set; }
		public List<string> Motions { get; set; }
	}

	public class MiniEventChars
	{
		public string Part { get; set; }
		public string Anims { get; set; }
		public string ShapeMotions { get; set; }
	}
}

