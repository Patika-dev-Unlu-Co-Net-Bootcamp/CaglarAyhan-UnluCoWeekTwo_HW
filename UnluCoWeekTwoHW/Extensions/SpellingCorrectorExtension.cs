using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnluCoWeekTwoHW.Extensions
{
    public class SpellingCorrectorExtension
    {
		public class Spelling
		{
			private HashSet<string> _hashSet = new HashSet<string>();
			
			private static readonly Regex _wordRegex = new Regex("[a-z]+", RegexOptions.Compiled);
			//BloomFilter bloom = new BloomFilter();
			public Spelling(string dictionary)
			{
				List<string> wordList = dictionary.Split('\n', ' ').ToList();
				//foreach (var item in wordList)
				//{
				//    string trimmedWord = item.Trim().ToLower();
				//    bloom.AddItemHash(trimmedWord, _filter);
				//}
				foreach (var word in wordList)
				{
					string trimmedWord = word.Trim().ToLower();
					if (_wordRegex.IsMatch(trimmedWord))
					{
						
							_hashSet.Add(trimmedWord);
					}
				}
			}

			public string CorrectSentence(string sentence)
			{
				if (string.IsNullOrEmpty(sentence))
					return sentence;

				var corrections = new List<string>();
				foreach (string word in sentence.Split(' '))
				{
					corrections.Add(Correct(word));
				}

				return string.Join(" ", corrections);
			}

			public string Correct(string word)
			{
				if (string.IsNullOrEmpty(word))
					return word;

				word = word.ToLower();

				// known()
				if (_hashSet.Contains(word))
					return word;

				List<String> list = Edits(word);
				Dictionary<string, int> candidates = new Dictionary<string, int>();

				foreach (string wordVariation in list)
				{
					if (_hashSet.Contains(wordVariation) && !candidates.ContainsKey(wordVariation))
						candidates.Add(wordVariation, 1);
				}

				if (candidates.Count > 0)
					return candidates.OrderByDescending(x => x.Value).First().Key;

				// known_edits2()
				foreach (string item in list)
				{
					foreach (string wordVariation in Edits(item))
					{
						if (_hashSet.Contains(wordVariation) && !candidates.ContainsKey(wordVariation))
							candidates.Add(wordVariation, 1);
					}
				}

				return (candidates.Count > 0) ? candidates.OrderByDescending(x => x.Value).First().Key : word;
			}

			private List<string> Edits(string word)
			{
				var splits = new List<Tuple<string, string>>();
				var transposes = new List<string>();
				var deletes = new List<string>();
				var replaces = new List<string>();
				var inserts = new List<string>();

				// Splits aşaması gelen kelimeyi varyansyonlarına ayırıyoruz.
				for (int i = 0; i < word.Length; i++)
				{
					var tuple = new Tuple<string, string>(word.Substring(0, i), word.Substring(i));
					splits.Add(tuple);
				}

				// Deletes
				for (int i = 0; i < splits.Count; i++)
				{
					string a = splits[i].Item1;
					string b = splits[i].Item2;
					if (!string.IsNullOrEmpty(b))
					{
						deletes.Add(a + b.Substring(1));
					}
				}

				// Transposes ile girilen kelimedeki harflerin yerlerini değiştiriyorum

				for (int i = 0; i < splits.Count; i++)
				{
					string a = splits[i].Item1;
					string b = splits[i].Item2;
					if (b.Length > 1)
					{
						transposes.Add(a + b[1] + b[0] + b.Substring(2));
					}
				}

				// Replaces ile alfabedeki harfler ile yer değişmi yaparak alternatifleri belirliyorum.
				for (int i = 0; i < splits.Count; i++)
				{
					string a = splits[i].Item1;
					string b = splits[i].Item2;
					if (!string.IsNullOrEmpty(b))
					{
						for (char c = 'a'; c <= 'z'; c++)
						{
							replaces.Add(a + c + b.Substring(1));
						}
					}
				}

				// Inserts işlemi ile gelen kelimenin arasına alfabedeki olabilecek harfleri ekliyoruz.
				for (int i = 0; i < splits.Count; i++)
				{
					string a = splits[i].Item1;
					string b = splits[i].Item2;
					for (char c = 'a'; c <= 'z'; c++)
					{
						inserts.Add(a + c + b);
					}
				}

				return deletes.Union(transposes).Union(replaces).Union(inserts).ToList();
			}
		}
	}
}
