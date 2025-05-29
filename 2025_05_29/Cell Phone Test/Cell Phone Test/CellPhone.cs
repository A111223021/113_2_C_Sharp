using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Test
{
    class CellPhone
    {
        //手機品牌(封裝)
        private string _brand;
        //手機型號(封裝)
        private string _model;
        //手機價格(封裝)
        private decimal _price;

        public CellPhone() 
        {
            _brand = "";
            _model = "";
            _price = 0;
        }

        
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set 
            {
                if ((value) < 0) 
                { 
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                _price = value;
            }
        }
    }
}
