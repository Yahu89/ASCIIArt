namespace ASCIIArt
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Program p = new Program();

			string row1 = " #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ### ### ";
			string row2 = "# # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #   # ";
			string row3 = "### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #   ## ";
			string row4 = "# # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #       ";
			string row5 = "# # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###  #  ";

			string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
			var letterNumbers = p.CreateLetterNumbers(alphabet);
			string[] rows = new string[] { row1, row2, row3, row4, row5 };

			Console.Write("Podaj wyraz: ");
			string insertWord = Console.ReadLine();

			var template = p.GenerateTemplate(rows, letterNumbers);
			var finalWord = p.GenerateResult(insertWord, template);

			foreach (var str in finalWord)
			{
				Console.WriteLine(str);
			}

			Console.ReadKey();
		}

		public List<int> CreateLetterNumbers(string alphabet)
		{
			var numbers = alphabet.Select(x => (int)x).ToList();
			return numbers;
		}

		public List<Dictionary<int, string>> GenerateTemplate(string[] rows, List<int> numbers)
		{
			List<Dictionary<int, string>> finalList = new List<Dictionary<int, string>>();

			for (int i = 0; i < rows.Length; i++)
			{
				Dictionary<int, string> oneRow = new Dictionary<int, string>();

				int j = 0;

				foreach (var number in numbers)
				{
					oneRow[number] = rows[i].Substring(j, 4);
					j = j + 4;
				}

				finalList.Add(oneRow);
			}

			return finalList;
		}

		public string[] GenerateResult(string word, List<Dictionary<int, string>> template)
		{
			word = word.ToUpper();

			string[] rows = new string[5];

			for (int i = 0; i < rows.Length; i++)
			{
				string line = "";

				for (int j = 0; j < word.Length; j++)
				{
					line += template[i][(int)word[j]].ToString();
				}

				rows[i] = line;
			}

			return rows;
		}
	}
}
