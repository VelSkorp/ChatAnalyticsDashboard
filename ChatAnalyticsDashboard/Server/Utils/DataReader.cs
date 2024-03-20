namespace Server
{
	public static class DataReader
	{
		public static string ReadData(string fileName)
		{
			return File.ReadAllText(@$"./Data/{fileName}");
		}
	}
}