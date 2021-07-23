using NFT.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFT.Models
{
    public class IOModel
    {
        public string InputString { get; set; }
        public string OutputString { get; set; }
        public string Action { get; set; }
        public List<IMethod> Methods { get; set; }
        public string SelectedMethod { get; set; }

        public IOModel()
        {
            Methods = new List<IMethod>();

            var morse = new Morse()
            {
                Name = "Morse"
            };
            Action = "Encrypt";

            Methods.Add(morse);
        }

    }
}
