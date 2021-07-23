using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFT.Logic
{
    public interface IMethod
    {
        public string Name { get; set; }
        public Dictionary<char, string> Mappings { get; set; }
        public string Encrypt(string input);
        public string Decrypt(string input);
        public bool ValidateInputForEncrypt(string input);
        public bool ValidateInputForDecrypt(string input);
        public string TestInput { get; }
        public string TestOutput { get; }
    }
}
