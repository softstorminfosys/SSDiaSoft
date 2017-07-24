using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiamondPro.DLL
{
    public class Validation
    {
        public Int16 ToInt16(Object TextValue)
        {
            Int16 Val = 0;
            //Int16.TryParse(TextValue, out Val);
            Int16.TryParse(TextValue == null ? "0" : TextValue.ToString(), out Val);
            return Val;
        }
        public Int32 ToInt(Object TextValue)
        {
            int Val = 0;
            //int.TryParse(TextValue, out Val);
            Int32.TryParse(TextValue == null ? "0" : TextValue.ToString(), out Val);
            return Val;
        }

        public Int64 ToInt64(Object TextValue)
        {
            Int64 Val = 0;
            //Int16.TryParse(TextValue, out Val);
            Int64.TryParse(TextValue == null ? "0" : TextValue.ToString(), out Val);
            return Val;
        }
        public String ToString(Object TextValue)
        {
            String Val = String.Empty;
            if (!Equals(TextValue, null))
            {
                Val = TextValue.ToString();
            }
            return Val;
        }
        public Boolean ToBoolean(Object TextValue)
        {
            Boolean Val = false;
            if (!Equals(TextValue, null))
            {
                if (TextValue.ToString().Trim().Equals("1"))
                    Val = true;
                else
                    Boolean.TryParse(TextValue.ToString(), out Val);
            }
            return Val;
        }
        public Double ToDouble(Object TextValue)
        {
            Double Val = 0;
            Double.TryParse(TextValue == null ? "0" : TextValue.ToString().ToLower(), out Val);
            return Val;
        }


        public object ValToDateWithTry(Object StrDateNew)
        {
            DateTime result;
            if (StrDateNew == null)
                return DBNull.Value;
            if (StrDateNew.ToString().Length == 0)
                return DBNull.Value;
            string format;
            String StrDate = StrDateNew.ToString();
            CultureInfo Provider = CultureInfo.InvariantCulture;
            if (StrDate.Length == 10)
                format = "dd/MM/yyyy";
            else if (StrDate.Length == 8)
                format = "hh:mm:ss";
            else if (StrDate.Length == 11)
                format = "hh:mm:ss tt";
            else if (StrDate.Length == 19 && StrDate.ToUpper().Contains("M"))
                format = "dd/MM/yyyy hh:mm tt";
            else if (StrDate.Length <= 18)
                format = "d/M/yyyy HH:mm:ss";
            else if (StrDate.Length == 19)
                format = "dd/MM/yyyy HH:mm:ss";
            else if (StrDate.Length <= 21)
                format = "d/M/yyyy hh:mm:ss tt";
            else
                format = "dd/MM/yyyy hh:mm:ss tt";

            result = DateTime.ParseExact(DateTime.ParseExact(StrDate, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString(format), format, CultureInfo.InvariantCulture);
            //result = DateTime.ParseExact(StrDate, format, Provider);
            return result;
        }

        public DateTime toDate(string StrDate)
        {
            DateTime result;
            if (StrDate == string.Empty)
                return DateTime.Now.Date;
            string format;

            CultureInfo Provider = CultureInfo.InvariantCulture;
            if (StrDate.Length == 10)
                format = "dd/MM/yyyy";
            else if (StrDate.Length == 8)
                format = "hh:mm:ss";
            else if (StrDate.Length == 11)
                format = "hh:mm:ss tt";
            else if (StrDate.Length == 19 && StrDate.ToUpper().Contains("M"))
                format = "dd/MM/yyyy hh:mm tt";
            else if (StrDate.Length <= 18)
                format = "d/M/yyyy HH:mm:ss";
            else if (StrDate.Length == 19)
                format = "dd/MM/yyyy HH:mm:ss";
            else if (StrDate.Length <= 21)
                format = "d/M/yyyy hh:mm:ss tt";
            else
                format = "dd/MM/yyyy hh:mm:ss tt";
            result = DateTime.ParseExact(DateTime.ParseExact(StrDate, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString(format), format, CultureInfo.InvariantCulture);
            //result = DateTime.ParseExact(StrDate, format, Provider);            
            return result;
        }
        public Object ValToDateWithTry(Object NewStrDate, string format)
        {
            if (NewStrDate == null)
                return DBNull.Value;
            if (NewStrDate.ToString().Length == 0)
                return DBNull.Value;
            String StrDate = NewStrDate.ToString();
            DateTime result;
            CultureInfo Provider = CultureInfo.InvariantCulture;

            result = DateTime.ParseExact(StrDate, format, Provider);
            return result;
        }
        public DateTime ValToDate(string StrDate, string format)
        {
            DateTime result;
            CultureInfo Provider = CultureInfo.InvariantCulture;

            result = DateTime.ParseExact(StrDate, format, Provider);
            return result;
        }

        public Image byteArrayToImage(Byte[] byteArrayIn)
        {

            if (Equals(byteArrayIn, null))
            {
                byteArrayIn = new Byte[0];
            }
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);

            return returnImage;
        }
        public Byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public String setTitlecase(String Textboxtext, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 || e.KeyChar == 13)
                Textboxtext = new CultureInfo("en").TextInfo.ToTitleCase(Textboxtext.ToLower());
            return Textboxtext;
        }

        public double TruncateDecimal(double value, int precision)
        {
            double step = (double)Math.Pow(10, precision);
            double tmp = Math.Truncate(step * value);
            return tmp / step;
        }
    }
}
