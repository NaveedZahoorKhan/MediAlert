using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace MediClientMac
{
	public class JsonHelper<T> where T : class
	{
		public static string JsonSerializer(T t)
		{
			////DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
			//Newtonsoft.Json.JsonSerializer ser = new Newtonsoft.Json.JsonSerializer();
			//MemoryStream ms = new MemoryStream();
			//JsonWriter writer = new JsonWriter(ms, typeof(T));
			//ser.Serialize(ms as System.IO.TextWriter, typeof(T));
			//string jsonString = Encoding.UTF8.GetString(ms.ToArray());
			//ms.Close();
			////Replace Json Date String
			//string p = @"\\/Date\((\d+)\+\d+\)\\/";
			//MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
			//Regex reg = new Regex(p);
			//jsonString = reg.Replace(jsonString, matchEvaluator);
			return null;
		}

		/// <summary>
		/// JSON Deserialization
		/// </summary>
		public static T JsonDeserialize(string jsonString)
		{
			//Convert "yyyy-MM-dd HH:mm:ss" String as "\/Date(1319266795390+0800)\/"
			string p = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
			MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
			Regex reg = new Regex(p);
			jsonString = reg.Replace(jsonString, matchEvaluator);
			//DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
			Newtonsoft.Json.JsonSerializer serializer = new JsonSerializer();
			MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
			JsonReader reader = new JsonTextReader(new StreamReader(ms));
			T obj2 = serializer.Deserialize<T>(reader);
			//            T obj = (T)ser.ReadObject(ms);
			return obj2;
		}

		/// <summary>
		/// Convert Serialization Time /Date(1319266795390+0800) as String
		/// </summary>
		private static string ConvertJsonDateToDateString(Match m)
		{
			string result = string.Empty;
			DateTime dt = new DateTime(1970, 1, 1);
			dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
			dt = dt.ToLocalTime();
			result = dt.ToString("yyyy-MM-dd HH:mm:ss");
			return result;
		}

		/// <summary>
		/// Convert Date String as Json Time
		/// </summary>
		private static string ConvertDateStringToJsonDate(Match m)
		{
			string result = string.Empty;
			DateTime dt = DateTime.Parse(m.Groups[0].Value);
			dt = dt.ToUniversalTime();
			TimeSpan ts = dt - DateTime.Parse("1970-01-01");
			result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
			return result;
		}
	}
}
