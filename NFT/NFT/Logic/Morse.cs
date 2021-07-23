using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NFT.Logic
{
    public class Morse : IMethod
    {
        public string Name { get; set; }
        public Dictionary<char, string> Mappings { get; set; }
        public string TestInput { get => @"Where other men blindly follow the truth, Remember, nothing is true. Where other men are limited by morality or law, Remember, everything is permitted. We work in the dark to serve the light, we are the Assassins!"; }
        public string TestOutput { get => @".-- .... . .-. .  /  --- - .... . .-.  /  -- . -.  /  -... .-.. .. -. -.. .-.. -.--  /  ..-. --- .-.. .-.. --- .--  /  - .... .  /  - .-. ..- - .... --..--  /  .-. . -- . -- -... . .-. --..--  /  -. --- - .... .. -. --.  /  .. ...  /  - .-. ..- . .-.-.-  /  .-- .... . .-. .  /  --- - .... . .-.  /  -- . -.  /  .- .-. .  /  .-.. .. -- .. - . -..  /  -... -.--  /  -- --- .-. .- .-.. .. - -.--  /  --- .-.  /  .-.. .- .-- --..--  /  .-. . -- . -- -... . .-. --..--  /  . ...- . .-. -.-- - .... .. -. --.  /  .. ...  /  .--. . .-. -- .. - - . -.. .-.-.-  /  .-- .  /  .-- --- .-. -.-  /  .. -.  /  - .... .  /  -.. .- .-. -.-  /  - ---  /  ... . .-. ...- .  /  - .... .  /  .-.. .. --. .... - --..--  /  .-- .  /  .- .-. .  /  - .... .  /  .- ... ... .- ... ... .. -. ... -.-.--"; }

        public Morse()
        {
            Mappings = new Dictionary<char, string>();

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Codes\MorseCodes.json");
            string loadedFile = System.IO.File.ReadAllText(path);

            Mappings = JsonConvert.DeserializeObject<Dictionary<char, string>>(loadedFile);
        }

        public string Decrypt(string input)
        {
            StringBuilder output = new StringBuilder(); ;
            var parsedWords = input.Split(new string[] { "  /  " }, StringSplitOptions.None);

            foreach (var word in parsedWords)
            {
                if (output.Length != 0)
                {
                    output.Append(" ");
                }

                var parsedCharacters = word.Split(new string[] { " " }, StringSplitOptions.None);
                foreach (var character in parsedCharacters)
                {
                    output.Append(Mappings.FirstOrDefault(x => x.Value == character).Key);
                }
            }

            return output.ToString();
        }

        public string Encrypt(string input)
        {
            StringBuilder output = null;
            input = input.ToLower();

            for (int i = 0; i < input.Length; i++)
            {
                if (output == null)
                {
                    output = new StringBuilder();
                    output.Append(Mappings.FirstOrDefault(x => x.Key == input[i]).Value);
                }
                else
                {
                    output.Append(" " + Mappings.FirstOrDefault(x => x.Key == input[i]).Value);
                }

            }
            return output.ToString();
        }

        public bool ValidateInputForEncrypt(string input)
        {
            try
            {
                foreach (var item in input.ToLower())
                {
                    if (!Mappings.ContainsKey(item))
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidateInputForDecrypt(string input)
        {
            try
            {
                var parsedWords = input.Split(new string[] { "  /  " }, StringSplitOptions.None);

                foreach (var word in parsedWords)
                {
                    var parsedCharacters = word.Split(new string[] { " " }, StringSplitOptions.None);
                    foreach (var character in parsedCharacters)
                    {
                        if (!Mappings.Any(x => x.Value == character))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
