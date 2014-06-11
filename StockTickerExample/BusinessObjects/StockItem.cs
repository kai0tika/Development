using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects
{
    public class StockItem
    {
        private string _symbol;
        private string _pricevalue;

        public string Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
            }
        }

        public string Pricevalue(string Id, string SymbolName)
        {

            //initialize stockitem Class
            _symbol = SymbolName;
            //create random price
            
            //currently a quick and easy random generator is used.
            //we could create multiple methods of getting the price.. from a webserivce call to a Db query
            Random myNew = new Random();
            int NewNum = DateTime.Now.Second;
            for (int i = 0; i < Convert.ToInt16(Id) * 3; i++)
            {
                NewNum = myNew.Next(i, 500);
            }

            return string.Format("${0}.00", NewNum.ToString());
        }
    }
}
