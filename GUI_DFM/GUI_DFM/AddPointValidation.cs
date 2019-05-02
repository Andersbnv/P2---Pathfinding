using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class AddPointValidation
    {
        private bool addressHasInput, xHasInput, yHasInput, addressIsLetters, xIsNumber, yIsNumber;
        
        public AddPointValidation(string addressInput, string xCoordinateInput, string yCoordinateInput)
        {
            var adressRegex = new Regex(@"^[A-Za-z]");
            var coordinateRegex = new Regex(@"^[0-9]");

            addressHasInput = (addressInput.Length > 0);
            xHasInput = (xCoordinateInput.Length > 0);
            yHasInput = (yCoordinateInput.Length > 0);
            addressIsLetters = adressRegex.IsMatch(addressInput);
            xIsNumber = coordinateRegex.IsMatch(xCoordinateInput);
            yIsNumber = coordinateRegex.IsMatch(yCoordinateInput);
        }
        public bool HasErrors()
        {
            return !(addressHasInput && xHasInput && yHasInput && addressIsLetters && xIsNumber && yIsNumber);
        }
        public string GetErrorMessage()
        {
            string message = "";      
            message += addressHasInput ? addressIsLetters ? "" : "Bynavn må kun indeholde bogstaver.\n" : "Indskriv venligst et bynavn (bogstaver).\n";
            message += xHasInput ? xIsNumber ? "" : "X-koordinat må kun indeholde tal.\n" : "Indskriv venligst et x-koordinat (tal).\n";
            message += yHasInput ? yIsNumber ? "" : "Y-koordinat må kun indeholde tal.\n" : "Indskriv venligst et y-koordinat (tal).\n";  
            return message;
        }
    }
}
