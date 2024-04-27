namespace AzarDataNetTestAPI.Modules.Common.Application.Services
{
    public class RandomCustom
    {
        public static string GetRandomString(int size, int maxIndex = 60)
        {
            char[] RandomChars = new char[size];

            //Your character string, note that " was doubled because the first one is used as an escape character
            //86 chracter
            string seed = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890+-*/~!@#$%&*();:'\|<>,./?";

            //Instantiate an object for generating random numbers
            Random rnd = new Random();

            int i = 0;
            while (i < size)
            {
                int index = rnd.Next(0, maxIndex);
                RandomChars[i] = char.Parse(seed.Substring(index, 1));
                i++;
            }
            return new string(RandomChars);
        }
    }
}
