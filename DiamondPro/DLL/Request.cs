using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DiamondPro.DLL
{
    public class Request
    {
        public Request()
        {
            _collectionParameters = new ArrayList();
        }

        ~Request()
        {
            _collectionParameters = null;
        }


        private ArrayList _collectionParameters;

        public ArrayList CollectionParameters
        {
            get { return _collectionParameters; }
            set { _collectionParameters = value; }
        }

        private string ComandText;

        public string ComandText1
        {
            get { return ComandText; }
            set { ComandText = value; }
        }

        private CommandType _CommandType;

        public CommandType CommandType
        {
            get { return _CommandType; }
            set { _CommandType = value; }
        }


        public void AddParameter(string ParaName,object ParaValue, DbType ParaType, ParameterDirection ParamDirection)
        {
            ParameterInfo Param = new ParameterInfo();
            Param.ParameterName1 = ParaName;
            Param.ParameterValue = ParaValue;
            Param.ParameterType = ParaType;
            Param.ParameterDirection = ParamDirection;
            _collectionParameters.Add(Param);
            Param = null;
        }
    }


    public class ParameterInfo
    {
        private string ParameterName;

        public string ParameterName1
        {
            get { return ParameterName; }
            set { ParameterName = value; }
        }

        private object _ParameterValue;

        public object ParameterValue
        {
            get { return _ParameterValue; }
            set { _ParameterValue = value; }
        }

        private DbType _ParameterType;

        public DbType ParameterType
        {
            get { return _ParameterType; }
            set { _ParameterType = value; }
        }

        private ParameterDirection _parameterDirection;

        public ParameterDirection ParameterDirection
        {
            get { return _parameterDirection; }
            set { _parameterDirection = value; }
        }
    }
}
