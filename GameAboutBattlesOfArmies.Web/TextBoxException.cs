using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.Web
{
    public class TextBoxException:Exception
    {
        public string ValueTextBox { get; set; }
        public string NameTextBox { get; set; }
        public TextBoxException(string message) : base(message)
        {
            //ValueTextBox = value;
            //NameTextBox = name;
        }
    }
}
